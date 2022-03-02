using CadastroViagens.Data;
using CadastroViagens.Interfaces;
using CadastroViagens.Models;
using CadastroViagens.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroViagens.Repositorio
{
    public class RepositorioViagem : BaseRepositorio<Viagem>, IRepositorioViagem
    {
        private readonly AppDbContext _contexto;

        public RepositorioViagem(AppDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public int CadastrarViagem(Viagem dados)
        {
            _contexto.Add(new Viagem(
                dados.DataHoraViagem,
                dados.IdMotorista,
                dados.LocalEntrega,
                dados.LocalSaida,
                dados.Motorista,
                dados.TotalKmEntreCidade
                ));
            try
            {
                _contexto.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public List<Motorista> BuscaMotorista(string Nome)
        {
            List<Motorista> ListarMotorista = _contexto.Motorista
                .Include(x => x.Viagem)
                .Where(p => EF.Functions.Like(p.Nome, "%" + Nome + "%"))
                .AsNoTracking()
                .ToList();

            return ListarMotorista;
        }
    }
}
