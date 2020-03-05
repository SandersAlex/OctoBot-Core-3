using System;
using System.Collections.Generic;
using System.Text;
using OctoBot.Core;

namespace OctoBot.Tentacles.Manager
{
	public class TentacleManagerService : ITentacleManagerService
	{
		private readonly ILoggingService loggingService;

		public TentacleManagerService(ILoggingService loggingService)
		{
			this.loggingService = loggingService;
		}

		public ITentacleManager CreateTentacleManager(ICoreConfig coreConfig)
		{
			return new TentacleManager(coreConfig);
		}

		public bool TentaclesArchExists()
		{
			return TentacleUtil.TentaclesArchExists();
		}
	}
}