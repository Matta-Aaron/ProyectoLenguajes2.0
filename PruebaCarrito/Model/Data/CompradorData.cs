using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace Model.Data
{
    public class CompradorData
    {

        private string connectionString;

        string sqlconnect = "data source = " +
                "163.178.173.148;initial " +
                "catalog=ProyectoLenguajes;user id=estudiantesrp;password=estudiantesrp;" +
                "multipleactiveresultsets=True";

        public CompradorData()
        {
            this.connectionString = sqlconnect;
        }

        public List<Comprador> ObtenerCompradores()
        {
            List<Comprador> comprador = new List<Comprador>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select Id, Nombre,Password,email from Comprador";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string Nombre = reader.GetString(1);
                            string Password = reader.GetString(2);
                            string email = reader.GetString(3);

                            comprador.Add(new Comprador( Nombre, Password,id, email));
                        }
                        reader.Close();
                    };
                }
                connection.Close();
            }

            return comprador;
        }


    }
}
