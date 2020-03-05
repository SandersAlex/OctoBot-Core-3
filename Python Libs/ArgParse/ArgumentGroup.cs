using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ArgParse.Interfaces;

namespace ArgParse
{
	public class ArgumentGroup : ActionsContainer
	{
		public string Title { get; set; }
		private IList<object> GroupActions { get; set; }

		public ArgumentGroup(IActionsContainer container, string title = "", string description = "") : base(container:container)
		{
			Dictionary<string, object> update = new Dictionary<string, object>() {
				/*update('conflict_handler', container.conflict_handler)
				update('prefix_chars', container.prefix_chars)
				update('argument_default', container.argument_default)*/
			};

			// Атрибуты группы
			Title = title;
			GroupActions = new List<object>();

			// получить большинство атрибутов из контейнера
			/*self._registries = container._registries
			self._actions = container._actions
			self._option_string_actions = container._option_string_actions
			self._defaults = container._defaults
			self._has_negative_number_optionals = container._has_negative_number_optionals
			self._mutually_exclusive_groups = container._mutually_exclusive_groups*/
		}
	}
}