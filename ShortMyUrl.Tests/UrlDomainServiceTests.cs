using ShortMyUrl.Domain.DTOs;
using ShortMyUrl.Domain.Entities;
using ShortMyUrl.Domain.Interfaces.Repositories;
using ShortMyUrl.Domain.Services;

namespace ShortMyUrl.Tests;

public class UrlDomainServiceTests
{
    [Fact]
    public async Task Encurtar_e_resolver_devolvem_a_url_original()
    {
        var repository = new RepositorioEmMemoria();
        var service = new UrlDomainService(repository, "http://localhost:8081");

        var curta = await service.Encurtar(new UrlDTO { urlOriginal = "https://example.org/artigo" });
        var codigo = curta.Split('/').Last();

        Assert.StartsWith("http://localhost:8081/r/", curta);
        Assert.Equal(12, codigo.Length);
        Assert.Equal("https://example.org/artigo", await service.Resolver(codigo));
    }

    [Fact]
    public async Task Resolver_devolve_nulo_para_codigo_desconhecido()
    {
        var service = new UrlDomainService(new RepositorioEmMemoria(), "https://links.exemplo.test");

        var resultado = await service.Resolver("aBcDef123456");

        Assert.Null(resultado);
    }

    [Theory]
    [InlineData("javascript:alert(1)")]
    [InlineData("ftp://example.com/arquivo")]
    [InlineData("sem-protocolo")]
    public async Task Encurtar_rejeita_protocolos_indevidos(string url)
    {
        var service = new UrlDomainService(new RepositorioEmMemoria(), "https://links.exemplo.test");

        await Assert.ThrowsAsync<ArgumentException>(() => service.Encurtar(new UrlDTO { urlOriginal = url }));
    }

    private sealed class RepositorioEmMemoria : IUrlRepository
    {
        private readonly List<Url> _urls = new();

        public Task AddAsync(Url model)
        {
            _urls.Add(model);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string nomeUrlOriginal)
        {
            _urls.RemoveAll(url => url.UrlOriginal == nomeUrlOriginal);
            return Task.CompletedTask;
        }

        public Task<Url?> GetByUrlOrigin(string urlOriginal)
        {
            return Task.FromResult(_urls.FirstOrDefault(url => url.UrlOriginal == urlOriginal));
        }

        public Task<Url?> GetByUrlNova(string urlNova)
        {
            return Task.FromResult(_urls.FirstOrDefault(url => url.UrlNova == urlNova));
        }
    }
}
