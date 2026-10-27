using ShortMyUrl.Domain.DTOs;
using ShortMyUrl.Domain.Entities;
using ShortMyUrl.Domain.Interfaces.Repositories;
using ShortMyUrl.Domain.Interfaces.Services;
using System.Security.Cryptography;

namespace ShortMyUrl.Domain.Services
{
    public class UrlDomainService : IUrlDomainService
    {
        private readonly IUrlRepository _urlRepository;
        private readonly Uri _baseUrl;

        public UrlDomainService(IUrlRepository urlRepository, string baseUrl)
        {
            _urlRepository = urlRepository;

            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var parsedBaseUrl) || (parsedBaseUrl.Scheme != Uri.UriSchemeHttp && parsedBaseUrl.Scheme != Uri.UriSchemeHttps))
            {
                throw new ArgumentException("Configure uma URL pública HTTP ou HTTPS válida.", nameof(baseUrl));
            }

            _baseUrl = new Uri(parsedBaseUrl.GetLeftPart(UriPartial.Authority).TrimEnd('/') + "/");
        }

        public async Task<string> Encurtar(UrlDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.urlOriginal) || !Uri.TryCreate(dto.urlOriginal, UriKind.Absolute, out var original) || (original.Scheme != Uri.UriSchemeHttp && original.Scheme != Uri.UriSchemeHttps))
            {
                throw new ArgumentException("Informe uma URL HTTP ou HTTPS válida.");
            }

            for (var tentativa = 0; tentativa < 5; tentativa++)
            {
                var codigo = Convert.ToBase64String(RandomNumberGenerator.GetBytes(9)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
                var urlCurta = new Uri(_baseUrl, "r/" + codigo).AbsoluteUri;

                if (await _urlRepository.GetByUrlNova(urlCurta) != null)
                {
                    continue;
                }

                var url = new Url
                {
                    Id = Guid.NewGuid().ToString(),
                    UrlOriginal = original.AbsoluteUri,
                    UrlNova = urlCurta
                };

                await _urlRepository.AddAsync(url);
                return urlCurta;
            }

            throw new InvalidOperationException("Não foi possível gerar um código disponível.");
        }

        public async Task<string?> Resolver(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo) || codigo.Length != 12 || codigo.Any(ch => !char.IsLetterOrDigit(ch) && ch != '-' && ch != '_'))
            {
                return null;
            }

            var urlCurta = new Uri(_baseUrl, "r/" + codigo).AbsoluteUri;
            var registro = await _urlRepository.GetByUrlNova(urlCurta);
            return registro?.UrlOriginal;
        }

        public async Task<string> Deletar(UrlDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.urlOriginal))
            {
                throw new ArgumentException("Informe a URL original.");
            }

            var registro = await _urlRepository.GetByUrlOrigin(dto.urlOriginal);

            if (registro == null)
            {
                throw new ArgumentException("URL não encontrada.");
            }

            await _urlRepository.DeleteAsync(registro.UrlOriginal);
            return $"URL {registro.UrlOriginal} removida com sucesso!";
        }
    }
}
