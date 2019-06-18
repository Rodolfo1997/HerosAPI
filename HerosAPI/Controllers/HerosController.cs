using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerosAPI.Interface;
using HerosAPI.Models;
using HerosAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;

namespace HerosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerosController : ControllerBase
    {
        private readonly HeroService _heroService;

        public HerosController(HeroService heroService)
        {
            _heroService = heroService;
        }

        /// <summary>
        /// Get All Heros.
        /// </summary>
        [HttpGet]
        public ActionResult<List<Hero>> Get()
        {
            return _heroService.Get();
        }

        /// <summary>
        /// Add Hero.
        /// </summary>
        [HttpPost]
        public ActionResult<Hero> Create(Hero hero)
        {
            return _heroService.Create(hero);
        }

        /// <summary>
        /// Edit Hero.
        /// </summary>
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Hero heroIn)
        {
            //throw new Exception();

            var hero = _heroService.Get(id);

            if (hero == null)
            {
                return NotFound();
            }

            _heroService.Update(id, heroIn);

            return NoContent();
        }

        /// <summary>
        /// Delete Hero.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var hero = _heroService.Get(id);

            if (hero == null)
            {
                return NotFound();
            }

            _heroService.Remove(hero.Id);

            return NoContent();
        }
    }
}