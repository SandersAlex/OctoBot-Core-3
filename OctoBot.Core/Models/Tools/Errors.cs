using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OctoBot
{
	[Serializable]
	public class ConfigError : Exception
	{
		public ConfigError()
		{
		}
		public ConfigError(string message) : base(message)
		{
		}
		public ConfigError(string message, Exception innerException) : base(message, innerException)
		{
		}
		public ConfigError(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
	[Serializable]
	public class ConfigEvaluatorError : Exception
	{
		public ConfigEvaluatorError()
		{
		}
		public ConfigEvaluatorError(string message) : base(message)
		{
		}
		public ConfigEvaluatorError(string message, Exception innerException) : base(message, innerException)
		{
		}
		public ConfigEvaluatorError(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
	[Serializable]
	public class ConfigTradingError : Exception
	{
		public ConfigTradingError()
		{
		}
		public ConfigTradingError(string message) : base(message)
		{
		}
		public ConfigTradingError(string message, Exception innerException) : base(message, innerException)
		{
		}
		public ConfigTradingError(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
	[Serializable]
	public class TentacleNotFound : Exception
	{
		public TentacleNotFound()
		{
		}
		public TentacleNotFound(string message) : base(message)
		{
		}
		public TentacleNotFound(string message, Exception innerException) : base(message, innerException)
		{
		}
		public TentacleNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}