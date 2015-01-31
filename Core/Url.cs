using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netricity.LinkChecker.Core
{
	public class Url : IUrl
	{
		#region Constructors

		public Url(string url)
		{
			this.Parse(url, null);
		}

		public Url(string url, string baseUrl)
		{
			this.Parse(url, baseUrl);
		}

		#endregion

		#region Properties

		public string Origin { get; set; }

		public string Href { get; set; }

		public string Protocol { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string Host { get; set; }

		public string Hostname { get; set; }

		public int Port { get; set; }

		public string Pathname { get; set; }

		public string Search { get; set; }

		public string Hash { get; set; }

		public string Title { get; set; }

		#endregion

		#region Methods

		public bool IsEqualTo(IUrl other, bool caseSensitive)
		{
			if (other == null)
				return false;

			if (caseSensitive)
			{
				return this.Href == other.Href;
			}
			else
			{
				return this.Href.ToLower() == other.Href.ToLower();
			}
		}

		public void Parse(string url, string baseUrl)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
