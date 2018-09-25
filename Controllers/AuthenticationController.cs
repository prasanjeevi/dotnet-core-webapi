using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_webapi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        public ActionResult<bool> Validate([FromHeader] string authorization)
        {
            if(authorization.StartsWith("basic ", StringComparison.InvariantCultureIgnoreCase))
            {
               string base64EncodedData = authorization.Replace("basic", string.Empty, StringComparison.InvariantCultureIgnoreCase);
               return AuthenticationController.Base64Decode(base64EncodedData) == "username:password";
            }
            return false;
        }

        public static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData) {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
