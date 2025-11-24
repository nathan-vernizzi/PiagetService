using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record AlunoDto(
    Guid Id,
    string Nome,
    DateTime DataNascimento,
    string Matricula,
    string EscolaNome
    );

}
