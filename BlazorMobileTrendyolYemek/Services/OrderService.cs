using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorMobileTrendyolYemek.Models;

namespace BlazorMobileTrendyolYemek.Services
{
    public class OrderService : IOrderService
    {
        public HttpClient _client;
        public IHttpClientFactory _clientFactory;
        private readonly string urlGetApi = "https://stageapi.trendyol.com/mealgw/suppliers/{supplierId}/packages";
        private readonly string urlGetApiLocal = "https://10.0.2.2:5001/Home/GetAll";
        private readonly string username = "1YgIXshY2al5iZg9GIJ2";
        private readonly string password = "t28HZREher7c6wzJukqi";
        private readonly string supplierId = "121754";
        private readonly string executerMail = "ertunckoybasi@gmail.com";

        private List<Content> Orders { get; set; }
        public OrderService(HttpClient httpClient, IHttpClientFactory clientFactory)
        {
            _client = httpClient;
            _clientFactory = clientFactory;
        }

        public async Task<List<Content>> GetOrders()
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("HttpClientWithSSLUntrusted");
                var response = await httpClient.GetAsync(urlGetApiLocal);

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var tyOrders = await JsonSerializer.DeserializeAsync<List<Content>>(responseStream);
                        Orders = tyOrders;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return Orders;
        }

        public async Task<List<Content>> GetOrdersDirectly()
        {
            try
            {
                string urlApiAddress = urlGetApi.Replace("{supplierId}", supplierId);
                string authString = Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToString(username + ":" + password)));
                var requestApi = new HttpRequestMessage(HttpMethod.Get, urlApiAddress);
                requestApi.Headers.Add("Authorization", $"Basic {authString}");
                requestApi.Headers.Add("x-agentname", $"SentezYazilim");
                requestApi.Headers.Add("x-executor-user", executerMail);

                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(requestApi);

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var tyOrders = await JsonSerializer.DeserializeAsync<TrendyolYemekOrder>(responseStream);
                        Orders = tyOrders.content;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return Orders;

        }
    }
}

