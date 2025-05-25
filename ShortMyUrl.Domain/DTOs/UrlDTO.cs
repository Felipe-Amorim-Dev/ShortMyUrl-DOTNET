using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortMyUrl.Domain.DTOs
{
    public class UrlDTO
    {
        [Required(ErrorMessage = "Informe a URL para encurtar.")]
        [Url(ErrorMessage = "Não é uma URL válida.")]
        public string? urlOriginal { get; set; }
    }
}
