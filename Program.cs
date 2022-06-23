
// See https://aka.ms/new-console-template for more information

using System.Threading;
using Newtonsoft.Json;
using RestSharp;

Console.WriteLine("Hello, World!");

var baseUrl = "https://api.codat.io";
var authHeaderValue = "Basic WDBJMnVIamFGMUJjYWg4VVlqbHB5MTZOT3B6Z2EwNTlSYjRITlRnTQ==";

//Create a REST client using codat's API basr Url
var codatApiClient = new RestClient(baseUrl);
codatApiClient.AddDefaultHeader("Authorization", authHeaderValue);

// Create a GET requestS
var getCompaniesRequest = new RestRequest("companies", Method.Get);
getCompaniesRequest.AddQueryParameter("page","1");

//Execute the request
var getCompaniesResponse = codatApiClient.Execute(getCompaniesRequest);
//var getCompaniesResponse = await codatApiClient.GetAsync(getCompaniesRequest, cancellationToken);

//print the response status code and content
Console.WriteLine(getCompaniesResponse.StatusCode.ToString());

var parsedJson = JsonConvert.DeserializeObject(getCompaniesResponse.Content);
Console.WriteLine(JsonConvert.SerializeObject(parsedJson, Formatting.Indented));


