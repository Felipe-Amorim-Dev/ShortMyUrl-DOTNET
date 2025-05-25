using ShortMyUrl.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortMyUrl.Domain.Interfaces.Services
{
    public interface IUrlDomainService
    {
        Task<string> Encurtar(UrlDTO dto);

        Task<string> Deletar(UrlDTO dto);
    }
}
