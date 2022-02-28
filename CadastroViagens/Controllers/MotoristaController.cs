using CadastroViagens.Interfaces;
using CadastroViagens.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CadastroViagens.Controllers
{
    public class MotoristaController : Controller
    {

        private readonly IRepositorioMotorista _IRepositorioMotorista;

        public MotoristaController(IRepositorioMotorista repositorioMotorista)
        {
            _IRepositorioMotorista = repositorioMotorista;
        }

        public IActionResult Motorista()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarMotorista(Motorista Dados)
        {
            int retorno;

            if (ModelState.IsValid)
            {
                retorno = _IRepositorioMotorista.CadastrarMotorista(Dados);
            }
            else
                retorno = 3;

            return RedirectToAction("Motorista", new { id = retorno });
        }
        [HttpGet]
        public IActionResult ListarMotorista(string Nome)
        {
            List<Motorista> listaMotorista = new List<Motorista>();
            if(Nome != null)
            {
                foreach (var item in _IRepositorioMotorista.ListarMotorista(Nome))
                {
                    listaMotorista.Add(new Motorista
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        UltimoNome = item.UltimoNome,
                        Logradouro = item.Logradouro,
                        Numero = item.Numero,
                        Complemento = item.Complemento,
                        CEP = item.CEP,
                        Bairro = item.Bairro,
                        Localidade = item.Localidade,
                        UF = item.UF,
                        Caminhao = new Caminhao
                        {
                            Marca = item.Caminhao.Marca,
                            Modelo = item.Caminhao.Modelo,
                            Placa = item.Caminhao.Placa,
                            Eixos = item.Caminhao.Eixos
                        }
                    });
                }
                return View(listaMotorista);
            }
            return View(listaMotorista);
        }
        public IActionResult AlterarMotorista(int Id, string Nome_, string UltimoNome,
            string Logradouro, string Numero, string Complemento, string CEP, string Bairro, 
            string Localidade, string UF, string Marca, string Modelo, string Placa, string Eixos)
        {
            Motorista alteraMotorista = new Motorista();
            Caminhao alteraCaminhao = new Caminhao();

            if (Nome_ != null)
            {
                alteraMotorista.Id = Id;
                alteraMotorista.Nome = Nome_;
                alteraMotorista.UltimoNome = UltimoNome;
                alteraMotorista.Logradouro = Logradouro;
                alteraMotorista.Numero = Numero;
                alteraMotorista.Complemento = Complemento;
                alteraMotorista.CEP = CEP;
                alteraMotorista.Bairro = Bairro;
                alteraMotorista.Localidade = Localidade;
                alteraMotorista.UF = UF;

                alteraCaminhao.Id = _IRepositorioMotorista.PegaID(Id);
                alteraCaminhao.IdMotorista = Id;
                alteraCaminhao.Marca = Marca;
                alteraCaminhao.Modelo = Modelo;
                alteraCaminhao.Placa = Placa;
                alteraCaminhao.Eixos = Eixos;

                _IRepositorioMotorista.AlterarMotorista(alteraMotorista, alteraCaminhao);
  
                return View();
            }
            return View();
        }
        public IActionResult ExcluirMotorista(int Id)
        {
            int result = _IRepositorioMotorista.ExcluirMotorista(Id);

            return View(result);
        }
    }
}
