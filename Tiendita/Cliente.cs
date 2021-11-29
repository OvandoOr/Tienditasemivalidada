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
    public partial class Cliente : Form
    {
        int ps;
        string p = "";
        public static Cliente mostrar;

        public static Cliente ver()
        {
            if (mostrar == null)
            {
                mostrar = new Cliente();
            }
            return mostrar;
        }

        public Cliente()
        {
            InitializeComponent();
            Idclien.Enabled = false;
            cancelar();
            datagrid();
        }
        private void Cliente_Load(object sender, EventArgs e)
        {
            dataGridView1.MouseClick += new MouseEventHandler(dataGridView1_MouseClick);
        }

        private void Nombreclien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Apellidoclien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Direccionclien_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cpostalclient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if ((Cpostalclient.Text.Length > 4) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Excedió rango", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void CURPclien_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Telefonoclien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if ((Telefonoclien.Text.Length > 6) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Excedió rango", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Celularclien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if ((Celularclien.Text.Length > 9) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Excedió rango", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        
        private void Cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrar = null;
        }

        public void datagrid()
        {
            string buscar = txtxbuscar.Text;
            string q = "SELECT * FROM examen.cliente;";
            if (buscar.Length != 0)
            {
                //ejecutar con like
                q = "SELECT * FROM examen.cliente where concat(NombreClie,' ',ApellidoClie) like '%"+buscar+"%';";
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

        private void txtxbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            datagrid();
        }

        public void nuevo()
        {
            Nombreclien.Clear();
            Apellidoclien.Clear();
            Direccionclien.Clear();
            Cpostalclient.Clear();
            CURPclien.Clear();
            Correoelectronicoclien.Clear();
            Telefonoclien.Clear();
            Celularclien.Clear();
            Idclien.Clear();
            sexoclien.SelectedItem = "Selecionar";
            Btnnuevoclien.Enabled = false;
            Btnguardarclien.Enabled = true;
            Btncancelarclien.Enabled = true;
            groupBox1.Enabled = true;
        }
        public void cancelar()
        {
            Idclien.Clear();
            Nombreclien.Clear();
            Apellidoclien.Clear();
            Direccionclien.Clear();
            Cpostalclient.Clear();
            CURPclien.Clear();
            Correoelectronicoclien.Clear();
            Telefonoclien.Clear();
            Celularclien.Clear();
            sexoclien.SelectedItem = "Selecionar";
            Btnnuevoclien.Enabled = true;
            Btnguardarclien.Enabled = false;
            Btncancelarclien.Enabled = false;
            groupBox1.Enabled = false;
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
            string id = Convert.ToString(dataGridView1[0, ps].Value);
            p = id;
            switch (e.ClickedItem.Name.ToString())
            {
                case "Eliminar":
                    //eliminar

                    MySqlCommand c = new MySqlCommand("DELETE FROM cliente WHERE IDCliente='" + id + "';", Conexion.ObtenerConexion());
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
                        MySqlCommand com = new MySqlCommand("SELECT * FROM examen.cliente WHERE IDCliente='" + id + "';", Conexion.ObtenerConexion());
                        MySqlDataReader dr = com.ExecuteReader();

                        if (dr.Read())
                        {
                            nuevo();
                            Idclien.Text = Convert.ToString(dr["IDCliente"]);
                            Nombreclien.Text = Convert.ToString(dr["NombreClie"]);
                            Apellidoclien.Text = Convert.ToString(dr["ApellidoClie"]);
                            Direccionclien.Text = Convert.ToString(dr["DireciónClie"]);
                            Cpostalclient.Text = Convert.ToString(dr["CodPostalClie"]);
                            CURPclien.Text = Convert.ToString(dr["CURPClie"]);
                            Correoelectronicoclien.Text = Convert.ToString(dr["CorreoElectronico"]);
                            Telefonoclien.Text = Convert.ToString(dr["Telefono"]);
                            Celularclien.Text = Convert.ToString(dr["Celular"]);
                            sexoclien.SelectedItem = Convert.ToString(dr["Sexo_cliente"]);

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    break;
            }
        }

        private void Btnnuevoclien_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void Btncancelarclien_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void Btnguardarclien_Click(object sender, EventArgs e)
        {
            //guardar :c 
            //2:57 AM
            string id, nombre, apellido, dir, cod, curp, correo, telefono, cel, sexo;
            id = Idclien.Text;
            nombre = Nombreclien.Text;
            apellido = Apellidoclien.Text;
            dir = Direccionclien.Text;
            cod = Cpostalclient.Text;
            curp = CURPclien.Text;
            correo = Correoelectronicoclien.Text;
            telefono = Telefonoclien.Text;
            cel = Celularclien.Text;
            sexo = sexoclien.Text;
            if (nombre.Length == 0  || apellido.Length == 0 || dir.Length == 0 || cod.Length == 0 || curp.Length == 0 || correo.Length==0 || telefono.Length==0 || cel.Length==0 || sexo== "Selecionar")
            {
                MessageBox.Show("Campos faltantes");
            }
            else if (id.Length != 0)
            {
                //modificar :v
                MySqlCommand c = new MySqlCommand("UPDATE `examen`.`cliente` SET `NombreClie`='"+nombre+"', `ApellidoClie`='"+apellido+"', `DireciónClie`='"+dir+" ', `CodPostalClie`='"+cod+"', `CURPClie`='"+curp+"', `CorreoElectronico`='"+correo+"', `Telefono`='"+telefono+"', `Celular`='"+cel+"', `Sexo_cliente`='"+sexo+"' WHERE `IDCliente`='"+Idclien.Text+"';", Conexion.ObtenerConexion());
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
                MySqlCommand c = new MySqlCommand("INSERT INTO `examen`.`cliente` (`NombreClie`, `ApellidoClie`, `DireciónClie`, `CodPostalClie`, `CURPClie`, `CorreoElectronico`, `Telefono`, `Celular`, `Sexo_cliente`) VALUES ('"+nombre+"', '"+apellido+"', '"+dir+"', '"+cod+"', '"+curp+"', '"+correo+"', '"+telefono+"', '"+cel+"', '"+sexo+"');", Conexion.ObtenerConexion());
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
        //QWERTYUIOPASDFGHJKLÑZXCVBNM

        //INSERT INTO `examen`.`cliente` (`NombreClie`, `ApellidoClie`, `DireciónClie`, `CodPostalClie`, `CURPClie`, `CorreoElectronico`, `Telefono`, `Celular`, `Sexo_cliente`) VALUES ('Maria', 'López', 'Real del Valle #300', '82132', 'LHCDKCJH65', 'maylopez@hotmail.com', '9836521', '6699926826', 'Femenino');
        //UPDATE `examen`.`cliente` SET `NombreClie`='Mariana', `ApellidoClie`='Zatarain', `DireciónClie`='Francisco Villa ', `CodPostalClie`='82127', `CURPClie`='LHLDKCJH65', `CorreoElectronico`='marzat@hotmail.com', `Telefono`='9836522', `Celular`='6699926898', `Sexo_cliente`='Masculino' WHERE `IDCliente`='2';
    }
}
