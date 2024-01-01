using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTR_APP.Classes
{
    internal class DatabaseHandlerClass
    {
        static string mysqlConnection = "server=localhost;uid=root;pwd=;database=utr";
        static MySqlConnection connection = new MySqlConnection(mysqlConnection);

        public static bool Int_To_Bool(int value)
        {
            return value > 0 ? true : false;
        }

        public static int Bool_To_Int(bool value)
        {
          return value == true ? 1 : 0;
        }
        public static FunctionResult UserExists(string id)
        {
            FunctionResult result = new FunctionResult();
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT  Count(*)  FROM  `users` WHERE EmployeeID=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    result.Result = Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
                    result.Message = result.Result ? "" : "There is no user with employee ID as " + id;
                    result.Fresult = FunctionResultType.ok;
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = false;
                result.Fresult = FunctionResultType.fatal;
            }
            finally { connection.Close(); }
            return result;
        }

        public static FunctionResult PasswordMatches(string id, string password)
        {
            FunctionResult result = new FunctionResult();
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT  *  FROM  `users` WHERE EmployeeID=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Result = PasswordHash.Password_Hash_Decode(reader.GetString(2), password);
                            result.Fresult = result.Result ? FunctionResultType.ok : FunctionResultType.error;
                            result.Message = result.Result ? "" : "Incorrect password";

                            if (result.Result) // password also matched
                            {
                                StaticDataClass.loggedInUser = new UserClass(reader.GetInt32(0), reader.GetString(1), password, reader.GetInt32(3), 
                                    reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8), Int_To_Bool(reader.GetInt32(9)), reader.GetInt32(10) );
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = false;
                result.Fresult = FunctionResultType.fatal;
            }
            finally { connection.Close(); }
            return result;
        }

        internal static FunctionResult RegistrationOfNewEmployee(UserClass newUser)
        {
            FunctionResult result = new FunctionResult();
            string hashedPass =  PasswordHash.Password_Hash(newUser.Password);


            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO `users` " +
                    "(ID, employeeID, password, roleID, name, address, email, departmentID, employmentID, notificationOn, timeRegTypeID, created) " +
                    " VALUES(@id, @employeeId, @pass,@roleId, @name, @address,@email, @departmentId, @employmentId, @notificaitonOn, @timeregTypeId, @created)", connection))
                {
                    cmd.Parameters.AddWithValue("@id", 0);
                    cmd.Parameters.AddWithValue("@employeeId", newUser.EmployeeID);
                    cmd.Parameters.AddWithValue("@pass", hashedPass);
                    cmd.Parameters.AddWithValue("@roleId", newUser.RoleId);
                    cmd.Parameters.AddWithValue("@name", newUser.Name);
                    cmd.Parameters.AddWithValue("@address", "");
                    cmd.Parameters.AddWithValue("@email", "");
                    cmd.Parameters.AddWithValue("@departmentId", newUser.DeparmentId);
                    cmd.Parameters.AddWithValue("@employmentId", newUser.EmploymentId);
                    cmd.Parameters.AddWithValue("@notificaitonOn", false);
                    cmd.Parameters.AddWithValue("@timeregTypeId", 1);
                    cmd.Parameters.AddWithValue("@created", DateTime.Now);
                    result.Result = cmd.ExecuteNonQuery() > 0;
                    result.Message = result.Result ? "New employee is saved" : "";
                    result.Fresult = FunctionResultType.ok;
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = false;
                result.Fresult = FunctionResultType.fatal;
            }
            finally { connection.Close(); }

            return result;

        }
        internal static Dictionary<int, string> GetEmploymentTypes()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT  *  FROM  `employmenttypes`", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            } catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static Dictionary<int, string> GetDepartmentTypes()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT  *  FROM  `departments`", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static Dictionary<int, string> GetRoleTypes()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT  *  FROM  `roles`", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static FunctionResult Update_EmployeeData(bool passwordChanged, UserClass User, bool adminUpdated)
        {
            FunctionResult result = new FunctionResult();
            if (!adminUpdated)
            {
                string query = "UPDATE `users`  SET name = @name, address = @address, email = @email, notificationOn = @notification, timeRegTypeID = @timereg";
                if (passwordChanged)
                {
                        query += ", password = @pass WHERE ID = @id";
                 } else
                 {
                        query += "WHERE ID = @id";
                 }

                try
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand( query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", User.Id);
                        cmd.Parameters.AddWithValue("@name", User.Name);
                        cmd.Parameters.AddWithValue("@address", User.Address);
                        cmd.Parameters.AddWithValue("@email", User.Email);
                        cmd.Parameters.AddWithValue("@notification", Bool_To_Int(User.NotificationOn));
                        cmd.Parameters.AddWithValue("@timereg", User.TimeRegTypeId);
                        if (passwordChanged)
                        {
                            string hasshedNewPass = PasswordHash.Password_Hash(User.Password);
                            cmd.Parameters.AddWithValue("@pass", hasshedNewPass);
                        }
                        result.Result = cmd.ExecuteNonQuery() > 0;
                        result.Message = result.Result ? "Employee is updated" : "";
                        result.Fresult = FunctionResultType.ok;
                    }

                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                    result.Result = false;
                    result.Fresult = FunctionResultType.fatal;
                }
                finally { connection.Close(); }

            } else // admin update
            {

            }

            

            return result;

        }
    }
}
