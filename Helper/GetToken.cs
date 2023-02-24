using System.Security.Claims;

namespace form.Helper
    {
    public class GetToken
        {
        public static string GetTokenValue(ClaimsPrincipal userObj, string claimType)
            {

            var identity = userObj.Identity as ClaimsIdentity;
            if(identity != null)
                {
                var claim = identity.FindFirst(claimType);
                return claim?.Value ?? "";
                }
            throw new Exception("Unable to validate the user.Please login again");

            }
        }
    }
