
using AutoMapper;
using Domain.Comentarios;
using Domain.Configuration;
using Domain.Likes;
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
	public sealed class LikeClient : ILikeClient
	{
		private readonly List<EndpointConfiguration> _endpoints;
		private readonly HttpClient _client;
		private readonly IMapper _mapper;

		public LikeClient(IOptions<List<EndpointConfiguration>> options, HttpClient client, IMapper mapper)
		{
			_endpoints = options.Value.Where
				(w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
			_client = client;
			_mapper = mapper;
		}

		public async Task<Result> Create(CreateLike createLike)
		{
			var content = new StringContent(JsonSerializer.Serialize(createLike), Encoding.UTF8, "application/json");
			var result = await _client.PostAsync
				(_endpoints.Where(w => w.Name.Equals("Likes", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

			return result.StatusCode == System.Net.HttpStatusCode.Created
				? Result.Success()
				: Result.Failure(ComentarioErrors.NotCreated());
		}

		public async Task<List<LikeDTO>> List()
		{
			var content = await _client.GetStringAsync
				(_endpoints.Where(w => w.Name.Equals("Likes", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
			var likes = JsonSerializer.Deserialize<List<Like>>(content);

			return _mapper.Map<List<LikeDTO>>(likes);
		}
	}
}
