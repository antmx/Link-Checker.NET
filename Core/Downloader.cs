using System;
using System.Text.RegularExpressions;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Netricity.Common;

namespace Netricity.Linkspector.Core
{
	public class Downloader : IDownloader
	{
		private IHttpMessageHandler MessageHandler { get; set; }
		private IResource Resource { get; set; }
		private TimeSpan RequestTimeout { get; set; }
		private string UserAgent { get; set; }
		public Action<IResource> OnStart { get; set; }
		public Action<IResource> OnComplete { get; set; }
		public Action<IResource> OnError { get; set; }
		public Action<IResource> OnTimeout { get; set; }

      //public Downloader(IHttpMessageHandler messageHandler, IResource resource)
      public Downloader(IHttpMessageHandler messageHandler)
      {
         this.MessageHandler = messageHandler;
         //this.Resource = resource;
      }

		public Downloader(
			IHttpMessageHandler messageHandler,
			//IResource resource,
			int requestTimeout,
			string userAgent,
			Action<IResource> onStart,
			Action<IResource> onComplete,
			Action<IResource> onError,
			Action<IResource> onTimeout)
         //: this(messageHandler, resource)
         : this(messageHandler)
      {
			//this.Resource = resource;
			this.RequestTimeout = new TimeSpan(0, 0, 0, 0, requestTimeout);
			this.UserAgent = userAgent;
			this.OnStart = onStart;
			this.OnComplete = onComplete;
			this.OnError = onError;
			this.OnTimeout = onTimeout;
		}

      public async Task Download(IResource resource)
      {
         this.Resource = resource;

         using (var httpClient = new HttpClient((HttpMessageHandler)this.MessageHandler))
         {
            httpClient.Timeout = this.RequestTimeout.Ticks > 0 ? this.RequestTimeout : httpClient.Timeout;
            
            if (this.UserAgent.HasValue())
               httpClient.DefaultRequestHeaders.Add("User-Agent", this.UserAgent);

            //httpClient.MaxResponseContentBufferSize = 123;

            HttpResponseMessage response = null;

            try
            {
               if (this.OnStart != null)
                  OnStart(Resource);

               response = await httpClient.GetAsync(this.Resource.Url.Href);

               response.EnsureSuccessStatusCode();
               
               var status = response.StatusCode + " " + response.ReasonPhrase;
               //string responseBodyAsText = null;

               //await response.Content.ReadAsByteArrayAsync

               Resource.ContentType = response.Content.Headers.ContentType.MediaType;
               Resource.ContentEncoding = string.Join(";", response.Content.Headers.ContentEncoding);
               Resource.ContentLength = response.Content.Headers.ContentLength.GetValueOrDefault();

               if (Resource.ContentType.StartsWith("text"))
               {
                  Resource.Content = await response.Content.ReadAsStringAsync();
               }

               //Product product = await response.Content.h ReadAsAsync<Product>();
               //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
            }
            catch (HttpRequestException ex)
            {
               Resource.Status = response.StatusCode + " " + response.ReasonPhrase;
               Resource.Error = ex.ToString();
               
               if (OnError != null)
                  OnError(Resource);
            }
            catch (Exception ex)
            {
               Resource.Error = ex.ToString();

               if (OnError != null)
                  OnError(Resource);
            }
         }
      }

		public bool IsSuccessHttpStatus(string httpStatus)
		{
			throw new NotImplementedException();
		}

		public bool IsProtocolSupported
		{
			get
			{
				var regex = new Regex("^(http|https):", RegexOptions.Compiled);

				return regex.IsMatch(this.Resource.Url.Href);
			}
		}

		//public event EventHandler OnProgress;

		//public event EventHandler OnLoad;

		//public event EventHandler OnError;

		//public event EventHandler OnTimeout;

		//public event EventHandler OnLoadStart;

		//public event EventHandler OnAbort;

		//public event EventHandler OnLoadEnd;
	}
}
