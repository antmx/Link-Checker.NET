using Netricity.Linkspector.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace CoreTests
{
   class FakeResponseHandler : DelegatingHandler, IHttpMessageHandler
   {
      private readonly Dictionary<Uri, HttpResponseMessage> _fakeResponses = new Dictionary<Uri, HttpResponseMessage>();

      //public void AddResponse(Uri uri, HttpResponseMessage responseMessage, string content, string contentType, string contentEncoding, long contentLength)
      public void AddHtmlResponse(Uri uri, HttpStatusCode statusCode, string content, long contentLength)
      {
         //var responseMsg = new HttpResponseMessage(statusCode);
         //responseMsg.Content = new StringContent(content, null, "text/html");
         //responseMsg.Content.Headers.ContentEncoding.Add("utf-8");
         //responseMsg.Content.Headers.ContentLength = contentLength;

         //_fakeResponses.Add(uri, responseMsg);

         var responseMsg = AddResponse(uri,statusCode, "text/html", contentLength);
         responseMsg.Content = new StringContent(content, null, "text/html");
      }

      private HttpResponseMessage AddResponse(Uri uri, HttpStatusCode statusCode, string contentType, long contentLength)
      {
         var responseMsg = new HttpResponseMessage(statusCode);
         //responseMsg.Content = new StringContent(content, null, "text/html");
         responseMsg.Content.Headers.ContentEncoding.Add("utf-8");
         responseMsg.Content.Headers.ContentLength = contentLength;
         responseMsg.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

         _fakeResponses.Add(uri, responseMsg);

         return responseMsg;
      }

      public async Task<HttpResponseMessage> SendAsyncPublic(HttpRequestMessage request, CancellationToken cancellationToken)
      {
         var msg = await SendAsync(request, cancellationToken);

         return msg;

         // Or just:
         //return await this.SendAsync(request, cancellationToken);
      }

      protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
      {
         // Return an awaitable Task that runs an inline anonymous function that returns a HttpResponseMessage
         return await Task.Run(() =>
         {
            if (_fakeResponses.ContainsKey(request.RequestUri))
            {
               var responseMsg = _fakeResponses[request.RequestUri];

               return responseMsg;
            }
            else
            {
               return new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request };
            }
         });
      }
   }
}
