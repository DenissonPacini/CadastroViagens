using CadastroViagens.Models;
using System.Collections.Generic;

namespace CadastroViagens.Interfaces
{
    public interface IRepositorioMotorista
    {
        int CadastrarMotorista(Motorista dados);
        List<Motorista> ListarMotorista(string Nome);
        int PegaID(int Id);
        int AlterarMotorista(Motorista motorista, Caminhao caminhao);
        int ExcluirMotorista(int Id);
    }
}
