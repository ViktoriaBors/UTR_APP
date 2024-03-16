using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.ComTypes;

namespace UTR_APP.Classes
{
    internal class DatabaseHandlerClass
    {
        static string mysqlConnection = StaticDataClass.Connection_Settings(StaticDataClass.SettingIniPath); // "server=localhost;uid=root;pwd=;database=utr";
        static MySqlConnection connection = new MySqlConnection(mysqlConnection);

        public static bool Int_To_Bool(int value)
        {
            return value > 0 ? true : false;
        }

        public static int Bool_To_Int(bool value)
        {
            return value == true ? 1 : 0;
        }

        #region Users and Login, registration, modification,delete
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

        public static FunctionResult PasswordMatches(string employeeId, string password)
        {
            FunctionResult result = new FunctionResult();
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT  *  FROM  `users` WHERE EmployeeID=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", employeeId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Result = PasswordHash.Password_Hash_Decode(reader.GetString(2), password);
                            result.Fresult = result.Result ? FunctionResultType.ok : FunctionResultType.error;
                            result.Message = result.Result ? "" : "Incorrect password";

                            if (result.Result) // password also matched
                            {
                                StaticDataClass.loggedInUser = new UserClass(reader.GetInt32(0), reader.GetString(1), "hahaha_0", reader.GetInt32(3),
                                    reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetFloat(9), reader.GetDateTime(11));
                                StaticDataClass.UsersFlexHoursFromPrevSystem = StaticDataClass.loggedInUser.HoursFromPrevSystem;
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
            string hashedPass = PasswordHash.Password_Hash(newUser.Password);
            string query = "INSERT INTO `users` " +
                    "(ID, employeeID, password, roleID, name, address, email, departmentID, employmentID, hoursFromPrevSystem, created) " +
                    " VALUES(@id, @employeeId, @pass,@roleId, @name, @address,@email, @departmentId, @employmentId, @hoursFromPrevSystem,  @created)";
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
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
                    cmd.Parameters.AddWithValue("@hoursFromPrevSystem", newUser.HoursFromPrevSystem);
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

        internal static FunctionResult DeleteUser(UserClass User)
        {
            FunctionResult result = new FunctionResult();

            string query1 = "DELETE FROM `users` WHERE ID = @id";
            string query2 = "DELETE FROM `userfavoriteprojects` WHERE userID = @id";

            try
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query2, connection))
                {
                    cmd.Parameters.AddWithValue("@id", User.Id);
                    result.Result = cmd.ExecuteNonQuery() > 0;
                }

                using (MySqlCommand cmd = new MySqlCommand(query1, connection))
                {
                    cmd.Parameters.AddWithValue("@id", User.Id);
                    result.Result = cmd.ExecuteNonQuery() > 0;
                    result.Message = result.Result ? "Employee is deleted" : "";
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

        internal static FunctionResult Update_EmployeeData(bool passwordChanged, UserClass User, bool adminUpdated)
        {
            FunctionResult result = new FunctionResult();
            if (!adminUpdated)
            {
                string query = "UPDATE `users`  SET name = @name, address = @address, email = @email";
                if (passwordChanged)
                {
                    query += ", password = @pass WHERE ID = @id";
                }
                else
                {
                    query += " WHERE ID = @id";
                }

                try
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", User.Id);
                        cmd.Parameters.AddWithValue("@name", User.Name);
                        cmd.Parameters.AddWithValue("@address", User.Address);
                        cmd.Parameters.AddWithValue("@email", User.Email);
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

            }
            else // admin update
            {
                string query = "UPDATE `users`  SET roleID = @role, departmentID = @dep, employmentID = @empl";
                if (passwordChanged) // amdin updated password - forgottenpassword
                {
                    query += ", password = @pass WHERE ID = @id";
                }
                else
                {
                    query += " WHERE ID = @id";
                }

                connection.Open();
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", User.Id);
                        cmd.Parameters.AddWithValue("@role", User.RoleId);
                        cmd.Parameters.AddWithValue("@dep", User.DeparmentId);
                        cmd.Parameters.AddWithValue("@empl", User.EmploymentId);
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
            }
            return result;
        }
        internal static List<UserClass> AllUsers(bool loggedInUserIncluded = false)
        {
            List<UserClass> result = new List<UserClass>();

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT  *  FROM  `users`", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!loggedInUserIncluded)
                            {
                                if (reader.GetInt32(0) != StaticDataClass.loggedInUser.Id)
                                {
                                    result.Add(new UserClass(reader.GetInt32(0), reader.GetString(1), "hahaha_0", reader.GetInt32(3),
                                                                       reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetFloat(9), reader.GetDateTime(11)));
                                }
                            } else
                            {
                                result.Add(new UserClass(reader.GetInt32(0), reader.GetString(1), "hahaha_0", reader.GetInt32(3),
                                                                       reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8), reader.GetFloat(9), reader.GetDateTime(11)));
                            }
                                                    
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }
        #endregion

        #region Employment Types
        internal static List<EmploymentType> GetEmploymentTypes()
        {
            List<EmploymentType> result = new List<EmploymentType>();

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT  *  FROM  `employmenttypes`", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new EmploymentType(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                }
            } catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }


