using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ArgParse.Interfaces;

namespace ArgParse.Actions
{
	public class StoreTrueAction : StoreConstAction
	{
		public StoreTrueAction(Argument argument, IActionsContainer container) : base(argument, container)
		{
			Debug.WriteLine(1);
		}
	}
}