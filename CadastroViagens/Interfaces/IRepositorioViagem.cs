using CadastroViagens.Models;
using System.Collections.Generic;

namespace CadastroViagens.Interfaces
{
    public interface IRepositorioViagem
    {
        int CadastrarViagem(Viagem dados);
        List<Motorista> BuscaMotorista(string Nome);
    }
}
