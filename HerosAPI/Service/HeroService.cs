using HerosAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerosAPI.Service
{
    public class HeroService
    {
        private readonly IMongoCollection<Hero> _heros;

        public HeroService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("HerosGalleryDB"));
            var database = client.GetDatabase("HerosGalleryDB");
            _heros = database.GetCollection<Hero>("Heros");
        }

        public List<Hero> Get()
        {
            return _heros.Find(hero => true).ToList();
        }

        public Hero Get(string id)
        {
            return _heros.Find<Hero>(hero => hero.Id == id).FirstOrDefault();
        }

        public Hero Create(Hero hero)
        {
            _heros.InsertOne(hero);
            return hero;
        }

        public void Update(string id, Hero heroIn)
        {
            _heros.ReplaceOne(hero => hero.Id == id, heroIn);
        }

        public void Remove(Hero heroIn)
        {
            _heros.DeleteOne(hero => hero.Id == heroIn.Id);
        }

        public void Remove(string id)
        {
            _heros.DeleteOne(hero => hero.Id == id);
        }
    }
}
