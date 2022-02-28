using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroViagens.Interfaces
{
    public interface IRepositorioBuscaMotorista
    {
        string PegaMotorista(string Nome);
    }
}
