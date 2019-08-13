using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CasoPropuesto_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CasoPropuesto_02"].ConnectionString);

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaBox();
            ListaClientes();
        }

        public void ListaClientes()
        {

            using (SqlDataAdapter df = new SqlDataAdapter("Usp_Caso_Segundo", cn))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                using (DataSet Da = new DataSet())
                {
                    df.Fill(Da, "Pedidos");
                    dg01.DataSource = Da.Tables["Pedidos"];
                }
            }
        }

        public void ListaBox()
        {
            using (SqlDataAdapter df = new SqlDataAdapter("Usp_Caso_Segundo_Box", cn))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                using (DataSet Da = new DataSet())
                {
                    df.Fill(Da, "Pedidos");
                    var datos = Da.Tables["Pedidos"];
                    cb01.DataSource = Da.Tables["Pedidos"];
                    cb01.ValueMember = "IdEmpleado";
                    cb01.DisplayMember = "IdEmpleado";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
