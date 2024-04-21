
using AutoMapper;
using Domain.Comentarios;
using Domain.Configuration;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Comentarios
{
	public sealed class ComentarioClient : IComentarioClient
	{
		private readonly List<EndpointConfiguration> _endpoints;
		private readonly HttpClient _client;
		private readonly IMapper _mapper;

		public ComentarioClient(IOptions<List<EndpointConfiguration>> options, HttpClient client, IMapper mapper)
		{
			_endpoints = options.Value.Where
				(w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
			_client = client;
			_mapper = mapper;
		}

		public async Task<Result> Create(CreateComentario createComentario)
		{
			var content = new StringContent(JsonSerializer.Serialize(createComentario), Encoding.UTF8, "application/json");
			var result = await _client.PostAsync
				(_endpoints.Where(w => w.Name.Equals("Comentarios", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

			return result.StatusCode == System.Net.HttpStatusCode.Created
				? Result.Success()
				: Result.Failure(ComentarioErrors.NotCreated());
		}

		public async Task<List<ComentarioDTO>> List()
		{
			var content = await _client.GetStringAsync
				(_endpoints.Where(w => w.Name.Equals("Comentarios", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
			var Comentarios = JsonSerializer.Deserialize<List<Comentario>>(content);

			return _mapper.Map<List<ComentarioDTO>>(Comentarios);
		}
	}
}
