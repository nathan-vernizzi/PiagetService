using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Escola : Base
    {   

        [Required, MaxLength(200)]
        public string Nome { get; private set; }

        [Required, MaxLength(300)]
        public string Endereco { get; private set; }

        public DateTime DataFundacao { get; private set; }

        public ICollection<Professor> Professores { get; private set; } = new();
        public ICollection<Aluno> Alunos { get; private set; } = new();


        private Escola() { }


        public Escola(string nome, string endereco, DateTime dataFundacao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Endereco = endereco;
            DataFundacao = dataFundacao;
        }

        public void Atualizar(string nome, string endereco)
        {
            Nome = nome;
            Endereco = endereco;
        }


    }
}
