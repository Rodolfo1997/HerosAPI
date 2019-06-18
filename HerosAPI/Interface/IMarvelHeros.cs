using HerosAPI.Models;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerosAPI.Interface
{
    public interface IMarvelHeros
    {
        [Get("")]
        Task<List<dynamic>> GetAll();

        [Get("/health")]
        Task<Health> GetHealth();

        [Post("")]
        Task<Hero> AddHero([Body]Hero produto);
    }
}
