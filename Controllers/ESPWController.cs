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
			//passing parameters in query string
			//Change URL with ESP-32 
			//PASSING VALUES VIA QUERY-STRING
			string apiUrl = "http://192.168.4.1/get?input1=" + clientInfo.doses.ToString()  + 
				"&input2="+ clientInfo.mass.ToString() + 
				"&input3="+ clientInfo.time.ToString() + "&input4=1";

			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(apiUrl);

				if (response.IsSuccessStatusCode)
				{
					string responseContent = await response.Content.ReadAsStringAsync();
				}

			}
		}

		
	}





}