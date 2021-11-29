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
    public partial class DetalleCompra : Form
    {
        public DetalleCompra()
        {
            InitializeComponent();
            datagrid();
        }

        public static DetalleCompra mostrar;

        public static DetalleCompra ver()
        {
            if (mostrar == null)
            {
                mostrar = new DetalleCompra();
            }
            return mostrar;
        }

        private void DetalleCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrar = null;
        }

        public void datagrid()
        {
            string q = "SELECT IDCompra, FechaCompra, Monto, concat(empleado.NombreEmp,' ',empleado.ApellidoEmp) as 'Empleado', concat(proveedor.NombreProv, ' ',proveedor.ApellidoProv) as 'Proveedor'  FROM examen.compra INNER JOIN empleado ON compra.Empleado_IDEmpleado=empleado.IDEmpleado INNER JOIN proveedor ON compra.Proveedor_IDProveedor=proveedor.IDProveedor;";
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
