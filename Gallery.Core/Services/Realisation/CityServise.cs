using Gallery.Core.Models;
using Gallery.Core.Rest.Intarface;
using Gallery.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Core.Services.Realisation
{
    public class CityServise : ICityServise
    {
        private readonly IRestClient _restClient;

        public CityServise(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<PagedResult<City>> GetCitiesAsync(string url = null)
        {
            return string.IsNullOrEmpty(url)
                ? _restClient.MakeApiCall<PagedResult<City>>($"{Constants.BaseUrl}/view/", HttpMethod.Get)
                : _restClient.MakeApiCall<PagedResult<City>>(url, HttpMethod.Get);
        }

        private PagedResult<City> GetMockedCity()
        {
            return new PagedResult<City>()
            {
                Count = 3,
                Next = string.Empty,
                Previous = string.Empty,
                Result = new List<City>
                {
                    new City
                    (
                        "Germany",
                        "Some information about it",
                        "Germany.jpg"
                    ),
                    new City
                    (
                        "Japan",
                        "Some information about it",
                        "Japan.jpg"
                    ),
                    new City
                    (
                        "New York",
                        "Some information about it",
                        "NewYouk.jpg"
                    )
                }
            };
        }
    }
}
