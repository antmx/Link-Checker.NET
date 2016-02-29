using System;
using System.Linq;

namespace Netricity.Linkspector.Core
{
	public interface IUrl
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

		bool IsEqualTo(IUrl other, bool caseSensitive);

		#endregion
	}
}
