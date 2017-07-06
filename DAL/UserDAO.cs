using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class UserDAO : IUserDAO
    {
        public string ConnectionString = @"Server=.\SQLEXPRESS;Database=Capstone;Trusted_Connection=True;";
        private IDAO DataWriter;

        public UserDAO(IDAO dataWriter)
        {
            DataWriter = dataWriter;
        }
        public List<UserDM> ReadUsers(SqlParameter[] parameter, string statement)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parameter != null)
                        {
                            command.Parameters.AddRange(parameter);
                        }
                        connection.Open();
                        SqlDataReader data = command.ExecuteReader();
                        List<UserDM> users = new List<UserDM>();
                        while (data.Read())
                        {
                            UserDM user = new UserDM();
                            user.Email = data["Email"].ToString();
                            user.Password = data["Password"].ToString();
                            user.ID = (Int32)data["ID"];
                            user.Role = data["Role"].ToString();
                            user.FirstName = data["FirstName"].ToString();
                            user.LastName = data["LastName"].ToString();
                            user.UserName = data["UserName"].ToString();
                            users.Add(user);
                        }
                        return users;
                    }
                    catch
                    {
                        return null;
                    }

                }
            }
        }
        //Gets all users from the database
        public List<UserDM> GetUsers()
        {
            try
            {
                return ReadUsers(null, "ReadAllUsers");
            }
            catch
            {
                return null;
            }
        }
        //Gets a single user from the database
        public UserDM GetUser(string email)
        {
            try
            {
                return ReadUsers(new SqlParameter[] { new SqlParameter("@Email", email) }, "GetUser")[0];
            }
            catch
            {
                return null;
            }
        }
        public string CheckIfEmailExists(string email)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@Email", email) };
                string statement = "CheckIfEmailExists";
                string check = "";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(statement, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parameter != null)
                        {
                            command.Parameters.AddRange(parameter);
                        }
                        connection.Open();
                        SqlDataReader data = command.ExecuteReader();
                        while (data.Read())
                        {
                            check = data["Email"].ToString();
                        }
                        return check;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        //Creates a new user
        public void CreateUser(UserDM user)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@Email", user.Email)
                ,new SqlParameter("@Password", user.Password)
                ,new SqlParameter("@Role", user.Role)
                ,new SqlParameter("@FirstName", user.FirstName)
                ,new SqlParameter("@LastName", user.LastName)
                ,new SqlParameter("@UserName",user.UserName)
            };
                DAO dataWriter = new DAO();
                dataWriter.Write(parameter, "CreateUser");
            }
            catch
            {
            }
        }
        //Changes the information of a user
        public void UpdateUser(UserDM user)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@Email", user.Email)
                ,new SqlParameter("@Password", user.Password)
                ,new SqlParameter("@ID", user.ID)
                ,new SqlParameter("@Role", user.Role)
                ,new SqlParameter("@FirstName", user.FirstName)
                ,new SqlParameter("@LastName", user.LastName)
                ,new SqlParameter("@UserName",user.UserName)
            };
                DAO dataWriter = new DAO();
                dataWriter.Write(parameter, "UpdateUser");
            }
            catch
            {
            }
        }
        //Deletes a user from the database
        public void DeleteUser(string email)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@Email", email)
            };
                DAO dataWriter = new DAO();
                dataWriter.Write(parameter, "DeleteUser");
            }
            catch
            {
            }

        }
    }
}
