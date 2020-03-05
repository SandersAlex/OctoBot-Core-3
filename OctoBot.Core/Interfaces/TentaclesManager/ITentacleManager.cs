using System;
using System.Collections.Generic;
using System.Text;

namespace OctoBot.Core
{
	public interface ITentacleManager
	{
		void ParseCommands(IList<string> commands, bool force = false, string defaultGitBranch = "");
	}
}
