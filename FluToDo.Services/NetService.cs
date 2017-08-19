using Newtonsoft.Json;
using FluToDo.Models.Entities;
using FluToDo.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.Services
{
    public class NetService : INetService
    {
        #region Fields

        private HttpClient client;

        private int port;
        private string restServerUrl;
        private string apiRoute;
        #endregion Fields

        #region Properties

        public string ServerUrl { get { return restServerUrl; } set { restServerUrl = value; } }
        public int Port { get { return port; } set { port = value; } }
        public string ApiRoute { get { return apiRoute; } set { apiRoute = value; } }
        public string RestServiceUrl { get { return $"{ServerUrl}:{Port}{ApiRoute}"; } }

        #endregion Properties

        #region Constructor

        public NetService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        #endregion Constructor

        #region INetService

        public async Task<TodoItem> Create(TodoItem item)
        {
            var uri = $"{RestServiceUrl}";
            var json = JsonConvert.SerializeObject(item);
            var bodyContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TodoItem>(content);
            }

            return null;
        }

        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                return false;

            var uri = $"{RestServiceUrl}{id}";
            var response = await client.DeleteAsync(uri);

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public Task<bool> Delete(TodoItem item)
        {
            return Delete(item.Key);
        }

        public Task<List<TodoItem>> GetAll()
        {
            return GetRequest<List<TodoItem>>();
        }

        public async Task<TodoItem> GetById(string id)
        {
            if (!string.IsNullOrEmpty(id))
                return await GetRequest<TodoItem>(id);

            throw new ArgumentException("id must have a value");
        }

        public async Task<bool> Update(TodoItem item, string id = null)
        {
            var fid = string.IsNullOrEmpty(id) ? string.Empty : id;
            var uri = $"{RestServiceUrl}{fid}";
            var json = JsonConvert.SerializeObject(item);
            var bodyContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(uri, bodyContent);

            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        #endregion INetService

        #region Methods

        private async Task<T> GetRequest<T>(string uriParameter = "")
        {
            string url = $"{RestServiceUrl}{uriParameter}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var bodyContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(bodyContent);
            }

            throw new Exception(Enum.GetName(typeof(HttpStatusCode), response.StatusCode));
        }

        #endregion Methods
    }
}
