using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConexionBD
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string QueryGetEmpleados = "SELECT empleado.nombre,empleado.sueldo,departamento.nombre FROM dbo.empleado " +
                    "JOIN dbo.departamento on empleado.idDepartamento = departamento.id_departamento; ";
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString))
                {
                    SqlCommand comando = new SqlCommand(QueryGetEmpleados, conexion);
                    conexion.Open();
                    DGEmpleados.DataSource = comando.ExecuteReader();
                    DGEmpleados.DataBind();
                    conexion.Close();
                }
            }
        }
    }
}