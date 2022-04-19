using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Api.Models;
using MediatR;


namespace Api.Features
{
    public class GetOrdersQuery : IRequest<List<Content>>
    {
        public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<Content>>
        {
            private readonly string username = "2p2gqTsNrXboBVnA8ZF7";
            private readonly string password = "CCcq8C1ex5rLiN5f0a3g";
            private readonly string supplierId = "121754";
            private readonly string executerMail = "ertunckoybasi@gmail.com";
            private readonly string urlApi = "https://stageapi.trendyol.com/mealgw/suppliers/{supplierId}/packages";
            private List<Content> Orders { get; set; }
            private readonly IHttpClientFactory _clientFactory;
            public GetOrdersQueryHandler(IHttpClientFactory clientFactory)
            {
                _clientFactory = clientFactory;
            }
            public async Task<List<Content>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
            {
                string urlApiAddress = urlApi.Replace("{supplierId}", supplierId);
                string authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToString(username + ":" + password)));
                var requestApi = new HttpRequestMessage(HttpMethod.Get, urlApiAddress);
                requestApi.Headers.Add("Authorization", $"Basic {authString}");
                requestApi.Headers.Add("x-agentname", $"SentezYazilim");
                requestApi.Headers.Add("x-executor-user", executerMail);

                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(requestApi);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var tyOrders = await JsonSerializer.DeserializeAsync<TrendyolYemekOrder>(responseStream);
                    Orders = tyOrders.content;
                }
                return Orders;
            }

        }
    }
}
