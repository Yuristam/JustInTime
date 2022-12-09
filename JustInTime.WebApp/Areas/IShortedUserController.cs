using JustInTime.WebApp.Areas.Identity.Data;

namespace JustInTime.WebApp.Areas
{
    public interface IShortedUserController
    {
        public void AddUser(JustInTimeUser user,  string firstName, string lastName, DateTime dateTime);

    }
}
