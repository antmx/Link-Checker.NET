using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netricity.LinkChecker.Core
{
	public interface IContentParser
	{
		ICollection<string> ParseUrls(string content, string contentType, string contentUrl);

		ICollection<string> ParseHtml();

		ICollection<string> ParseCss();

		ICollection<string> ParseCssImports();

		ICollection<string> ParseCssStyles();

		ICollection<string> ParseTagUrls(IEnumerable<string> tagNames, IEnumerable<string> tagAttributes);

		string ParseTagTitle(object tagHtml);

		string ParseTagText(string html, string tagName);

		string ParseTagAttribute(string html, string tagName, string attributeName);

		bool CanParse(string contentType);


	}
}
