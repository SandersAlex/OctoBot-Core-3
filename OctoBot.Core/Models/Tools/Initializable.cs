using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.Tools
{
	public abstract class Initializable : IInitializable
	{
		public Initializable()
		{
			Debug.WriteLine(1);
		}

		async private void Initialize(bool force = false)
		{
			Debug.WriteLine(1);
		}
		protected abstract void InitializeImpl();
		private void GetIsInitialized()
		{
			Debug.WriteLine(1);
		}
	}
}
