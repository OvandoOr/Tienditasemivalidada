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
    public partial class Proveedor : Form
    {
        int ps;
        string p = "";
        public static Proveedor mostrar;

        public static Proveedor ver()
        {
            if (mostrar == null)
            {
                mostrar = new Proveedor();
            }
            return mostrar;
        }

        public Proveedor()
        {
            InitializeComponent();
            datagrid();
            cancelar();
            IDProv.Enabled = false;
        }

        private void Telefonoprov_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if ((Telefonoprov.Text.Length > 9) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Excedió rango", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Nombreprov_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Apellidoprov_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Correoprov_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Proveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrar = null;
        }
        public void datagrid()
        {
            string buscar = textBox1.Text;
            string q = "SELECT * FROM examen.proveedor;";
            if (buscar.Length != 0)
            {
                //ejecutar con like
                q = "SELECT * FROM examen.proveedor where concat(NombreProv,' ',ApellidoProv) like '%" + buscar + "%';";
            }
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            datagrid();
        }

        private void Btnnuevopro_Click(object sender, EventArgs e)
        {
            nuevo();
        }
        private void Btncancelarpro_Click(object sender, EventArgs e)
        {
            cancelar();
        }
        
        public void nuevo()
        {
            IDProv.Clear();
            Nombreprov.Clear();
            Apellidoprov.Clear();
            Compañiaprov.Clear();
            Telefonoprov.Clear();
            Giroprov.Clear();
            Correoprov.Clear();
            Direccionprov.Clear();
            Razonsocialprov.Clear();
            CURPprov.Clear();
            RFCprov.Clear();
            groupBox1.Enabled = true;
            Btncancelarpro.Enabled = true;
            BtnGuardarpro.Enabled = true;
            Btnnuevopro.Enabled = false;

        }

        public void cancelar()
        {
            IDProv.Clear();
            Nombreprov.Clear();
            Apellidoprov.Clear();
            Compañiaprov.Clear();
            Telefonoprov.Clear();
            Giroprov.Clear();
            Correoprov.Clear();
            Direccionprov.Clear();
            Razonsocialprov.Clear();
            CURPprov.Clear();
            RFCprov.Clear();
            groupBox1.Enabled = false;
            Btncancelarpro.Enabled = false;
            BtnGuardarpro.Enabled = false;
            Btnnuevopro.Enabled = true;
        }

        private void BtnGuardarpro_Click(object sender, EventArgs e)
        {
            //guardar :c 
            //2:57 AM
            string id, nombre, apellido, compa, tel, giro, correo, razon, curp, rfc, dir;
            id = IDProv.Text;
            nombre = Nombreprov.Text;
            apellido = Apellidoprov.Text;
            compa = Compañiaprov.Text;
            tel = Telefonoprov.Text;
            giro = Giroprov.Text;
            correo = Correoprov.Text;
            razon = Razonsocialprov.Text;
            curp = CURPprov.Text;
            rfc = RFCprov.Text;
            dir = Direccionprov.Text;
         
           if (nombre.Length == 0 || apellido.Length == 0 || compa.Length == 0 || tel.Length == 0 || giro.Length == 0 || correo.Length == 0 || razon.Length == 0 || curp.Length == 0 || rfc.Length ==0)
            {
                MessageBox.Show("Campos faltantes");
            }
            else if (id.Length != 0)
            {
                //modificar :v
                MySqlCommand c = new MySqlCommand("UPDATE `examen`.`proveedor` SET `NombreProv`='"+nombre+"', `ApellidoProv`='"+apellido+ "', `CompaníaProv`='"+compa+ "', `Telefono`='"+tel+ "', `GiroProv`='"+giro+ "', `Correo`='"+correo+ "', `Direccion`='"+dir+ "', `Razonsocial`='"+razon+ "', `CURPProv`='"+curp+ "', `RFCProv`='"+rfc+ "' WHERE `IDProveedor`='"+id+"';", Conexion.ObtenerConexion());
                int rows = c.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Modificado con exito");
                }
                else
                {
                    MessageBox.Show("No se modificó");
                }
                datagrid();
                cancelar();
            }
            else
            {
                //agregar :v
                MySqlCommand c = new MySqlCommand("INSERT INTO `examen`.`proveedor` (`NombreProv`, `ApellidoProv`, `CompaníaProv`, `Telefono`, `GiroProv`, `Correo`, `Direccion`, `Razonsocial`, `CURPProv`, `RFCProv`) VALUES ('" + nombre + "', '" + apellido + "', '" + compa + "', '" + tel + "', '" + giro + "', '" + correo + "', '"+dir+"', '" + razon+"', '" + curp+"', '" + rfc+"');", Conexion.ObtenerConexion());

                int rows = c.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Agregado con exito");
                }
                else
                {
                    MessageBox.Show("No se agregó");
                }
                datagrid();
                cancelar();
            }
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            dataGridView1.MouseClick += new MouseEventHandler(dataGridView1_MouseClick);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

            }
            else
            {
                ContextMenuStrip menu = new System.Windows.Forms.ContextMenuStrip();
                int poss = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                ps = poss;
                // MessageBox.Show(""+poss+" "+ps);
                if (poss >= 0)
                {
                    menu.Items.Add("Eliminar").Name = "Eliminar";
                    menu.Items.Add("Modificar").Name = "Modificar";
                }
                menu.Show(dataGridView1, new Point(e.X, e.Y));
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menu_ItemClicked);
            }
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // throw new NotImplementedException();
            string id = Convert.ToString(dataGridView1[0, ps].Value);
            p = id;
            switch (e.ClickedItem.Name.ToString())
            {
                case "Eliminar":
                    //eliminar

                    MySqlCommand c = new MySqlCommand("DELETE FROM proveedor WHERE IDProveedor='" + id + "';", Conexion.ObtenerConexion());
                    int rows = c.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Eliminado con exito");
                    }
                    else
                    {
                        MessageBox.Show("No se eliminó");
                    }
                    datagrid();
                    break;

                case "Modificar":
                    //caregar datos para modificar
                    try
                    {
                        MySqlCommand com = new MySqlCommand("SELECT * FROM examen.proveedor WHERE IDProveedor='" + id + "';", Conexion.ObtenerConexion());
                        MySqlDataReader dr = com.ExecuteReader();

                        if (dr.Read())
                        {
                            nuevo();
                            IDProv.Text = Convert.ToString(dr["IDProveedor"]);
                            Nombreprov.Text = Convert.ToString(dr["NombreProv"]);
                            Apellidoprov.Text = Convert.ToString(dr["ApellidoProv"]);
                            Compañiaprov.Text = Convert.ToString(dr["CompaníaProv"]);
                            Telefonoprov.Text = Convert.ToString(dr["Telefono"]);
                            Giroprov.Text = Convert.ToString(dr["GiroProv"]);
                            Correoprov.Text = Convert.ToString(dr["Correo"]);
                            Direccionprov.Text = Convert.ToString(dr["Direccion"]);
                            Razonsocialprov.Text = Convert.ToString(dr["Razonsocial"]);
                            CURPprov.Text = Convert.ToString(dr["CURPProv"]);
                            RFCprov.Text = Convert.ToString(dr["RFCProv"]);

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    break;
            }
        }
    }
}
