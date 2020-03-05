using System;
using System.Collections.Generic;
using System.Text;
using ArgParse;

namespace OctoBot.Core
{
	public interface ICoreService
	{
		ICoreConfig Config { get; }
		void Start(ParseResult parseResult);
		void Stop();
		void Restart();
	}
}