        internal static FunctionResult DeleteEmploymentType(EmploymentType forDelete)
        {
            FunctionResult result = new FunctionResult();
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM  `employmenttypes` WHERE ID=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", forDelete.Id);
                    result.Result = cmd.ExecuteNonQuery() > 0;
                    result.Message = result.Result ? "Employment types: " + forDelete.Name + "was deleted" : "";
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

        internal static FunctionResult EmploymentTypeUpdateAdd(EmploymentType employmentType)
        {
            FunctionResult result = new FunctionResult();
            bool exist = EmploymentTypeExist(employmentType.Id);
            try
            {
                connection.Open();
                string query = string.Empty;
                if (exist)
                {
                    query = "UPDATE `employmenttypes` SET ID = @id, name = @name, description= @desc WHERE ID=@id ";
                }
                else
                {
                    query = "INSERT INTO `employmenttypes` (ID, name, description) VALUES(@id,@name,@desc)";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", employmentType.Id);
                    cmd.Parameters.AddWithValue("@name", employmentType.Name);
                    cmd.Parameters.AddWithValue("@desc", employmentType.Description);
                    result.Result = cmd.ExecuteNonQuery() > 0;

                    result.Message = result.Result ? "Employment type: " + employmentType.Name + "was updated" : "";
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

        public static bool EmploymentTypeExist(int emplID)
        {
            bool result = false;
            try
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand("Select Count(*) FROM `employmenttypes` WHERE ID=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", emplID);
                    // cmd.ExecuteScalar();
                    result = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally { connection.Close(); }
            return result;
        }

        #endregion

        #region Department
        internal static List<Department> GetDepartmentTypes()
        {
            List<Department> result = new List<Department>();

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT  *  FROM  `departments`", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Department(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        public static FunctionResult DeleteDepartment(Department forDelete)
        {
            FunctionResult result = new FunctionResult();
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM  `departments` WHERE ID=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", forDelete.Id);
                    result.Result = cmd.ExecuteNonQuery() > 0;
                    result.Message = result.Result ? "Department: " + forDelete.Name + "was deleted" : "";
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

        public static FunctionResult DepartmentUpdateAdd(Department department)
        {
            FunctionResult result = new FunctionResult();
            bool exist = DepartmentExist(department.Id);
            try
            {
                connection.Open();
                string query = string.Empty;
                if (exist)
                {
                    query = "UPDATE `departments` SET ID = @id, name = @name, description= @desc WHERE ID=@id ";
                } else
                {
                    query = "INSERT INTO `departments` (ID, name, description) VALUES(@id,@name,@desc)";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", department.Id);
                    cmd.Parameters.AddWithValue("@name", department.Name);
                    cmd.Parameters.AddWithValue("@desc", department.Description);
                    result.Result = cmd.ExecuteNonQuery() > 0;

                    result.Message = result.Result ? "Department: " + department.Name + "was updated" : "";
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

        public static bool DepartmentExist(int departmentID)
        {
            bool result = false;
            try
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand("Select Count(*) FROM `departments` WHERE ID=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", departmentID);
                    // cmd.ExecuteScalar();
                    result = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally { connection.Close(); }
            return result;
        }

        #endregion

        #region Roles
        internal static List<Role> GetRoleTypes()
        {
            List<Role> result = new List<Role>();

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT  *  FROM  `roles`", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Role(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static FunctionResult DeleteRole(Role forDelete)
        {
            FunctionResult result = new FunctionResult();
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM  `roles` WHERE ID=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", forDelete.Id);
                    result.Result = cmd.ExecuteNonQuery() > 0;
                    result.Message = result.Result ? "Role: " + forDelete.Name + "was deleted" : "";
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

        internal static FunctionResult RoleUpdateAdd(Role role)
        {
            FunctionResult result = new FunctionResult();
            bool exist = RoleExist(role.Id);
            try
            {
                connection.Open();
                string query = string.Empty;
                if (exist)
                {
                    query = "UPDATE `roles` SET ID = @id, name = @name, description= @desc WHERE ID=@id ";
                }
                else
                {
                    query = "INSERT INTO `roles` (ID, name, description) VALUES(@id,@name,@desc)";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", role.Id);
                    cmd.Parameters.AddWithValue("@name", role.Name);
                    cmd.Parameters.AddWithValue("@desc", role.Description);
                    result.Result = cmd.ExecuteNonQuery() > 0;

                    result.Message = result.Result ? "Role: " + role.Name + "was updated" : "";
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

        public static bool RoleExist(int roleID)
        {
            bool result = false;
            try
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand("Select Count(*) FROM `roles` WHERE ID=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", roleID);
                    // cmd.ExecuteScalar();
                    result = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally { connection.Close(); }
            return result;
        }

        #endregion

        #region Projects
        internal static List<Project> AllProjects(bool showDeactivated = false)
        {
            List<Project> result = new List<Project>();
            string query = showDeactivated ? "SELECT  *  FROM  `projects`" : "SELECT  *  FROM  `projects`  WHERE isactive = 1";
            

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Project(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), Int_To_Bool(reader.GetInt32(3)), reader.GetInt32(4)));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static FunctionResult RegistrationOfNewProject(Project project)
        {
            FunctionResult result = new FunctionResult();

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO `projects` " +
                    "(ID, name, description, isactive, departmentID ) " +
                    " VALUES(@id, @name, @desc, @active, @departmentId)", connection))
                {
                    cmd.Parameters.AddWithValue("@id", 0);
                    cmd.Parameters.AddWithValue("@name", project.Name);
                    cmd.Parameters.AddWithValue("@desc", project.Description);
                    cmd.Parameters.AddWithValue("@active", Bool_To_Int(project.IsActive));
                    cmd.Parameters.AddWithValue("@departmentId", project.DepartmentId);
                    result.Result = cmd.ExecuteNonQuery() > 0;
                    result.Message = result.Result ? "New project is saved" : "";
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

        internal static FunctionResult UpdateProjectData(Project project)
        {
            FunctionResult result = new FunctionResult();
            string query = "UPDATE `projects`  SET name = @name, description=@desc, isactive = @active, departmentID = @departmentId where ID = @id";
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", project.Id);
                    cmd.Parameters.AddWithValue("@name", project.Name);
                    cmd.Parameters.AddWithValue("@desc", project.Description);
                    cmd.Parameters.AddWithValue("@active", Bool_To_Int(project.IsActive));
                    cmd.Parameters.AddWithValue("@departmentId", project.DepartmentId);
                    result.Result = cmd.ExecuteNonQuery() > 0;
                    result.Message = result.Result ? "Project is updated" : "";
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

        internal static FunctionResult DeactivateProject(Project project)
        {
            FunctionResult result = new FunctionResult();
            string query = "UPDATE `projects`  SET  isactive = @active where ID = @id";
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", project.Id);
                    cmd.Parameters.AddWithValue("@active", Bool_To_Int(project.IsActive));
                    result.Result = cmd.ExecuteNonQuery() > 0;
                    result.Message = result.Result ? "Project is updated" : "";
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

        internal static List<UserFavoriteProject> AllFavoriteProjects()
        {
            List<UserFavoriteProject> result = new List<UserFavoriteProject>();
            string query = "SELECT userID, projectID, name FROM userfavoriteprojects " +
                              "INNER JOIN projects ON projects.ID = userfavoriteprojects.projectID " +
                              "WHERE userID = @id;";

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", StaticDataClass.loggedInUser.Id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {                       
                        while (reader.Read())
                        {
                            result.Add(new UserFavoriteProject(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2)));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static List<FunctionResult> SaveFavoriteProjects(List<UserFavoriteProject> favoriteProjects)
        {
            FunctionResult oneResult = new FunctionResult();
            List <FunctionResult> result = new List<FunctionResult >();
            string query = "INSERT INTO userfavoriteprojects (userID, projectID) " +
                              "VALUES (@userId, @projectId) " +
                              "ON DUPLICATE KEY UPDATE userID = @userId, projectID = @projectId;";

            foreach (var item in favoriteProjects)
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", item.UserId);
                        cmd.Parameters.AddWithValue("@projectId", item.ProjectId);
                        oneResult.Result = cmd.ExecuteNonQuery() > 0;
                        oneResult.Message = oneResult.Result ? "Project is updated" : "";
                        oneResult.Fresult = FunctionResultType.ok;
                    }
                }
                catch (Exception ex)
                {
                    oneResult.Message = ex.Message;
                    oneResult.Result = false;
                    oneResult.Fresult = FunctionResultType.fatal;
                }
                finally { connection.Close(); }
                result.Add(oneResult);
            }           
            return result;
        }

        internal static List<FunctionResult> DeleteFavoriteProjects(List<UserFavoriteProject> deletedProjects)
        {
            FunctionResult oneResult = new FunctionResult();
            List<FunctionResult> result = new List<FunctionResult>();
            string query = "DELETE FROM userfavoriteprojects WHERE userID = @userId AND projectID = @projectId;";

            foreach (var item in deletedProjects)
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", item.UserId);
                        cmd.Parameters.AddWithValue("@projectId", item.ProjectId);
                        oneResult.Result = cmd.ExecuteNonQuery() > 0;
                        oneResult.Message = oneResult.Result ? "Project is deleted" : "";
                        oneResult.Fresult = FunctionResultType.ok;
                    }
                }
                catch (Exception ex)
                {
                    oneResult.Message = ex.Message;
                    oneResult.Result = false;
                    oneResult.Fresult = FunctionResultType.fatal;
                }
                finally { connection.Close(); }
                result.Add(oneResult);
            }
            return result;
        }

        #endregion

        #region Timeregistration
        internal static List<RegistratedTime> AllRegisteredHoursByUser(string date) // for one day
        {
            List<RegistratedTime> result = new List<RegistratedTime>();
            string query = "SELECT * FROM `registeredhours` WHERE userID = @id AND DATE(date) = @date";

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", StaticDataClass.loggedInUser.Id);
                    cmd.Parameters.AddWithValue("@date", date);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new RegistratedTime(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetFloat(4), reader.GetDateTime(5), Int_To_Bool(reader.GetInt32(6)), Int_To_Bool(reader.GetInt32(7))));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static List<RegistratedTime> AllRegisteredHoursByUser(string startdate, string enddate) // for period
        {
            List<RegistratedTime> result = new List<RegistratedTime>();
            string query = "SELECT * FROM `registeredhours` WHERE userID = @id AND DATE(date) BETWEEN @startdate AND @enddate";

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", StaticDataClass.loggedInUser.Id);
                    cmd.Parameters.AddWithValue("@startDate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new RegistratedTime(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetFloat(4), reader.GetDateTime(5), Int_To_Bool(reader.GetInt32(6)), Int_To_Bool(reader.GetInt32(7))));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static double AllRegisteredHoursByUserFromEmplymentStart(string enddate)
        {
            double result = 0;
            string query = "SELECT SUM(hours) AS total_hours FROM `registeredhours` WHERE userID = @id AND DATE(date) BETWEEN @startdate AND @enddate;";

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", StaticDataClass.loggedInUser.Id);
                    cmd.Parameters.AddWithValue("@startDate", StaticDataClass.loggedInUser.EmploymentStart);
                    cmd.Parameters.AddWithValue("@enddate", enddate);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = reader.GetDouble(0);
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static List<RegistratedTime> AllRegisteredHoursByUser(string startdate, string enddate, int projectId) // for period - filter projectid
        {
            List<RegistratedTime> result = new List<RegistratedTime>();
            string query = "SELECT * FROM `registeredhours` WHERE userID = @id AND projectID=@projectId AND DATE(date) BETWEEN @startdate AND @enddate";

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", StaticDataClass.loggedInUser.Id);
                    cmd.Parameters.AddWithValue("@startDate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);
                    cmd.Parameters.AddWithValue("@projectId", projectId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new RegistratedTime(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetFloat(4), reader.GetDateTime(5), Int_To_Bool(reader.GetInt32(6)), Int_To_Bool(reader.GetInt32(7))));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static List<RegistratedTime> AllRegisteredHours(string startdate, string enddate, int projectId) // for period - filter projectid
        {
            List<RegistratedTime> result = new List<RegistratedTime>();
            string query = "SELECT * FROM `registeredhours` WHERE  projectID=@projectId AND DATE(date) BETWEEN @startdate AND @enddate";

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@startDate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);
                    cmd.Parameters.AddWithValue("@projectId", projectId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new RegistratedTime(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetFloat(4), reader.GetDateTime(5), Int_To_Bool(reader.GetInt32(6)), Int_To_Bool(reader.GetInt32(7))));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static List<RegistratedTime> AllRegisteredHours(string startdate, string enddate) // for period
        {
            List<RegistratedTime> result = new List<RegistratedTime>();
            string query = "SELECT * FROM `registeredhours` WHERE  DATE(date) BETWEEN @startdate AND @enddate";

            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@startDate", startdate);
                    cmd.Parameters.AddWithValue("@enddate", enddate);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new RegistratedTime(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetFloat(4), reader.GetDateTime(5), Int_To_Bool(reader.GetInt32(6)), Int_To_Bool(reader.GetInt32(7))));
                        }
                    }
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return result;
        }

        internal static List<FunctionResult> SaveUpdateHours(List<RegistratedTime> workedHours)
        {
            FunctionResult oneResult = new FunctionResult();
            List<FunctionResult> result = new List<FunctionResult>();
            string query = string.Empty;

            foreach (RegistratedTime item in workedHours)
            {
                bool exist = DatabaseHandlerClass.RegisteresHoursIDExists(item.Id);
                if (exist  || item.Modified)
                {
                    query = "UPDATE `registeredhours` SET projectID = @project, description = @desc, hours = @hours, modified = @modified, approved=@approved WHERE ID = @id";
                }
                else
                {
                    query = "INSERT INTO `registeredhours` (ID, userID, projectID, description, hours, date, modified, approved) VALUES(@id, @userID, @project, @desc, @hours, @date, @modified, @approved) ";
                }

                try
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@project", item.ProjectID);
                        cmd.Parameters.AddWithValue("@desc", item.Description);
                        cmd.Parameters.AddWithValue("@hours", item.Hours);
                        cmd.Parameters.AddWithValue("@modified", item.Modified);
                        cmd.Parameters.AddWithValue("@approved", item.Approved);
                        if (exist || item.Modified)
                        {
                            cmd.Parameters.AddWithValue("@id", item.Id);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@id", 0);
                            cmd.Parameters.AddWithValue("@userID", StaticDataClass.loggedInUser.Id);
                            cmd.Parameters.AddWithValue("@date", item.Date);
                        }

                        oneResult.Result = cmd.ExecuteNonQuery() > 0;
                        oneResult.Message = oneResult.Result ? "Hours are saved" : "";
                        oneResult.Fresult = FunctionResultType.ok;
                    }
                }
                catch (Exception ex)
                {
                    oneResult.Message = ex.Message;
                    oneResult.Result = false;
                    oneResult.Fresult = FunctionResultType.fatal;
                }
                finally { connection.Close(); }
                result.Add(oneResult);
            }
            return result;
        }

        private static bool RegisteresHoursIDExists(int id)
        {
            bool result = false;

            string query = "SELECT COUNT(*) FROM `registeredhours` WHERE ID=@id";
            try
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    result = Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally { connection.Close(); }
            return result;
        }

        internal static FunctionResult DeleteGivenWorkedHours(RegistratedTime forDelete)
        {
            FunctionResult result = new FunctionResult();
            try
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM  `registeredhours` WHERE ID=@id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", forDelete.Id);
                    result.Result = cmd.ExecuteNonQuery() > 0;
                    result.Message = result.Result ? "Worked hours was deleted" : "";
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

        #endregion
    }
}
