using System;

namespace Netricity.Linkspector.Core
{
	public class Uri2 : Uri, IUrl
	{
		public Uri2(string uriString)
			: base(uriString)
		{
			SetOrigin();
		}

		public Uri2(Uri2 baseUri, string relativeUri)
			: base(baseUri, relativeUri)
		{
			SetOrigin();
		}

		public bool IsEqual(Uri other, bool caseSensitive)
		{
			if (other == null)
				return false;

			var compairisonType = caseSensitive
				? StringComparison.Ordinal
				: StringComparison.OrdinalIgnoreCase;

			var equal = string.Compare(this.ToString(), other.ToString(), compairisonType);
			
			return equal == 0;
		}

		private void SetOrigin()
		{
			this.Origin = Scheme + (Scheme != "" || Host != "" ? "//" : "") + Host;
		}

		public bool IsEqualTo(IUrl other, bool caseSensitive)
		{
			if (other == null)
				return false;

			if (caseSensitive)
			{
				return this.ToString() == other.ToString();
			}
			else
			{
				return this.ToString().ToLower() == other.ToString().ToLower();
			}
		}

		public string Title { get; set; }

		public string Href
		{
			get { return this.ToString(); }
		}

		public string Origin { get; set; }
	}
}
