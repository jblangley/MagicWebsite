using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUserLogic
    {
        UserSM VerifyRole(string email, string password);

        List<UserSM> GetUserList();

        UserSM GetUserDetail(string email);

        bool RegisterUser(string email, string password, string confirmpassword, string firstname, string lastname, string username, string role);

        void UpdateUserInfo(int id, string email, string password, string firstname, string lastname, string username, string role);

        void DeleteUser(string email);
    }
}
