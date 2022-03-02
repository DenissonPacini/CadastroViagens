using System.Text.Json.Serialization;

namespace CadastroViagens.Models
{
    public class Motorista
    {
        public Motorista(){}

        public Motorista(string nome, string ultimoNome, string bairro, string cEP, string complemento, string localidade, string logradouro, string numero, string uF, Caminhao caminhao)
        {
            Nome = nome;
            UltimoNome = ultimoNome;
            Bairro = bairro;
            CEP = cEP;
            Complemento = complemento;
            Localidade = localidade;
            Logradouro = logradouro;
            Numero = numero;
            UF = uF;
            Caminhao = caminhao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        [JsonIgnore]
        public Caminhao Caminhao { get; set; }
        [JsonIgnore]
        public Viagem Viagem { get; set; }
    }
}
