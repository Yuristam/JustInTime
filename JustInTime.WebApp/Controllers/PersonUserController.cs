using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using JustInTime.WebApp.Areas;
using JustInTime.WebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.WebApp.Controllers
{
    public class PersonUserController : IShortedUserController
    {
        private readonly NotesDbContext _dbContext;
        public PersonUserController(NotesDbContext dbContext) {
            _dbContext=dbContext;
        }

        public void AddUser(JustInTimeUser user,  string firstName, string lastName, DateTime dateTime)
        {
            var shortenUser = MapUser(user);
            ExpandUserObject(shortenUser,  firstName, lastName, dateTime);
            _dbContext.Person.Add(shortenUser);

            _dbContext.SaveChanges();
        }

        private void ExpandUserObject(Person user, string firstName, string lastName, DateTime dateTime)
        {
            user.FirstName = firstName;
            user.LastName = lastName;
            user.BirthdayDate = dateTime;
        }

        private Person MapUser(JustInTimeUser mozgoeb)
        {
            return new Person()
            {
                Id = mozgoeb.Id,

            };
        }
    }
}
