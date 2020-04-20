using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinaWeb.MinhaAPI.API.HATEOAS
{
    public class RestLink
    {
        public string Rel { get; set; } //lugar onde vai ter as relações com ações do que o cliente pode ou nao fazer
        public string HRef { get; set; } //hyperlink de acesso
    }
}