using MediatR;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Hondenasiel.Application.Queries.Decorators
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
	public sealed class AuditLogAttribute : Attribute
	{
		public AuditLogAttribute()
		{
		}
	}

	public sealed class AuditLoggingDecorator<TCommand, TResult> : IRequestHandler<TCommand, TResult>
	   where TCommand : IRequest<TResult>
	{
		private readonly IRequestHandler<TCommand, TResult> _handler;

		public AuditLoggingDecorator(IRequestHandler<TCommand, TResult> handler)
		{
			_handler = handler;
		}

		async Task<TResult> IRequestHandler<TCommand, TResult>.Handle(TCommand request, CancellationToken cancellationToken)
		{
			var commandJson = JsonConvert.SerializeObject(request);

			// Use proper logging here
			Debug.WriteLine($"Command of type {request.GetType().Name}: {commandJson}");

			var result = await _handler.Handle(request, cancellationToken);

			var resultJson = JsonConvert.SerializeObject(result);

			// Use proper logging here
			Debug.WriteLine($"Result of type {result.GetType().Name}: {resultJson}");

			return result;
		}
	}
}