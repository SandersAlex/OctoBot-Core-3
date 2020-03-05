using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace OctoBot.AppServices
{
	public abstract class BaseThread
	{
		private Thread _thread;

		protected BaseThread()
		{
			_thread = new Thread(new ThreadStart(this.RunThread));
		}

		// Thread methods / properties
		public void Start() => _thread.Start();
		public void Join() => _thread.Join();
		public bool IsAlive => _thread.IsAlive;

		// Override in base class
		public abstract void RunThread();
	}
	public abstract class AbstractDispatcher : BaseThread
	{
		public AbstractDispatcher() : base()
		{
			Debug.WriteLine(1);
		}

		public override void RunThread()
		{
			Debug.WriteLine(1);
		}
		private void GetName(object cls)
		{
			Debug.WriteLine(1);
		}
		private void NotifyRegisteredClientsIfInterested(object notification_description, object notification)
		{
			Debug.WriteLine(1);
		}
		private void RegisterClient(object client)
		{
			Debug.WriteLine(1);
		}
		/// <summary>
		/// Override this method if the dispatcher implementation is using a dispatcher handled in the service layer (ie: TelegramDispatcher)
		/// </summary>
		private static void GetServiceLayerDispatcher()
		{
			Debug.WriteLine(1);
		}
		protected abstract void StartDispatcher();
		protected abstract void SomethingToWatch();
		protected abstract void GetData();
		private void Run()
		{
			Debug.WriteLine(1);
		}
		private void GetIsSetupCorrectly()
		{
			Debug.WriteLine(1);
		}
		private void Stop()
		{
			Debug.WriteLine(1);
		}
	}
	public abstract class DispatcherAbstractClient : IDispatcherAbstractClient
	{
		public DispatcherAbstractClient()
		{
			Debug.WriteLine(1);
		}

		protected abstract void ReceiveNotificationData(object data);
		protected abstract void GetDispatcherClass();
		protected abstract void IsInterestedByThisBotification(object notification_description);
		private void SetDispatcher(object dispatcher)
		{
			Debug.WriteLine(1);
		}
		private void IsClientToThisDispatcher(object dispatcher_instance)
		{
			Debug.WriteLine(1);
		}
	}
	public interface IDispatcherAbstractClient
	{

	}
}