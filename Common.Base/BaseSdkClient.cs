using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Common.Base
{
    public class BaseSdkClient
    {
        private readonly HttpClient _httpClient;

        protected string BaseUrl
        {
            set
            {
                _baseUrl = value;
                if (_baseUrl.EndsWith("/"))
                {
                    _baseUrl = _baseUrl[0..^1];
                }
            }
        }
        private string _baseUrl;

        public BaseSdkClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected virtual async Task<T> SendJsonRequest<T>(HttpMethod method, string url, object payload)
        {
            try
            {
                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(method, BuildUrl(url))
                {
                    Content = content
                };

                HttpResponseMessage response = await _httpClient.SendAsync(request);
                return await ConvertJsonResult<T>(response);
            }

            catch (Exception ex)
            {
                return default;
            }

        }

        protected virtual async Task<T> SendPlainRequest<T>(HttpMethod method, string url)
        {

            try
            {
                var request = new HttpRequestMessage(method, BuildUrl(url));
                HttpResponseMessage response = await _httpClient.SendAsync(request);
                return await ConvertJsonResult<T>(response);
            }
            catch (Exception ex)
            {
                return default;
            }

        }

        protected virtual async Task<T> ConvertJsonResult<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception("Request unsuccessful! Status Code 500. ResponseText: " + await response.Content.ReadAsStringAsync());
                }
                else
                {
                    throw new Exception($"Request unsuccessful! Status Code: {response.StatusCode}");
                }
            }

            var responseText = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(responseText);
            if (result == null)
            {
                throw new Exception("Received invalid response from service");
            }

            return result;
        }

        private string BuildUrl(string url)
        {
            if (string.IsNullOrEmpty(_baseUrl))
            {
                throw new ArgumentException("BaseUrl is not set!");
            }
            return url.StartsWith("/") ? $"{_baseUrl}{url}" : $"{_baseUrl}/{url}";
        }
    }
}