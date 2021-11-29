using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tiendita
{
    public partial class DetalleVenta : Form
    {
        public DetalleVenta()
        {
            InitializeComponent();
            datagrid();
        }
        public static DetalleVenta mostrar;

        public static DetalleVenta ver()
        {
            if (mostrar == null)
            {
                mostrar = new DetalleVenta();
            }
            return mostrar;
        }

        private void DetalleVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrar = null;
        }
        public void datagrid()
        {
            string q = "SELECT IDVenta, FechaVenta, Monto, IVA, Descuento, Recarga, Redondeo,Tipodepago, concat(empleado.NombreEmp,' ',empleado.ApellidoEmp) as 'Empleado', concat(cliente.NombreClie,' ',cliente.ApellidoClie) as 'Cliente' FROM examen.venta INNER JOIN empleado ON venta.Empleado_IDEmpleado=empleado.IDEmpleado INNER JOIN cliente ON venta.Cliente_IDCliente=cliente.IDCliente;";
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(q, Conexion.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //nos mostrará en caso de error 
            }
        }
    }
}
