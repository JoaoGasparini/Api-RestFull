using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TreinaWeb.Comum.Repositorios.Interfaces;
using TreinaWeb.MinhaApi.Repositorio.Entity;
using TreinaWeb.MinhaAPI.AcessaDados.Entity.Context;
using TreinaWeb.MinhaAPI.API.AutoMapper;
using TreinaWeb.MinhaAPI.API.DTO;
using TreinaWeb.MinhaAPI.API.Filters;
using TreinaWeb.MinhaAPI.Dominio;

namespace TreinaWeb.MinhaAPI.API.Controllers
{
    public class AlunosController : ApiController
    {
        private IRepositorioTreinaWeb<Aluno, int> _repositorioAlunos 
            = new RepositorioAluno(new MinhaApiDbContext());

        public IHttpActionResult Get()
        {
            List<Aluno> alunos = _repositorioAlunos.Selecionar();
            List<AlunoDTO> dto 
                = AutoMapperManager.instance.imapper.Map<List<Aluno>, List<AlunoDTO>> (alunos);

            return Ok(dto);
        }
    
        public IHttpActionResult Get (int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            
            Aluno aluno = _repositorioAlunos.SelecionarPorId(id.Value);

            if(aluno == null)
            {
                return NotFound();
            }
            AlunoDTO dto = AutoMapperManager.instance.imapper.Map<Aluno, AlunoDTO>(aluno);
            return Content(HttpStatusCode.Found, dto);
        }
        [ApplyValidationModel]
        public IHttpActionResult Post([FromBody]AlunoDTO dto)
        {
            
            try
            {
                Aluno aluno = AutoMapperManager.instance.imapper.Map<AlunoDTO, Aluno>(dto);
                _repositorioAlunos.Inserir(aluno);
                return Created($"{Request.RequestUri}/{ aluno.Id}", aluno);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
            
        }
        [ApplyValidationModel]
        public IHttpActionResult Put(int? id, [FromBody]AlunoDTO dto)
        {

            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }

                Aluno aluno = AutoMapperManager.instance.imapper.Map<AlunoDTO, Aluno>(dto);
                aluno.Id = id.Value;
                _repositorioAlunos.Atualizar(aluno);
                return Ok(dto);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }

                if(id == null)
                {
                    return NotFound();
                }

                //var aluno = _repositorioAlunos.SelecionarPorId(id.Value);
                //_repositorioAlunos.Excluir(aluno);
                _repositorioAlunos.ExcluirporId(id.Value);
                return Ok();
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
