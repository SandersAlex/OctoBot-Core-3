using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ArgParse.Enums;

namespace ArgParse
{
	public class ParserSettings
	{
		/// <summary>
		/// Описание того, что делает программа
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// Символы префексов для дополнительных аргументов
		/// </summary>
		public IList<string> PrefixChars { get; set; }
		/// <summary>
		/// Значение по умолчанию для всех аргументов
		/// </summary>
		public object ArgumentDefault { get; set; }
		/// <summary>
		/// Строка, указывающая, на обработчик ошибок
		/// </summary>
		public ConflictHandlerType ConflictHandlerType { get; set; }
		public bool AddHelp { get; set; } = false;


		public ParserSettings()
		{
			Description = "";
			PrefixChars = new List<string>() { "-", "--", "/" };
			ConflictHandlerType = ConflictHandlerType.Error;
			AddHelp = true;
		}
	}
}