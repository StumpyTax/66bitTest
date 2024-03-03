using _66bitTest.app.entities;
using _66bitTest.domain;
using Microsoft.EntityFrameworkCore;

namespace _66bitTest.app.services.interfaces
{
    public interface IPlayerService
    {
        List<PlayerEntity> GetAll();
        PlayerEntity Get(int id);
        void Add(string name, string surname, Gender gender, string birhday, string teamName, Country country);
        List<string> GetTeamsNames();
        public void Update(long id, string name, string surname, Gender gender, string birhday, string teamName, Country country);
    }
}
