using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Hondenasiel.Infrastructure.Webapi
{
	public static class MediatorExtensions
	{
		public static IServiceCollection AddMediatrOnUseCases(this IServiceCollection services)
		{
			services.AddMediatR(typeof(MediatorExtensions).GetTypeInfo().Assembly);

			return services;
		}
	}
}