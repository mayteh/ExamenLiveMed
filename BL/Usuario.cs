using ML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll ()
        {
            ML.Result result = new ML.Result ();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    var query = "SELECT Id_user, Usuario, Usuario.Id_country, Country.Country FROM Usuario LEFT JOIN Country ON Country.Id_country = Usuario.Id_country";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection= context;
                        cmd.CommandText= query;
                        context.Open ();

                        result.Objects = new List<object>();

                        using (SqlDataReader reader = cmd.ExecuteReader ())
                        {
                            while (reader.Read ())
                            {
                                ML.Usuario usuarioDB = new ML.Usuario ();

                                usuarioDB.Id_usuario = reader.GetInt32(0);
                                usuarioDB.UsuarioN = reader.GetString(1);
                                //usuarioDB.Id_country = reader.GetInt32(2);
                                usuarioDB.Country = new ML.Country();
                                usuarioDB.Country.Id_country = reader.GetInt32(2);

                                if(reader.IsDBNull(3))
                                {
                                    usuarioDB.Country.Name = null;
                                }
                                else
                                {
                                    usuarioDB.Country.Name = reader.GetString(3);
                                }

                                result.Objects.Add(usuarioDB);

                            }
                        }

                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la informacion" + result.Ex;
            }
            return result;
        }
    }
}
