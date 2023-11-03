//namespace HJTB.Server.Infrastructure
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Infrastructure
{
	[ApiController]
	[Route("[controller]")]
	[Produces(MediaTypeNames.Application.Json)]
	public class BaseApiController : ControllerBase
	{
		public BaseApiController() : base()
		{
		}
	}
}
