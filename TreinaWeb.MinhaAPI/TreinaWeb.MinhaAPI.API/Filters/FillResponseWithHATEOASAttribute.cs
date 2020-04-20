using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using TreinaWeb.MinhaAPI.API.HATEOAS.Helpers;

namespace TreinaWeb.MinhaAPI.API.Filters
{
    public class FillResponseWithHATEOASAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //aplication/hal+json
            if (actionExecutedContext.Response.IsSuccessStatusCode &&
                actionExecutedContext.Request.Headers.SelectMany(s => s.Value).Any(a => a.Contains("hal")))
            {
                //pegando oconteudo
                ObjectContent responseContent = actionExecutedContext.Response.Content as ObjectContent;

                object responseValue = responseContent.Value;
                RestResourceBuilder.BuildResource(responseValue, actionExecutedContext.Request);

            }




        }
    }
}