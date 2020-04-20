﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Comum.Repositorios.Interfaces;

namespace TreinaWeb.Comum.Repositorio.Entity
{
    public abstract class RepositorioTreinaWeb<TDominio, TChave> : IRepositorioTreinaWeb<TDominio, TChave>
       where TDominio : class
    {
        protected DbContext _context;
        public RepositorioTreinaWeb(DbContext context)
        {
            _context = context;
        }
        public void Atualizar(TDominio dominio)
        {
            _context.Entry(dominio).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(TDominio dominio)
        {
            _context.Entry(dominio).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void ExcluirporId(TChave Id)
        {
            TDominio dominio = SelecionarPorId(Id);
            Excluir(dominio);
        }

        public void Inserir(TDominio dominio)
        {
            _context.Set<TDominio>().Add(dominio);
            _context.SaveChanges();
        }

        public List<TDominio> Selecionar(Expression<Func<TDominio, bool>> where = null)
        {
            DbSet<TDominio> dbSet = _context.Set<TDominio>();
            if( where == null)
            {
                return dbSet.ToList();
            }
            else
            {
                return dbSet.Where(where).ToList();
            }
        }

        public TDominio SelecionarPorId(TChave Id)
        {
            return _context.Set<TDominio>().Find(Id);
        }
    }
}
