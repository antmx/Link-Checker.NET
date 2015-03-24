using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Netricity.Common
{
	/// <summary>
	/// Extended version of the System.ApplicationException class.
	/// </summary>
	/// <remarks></remarks>
	public class CustomException : ApplicationException
	{

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="format">String containing optional string formatting placeholders.</param>
		/// <param name="args">Optional list of arguments for <paramref name="format">format</paramref></param>
		/// <remarks></remarks>
		public CustomException(string format, params object[] args)
			: base(string.Format(format, args))
		{
		}

		public CustomException(string format, ExceptionPriority Priority, params object[] args)
			: base(string.Format(format, args))
		{
			ExceptionPriority = Priority;
		}

		public ExceptionPriority ExceptionPriority { get; set; }

	}

	public enum ExceptionPriority
	{
		Normal,
		High
	}

}
