using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using CRUD.Controller;

namespace CRUD.Service
{
    public class MySQLHelper
    {

        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader dr;

        private string connectionString = Properties.Settings.Default.DB;
        private string query = string.Empty;


        /// <summary>
        /// Call this method/function to get data from database and store to DataTable.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public DataTable GetEmployee(AppInterface view)
        {
            try
            {
                DataTable dt = new DataTable();

                using (conn = new MySqlConnection(connectionString))
                {

                    conn.Open();

                    query = "SELECT * FROM Employee WHERE ID = @id";

                    using (cmd = new MySqlCommand(query, conn))
                    {
                        //if your quer/script is stored procedure use the code below
                        //cmd.CommandType = CommandType.StoredProcedure;

                        //parameters
                        cmd.Parameters.AddWithValue("@id", view.EmployeeId);

                        using (dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }

                    }

                }

                return dt;
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// Call this method/function to save employee
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public int SaveEmployee(AppInterface view)
        {
            try
            {
                int result = 0;

                using (conn = new MySqlConnection(connectionString))
                {

                    conn.Open();

                    query = "INSERT INTO Employee (lname, fname, mname) VALUES (@lname, @fname, @mname)";

                    using (cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@lname", view.LastName);
                        cmd.Parameters.AddWithValue("@fname", view.FirstName);
                        cmd.Parameters.AddWithValue("@mname", view.MiddleName);

                        result = cmd.ExecuteNonQuery();
                        
                    }
                }

                return result;
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// Call this method/function to update employee details.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public int UpdateEmployee(AppInterface view)
        {
            try
            {
                int result = 0;

                using (conn = new MySqlConnection(connectionString))
                {

                    conn.Open();

                    query = "UPDATE Employee SET lname = @lname, fname = @fname, mname = @mname WHERE ID = @id";

                    using (cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@lname", view.LastName);
                        cmd.Parameters.AddWithValue("@fname", view.FirstName);
                        cmd.Parameters.AddWithValue("@mname", view.MiddleName);
                        cmd.Parameters.AddWithValue("@id", view.MiddleName);

                        result = cmd.ExecuteNonQuery();

                    }
                }

                return result;
            }
            catch
            {

                throw;
            }
        }

        public int DeleteEmployee(AppInterface view)
        {
            try
            {
                int result = 0;

                using (conn = new MySqlConnection(connectionString))
                {

                    conn.Open();

                    query = "DELETE FROM Employee WHERE ID = @id";

                    using (cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@id", view.MiddleName);

                        result = cmd.ExecuteNonQuery();

                    }
                }

                return result;
            }
            catch
            {

                throw;
            }
        }
    }
}
