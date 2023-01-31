using Domain_Layer.Models;
using Microsoft.AspNetCore.Localization;
using Newtonsoft.Json;

using System.Net.Http.Headers;
using System.Text;

namespace Presentations.Common
{
    public class HttpHelper<T> where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _sBaseUrl = string.Empty;
        private static string _sMigrationBaseUrl = string.Empty;
        private static string _sAdminBaseUrl = string.Empty;
        private static string token = string.Empty;
        private static string language = string.Empty;
        public HttpHelper(IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _sBaseUrl = _configuration.GetSection("APIBaseUrl").Value;
            //token = _httpContextAccessor.HttpContext.Session.GetString("token");
            var requestCulture = _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
            language = requestCulture?.RequestCulture.UICulture.Name == "ar" ? "ar" : "en-US";
        }
        public async Task<TOut> PostRequest<TIn, TOut>(string uri, TIn content)
        {
            try
            {
                string responseBody = String.Empty;
                using (var client = new HttpClient())
                {
                    if (uri == "Migration/RevertImport")
                    {
                        uri = _sMigrationBaseUrl + uri;
                    }
                    else
                    {
                        uri = _sBaseUrl + uri;
                    }
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(_sAdminBaseUrl))
                    {
                        client.DefaultRequestHeaders.Add("Origin", _sAdminBaseUrl);
                    }
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    }
                    if (!string.IsNullOrEmpty(language))
                    {
                        client.DefaultRequestHeaders.Add("Accept-Language", language);
                    }
                    var serialized = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.PostAsync(uri, serialized))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            response.EnsureSuccessStatusCode();
                        }
                        responseBody = await response.Content.ReadAsStringAsync();
                    }
                }
                if (!string.IsNullOrEmpty(responseBody))
                    return JsonConvert.DeserializeObject<TOut>(responseBody);
                else
                    return default(TOut);
            }
            catch (Exception ex)
            {
                return default(TOut);
            }
        }
        public async Task<T> GetRequest<T>(string uri)
        {
            try
            {
                string responseBody = String.Empty;
                using (var client = new HttpClient())
                {
                    uri = _sBaseUrl + uri;
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                    //if (!string.IsNullOrEmpty(_sAdminBaseUrl))
                    //{
                    //    client.DefaultRequestHeaders.Add("Origin", _sAdminBaseUrl);
                    //}
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    }
                    if (!string.IsNullOrEmpty(language))
                    {
                        client.DefaultRequestHeaders.Add("Accept-Language", language);
                    }
                    using (HttpResponseMessage response = await client.GetAsync(uri))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            response.EnsureSuccessStatusCode();
                        }
                        responseBody = await response.Content.ReadAsStringAsync();
                    }
                }
                if (!string.IsNullOrEmpty(responseBody))
                    return JsonConvert.DeserializeObject<T>(responseBody);
                else
                    return default(T);
            }
            catch (Exception ex)
            {

                return default(T);
            }
        }
    }
}
