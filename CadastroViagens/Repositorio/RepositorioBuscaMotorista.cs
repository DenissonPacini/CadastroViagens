using CadastroViagens.Data;
using CadastroViagens.Interfaces;
using CadastroViagens.Models;
using CadastroViagens.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CadastroViagens.Repositorio
{
    public class RepositorioBuscaMotorista : BaseRepositorio<Motorista>, IRepositorioBuscaMotorista
    {
        private readonly AppDbContext _contexto;

        public RepositorioBuscaMotorista(AppDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public string PegaMotorista(string Nome)
        {
            var dados = (from m in _appDbContext.Motorista where (EF.Functions.Like(m.Nome, "%" + Nome +"%")) select new { m.Nome });
            return "";
        }
    }
}
