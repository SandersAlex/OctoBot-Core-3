using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OctoBot.TentaclesManagement
{
	public abstract class AbstractTentacle
	{
		public AbstractTentacle()
		{
			Debug.WriteLine(1);
		}

		private void GetName(object cls)
		{
			Debug.WriteLine(1);
		}
		protected abstract void GetConfigTentacleType(object cls);
		protected abstract void GetTentacleFolder(object cls);
		private void GetAllSubclasses(object cls)
		{
			Debug.WriteLine(1);
		}
		private void GetConfigFolder(object cls, object configTentacleType = null)
		{
			Debug.WriteLine(1);
		}
		private void GetConfigFileName(object cls, object configTentacleType = null)
		{
			Debug.WriteLine(1);
		}
		private void GetConfigFileSchemaName(object cls, object configTentacleType = null)
		{
			Debug.WriteLine(1);
		}
		private void GetConfigFileErrorMessage(object cls, object error)
		{
			Debug.WriteLine(1);
		}
		private void GetSpecificConfig(object cls, bool raiseException = true, bool rawFile = false)
		{
			Debug.WriteLine(1);
		}
		private void GetSpecificConfigSchema(object cls, bool raiseException = true)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// Used to provide a new logger for this particular indicator
		/// </summary>
		/// <param name="logger"></param>
		private void SetLogger(object logger)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// returns DESCRIPTION class attribute, used as documentation
		/// </summary>
		/// <param name="cls"></param>
		private void GetDescription(object cls)
		{
			Debug.WriteLine(1);
		}
	}
}