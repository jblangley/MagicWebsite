using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserDAO
    {
        List<UserDM> GetUsers();

        UserDM GetUser(string email);

        string CheckIfEmailExists(string email);

        void CreateUser(UserDM user);

        void UpdateUser(UserDM user);

        void DeleteUser(string email);
    }
}
