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
    public partial class Producto : Form
    {
        int ps;
        string p="";
        public static Producto mostrar;

        public static Producto ver()
        {
            if (mostrar == null)
            {
                mostrar = new Producto();
            }
            return mostrar;
        }
        public Producto()
        {
            InitializeComponent();
            datagrid();
            Idpro.Enabled = false;
            Btnnuevopro.Enabled = true;
            Btnguardarpro.Enabled = false;
            Btncancelarpro.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            dataGridView1.MouseClick += new MouseEventHandler(dataGridView1_MouseClick);
        }

        private void Nombrepro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Descripcionpro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar!=(char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Costopro_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void Producto_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrar = null;
        }
        public void datagrid()
        {
            string buscar = textBox1.Text;
            string q = "SELECT * FROM examen.productos;";
            if (buscar.Length != 0)
            {
                //ejecutar con like
                q = "SELECT * FROM examen.productos where concat(NombreProd,' ',DescripcionProd) like '%" + buscar + "%';";
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
        public void cancelar()
        {
            Btnnuevopro.Enabled = true;
            Btnguardarpro.Enabled = false;
            Btncancelarpro.Enabled = false;
            groupBox1.Enabled = false;
            Idpro.Clear();
            Nombrepro.Clear();
            Descripcionpro.Clear();
            Existenciapro.Clear();
            Costopro.Clear();
            Preciopro.Clear();
            Tipopro.Clear();
        }
        public void nuevo()
        {
            Btnnuevopro.Enabled = false;
            Btnguardarpro.Enabled = true;
            Btncancelarpro.Enabled = true;
            groupBox1.Enabled = true;
            Idpro.Clear();
            Nombrepro.Clear();
            Descripcionpro.Clear();
            Existenciapro.Clear();
            Costopro.Clear();
            Preciopro.Clear();
            Tipopro.Clear();
        }

        private void Btnnuevopro_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void Btncancelarpro_Click(object sender, EventArgs e)
        {
            cancelar();
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
            //throw new NotImplementedException();
            string id = Convert.ToString(dataGridView1[0,ps].Value);
            p = id;
            switch (e.ClickedItem.Name.ToString())
            {
                case "Eliminar":
                    //eliminar
                    
                    MySqlCommand c = new MySqlCommand("DELETE FROM productos WHERE IDProductos='" + id + "';",Conexion.ObtenerConexion());
                    int rows = c.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Eliminado con exito");
                        SoundPlayer sp7 = new SoundPlayer(@"C:\Audios\audio4.wav");
                        sp7.Play();
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
                        MySqlCommand com = new MySqlCommand("SELECT * FROM examen.productos WHERE IDProductos='"+id+"';", Conexion.ObtenerConexion());
                        MySqlDataReader dr = com.ExecuteReader();

                        if (dr.Read())
                        {
                            nuevo();
                            Idpro.Text = Convert.ToString(dr["IDProductos"]);
                            Nombrepro.Text = Convert.ToString(dr["NombreProd"]);
                            Descripcionpro.Text = Convert.ToString(dr["DescripcionProd"]);
                            Existenciapro.Text = Convert.ToString(dr["Existencia"]);
                            Costopro.Text = Convert.ToString(dr["Costo"]);
                            Preciopro.Text = Convert.ToString(dr["Precio"]);
                            Tipopro.Text = Convert.ToString(dr["TipoPro"]);
                            
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    break;
            }
        }

        private void Btnguardarpro_Click(object sender, EventArgs e)
        {
            string id, nombre, desc, exi, costo, precio, tipo;
            id = Idpro.Text;
            nombre = Nombrepro.Text;
            desc = Descripcionpro.Text;
            exi = Existenciapro.Text;
            costo = Costopro.Text;
            precio = Preciopro.Text;
            tipo = Tipopro.Text;
            if (nombre.Length==0 || desc.Length==0 || exi.Length==0 || costo.Length==0 || precio.Length==0 || tipo.Length==0)
            {
                MessageBox.Show("Campos faltantes");
            }else if (id.Length != 0)
            {
                //modificar :v
                MySqlCommand c = new MySqlCommand("UPDATE examen.productos SET NombreProd='"+nombre+"', DescripcionProd='"+desc+"', Existencia='"+exi+"', Costo='"+costo+"', Precio='"+precio+"', TipoPro='"+tipo+"' WHERE IDProductos='"+Idpro.Text+"';", Conexion.ObtenerConexion());
                int rows = c.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Modificado con exito");
                    SoundPlayer sp8 = new SoundPlayer(@"C:\Audios\audio5.wav");
                    sp8.Play();
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
                MySqlCommand c = new MySqlCommand("INSERT INTO `examen`.`productos` (`NombreProd`, `DescripcionProd`, `Existencia`, `Costo`, `Precio`, `TipoPro`) VALUES ('"+nombre+"', '"+desc+"', '"+exi+"', '"+costo+"', '"+precio+"', '"+tipo+"');", Conexion.ObtenerConexion());
                int rows = c.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Agregado con exito");
                    SoundPlayer sp9 = new SoundPlayer(@"C:\Audios\audio6.wav");
                    sp9.Play();
                }
                else
                {
                    MessageBox.Show("No se agregó");
                }
                datagrid();
                cancelar();
            }
        }
        //INSERT INTO `examen`.`productos` (`NombreProd`, `DescripcionProd`, `Existencia`, `Costo`, `Precio`, `TipoPro`) VALUES ('fanta 600ml', 'bebida gaseosa', '299', '8', '12', 'refresco');
        //UPDATE `examen`.`productos` SET `NombreProd`='coca-cola 600 ml', `DescripcionProd`='bebida gaseosa saborizada', `Existencia`='600', `Costo`='9', `Precio`='13', `TipoPro`='Refresco' WHERE `IDProductos`='3';
        //DELETE FROM productos WHERE IDProductos='3';
    }
}
