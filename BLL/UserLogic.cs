using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDAO UserData;

        public UserLogic(UserDAO userData)
        {
            UserData = userData;
        }
        //Checks to make sure the user exists to allow them to log in
        public UserSM VerifyRole(string email, string password)
        {
            try
            {
                UserSM temp = new UserSM();
                UserSM user = Mapper.Map<UserSM>(UserData.GetUser(email));
                if (email == user.Email && password == user.Password)
                {
                    temp = user;
                    return user;
                }
                return temp;
            }
            catch
            {
                return null;
            }
        }
        //Gets all users from the database
        public List<UserSM> GetUserList()
        {
            try
            {
                return Mapper.Map<List<UserSM>>(UserData.GetUsers());
            }
            catch
            {
                return null;
            }
        }
        //Gets the details of a user
        public UserSM GetUserDetail(string email)
        {
            try
            {
                return Mapper.Map<UserSM>(UserData.GetUser(email));
            }
            catch
            {
                return null;
            }
        }
        public bool CheckIfEmailExists(string email)
        {
            string check = UserData.CheckIfEmailExists(email);
            if (check == email)
            {
                return true;
            }
            return false;
        }
        //Creates a new user
        public bool RegisterUser(string email, string password, string confirmpassword, string firstname, string lastname, string username, string role)
        {
            try
            {
                if (CheckIfEmailExists(email) == false)
                {
                    bool verify = false;
                    if (password == confirmpassword)
                    {
                        if (role == null)
                        {
                            role = "User";
                        }
                        UserSM user = new UserSM();
                        user.Email = email;
                        user.Password = password;
                        user.ConfirmPassword = confirmpassword;
                        user.FirstName = firstname;
                        user.LastName = lastname;
                        user.UserName = username;
                        user.Role = role;
                        UserData.CreateUser(Mapper.Map<UserDM>(user));
                        verify = true;
                    }
                    return verify;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        //Edits existing information of a user
        public void UpdateUserInfo(int id, string email, string password, string firstname, string lastname, string username, string role)
        {
            try
            {
                UserSM user = new UserSM();
                user.ID = id;
                user.Email = email;
                user.Password = password;
                user.FirstName = firstname;
                user.LastName = lastname;
                user.UserName = username;
                user.Role = role;
                UserData.UpdateUser(Mapper.Map<UserDM>(user));
            }
            catch
            {
            }
        }
        //Deletes a user
        public void DeleteUser(string email)
        {
            try
            {
                UserData.DeleteUser(email);
            }
            catch
            {
            }
        }
    }
}