using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.MinhaAPI.API.DTO;

namespace TreinaWeb.MinhaAPI.API.HATEOAS.ResourceBuilders.Interfaces
{
    interface IResourceBuilder
    {
        void BuildResource(object resource, HttpRequestMessage request);
    }
}
