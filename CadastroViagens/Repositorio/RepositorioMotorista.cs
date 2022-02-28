using CadastroViagens.Data;
using CadastroViagens.Interfaces;
using CadastroViagens.Models;
using CadastroViagens.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CadastroViagens.Repositorio
{
    public class RepositorioMotorista : BaseRepositorio<Motorista>, IRepositorioMotorista
    {
        private readonly AppDbContext _contexto;

        public RepositorioMotorista(AppDbContext contexto) :base(contexto)
        {
            _contexto = contexto;
        }

        public int CadastrarMotorista(Motorista dados)
        {
            _contexto.Add(new Motorista(
                dados.Nome,
                dados.UltimoNome,
                dados.Bairro,
                dados.CEP,
                dados.Complemento, 
                dados.Localidade,
                dados.Logradouro,
                dados.Numero,
                dados.UF,
                dados.Caminhao
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
        public List<Motorista> ListarMotorista(string Nome)
        {
            List<Motorista> ListarMotoristas = new List<Motorista>();

            var Listar = (from m in _appDbContext.Motorista 
                          join c in _appDbContext.Caminhao
                          on m.Id equals c.IdMotorista
                          where (EF.Functions.Like(m.Nome, "%" + Nome +"%")) 
                          select new { m.Id,
                            m.Nome,
                            m.UltimoNome,
                            m.Logradouro,
                            m.Numero,
                            m.Complemento,
                            m.CEP,
                            m.Localidade,
                            m.Bairro,
                            m.UF,
                            c.Marca,
                            c.Modelo,
                            c.Placa,
                            c.Eixos
                          }).ToList();

            foreach (var item in Listar)
            {
                ListarMotoristas.Add(new Motorista
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    UltimoNome = item.UltimoNome,
                    Logradouro = item.Logradouro,
                    Numero = item.Numero,
                    Complemento = item.Complemento,
                    CEP = item.CEP,
                    Bairro =  item.Bairro,
                    Localidade = item.Localidade,
                    UF = item.UF,
                    Caminhao = new Caminhao { Marca = item.Marca
                    , Modelo = item.Modelo
                    , Placa = item.Placa
                    , Eixos = item.Eixos }
                });
            }

            return ListarMotoristas;
        }
        public int PegaID(int Id)
        {
            return (from c in _appDbContext.Caminhao where (c.IdMotorista == Id) select c.Id).SingleOrDefault();
        }

        public int AlterarMotorista(Motorista motorista, Caminhao caminhao)
        {
            _appDbContext.Update(motorista);
            _appDbContext.SaveChanges();

            _appDbContext.Update(caminhao);
            _appDbContext.SaveChanges();

            return 0;
        }
        public int ExcluirMotorista(int Id)
        {
            var excluir = (from m in _appDbContext.Motorista where m.Id == Id select m).FirstOrDefault();
            _appDbContext.Remove(excluir);
            _appDbContext.SaveChanges();

            var excluirCaminhao = (from c in _appDbContext.Caminhao where c.IdMotorista == PegaID(Id) select c).SingleOrDefault();
            try
            {
                _appDbContext.Remove(excluirCaminhao);
                _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }

            return 0;
        }
    }
}
