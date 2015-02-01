using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Netricity.Common;

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
			url = Regex.Replace(url, @"^\s+|\s+$", string.Empty);
			var match = Regex.Match(url, @"^([^:\/?#]+:)?(?:\/\/(?:([^:@\/?#]*)(?::([^:@\/?#]*))?@)?(([^:\/?#]*)(?::(\d*))?))?([^?#]*)(\?[^#]*)?(#[\s\S]*)?");
			var groups=new List<string>();

			if (!match.Success)
				throw new ApplicationException("url is not a valid url");

			foreach (var group in match.Groups)
			{
				var groupValue = group.ToString();
				groups.Add(groupValue);
			}
			
			//var matchValues = new List<string>();

			//do
			//{
			//	matchValues.Add(match.Value);
			//	match = match.NextMatch();
			//} while (match.Success);

			var protocol = groups[1].GetValueOrDefault();
			var username = groups[2].GetValueOrDefault();
			var password = groups[3].GetValueOrDefault();
			var host = groups[4].GetValueOrDefault();
			var hostname = groups[5].GetValueOrDefault();
			var port = groups[6].GetValueOrDefault();
			var pathname = groups[7].GetValueOrDefault();
			var search = groups[8].GetValueOrDefault();
			var hash = groups[9].GetValueOrDefault();
		}

		#endregion
	}
}
