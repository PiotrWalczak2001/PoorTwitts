using Microsoft.AspNetCore.Mvc;
using PoorTwittsProject.Domain.Dtos;
using PoorTwittsProject.Domain.Entities;
using PoorTwittsProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoorTwittsProject.Controllers
{
    [ApiController]
    [Route("twitts")]
    public class TwittsController : ControllerBase
    {
        private readonly ITwittRepository _twittRepository;
        public TwittsController(ITwittRepository twittRepository)
        {
            _twittRepository = twittRepository;
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
               return Ok(twittDto); 
            }
            return NotFound();
        }

    }
}
