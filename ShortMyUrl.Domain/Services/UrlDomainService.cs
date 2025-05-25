using ShortMyUrl.Domain.DTOs;
using ShortMyUrl.Domain.Entities;
using ShortMyUrl.Domain.Interfaces.Repositories;
using ShortMyUrl.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortMyUrl.Domain.Services
{
    public class UrlDomainService : IUrlDomainService
    {
        protected readonly IUrlRepository _urlRepository;

        public UrlDomainService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<string> Encurtar(UrlDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.urlOriginal))
            {
                throw new ArgumentException("A URL não pode ser vazia.");
            }

            var shortUrl = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                .Replace("=", "").Replace("+", "").Replace("/", "").Substring(0, 8);

            var originalUrl = new Uri(dto.urlOriginal);
            var dominio = $"{originalUrl.Scheme}://{originalUrl.Host}";
            var novaUri = $"{dominio}/{shortUrl}";

            var url = new Url
            {
                Id = Guid.NewGuid().ToString(),
                UrlOriginal = dto.urlOriginal,
                UrlNova = novaUri
            };

            await _urlRepository.AddAsync(url);

            return novaUri;
        }

        public async Task<string> Deletar(UrlDTO dto)
        {
            var url = await _urlRepository.GetByUrlOrigin(dto.urlOriginal);

            if (url == null)
            {
                throw new ArgumentException("URL não encontrada.");
            }

            await _urlRepository.DeleteAsync(url.UrlOriginal);

            return $"URL {url.UrlOriginal} removida com sucesso!";
        }        
    }
}
