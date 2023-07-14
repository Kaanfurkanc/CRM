using AdminPortalApi.ClientServices.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace AdminPortalApi.ClientServices
{
    public class SchoolManagementClientService<T> : IClientService<T> where T : class
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClient;

        public SchoolManagementClientService(IConfiguration configuration, IHttpClientFactory httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async  Task<HttpResponseMessage> requestProcessAsync(HttpContext httpContext, string endpoint, T entity = null)
        {
            string? baseUrl = _configuration.GetSection("Urls")["BaseUrlManagement"];
            var requestType = httpContext.Request.Method;

            switch (requestType)
            { 
                
                case "GET":
                    var client =  _httpClient.CreateClient();
                    var response = await client.GetAsync(baseUrl + endpoint);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Could not found any data !");
                    }
                    return response;

                case "POST":
                    var contentPost = JsonContent.Create(entity);
                    var clientPost = _httpClient.CreateClient();
                    var messagePost = await clientPost.PostAsync(baseUrl + endpoint, contentPost);
                    if (!messagePost.IsSuccessStatusCode) 
                    {
                        throw new Exception("Bad Request! Could not added !");
                    }
                    return messagePost;

                case "PUT":
                    var contentPut = JsonContent.Create(entity);
                    var clientPut = _httpClient.CreateClient();
                    var messagePut = await clientPut.PutAsync(baseUrl + endpoint, contentPut);
                    if (!messagePut.IsSuccessStatusCode)
                    {
                        throw new Exception("Bad request ! Could not updated !");
                    }
                    return messagePut;

                case "DELETE":
                    var clientDelete = _httpClient.CreateClient(baseUrl);
                    var messageDelete = await clientDelete.DeleteAsync(baseUrl + endpoint);
                    if (!messageDelete.IsSuccessStatusCode)
                    {
                        throw new Exception("Could not found an object by input id !");
                    }
                    return messageDelete;

                default:
                    break;
            }
            return new HttpResponseMessage();
        }
    }
}
