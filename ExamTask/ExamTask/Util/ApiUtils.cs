using Aquality.Selenium.Browsers;
using ExamTask.Models;
using RestSharp;

namespace ExamTask.Util
{
    public static class ApiUtils
    {
        private static RestClient Client;

        public static void SetClient(string Url)
        {
            AqualityServices.Logger.Info("Setting client");
            Client = new RestClient(Url);
        }


        public static (T, string) GetRequest<T>(string RequestUrl)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' GET request");
            var request = new RestRequest(RequestUrl);
            var response = Client.Get(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' GET respond");
            return (ParseJson.ModelFromJson<T>(response.Content), response.StatusCode.ToString());
        }

        public static (string, string) GetRequest(string RequestUrl)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' GET request");
            var request = new RestRequest(RequestUrl);
            var response = Client.Get(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' GET respond");
            return (response.Content, response.StatusCode.ToString());
        }

        public static (T, string) PostRequest<T>(string RequestUrl, object Json)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' POST request");
            var request = new RestRequest(RequestUrl).AddJsonBody(Json);
            var response = Client.Post(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' POST respond");
            return (ParseJson.ModelFromJson<T>(response.Content), response.StatusCode.ToString());
        }

        public static (string, string) PostRequest(string RequestUrl, object Json)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' POST request");
            var request = new RestRequest(RequestUrl).AddJsonBody(Json);
            var response = Client.Post(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' POST respond");
            return (response.Content, response.StatusCode.ToString());
        }

        public static (T, string) PostRequest<T>(string RequestUrl)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' POST request");
            var request = new RestRequest(RequestUrl);
            var response = Client.Post(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' POST respond");
            return (ParseJson.ModelFromJson<T>(response.Content), response.StatusCode.ToString());
        }

        public static (string, string) PostRequest(string RequestUrl)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' POST request");
            var request = new RestRequest(RequestUrl);
            var response = Client.Post(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' POST respond");
            return (response.Content, response.StatusCode.ToString());
        }

        public static (T, string) PostRequest<T>(string RequestUrl, IEnumerable<FileToJsonModel> files)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' POST request");
            var request = new RestRequest(RequestUrl);
            foreach(var file in files)
            {
                request.AddFile(file.parameterName, file.filePath, file.contentType);
            }
            RestClient TempClient = new RestClient();
            var response = TempClient.Post(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' POST respond");
            return (ParseJson.ModelFromJson<T>(response.Content), response.StatusCode.ToString());
        }

        public static (string, string) PostRequest(string RequestUrl, IEnumerable<FileToJsonModel> files)
        {
            AqualityServices.Logger.Info($"Creating '{RequestUrl}' POST request");
            var request = new RestRequest(RequestUrl);
            foreach (var file in files)
            {
                request.AddFile(file.parameterName, file.filePath, file.contentType);
            }
            RestClient TempClient = new RestClient();
            var response = TempClient.Post(request);
            AqualityServices.Logger.Info($"Returning '{RequestUrl}' POST respond");
            return (response.Content, response.StatusCode.ToString());
        }
    }
}
