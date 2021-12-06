using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Victor_Robinson_AspNet_AT.Models
{
    public class Aniversariante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        public Aniversariante() { }

        public Aniversariante(int id, string nome, string sobrenome, DateTime nascimento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Nascimento = nascimento;
        }

        public static List<Aniversariante> listaAniversariante = new List<Aniversariante>();

        public static void Salvar(Aniversariante aniversariante)
        {
            listaAniversariante.Add(aniversariante);
        }
    }
}
