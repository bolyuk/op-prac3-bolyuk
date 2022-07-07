using System;
using System.Data;
using System.Data.SqlClient;
using courseworkopbolyuk.classes;

namespace courseworkopbolyuk.kernel
{
    internal class SQLutil
    {
        public static String connString = "Server=localhost,1433;Initial Catalog=Dealer;User ID=sa;Password=DanbolyK2004;";



        public static void exec(string q)
        {
            try
            {
                var connection = new SqlConnection(connString);
                connection.Open();
                new SqlCommand(q, connection).ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Util.not(e.Message + "\n\n" + q);
            }
        }
        public static Boolean tableExist(string q)
        {
            return (int)getTable(q).Rows[0][0] > 0;
        }

        private static int generateId()
        {
            return new Random().Next(10, 50000);
        }

        public static DataTable removeCell(DataTable table, int i)
        {
            DataTable result = table.Clone();
            result.Columns[i].DataType = typeof(string);
            foreach (DataRow row in table.Rows)
            {
                DataRow temp = result.NewRow();
                for (int x = 0; x < table.Columns.Count; x++)
                    if (x == i)
                        temp[i] = row[i].ToString().Split(' ')[0];
                    else
                        temp[i] = row[i];

                result.Rows.Add(temp);
            }
            return result;
        }

        public static DataTable getTable(String q)
        {
            DataTable dt = new DataTable();
            try
            {
                var connection = new SqlConnection(connString);
                connection.Open();

                var command = new SqlCommand(q, connection);
                var adapter = new SqlDataAdapter(command);

                adapter.Fill(dt);


                connection.Close();

            }
            catch (Exception ex)
            {
                Util.not(ex.Message);
            }
            return dt;
        }
    }
}
