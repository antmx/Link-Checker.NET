using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netricity.LinkChecker.Core
{
	public interface IUrl
	{
		#region Properties

		string Origin { get; set; }

		string Href { get; set; }

		string Protocol { get; set; }

		string Username { get; set; }

		string Password { get; set; }

		string Host { get; set; }

		string Hostname { get; set; }

		int Port { get; set; }

		string Pathname { get; set; }

		string Search { get; set; }

		string Hash { get; set; }

		string Title { get; set; }

		#endregion

		#region Methods

		bool IsEqualTo(IUrl other, bool caseSensitive);
		
		void Parse(string url, string baseUrl);

		#endregion
	}
}
