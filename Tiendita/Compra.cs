using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tiendita
{
    public partial class Compra : Form
    {
        int ps;
        string empleado;
        public Compra(string id)
        {
            InitializeComponent();
            empleado = id;
            cancelar();
        }

        public static Compra mostrar;

        public static Compra ver(string id)
        {
            if (mostrar == null)
            {
                mostrar = new Compra(id);
            }
            return mostrar;
        }
        private void Compra_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrar = null;
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            autompletar(txtProveedorcomp);
            dataGridView1.MouseClick += new MouseEventHandler(dataGridView1_MouseClick);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Button == MouseButtons.Left)
            {

            }
            else
            {
                ContextMenuStrip menu = new System.Windows.Forms.ContextMenuStrip();
                int poss = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                // ps = poss;
                // MessageBox.Show(""+poss+" "+ps);
                if (poss >= 0)
                {
                    menu.Items.Add("Agregar").Name = "Agregar";
                    menu.Items.Add("Modificar").Name = "Modificar";
                    menu.Items.Add("Eliminar").Name = "Eliminar";


                }
                menu.Show(dataGridView1, new Point(e.X, e.Y));
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menu_ItemClicked);
            }
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //throw new NotImplementedException();
           // string id = Convert.ToString(dataGridView1[0, ps].Value);

            switch (e.ClickedItem.Name.ToString())
            {
                case "Agregar":
                    //agregar
                    CargaProductos c = new CargaProductos("2", "1", "", "", "", empleado);
                    c.ShowDialog();
                    break;
                case "Eliminar":
                    //eliminar
                    dataGridView1.Rows.RemoveAt(ps);
                    subtottal();
                    break;

                case "Modificar":
                    //caregar datos para modificar
                    string uno, dos;
                    uno = Convert.ToString(dataGridView1[1, ps].Value);
                    dos = Convert.ToString(dataGridView1[3, ps].Value);
                    CargaProductos c2 = new CargaProductos("2", "2", uno, dos, "" + ps, empleado);
                    c2.ShowDialog();
                    break;
            }
        }
        public void autompletar(TextBox cliente)
        {

            try
            {
                MySqlCommand com = new MySqlCommand("SELECT concat(NombreProv,' ',ApellidoProv) as nombre FROM examen.proveedor;", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cliente.AutoCompleteCustomSource.Add(dr["nombre"].ToString());
                }
                dr.Close();
            }
            catch
            {

            }
        }
        public void nuevo()
        {
            groupBox1.Enabled = true;
            txtProveedorcomp.Clear();
            txtttpagarcomp.Clear();
            cmbformadepagocomp.SelectedItem = "Seleccionar";
            btnNuevacompra.Enabled = false;
            btncancelarcompra.Enabled = true;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Add();
        }

        public void cancelar()
        {
            groupBox1.Enabled = false;
            txtProveedorcomp.Clear();
            txtttpagarcomp.Clear();
            cmbformadepagocomp.SelectedItem = "Seleccionar";
            btnNuevacompra.Enabled = true;
            btncancelarcompra.Enabled = false;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Add();
        }

        private void btnNuevacompra_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btncancelarcompra_Click(object sender, EventArgs e)
        {
            cancelar();
        }
        public void agregardata(string id, string nombre, string cantidad, string precio, string ps)
        {
            double can = Double.Parse(cantidad), pre = Double.Parse(precio);
            double res = can * pre;
            if (ps.Equals(""))
            {
                //agregar

                dataGridView1.Rows.Insert(0, id, nombre, precio, cantidad, "" + res);
            }
            else
            {
                //modificar
                int posi = Convert.ToInt32(ps);
                dataGridView1.Rows[posi].Cells[0].Value = id;
                dataGridView1.Rows[posi].Cells[1].Value = nombre;
                dataGridView1.Rows[posi].Cells[3].Value = cantidad;
                dataGridView1.Rows[posi].Cells[2].Value = precio;
                dataGridView1.Rows[posi].Cells[4].Value = "" + res;
            }
            subtottal();
        }
        public void subtottal()
        {
            double totaltemp, suma;
            int data = dataGridView1.RowCount;
            suma = 0;
            //MessageBox.Show("Kheeee"+(data));
            for (int i = 0; i < (data - 1); i++)
            {
                totaltemp = Double.Parse(Convert.ToString(dataGridView1[4, i].Value));
                suma = suma + totaltemp;
                // MessageBox.Show((i)+"Kheeee" + (Convert.ToString(dataGridView1[4, i].Value)));
            }
            txtttpagarcomp.Text = "" + suma;
        }
        DateTime dt = DateTime.Now;
        private void btngenerarrecibocomp_Click(object sender, EventArgs e)
        {
            //INSERT INTO `examen`.`compra` (`FechaCompra`, `Monto`, `Empleado_IDEmpleado`, `Proveedor_IDProveedor`, `Tipodepago`) VALUES ('2017-10-18', '100', '1', '1', 'Efectivo');
            //UPDATE `examen`.`compra` SET `FechaCompra`='2017-10-17 00:00:00', `Monto`='10', `Empleado_IDEmpleado`='2', `Proveedor_IDProveedor`='3', `Tipodepago`='Tarjeta' WHERE `IDCompra`='1';

            //string fecha = dt.ToString("yyyy-MM-dd")+" "+dt.ToString("hh:mm:ss");
            string fecha = dt.ToString("yyyy-MM-dd");
            //id cliente 
            string idproveedor = "";
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT IDProveedor FROM examen.proveedor  where concat(NombreProv,' ',ApellidoProv) = '"+txtProveedorcomp.Text+"';", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    idproveedor = Convert.ToString(dr["IDProveedor"]);

                }
            }
            catch (Exception ex)
            {

            }
            //guardar en venta primero 
            //conocer hora y fecha exacta :v it's very importatnt 
            MySqlCommand c = new MySqlCommand("INSERT INTO `examen`.`compra` (`FechaCompra`, `Monto`, `Empleado_IDEmpleado`, `Proveedor_IDProveedor`, `Tipodepago`) VALUES ('"+fecha+"', '"+txtttpagarcomp.Text+"', '"+empleado+"', '"+idproveedor+"', '"+cmbformadepagocomp.Text+"');", Conexion.ObtenerConexion());
            int rows = c.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("Agregado con exito compra");
                SoundPlayer sp6 = new SoundPlayer(@"C:\Audios\audio7.wav");
                sp6.Play();
            }
            else
            {
                MessageBox.Show("No se agregó");
            }
            //Obtener id del que se caba de guardar 
            string idcompra = "";
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT IDCompra FROM examen.compra ORDER BY IDCompra DESC;", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    idcompra = Convert.ToString(dr["IDCompra"]);
                    MessageBox.Show("ID de la compra: " + idcompra);
                }
            }
            catch (Exception ex)
            {

            }
            //después guardar en detalle de venta todos los de data grid view :o 
            int data = dataGridView1.RowCount;
            for (int i = 0; i < (data - 1); i++)
            {
                //INSERT INTO `examen`.`detallecompra` (`Compra_IDCompra`, `Productos_IDProductos`, `CantidadCompra`) VALUES ('1', '6', '11');
                MySqlCommand c2 = new MySqlCommand("INSERT INTO `examen`.`detallecompra` (`Compra_IDCompra`, `Productos_IDProductos`, `CantidadCompra`) VALUES ('"+idcompra+"', '"+Convert.ToString(dataGridView1[0, i].Value)+"', '"+ Convert.ToString(dataGridView1[3, i].Value) + "');", Conexion.ObtenerConexion());
                int rows2 = c2.ExecuteNonQuery();
                if (rows2 > 0)
                {
                    MessageBox.Show("Agregado con exito");
                    SoundPlayer sp11 = new SoundPlayer(@"C:\Audios\audio6.wav");
                    sp11.Play();
                }
                else
                {
                    MessageBox.Show("No se agregó");
                }
                //conocer la cantidad de cada id de producto 
                //SELECT Existencia FROM examen.productos WHERE IDProductos=8;
                double de = 0, en = 0;
                try
                {
                    MySqlCommand com = new MySqlCommand("SELECT Existencia FROM examen.productos WHERE IDProductos=" + Convert.ToString(dataGridView1[0, i].Value) + ";", Conexion.ObtenerConexion());
                    MySqlDataReader dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        de = double.Parse(Convert.ToString(dr["Existencia"]));

                    }
                }
                catch (Exception ex)
                {

                }
                //modificar cada cantidad 
                en = de + double.Parse(Convert.ToString(dataGridView1[3, i].Value));
                //guardar en base de datos
                //UPDATE `examen`.`productos` SET `Existencia`='2000' WHERE `IDProductos`='6';
                MySqlCommand c4 = new MySqlCommand("UPDATE `examen`.`productos` SET `Existencia`='" + en + "' WHERE `IDProductos`='" + Convert.ToString(dataGridView1[0, i].Value) + "';", Conexion.ObtenerConexion());
                int rows4 = c4.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Modificado con exito");
                    SoundPlayer sp10 = new SoundPlayer(@"C:\Audios\audio5.wav");
                    sp10.Play();
                }
                else
                {
                    MessageBox.Show("No se modificó");
                }
            }

            //generar el tikeck coon la información

            cancelar();
        }
    }
}
