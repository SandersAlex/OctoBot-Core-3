using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OctoBot.TentaclesManagement;

namespace OctoBot.Evaluator
{
	public class AbstractUtil : AbstractTentacle
	{
		public AbstractUtil()
		{
			Debug.WriteLine(1);
		}

		protected override void GetTentacleFolder(object cls)
		{
			Debug.WriteLine(1);
		}
		protected override void GetConfigTentacleType(object cls)
		{
			Debug.WriteLine(1);
		}
	}
}
