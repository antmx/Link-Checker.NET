using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netricity.LinkChecker.Core
{
	public class ContentParser:IContentParser
	{
		public ICollection<string> ParseUrls(string content, string contentType, string contentUrl)
		{
			throw new NotImplementedException();
		}

		public ICollection<string> ParseHtml()
		{
			throw new NotImplementedException();
		}

		public ICollection<string> ParseCss()
		{
			throw new NotImplementedException();
		}

		public ICollection<string> ParseCssImports()
		{
			throw new NotImplementedException();
		}

		public ICollection<string> ParseCssStyles()
		{
			throw new NotImplementedException();
		}

		public ICollection<string> ParseTagUrls(IEnumerable<string> tagNames, IEnumerable<string> tagAttributes)
		{
			throw new NotImplementedException();
		}

		public string ParseTagTitle(object tagHtml)
		{
			throw new NotImplementedException();
		}

		public string ParseTagText(string html, string tagName)
		{
			throw new NotImplementedException();
		}

		public string ParseTagAttribute(string html, string tagName, string attributeName)
		{
			throw new NotImplementedException();
		}

		public bool CanParse(string contentType)
		{
			throw new NotImplementedException();
		}
	}
}
