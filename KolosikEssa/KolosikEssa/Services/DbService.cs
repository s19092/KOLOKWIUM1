
using KolosikEssa.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KolosikEssa.Services
{
    public class DbService : IDbService
    {
        private string ConnectionString = "Data Source=db-mssql;Initial Catalog=s19092;Integrated Security=True";

        public bool Add(Models.Task task)
        {

            try
            {

                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand("SELECT * FROM TaskType WHERE idtasktype = @taskt", connection))
                    {

                        command.Parameters.AddWithValue("taskt", task.IdTaskType);

                        using (var reader = command.ExecuteReader())
                        {

                            if (!reader.Read())
                            {
                                reader.Close();
                                using (var command0 = new SqlCommand("INSERT INTO TaskType (idtasktype,name) VALUES (@id,'CREATED')", connection))
                                {
                                    command0.Parameters.AddWithValue("id", task.IdTaskType);
                                    command0.ExecuteNonQuery();
                                }

                            }

                        }

                    }
                    using (var command = new SqlCommand("INSERT INTO Task (idtask,name,description,deadline,idteam,idtasktype,idassignetto,idcreator) values (@q,@w,@e,@r,@t,@y,@u,@i", connection))
                    {

                        command.Parameters.AddWithValue("q", task.IdTask);
                        command.Parameters.AddWithValue("w", task.Name);
                        command.Parameters.AddWithValue("e", task.Description);
                        command.Parameters.AddWithValue("r", task.Deadline);
                        command.Parameters.AddWithValue("t", task.IdProject);
                        command.Parameters.AddWithValue("y", task.IdTaskType);
                        command.Parameters.AddWithValue("u", task.IdAsig);
                        command.Parameters.AddWithValue("i", task.IdCreator);

                        command.ExecuteNonQuery();
                        return true;
                    }






                }

            }
            catch(SqlException e)
            {
                return false;
            }
            return false;

        }

        public Project GetProject(int id)
        {
            try { 
            Project result = new Project();

                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand("SELECT * FROM Project WHERE idproject = @id", connection))
                    {
                        command.Parameters.AddWithValue("id", id);
                        using (var reader = command.ExecuteReader())
                        {

                            if (!reader.Read())
                            {
                                return null;
                            }

                            result.IdProject = (int)reader["idProject"];
                            result.ProjectName = reader["Name"].ToString();
                            result.Deadline = (DateTime)reader["Deadline"];
                            result.Tasks = new List<Models.Task>();
                        }

                    }

                    using (var command = new SqlCommand("SELECT t.* FROM project p inner join task t on t.IdProject = p.idproject where p.idproject = 3 order by t.idtask desc", connection))
                    {
                        command.Parameters.AddWithValue("id", id);



                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                result.Tasks.Add(new Models.Task
                                {

                                    IdTask = (int)reader["iDtask"],
                                    Name = reader["Name"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Deadline = (DateTime)reader["Deadline"],
                                    IdProject = (int)reader["idproject"],
                                    IdTaskType = (int)reader["idtasktype"],
                                    IdAsig = (int)reader["idassignedto"],
                                    IdCreator = (int)reader["idcreator"]


                                });

                            }


                        }


                    }
                }
                return result;


            }
            catch(SqlException e)
            {
                return null;
            }


        }
    }
}
