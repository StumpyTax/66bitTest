using _66bitTest.app.entities;
using _66bitTest.app.services.interfaces;
using _66bitTest.domain;
using Microsoft.EntityFrameworkCore;

namespace _66bitTest.app.services
{
    public class PlayerService:IPlayerService
    {
        private AppDbContext _dbContext;
        
        public PlayerService(AppDbContext context)
        {
            _dbContext = context;
        }

        public List<PlayerEntity> GetAll()
        {
            return _dbContext.PlayerEntities.
                ToList();
        }

        public PlayerEntity Get(int id)
        {
            return _dbContext.PlayerEntities
                .Where(x=>x.Id==id)
                .First();
        }

        public void Add(string name,string surname,Gender gender,string birhday,string teamName,Country country)
        {
            var date = DateOnly.ParseExact(birhday, "yyyy-M-dd", null);
            var player = new PlayerEntity(name, surname, gender, date, teamName, country);
            _dbContext.
                Add(player);
            _dbContext.SaveChanges();
        }
        public void Update(long id,string name, string surname, Gender gender, string birhday, string teamName, Country country)
        {
            var player=_dbContext.PlayerEntities.FirstOrDefault(x=> x.Id==id);
            if (player == null)
                throw new Exception("No player with id: "+id);
            var date = DateOnly.ParseExact(birhday, "yyyy-M-dd", null);
            player.SetAll(name, surname, gender, date,teamName,country);
            _dbContext.
                Update(player);
            _dbContext.SaveChanges();
        }

        public List<string> GetTeamsNames()
        {
            return _dbContext.PlayerEntities
                .Select(x => x.TeamName).Distinct().ToList();
        }

    }
}
