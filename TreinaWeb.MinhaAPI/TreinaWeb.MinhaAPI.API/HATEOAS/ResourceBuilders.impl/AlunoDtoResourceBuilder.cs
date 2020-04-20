using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using TreinaWeb.MinhaAPI.API.DTO;
using TreinaWeb.MinhaAPI.API.HATEOAS.ResourceBuilders.Interfaces;

namespace TreinaWeb.MinhaAPI.API.HATEOAS.ResourceBuilders.impl
{
    public class AlunoDTOResourceBuilder : IResourceBuilder
    {
        public void BuildResource(object resource, HttpRequestMessage request)
        {
            AlunoDTO dto = resource as AlunoDTO;
            if (dto == null)
            {
                throw new ArgumentException($"Era esperado um AlunoDTO, porem foi enviado um {resource.GetType().Name}");
            }
            UrlHelper urlHelper = new UrlHelper();
            string AlunoDTORoute = urlHelper.Link("DefaultApi", new { controller = "Alunos", id = dto.Id });

            dto.Links.Add(new RestLink
            {
                Rel = "self",
                HRef = AlunoDTORoute
            });

            dto.Links.Add(new RestLink
            {
                Rel = "edit",
                HRef = AlunoDTORoute
            });

            dto.Links.Add(new RestLink
            {
                Rel = "delete",
                HRef = AlunoDTORoute
            });   
        }

    }
}