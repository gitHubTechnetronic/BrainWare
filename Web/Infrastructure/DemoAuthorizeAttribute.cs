﻿using System;
using System.Linq;
using System.Web.Http;

namespace Web.Infrastructure
{
    public class DemoAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (Authorize(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var challengeMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
            throw new HttpResponseException(challengeMessage);
        }

        private bool Authorize(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {                
                var someCode = (from h in actionContext.Request.Headers where h.Key == "Authorization" select h.Value.First()).FirstOrDefault();
                return someCode == "demo Token";
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}