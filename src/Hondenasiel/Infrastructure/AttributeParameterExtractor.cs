using System;
using System.Linq;

namespace Hondenasiel.Infrastructure
{
	public sealed class AttributeParameterExtractor<T>
	{
		public static T GetParameterValue(Type handlerType, Type attributeType, string propertyName)
		{
			var attribute = handlerType.GetCustomAttributes(false).FirstOrDefault(x => x.GetType() == attributeType);
			T value = default(T);

			if (attribute != null)
			{
				var prop = attribute.GetType().GetProperty(propertyName);
				if (prop != null)
				{
					value = (T)attribute.GetType().GetProperty(propertyName).GetValue(attribute);
				}
			}

			return value;
		}
	}
}