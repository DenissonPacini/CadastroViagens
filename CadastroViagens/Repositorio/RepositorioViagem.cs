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
            List<Motorista> ListarMotorista = new List<Motorista>();

            var idMotorista = _contexto.Motorista
                .Where(P => EF.Functions.Like(P.Nome, "%" + Nome + "%"))
                .Select(p => new { p.Id, p.Nome })
                .ToList();

            foreach (var item in idMotorista)
            {
                ListarMotorista.Add(new Motorista { Id = item.Id, Nome = item.Nome });
            }

            return ListarMotorista;// _motorista.PegaMotorista(Nome);
        }
    }
}
