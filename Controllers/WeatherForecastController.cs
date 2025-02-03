using Microsoft.AspNetCore.Mvc;
using ESPWWebAPI.DAL;
using ESPWWebAPI.Utility;
namespace ESPWWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{




		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IActionResult Get()
		{
			DAL.DAL objDAL = new DAL.DAL();
			var result = objDAL.OnGet();			
			return Ok(result);
		}


		[HttpPost]
		public async void Post(ClientInfo clientInfo)
		{
			DAL.DAL objDAL = new DAL.DAL();
			var result = objDAL.OnPost(clientInfo);
			
			string url = "http://192.168.4.1";

			// Parameters to include in the POST request
			var parameters = new Dictionary<string, string>
		{
			{ "PARAM_INPUT_1", "10" },
			{ "PARAM_INPUT_2", "30" },
			{ "PARAM_INPUT_3", "40" },
			{ "PARAM_INPUT_4", "40" }
		};

			// Create an instance of the HttpService class
			var httpService = new HttpService();

			// Call the SendPostRequestAsync method and get the response
			string response = await httpService.SendPostRequestAsync(url, parameters);

			// Print the response (you can also handle it differently)
			Console.WriteLine($"Response: {response}");


		}



	}





}