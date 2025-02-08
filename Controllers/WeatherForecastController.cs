using Microsoft.AspNetCore.Mvc;
using ESPWWebAPI.DAL;
using ESPWWebAPI.Utility;
namespace ESPWWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ESPWController : ControllerBase
	{




		private readonly ILogger<ESPWController> _logger;

		public ESPWController(ILogger<ESPWController> logger)
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

			string url = "http://192.168.4.1";

			// Parameters to include in the POST request
			var parameters = new Dictionary<string, string>
	 	{
	 		{ "input1", clientInfo.doses.ToString() },
	 		{ "input2", clientInfo.mass.ToString() },
	 		{ "input3", clientInfo.time.ToString()},
	 		{ "input4", "4"}
	 	};


			// 		// Create an instance of the HttpService class
			var httpService = new HttpService();

			// 		// Call the SendPostRequestAsync method and get the response
			string response = await httpService.SendPostRequestAsync(url, parameters);
			Console.WriteLine("TEsting: ");

			// 		// Print the response (you can also handle it differently)
			Console.WriteLine($"Response: {response}");
			//return Ok(result);

		}



		[HttpGet]
	 	public async void GetESPW(string input1)
	 	{

			string url = "http://192.168.4.1";

	 		// Parameters to include in the POST request
	 		var parameters = new Dictionary<string, string>
	 	{
	 		{ "input1", input1 },
	 		{ "input2", "1" },
	 		{ "input3", "2"},
	 		{ "input4", "4"}
	 	};

	// 		// Create an instance of the HttpService class
	 		var httpService = new HttpService();

	// 		// Call the SendPostRequestAsync method and get the response
	 		string response = await httpService.SendPostRequestAsync(url, parameters);
	 		Console.WriteLine("TEsting: ");

	// 		// Print the response (you can also handle it differently)
	 		Console.WriteLine($"Response: {response}");
 	     	//return Ok(result);

	 	}

		// [HttpPost]
		// public async void Post(ClientInfo clientInfo)
		// {
		// 	DAL.DAL objDAL = new DAL.DAL();
		// 	var result = objDAL.OnPost(clientInfo);
			
			

		// }



	}





}