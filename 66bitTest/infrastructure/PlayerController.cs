using _66bitTest.app.entities;
using _66bitTest.app.services;
using _66bitTest.app.services.interfaces;
using _66bitTest.domain;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace _66bitTest.infrastructure
{
    [ApiController]
    [Route("/[controller]")]
    public partial class PlayerController : Controller
    {
        private IPlayerService _playerService;
        
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            try
            {
                return new OkObjectResult(_playerService.GetAll());
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult Get(int id)
        {
            try
            {
                return new OkObjectResult(_playerService.Get(id));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Add(PlayerDTO dto)
        {
            try
            {
                _playerService.Add(dto.name,dto.surname,dto.gender,dto.birthday,dto.teamName,dto.country);
                return new OkResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
        [HttpPut]
        [Route("[action]")]
        public ActionResult Update(FullPlayerDTO dto)
        {
            try
            {
                _playerService.Update(dto.id,dto.name, dto.surname, dto.gender, dto.birthday, dto.teamName, dto.country);
                return new OkResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetTeamsNames()
        {
            try
            {
                return new OkObjectResult(_playerService.GetTeamsNames());
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
        public record FullPlayerDTO(long id,string name,
             string surname,
             Gender gender,
             string birthday,
             string teamName,
             Country country){}
        public record PlayerDTO(
             string name,
             string surname,
             Gender gender,
             string birthday,
             string teamName,
             Country country) { }
    }
}
