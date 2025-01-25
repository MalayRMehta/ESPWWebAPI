using Microsoft.AspNetCore.Mvc;
using ESPWWebAPI.DAL;
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
	}
}