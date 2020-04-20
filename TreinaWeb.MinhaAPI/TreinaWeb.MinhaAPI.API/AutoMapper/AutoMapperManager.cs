using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinaWeb.MinhaAPI.API.DTO;
using TreinaWeb.MinhaAPI.Dominio;

namespace TreinaWeb.MinhaAPI.API.AutoMapper
{
    public class AutoMapperManager
    {
        private static readonly Lazy<AutoMapperManager> _instance
            = new Lazy<AutoMapperManager>(() =>
            {
                return new AutoMapperManager();
            });

        public static AutoMapperManager instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private MapperConfiguration _config;
        public IMapper imapper
        {
            get
            {
                return _config.CreateMapper();
            }
        }
        private AutoMapperManager()
        {
            _config = new MapperConfiguration((cfg) =>
            {

                cfg.CreateMap<Aluno, AlunoDTO>();
                cfg.CreateMap<AlunoDTO, Aluno>();

            });
        }
    }
}