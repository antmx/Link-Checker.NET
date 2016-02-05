using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Netricity.Linkspector.Core
{
   public interface IHttpMessageHandler : IDisposable
   {
      //
      // Summary:
      //     Send an HTTP request as an asynchronous operation.
      //
      // Parameters:
      //   request:
      //     The HTTP request message to send.
      //
      //   cancellationToken:
      //     The cancellation token to cancel operation.
      //
      // Returns:
      //     Returns System.Threading.Tasks.Task`1.The task object representing the asynchronous
      //     operation.
      //
      // Exceptions:
      //   T:System.ArgumentNullException:
      //     The request was null.
      Task<HttpResponseMessage> SendAsyncPublic(HttpRequestMessage request, CancellationToken cancellationToken);
   }
}
