using CadastroViagens.Interfaces;
using CadastroViagens.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace CadastroViagens.Controllers
{
    public class ViagemController : Controller
    {
        private const char V = ',';
        private readonly IRepositorioViagem _repositorioViagem;

        public ViagemController(IRepositorioViagem repositorioViagem)
        {
            _repositorioViagem = repositorioViagem;
        }

        public IActionResult CadastrarViagem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarViagem(Viagem dados)
        {
            ViewBag.Mensagem = "";
            if (ModelState.IsValid)
            {
                _repositorioViagem.CadastrarViagem(dados);
                ViewBag.Mensagem = "<script>alert('Viagem Gravada com sucesso.')</script>";
            }
            
            return View();
        }

        [HttpGet]
        public string buscarMotorista(string Nome)
        {
            return JsonSerializer.Serialize(_repositorioViagem.BuscaMotorista(Nome));
        }
    }
}
