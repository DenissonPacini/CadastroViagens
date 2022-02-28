using System.ComponentModel.DataAnnotations;

namespace CadastroViagens.Models
{
    public class Caminhao
    {
        public Caminhao() { }

        public Caminhao(string marca, string modelo, string placa, string eixos, int idMotorista)
        {
            Marca = marca;
            Modelo = modelo;
            Placa = placa;
            Eixos = eixos;
            IdMotorista = idMotorista;
        }

        public int Id { get; set; }
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Display(Name = "Placa")]
        public string Placa { get; set; }

        [Display(Name = "Eixos")]
        public string Eixos { get; set; }

        public int IdMotorista { get; set; }
        public Motorista Motorista { get; set; }
    }
}
