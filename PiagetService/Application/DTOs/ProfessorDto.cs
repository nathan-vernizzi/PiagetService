using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record ProfessorDto(
        Guid Id,
        string Nome,
        string Email,
        string Disciplina,
        string EscolaNome
    );
}
