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
			var groups = new List<string>();

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
			var port = int.Parse(groups[6].GetValueOrDefault("0"));
			var pathname = groups[7].GetValueOrDefault();
			var search = groups[8].GetValueOrDefault();
			var hash = groups[9].GetValueOrDefault();

			if (baseUrl != null)
			{
				var baseUrlObject = new Url(baseUrl);
				var flag = protocol == "" && host == "" && username == "";

				if (flag && pathname == "" && search == "")
				{
					search = baseUrlObject.Search;
				}

				if (flag && pathname[0] != '/')
				{
					pathname = (pathname != ""
						? (((baseUrlObject.Host != "" || baseUrlObject.Username != "") && baseUrlObject.Pathname == ""
						? "/"
						: "")
						//+ baseUrlObject.Pathname.slice(0, baseUrlObject.Pathname.LastIndexOf("/") + 1) 
						+ baseUrlObject.Pathname.Substring(0, baseUrlObject.Pathname.LastIndexOf("/") + 1)
						+ pathname)
						: baseUrlObject.Pathname);
				}

				// dot segments removal
				var output = new Stack<string>();

				//pathname.replace(/^(\.\.?(\/|$))+/, "")
				//  .replace(/\/(\.(\/|$))+/g, "/")
				//  .replace(/\/\.\.$/, "/../")
				//  .replace(/\/?[^\/]*/g, function (p) {
				//	if (p === "/..") {
				//		output.pop();
				//	} else {
				//		output.push(p);
				//	}
				//  });

				var modifiedPathname = Regex.Replace(pathname, @"^(\.\.?(\/|$))+", "");
				modifiedPathname = Regex.Replace(modifiedPathname, @"\/(\.(\/|$))+", "/");
				modifiedPathname = Regex.Replace(modifiedPathname, @"\/\.\.$", "/../");

				var matches = Regex.Match(modifiedPathname, @"\/?[^\/]*");

				if (matches.Success)
				{
					do
					{
						var value = matches.Value;

						if (value == "/..")
							output.Pop();
						else
							output.Push(value);

						matches = matches.NextMatch();
					} while (matches.Success);
				}


				//pathname = output.join("").replace(/^\//, pathname.charAt(0) === "/" ? "/" : "");
				pathname = String.Join("", output);
				pathname = Regex.Replace(pathname, @"^\/", pathname[0] == '/' ? "/" : "");


				if (flag)
				{
					port = baseUrlObject.Port;
					hostname = baseUrlObject.Hostname;
					host = baseUrlObject.Host;
					password = baseUrlObject.Password;
					username = baseUrlObject.Username;
				}

				if (protocol == "")
				{
					protocol = baseUrlObject.Protocol;
				}
			}

			this.Origin = protocol + (protocol != "" || host != "" ? "//" : "") + host;
			this.Href = protocol
				+ (protocol != "" || host != "" ? @"//" : "")
				+ (username != "" ? username
					+ (password != "" ? ":"
					+ password : "") + "@" : "")
				+ host
				+ pathname
				+ search
				+ hash;

			this.Protocol = protocol;
			this.Username = username;
			this.Password = password;
			this.Host = host;
			this.Hostname = hostname;
			this.Port = port;
			this.Pathname = pathname;
			this.Search = search;
			this.Hash = hash;
		}

		#endregion
	}
}
