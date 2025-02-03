namespace ESPWWebAPI.Utility
{
	using System;
	using System.Net.Http;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class HttpService
	{
		// Method to send a POST request
		public async Task<string> SendPostRequestAsync(string url, Dictionary<string, string> parameters)
		{
			using (HttpClient client = new HttpClient())
			{
				// Convert the parameters to FormUrlEncodedContent
				var content = new FormUrlEncodedContent(parameters);

				try
				{
					// Send POST request
					HttpResponseMessage response = await client.PostAsync(url, content);

					// Ensure successful response
					response.EnsureSuccessStatusCode();

					// Read and return the response content
					string responseContent = await response.Content.ReadAsStringAsync();
					return responseContent;
				}
				catch (Exception ex)
				{
					// Handle any exceptions and return the error message
					return $"Error: {ex.Message}";
				}
			}
		}
	}

}
