using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ArgParse.Interfaces;

namespace ArgParse.Actions
{
	public class StoreConstAction : ActionAP
	{
		public StoreConstAction(Argument argument, IActionsContainer container) : base (argument, container)
		{
			Debug.WriteLine(1);
		}
	}
}