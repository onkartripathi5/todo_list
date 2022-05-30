using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TodoList5.Utility;

namespace TodoList5.Models
{
    public class TodoDataAccessLayer
    {

        string connectionString = ConnectionString.CName;


        public IEnumerable<Todo> GetAllTask()
        {
            List<Todo> lstTodo = new List<Todo>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Todo todo = new Todo();

                    todo.Id = Convert.ToInt32(rdr["Id"]);
                    todo.TaskName = rdr["TaskName"].ToString();
                    todo.Priority = rdr["Priority"].ToString();
                    todo.Date = rdr["Date"].ToString();


                    lstTodo.Add(todo);
                }
                con.Close();
            }
            return lstTodo;
        }


        public void AddTask(Todo todo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaskName", todo.TaskName);
                cmd.Parameters.AddWithValue("@Priority", todo.Priority);
                cmd.Parameters.AddWithValue("@Date", todo.Date);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateTask(Todo todo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", todo.Id);
                cmd.Parameters.AddWithValue("@TaskName", todo.TaskName);
                cmd.Parameters.AddWithValue("@Priority",todo.Priority);
                cmd.Parameters.AddWithValue("@Date", todo.Date);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Todo GetTaskData(int? id)
        {
            Todo todo = new Todo();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Tasks WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    todo.Id = Convert.ToInt32(rdr["Id"]);
                    todo.TaskName = rdr["TaskName"].ToString();
                    todo.Priority = rdr["Priority"].ToString();
                    todo.Date = rdr["Date"].ToString();

                }
            }
            return todo;
        }

        public void DeleteTask(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
