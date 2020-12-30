using ApiRest_saati.Models;
using LibreriaGeneral.General;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiRest_saati.Negocio
{
    public class RegistrosNegocio: ConectaDb
    {

        private static readonly string CLASS_NAME = typeof(RegistrosNegocio).FullName;

        private static string Con = ConfigurationManager.ConnectionStrings["CATALOGO"].ConnectionString;

        private static SqlConnection Conexion()
        {

            return new SqlConnection(Con);
        }

        public List<EmpleadosOut> BuscarColaborador(EmpleadoIn empleado) {


            try
            {
                List<EmpleadosOut> empleados = new List<EmpleadosOut>();

                using (SqlConnection conn = Conexion())
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("saati_BuscarEmpleado", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@No", empleado.No);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {

                        EmpleadosOut emp = new EmpleadosOut();
                        emp.Nombre = dr["Nombre"].ToString();
                        emp.ApellidoP = dr["ApellidoP"].ToString();
                        emp.ApellidoM = dr["ApellidoM"].ToString();
                        emp.Cedis = dr["DenominacionS"].ToString();

                        empleados.Add(emp);
                    }

                    conn.Close();

                }

                return empleados;
            }
            catch (Exception e)
            {

                throw;
            }

        }

    }
}