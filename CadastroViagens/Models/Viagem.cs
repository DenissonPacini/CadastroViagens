using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroViagens.Models
{
    public class Viagem
    {
        public Viagem() { }

        public Viagem(string dataHoraViagem, int idMotorista, string localEntrega, string localSaida, Motorista motorista, string totalKmEntreCidade)
        {
            DataHoraViagem = dataHoraViagem;
            IdMotorista = idMotorista;
            LocalEntrega = localEntrega;
            LocalSaida = localSaida;
            Motorista = motorista;
            TotalKmEntreCidade = totalKmEntreCidade;
        }

        public int Id { get; set; }
        [Required]
        public string DataHoraViagem { get; set; }
        [Required]
        public string LocalEntrega { get; set; }
        [Required]
        public string LocalSaida { get; set; }
        [Required]
        public string TotalKmEntreCidade { get; set; }
        [Required]
        public int IdMotorista { get; set; }
        public Motorista Motorista { get; set; }
    }
}
