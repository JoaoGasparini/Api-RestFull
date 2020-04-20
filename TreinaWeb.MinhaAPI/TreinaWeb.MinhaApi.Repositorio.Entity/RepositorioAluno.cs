using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Comum.Repositorio.Entity;
using TreinaWeb.MinhaAPI.AcessaDados.Entity.Context;
using TreinaWeb.MinhaAPI.Dominio;

namespace TreinaWeb.MinhaApi.Repositorio.Entity
{
    public class RepositorioAluno : RepositorioTreinaWeb<Aluno, int> 
    {
        public RepositorioAluno(MinhaApiDbContext context) : base(context)
        {
            
        }
    }
}
