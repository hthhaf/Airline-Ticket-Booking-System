using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using B2C.ApiHelper.Model;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace B2C.ApiHelper
{
    public static class CallApi
    {

        /*public static async Task<SearchResponse> SearchAsync(string airlines,string departure, string arrival, string departureDate, string arrivalDate, int passenger)
        {
            var token = await ApiAuthenticateAsync();
            if (!string.IsNullOrEmpty(token))
                return await ApiSearchAsync(token, airlines, departure, arrival, departureDate, arrivalDate, passenger);

            return null;
        }

        public static async Task<CreateResponse> CreateAsync(CreateRequest request)
        {
            var token = await ApiAuthenticateAsync();
            if (!string.IsNullOrEmpty(token))
                return await ApiCreateAsync(token, request);

            return null;
        }

        private static async Task<string> ApiAuthenticateAsync()
        {
            string token = "";
            var url = "https://api.airlines.flyone.com.vn/token";

            var keyPair = new List<KeyValuePair<string, string>>();
            keyPair.Add(new KeyValuePair<string, string>("username", "FLYONEAPIUAT"));
            keyPair.Add(new KeyValuePair<string, string>("password", "dc03357328324b24b1580cba59508566"));
            keyPair.Add(new KeyValuePair<string, string>("grant_type", "password"));
            keyPair.Add(new KeyValuePair<string, string>("client_id", "api"));

            try
            {
                using (var client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip }) { Timeout = TimeSpan.FromMinutes(30) })
                {
                    var request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(url),
                        Method = HttpMethod.Post
                    };

                    request.Headers.Clear();
                    request.Content = new FormUrlEncodedContent(keyPair);

                    HttpResponseMessage response = client.SendAsync(request).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        return token;
                    }

                    string data = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(data))
                    {
                        var tokenRespones = JsonConvert.DeserializeObject<AuthenticateResponse>(data);
                        if (tokenRespones != null)
                            token = tokenRespones.access_token;
                    }
                }

                return token;
            }
            catch (Exception)
            {
                return token;
            }
        }

        private static async Task<SearchResponse> ApiSearch1Async(string token, string departure, string arrival, string departureDate, string arrivalDate, int passenger)
        {
            SearchResponse searchResponse = null;
            var url = "https://api.airlines.flyone.com.vn/api/Flights/Search";
            var jsonData = $"{{\r\n    \"SearchType\": \"ROUNDTRIP\",\r\n    \"AirlineSystem\": \"BAMBOO\",\r\n    \"NumberOfAdult\": {passenger},\r\n    \"NumberOfChildren\": 0,\r\n    \"NumberOfInfant\": 0,\r\n    \"IncludeConnectingFlight\": false,\r\n    \"Routes\": [\r\n        {{\r\n            \"RouteNo\": 1,\r\n            \"DepartureCode\": \"{departure}\",\r\n            \"ArrivalCode\": \"{arrival}\",\r\n            \"DepartureDate\": \"{departureDate}\",\r\n            \"Flights\": null\r\n        }},\r\n        {{\r\n            \"RouteNo\": 2,\r\n            \"DepartureCode\": \"{arrival}\",\r\n            \"ArrivalCode\": \"{departure}\",\r\n            \"DepartureDate\": \"{arrivalDate}\",\r\n            \"Flights\": null\r\n        }}\r\n    ]\r\n}}";

            try
            {
                using (var client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip }) { Timeout = TimeSpan.FromMinutes(30) })
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(url),
                        Method = HttpMethod.Post
                    };

                    request.Headers.Clear();
                    request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.SendAsync(request).Result;
                    if (!response.IsSuccessStatusCode)
                    {

                    }

                    string data = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(data))
                    {
                        var respones = JsonConvert.DeserializeObject<SearchResponse>(data);
                        if (respones != null)
                            searchResponse = respones;
                    }
                }

                return searchResponse;
            }
            catch (Exception)
            {
                return searchResponse;
            }
        }

        private static async Task<SearchResponse> ApiSearchAsync(string departure, string arrival, string departureDate, string arrivalDate, int passenger)
        {
            SearchResponse searchResponse = null;
            try
            {

                //var data = await _dbContext.Flights.Where(x => x.Id == model.Id).FirstOrDefaultAsync();



                return searchResponse;
            }
            catch (Exception)
            {
                return searchResponse;
            }
        }

        private static async Task<CreateResponse> ApiCreateAsync(string token, CreateRequest createData)
        {
            createData.PromotionCode = "";

            CreateResponse searchResponse = null;
            var url = "https://api.airlines.flyone.com.vn/api/BookingManage/CreateBooking";
            var jsonData = JsonConvert.SerializeObject(createData);

            try
            {
                using (var client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip }) { Timeout = TimeSpan.FromMinutes(30) })
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var request = new HttpRequestMessage()
                    {
                        RequestUri = new Uri(url),
                        Method = HttpMethod.Post
                    };

                    request.Headers.Clear();
                    request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.SendAsync(request).Result;
                    if (!response.IsSuccessStatusCode)
                    {

                    }

                    string data = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(data))
                    {
                        var respones = JsonConvert.DeserializeObject<CreateResponse>(data);
                        if (respones != null)
                            searchResponse = respones;
                    }
                }

                return searchResponse;
            }
            catch (Exception)
            {
                return searchResponse;
            }
        }*/
    }
}
