using System;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Netricity.Linkspector.Core
{
   public class CustomHttpMessageHandler : DelegatingHandler, IHttpMessageHandler
   {
      public async Task<HttpResponseMessage> SendAsyncPublic(HttpRequestMessage request, CancellationToken cancellationToken)
      {
         return await SendAsync(request, cancellationToken);
      }

      protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
      {
         IPrincipal principal = new GenericPrincipal(
             new GenericIdentity("myuser"), 
             new string[] { "myrole" });

         Thread.CurrentPrincipal = principal;
         //HttpContext.Current.User = principal;

         return await base.SendAsync(request, cancellationToken);
      }
   }
}
