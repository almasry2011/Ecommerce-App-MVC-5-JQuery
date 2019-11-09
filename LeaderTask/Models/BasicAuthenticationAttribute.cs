using LeaderTask.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LeaderTask.Models
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private const string Realm = "My Realm";
        public override async void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

                //    

            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                if (actionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate",
                        string.Format("Basic realm=\"{0}\"", Realm));
                }
            }
            else
            {
                // Gets header parameters  
                string authenticationString = actionContext.Request.Headers.Authorization.Parameter;
                string originalString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));
                // Gets username and password  
                string usrename = originalString.Split(':')[0];
                string password = originalString.Split(':')[1];

                //// Validate username and password  
                //if (!await NewMethod(usrename, password))
                //{
                //    // returns unauthorized error  
                //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                //}
            }
















            ////If the Authorization header is empty or null
            ////then return Unauthorized
            //if (actionContext.Request.Headers.Authorization == null)
            //{
            //    actionContext.Response = actionContext.Request
            //        .CreateResponse(HttpStatusCode.Unauthorized);

            //    // If the request was unauthorized, add the WWW-Authenticate header 
            //    // to the response which indicates that it require basic authentication
            //    if (actionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
            //    {
            //        actionContext.Response.Headers.Add("WWW-Authenticate",
            //            string.Format("Basic realm=\"{0}\"", Realm));
            //    }
            //}
            //else
            //{
            //    //Get the authentication token from the request header
            //    string authenticationToken = actionContext.Request.Headers
            //        .Authorization.Parameter;
            //    //Decode the string
            //    string decodedAuthenticationToken = Encoding.UTF8.GetString(
            //        Convert.FromBase64String(authenticationToken));
            //    //Convert the string into an string array
            //    string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
            //    //First element of the array is the username
            //    string username = usernamePasswordArray[0];
            //    //Second element of the array is the password
            //    string password = usernamePasswordArray[1];
            //    //call the login method to check the username and password
            //    if (UserValidator.Login(username, password))
            //    {
            //        var identity = new GenericIdentity(username);
            //        IPrincipal principal = new GenericPrincipal(identity, null);
            //        Thread.CurrentPrincipal = principal;
            //        if (HttpContext.Current != null)
            //        {
            //            HttpContext.Current.User = principal;
            //        }
            //    }
            //    else
            //    {
            //        actionContext.Response = actionContext.Request
            //            .CreateResponse(HttpStatusCode.Unauthorized);
            //    }










        }

        private static System.Threading.Tasks.Task<bool> NewMethod(string usrename, string password)
        {
            return ApiSecurity.VaidateUser(usrename, password);
        }
    }
}