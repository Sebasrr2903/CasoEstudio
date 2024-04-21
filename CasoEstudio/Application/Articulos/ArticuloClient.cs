using Domain.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using AutoMapper;
using Domain.Configuration;
using Microsoft.Extensions.Options;
using Shared;
using Domain.Comentarios;

namespace Application.Articulos
{
    public sealed class ArticuloClient : IArticuloClient
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public ArticuloClient(IOptions<List<EndpointConfiguration>> options ,HttpClient client, IMapper mapper) 
        {
            _endpoints = options.Value.Where
                (w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
            _client = client;
            _mapper = mapper;
        }

        public async Task<List<ArticuloDTO>> List()
        {
            var content = await _client.GetStringAsync
                (_endpoints.Where(w => w.Name.Equals("Articulos", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/withcomments");
            var Articulos = JsonSerializer.Deserialize<List<Articulo>>(content);

            return _mapper.Map<List<ArticuloDTO>>(Articulos);
        }




        public async Task<Result> Create(CreateArticulo createArticulo)
		{
			var content = new StringContent(JsonSerializer.Serialize(createArticulo), Encoding.UTF8, "application/json");
			var result = await _client.PostAsync
				(_endpoints.Where(w => w.Name.Equals("Articulos", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

			return result.StatusCode == System.Net.HttpStatusCode.Created
				? Result.Success()
				: Result.Failure(ArticuloErrors.NotCreated());
		}

	
	}
}
