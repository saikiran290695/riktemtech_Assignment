using RiktamTech.DTO;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace RiktamTech.Filters
{
    public class JWTAuthenticationFilter : IAuthenticationFilter
    {
            public bool AllowMultiple => false;

            private void SetPrincipal(IPrincipal principal)
            {
                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }
            }

            public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
            {

                if (context.Request.RequestUri.AbsolutePath != "/api/users/login" &&
                    context.Request.RequestUri.AbsolutePath != "/api/users/signup")
                {
                    try
                    {
                        string JWTtoken = context.Request.Headers.Where(x => x.Key == "token").FirstOrDefault().Value.FirstOrDefault();

                        if (JWTtoken != null)
                        {
                            AuthServices services = new AuthServices();
                            DecodedToken decodedToken = services.validateJWTToken(JWTtoken);

                            if (decodedToken.responseCode == 401)
                            {
                                context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
                            }
                            else
                            {
                                var principal = new ClaimsPrincipal(decodedToken.decodedUser);
                                context.Principal = principal;

                                SetPrincipal(principal);
                            }
                        }
                    }

                    catch (Exception ex)
                    {

                    }
                }
                return Task.FromResult(0);

            }

            public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
            {
                return Task.FromResult(0);
            }
     
    }
}