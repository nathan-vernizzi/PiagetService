using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Aluno : Base
    {
        [Required, MaxLength(100)]
        public string Nome { get; private set; }

        public DateTime DataNascimento { get; private set; }

        [Required, MaxLength(20)]
        public string Matricula { get; private set; }

        public Guid EscolaId { get; private set; }
        public Escola? Escola { get; private set; }

        private Aluno() { }

        public Aluno(string nome, DateTime dataNascimento, string matricula, Guid escolaId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataNascimento = dataNascimento;
            Matricula = matricula;
            EscolaId = escolaId;
        }

    }
}
