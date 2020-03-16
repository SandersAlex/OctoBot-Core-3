using System;
using System.Collections.Generic;
using System.Text;

namespace OctoBot.Core
{
	public interface ITentacleManagerService
	{
		bool TentaclesArchExists();
		ITentacleManager CreateTentacleManager(ICoreConfig coreConfig);
		void ManageAdvancedClasses(Core.OctoBot octobot);
	}
}
