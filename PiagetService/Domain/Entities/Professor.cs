using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Professor : Base
    {
        [Required, MaxLength(100)]
        public string Nome { get; private set; }

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; private set; }

        [Required, MaxLength(50)]
        public string Disciplina { get; private set; }

        public Guid EscolaId { get; private set; }
        public Escola? Escola { get; private set; }

        private Professor() { }


        public Professor(string nome, string email, string disciplina, Guid escolaId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Disciplina = disciplina;
            EscolaId = escolaId;
        }


        public void Atualizar(string nome, string email, string disciplina)
        {
            Nome = nome;
            Email = email;
            Disciplina = disciplina;
        }

    }
}
