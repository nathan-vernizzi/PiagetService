using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record EscolaDto(        
        Guid Id,
        string Nome,
        string Endereco,
        DateTime DataFundacao,
        int TotalProfessores,
        int TotalAlunos
    );
}
