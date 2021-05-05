using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PoorTwittsProject.Domain.Dtos;
using PoorTwittsProject.Domain.Entities;
using PoorTwittsProject.Domain.Interfaces;
using PoorTwittsProject.Hubs;
using System.Linq;

namespace PoorTwittsProject.Controllers
{
    [ApiController]
    [Route("twitts")]
    public class TwittsController : ControllerBase
    {
        private readonly ITwittRepository _twittRepository;
        private readonly IHubContext<TwittHubClient, ITwittHubClient> _twittHub;
        public TwittsController(ITwittRepository twittRepository, IHubContext<TwittHubClient, ITwittHubClient> twittHub)
        {
            _twittRepository = twittRepository;
            _twittHub = twittHub;
        }

        [HttpGet]
        [Route("getTwitts")]
        public IActionResult GetTwitts()
        {
            var twitts = _twittRepository.GetAllTwitts();
            var twittDto = twitts.Select(x => new TwittDto
            {
                Content = x.Content,
                Author = x.AuthorUserName,
            });

            return Ok(twittDto);
        }



        [HttpPost]
        [Route("sendTwitt")]
        public IActionResult SendTwitt([FromBody] TwittDto twittDto)
        {
            var twittEntity = new TwittEntity
            {
                AuthorUserName = twittDto.Author,
                Content = twittDto.Content,
                
            };

            var result = _twittRepository.AddTwitt(twittEntity);
            if(result)
            {
                _twittHub.Clients.All.NewTwitt().Wait();
                return Ok(twittDto); 
            }
            return NotFound();
        }

    }
}
