using System;
using System.Collections.Generic;
using System.Text;
using OctoBot.Core;

namespace OctoBot.Evaluator
{
	public interface IAbstractEvaluator : IAbstractTentacle
	{
		bool IsEnabled(Type cls, ICoreConfig config, bool defaultObject);
	}
}
