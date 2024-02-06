using System.Collections.Generic;
using System.Net;
using System.Text;
using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.Functions;

public class CachingFunction
{
    private const string SESSIONIZE_DATA_URL = "https://sessionize.com/api/v2/44is5yr6/view/All";
    private readonly ILogger _logger;

    public CachingFunction(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<CachingFunction>();
    }

    [Function(nameof(UpdateCacheFunction))]
    public async Task<HttpResponseData> UpdateCacheFunction([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var connectionString = Environment.GetEnvironmentVariable("SA_AZDEVCOMWEB_KEY");

        await UploadJsonToBlobStorage(connectionString);

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        return response;
    }

    // azure function to return json from an Azure Blob Storage container
    [Function(nameof(GetCacheFunction))]
    public async Task<HttpResponseData> GetCacheFunction([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
    {
        // get azure function environment variable 
        var connectionString = Environment.GetEnvironmentVariable("SA_AZDEVCOMWEB_KEY");
        
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        // download blob text from azure storage
        var blob = new BlobClient(connectionString, "cache", "sessionize-all.json");
        var text = (await blob.DownloadContentAsync()).Value.Content.ToString();
        
        response.WriteString(text);
        return response;
    }



    // method to download json file from url with httpclient and upload as text to Azure BLOB Storage
    private static async Task UploadJsonToBlobStorage(string connectionString) 
    {
        var httpClient = new HttpClient();
        var json = await httpClient.GetStringAsync(SESSIONIZE_DATA_URL);
        var blobServiceClient = new BlobServiceClient(connectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient("cache");
        await containerClient.CreateIfNotExistsAsync();
        var blobClient = containerClient.GetBlobClient("sessionize-all.json");
        await blobClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes(json)));
    }


}
