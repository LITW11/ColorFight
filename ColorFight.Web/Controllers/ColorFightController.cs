using ColorFight.Data;
using ColorFight.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ColorFight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorFightController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly IHubContext<ColorFightHub> _hubContext;

        public ColorFightController(IConfiguration configuration, IHubContext<ColorFightHub> hubContext)
        {
            _hubContext = hubContext;
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpPost("IncrementColor")]
        public void IncrementColors(IncrementViewModel viewModel)
        {
            var repo = new ColorStatRepo(_connectionString);
            repo.IncrementColorStat(viewModel.Color);
            _hubContext.Clients.All.SendAsync("ColorStatsUpdate", repo.GetStats()).Wait();
        }

        [HttpGet("GetColorStats")]
        public List<ColorStat> GetColorStats()
        {
            var repo = new ColorStatRepo(_connectionString);
            return repo.GetStats();
        }
    }
}
