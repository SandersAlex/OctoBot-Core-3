using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ArgParse.Interfaces;

namespace ArgParse.Actions
{
	public class StoreAction : ActionAP
	{
		public StoreAction(Argument argument, IActionsContainer container) : base(argument, container)
		{
			Debug.WriteLine(1);
		}
	}
}