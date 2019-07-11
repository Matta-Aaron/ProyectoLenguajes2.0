using Model.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Proyecto2.Model.Data
{
    public class UsuarioData
    {
        private string connectionString;

        string sqlconnect = "data source = " +
                "163.178.173.148;initial " +
                "catalog=ProyectoLenguajes;user id=estudiantesrp;password=estudiantesrp;" +
                "multipleactiveresultsets=True";

        public UsuarioData(string connectiostring)
        {
            this.connectionString = connectiostring;
        }

        public List<Comprador> GetAll()
        {
            List<Comprador> comprador = new List<Comprador>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select Id, Nombre, Password, email from Comprador";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nombre = reader.GetString(1);
                            string password = reader.GetString(2);
                            string email = reader.GetString(3);

                            comprador.Add(new Comprador(nombre, password, id,email));
                        }
                        reader.Close();
                    };
                }
                connection.Close();
            }

            return comprador;
        }


        public void InsertarComprador(Comprador comprador)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Insert into Comprador(Id,Nombre,Password,email) values(@Id, @Nombre, @Password, @email)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", comprador.Id));
                    command.Parameters.Add(new SqlParameter("@Nombre", comprador.Nombre));
                    command.Parameters.Add(new SqlParameter("@Password", comprador.Password));
                    command.Parameters.Add(new SqlParameter("@email", comprador.Email));
                }
                connection.Close();
            }
        }


        public void ActualizaComprador(Comprador comprador)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"UPDATE Comprador SET 
                          Nombre = @Nombre,
                          Password = @Password,
                          email = @email
                    WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("Nombre", comprador.Nombre);
                    command.Parameters.AddWithValue("Password", comprador.Password);
                    command.Parameters.AddWithValue("email", comprador.Email);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void BorrarComprador(int Id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"DELETE FROM Comprador 
                   WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("Id", Id);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
