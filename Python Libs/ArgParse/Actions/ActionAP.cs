using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ArgParse.Interfaces;

namespace ArgParse.Actions
{
	/// <summary>
	/// Объекты «Action» используются ArgumentParser для представления информации,
	/// необходимой для анализа одного аргумента из одной или нескольких строк из командной строки.
	/// Ключевыми аргументами конструктора «Action» также являются все атрибуты экземпляров «Action».
	/// </summary>
	public abstract class ActionAP
	{
		public Argument Argument { get; private set; }
		public IActionsContainer Container { get; protected internal set; }
		/// <summary>
		/// Список строк параметров командной строки, которые должны быть связаны с этим действием
		/// </summary>
		public IList<string> OptionStrings { get; private set; }
		/// <summary>
		/// Название атрибута для хранения созданных объектов
		/// </summary>
		public string Destination { get; private set; }

		public virtual bool HasDestination
		{
			get { return Destination != "" ? true : false; }
		}
		public virtual bool HasDefaultValue
		{
			get { return !Argument.SuppressDefaultValue; }
		}
		public bool HasValidDestination
		{
			get { return !string.IsNullOrWhiteSpace(Destination); }
		}
		public virtual object DefaultValue
		{
			get { return Argument.DefaultValue; }
		}
		public bool IsRemainder
		{
			get { return Argument.IsRemainder; }
		}
		public virtual bool IsParser
		{
			get { return false; }
		}
		public virtual ValueCount ValueCount
		{
			get { return Argument.ValueCount; }
		}
		public bool IsRequired { get; set; }
		public string MetaVariable
		{
			get { return Argument.MetaVariable; }
		}
		public Func<string, object> TypeFactory
		{
			get { return Argument.TypeFactory; }
		}
		public string TypeName
		{
			get { return Argument.TypeName; }
		}
		public Type Type
		{
			get { return Argument.Type; }
		}

		protected ActionAP(Argument argument, IActionsContainer container = null)
		{
			Argument = argument;
			Container = container;
			OptionStrings = new List<string>(Argument.OptionStrings ?? new string[] { });
			Destination = Argument.Destination;
			IsRequired = Argument.IsRequired;
		}
	}
}