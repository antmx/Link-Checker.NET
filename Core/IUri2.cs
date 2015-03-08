using System;
using System.Linq;

namespace Netricity.LinkChecker.Core
{
	public interface IUrl2
	{
		#region Properties

		string Origin { get; set; }

		//string Href { get; set; }

		string Scheme { get; }

		string UserInfo { get; }

		string Host { get; }

		int Port { get; }

		string AbsolutePath { get; }

		string Query { get; }

		string Fragment { get; }

		string Title { get; set; }

		string Href { get; }

		#endregion

		#region Methods

		bool IsEqualTo(IUrl2 other, bool caseSensitive);

		#endregion
	}
}
