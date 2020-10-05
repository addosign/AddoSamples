using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AddoSamples.Http
{
    public class Post 
    {
        public async Task<byte[]> Execute(string url, string body)
		{
			using (var httpClient = new HttpClient())
			{
				httpClient.BaseAddress = new Uri(url);
				httpClient.DefaultRequestHeaders.Accept.Clear();
                var httpContent = new StringContent(body, Encoding.UTF8, "application/json");
				var response = await httpClient.PostAsync(url, httpContent);
				if (!response.IsSuccessStatusCode)
				{
					throw new Exception($"Error while posting to {url}: {response.StatusCode} {response.ReasonPhrase}");
				}

				return await response.Content.ReadAsByteArrayAsync();
			}
		}
    }
}