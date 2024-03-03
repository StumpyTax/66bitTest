using _66bitTest.domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _66bitTest.app.entities
{
    public class PlayerEntity:IPlayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname{get;set;}
        public Gender Gend { get; set; }
        public DateOnly Birthday { get; set; }
        public String TeamName { get; set; }
        
        public Country country { get; set; }

        public PlayerEntity() { }
        public PlayerEntity(string name,string surname, Gender gender, DateOnly birthday, string teamName, Country country)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gend = gender;
            this.Birthday = birthday;
            this.TeamName = teamName;
            this.country = country;
        }
        public void SetAll(string name, string surname, Gender gender, DateOnly birthday, string teamName, Country country)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gend = gender;
            this.Birthday = birthday;
            this.TeamName = teamName;
            this.country = country;
        }
    }
}
