using Hondenasiel.Application.Queries.Decorators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hondenasiel.Infrastructure.Webapi
{
	public static class HandlerRegistration
	{
		//Extension for Service collection provided .NET Core DI infrastructure
		public static void AddHandlers(this IServiceCollection services)
		{
			//Get all the Types With
			var handlerTypes = Assembly.GetExecutingAssembly().GetTypes()
				.Where(x => x.GetInterfaces().Any(y => IsHandlerInterface(y)))
				.ToList();

			foreach (Type type in handlerTypes)
			{
				//Try to register each handler one by one
				AddHandler(services, type);
			}
		}

		private static void AddHandler(IServiceCollection services, Type type)
		{
			//Get all the custom attributes the Given Handler is decorated with.
			var attributes = type.GetCustomAttributes(false);
			//Convert those Attributes to the Decorator classes
			//using our one to one Attribute to Decorator Mapping
			var decorators = attributes
				.Select(x => ToDecorator(x))
				.Concat(new[] { type })
				.Reverse()
				.ToList();
			//Get the Type for the Handler Class that should be registered for Dependency Injection
			var interfaceType = type.GetInterfaces().FirstOrDefault(y => IsHandlerInterface(y));
			//Create Factory to Inject the HandlerClass decorated with all Decorators defined using Attributes.
			var factory = BuildFactory(decorators, interfaceType);

			services.AddTransient(interfaceType, factory);
		}

		//Check if the given Type is a Handler Interface
		//It can be Command handler or Query Handler
		//This method will return true if it is either of them
		private static bool IsHandlerInterface(Type type)
		{
			if (!type.IsGenericType)
				return false;

			Type typeDefinition = type.GetGenericTypeDefinition();

			return typeDefinition == typeof(IRequestHandler<>) || typeDefinition == typeof(IRequestHandler<,>);
		}

		//Receive the Attribute as input
		//And decide which Decorator should be used to enhance the class
		//As in our example we created Attributed corresponding to each Decorator
		//So it is simply one to one mapping between Attribute and Decorator Class
		private static Type ToDecorator(object attribute)
		{
			var type = attribute.GetType();

			if (type == typeof(AuditLogAttribute))
				return typeof(AuditLoggingDecorator<,>);

			// other attributes go here

			throw new ArgumentException(attribute.ToString());
		}

		//This method will be create dynamic factories
		//These dynamic factories will be configured into DI Container
		//List<Type> decorators: This will method recieve all the Decorators that should be applied to a Type
		//Type interfaceType: Type that should be Enhanced or decorated.
		private static Func<IServiceProvider, object> BuildFactory(List<Type> decorators, Type interfaceType)
		{
			//Get the constructor for each of the decorators
			var ctors = decorators
				.Select(x =>
				{
					var type = x.IsGenericType ? x.MakeGenericType(interfaceType.GenericTypeArguments) : x;
					return type.GetConstructors().Single();
				})
				.ToList();

			//Factory that will returned as result
			//This factory will take DI Container or ServiceProvider as parameter.
			Func<IServiceProvider, object> func = provider =>
			{
				object current = null;
				//Iterate through the Constructor for Each Decorator
				foreach (ConstructorInfo ctor in ctors)
				{
					//Get all the parameters for a given Decorator Constructor
					var parameterInfos = ctor.GetParameters().ToList();
					//Fetch the Required parameters from the ServiceProvider or DI container
					var parameters = GetParameters(parameterInfos, current, provider);
					//Invoke the Constructor
					current = ctor.Invoke(parameters);
				}

				return current;
			};

			return func;
		}

		//Get Parameters from Dependency Injection Container
		private static object[] GetParameters(List<ParameterInfo> parameterInfos, object current, IServiceProvider provider)
		{
			var result = new object[parameterInfos.Count];

			for (int i = 0; i < parameterInfos.Count; i++)
			{
				//Get the Object from DI Container for each ParameterInfo
				result[i] = GetParameter(parameterInfos[i], current, provider);
			}

			return result;
		}

		//Get Object or Parameter Value from DI Container
		private static object GetParameter(ParameterInfo parameterInfo, object current, IServiceProvider provider)
		{
			var parameterType = parameterInfo.ParameterType;

			if (IsHandlerInterface(parameterType))
				return current;
			//Get the Parameter object from DI Container(ServicesProvider)
			var service = provider.GetService(parameterType);
			if (service != null)
				return service;

			throw new ArgumentException($"Type {parameterType} not found");
		}
	}
}