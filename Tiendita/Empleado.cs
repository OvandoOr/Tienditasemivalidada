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
    public partial class Empleado : Form
    {
        int ps;
        string p = "";
        public static Empleado mostrar;

        public static Empleado ver()
        {
            if (mostrar == null)
            {
                mostrar = new Empleado();
            }
            return mostrar;
        }

        public Empleado()
        {
            InitializeComponent();
            idEmp.Enabled = false;
            cancelar();
            datagrid();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            dataGridView1.MouseClick += new MouseEventHandler(dataGridView1_MouseClick);
        }

        private void Telefonoemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if ((Telefonoemp.Text.Length > 6) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Excedió rango", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Celuraremp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            else if ((Celuraremp.Text.Length > 9) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Excedió rango", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Nombreemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Apllidoemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Empleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrar = null;
        }
             public void datagrid()
                {
                    string buscar = textBox1.Text;
                    string q = "select * from empleado inner join puesto on puesto.idPuesto=empleado.Puesto_idPuesto inner join usuario on usuario.Empleado_IDEmpleado=empleado.IDEmpleado;";
                    if (buscar.Length != 0)
                    {
                //ejecutar con like
               q    = "select * from empleado inner join puesto on puesto.idPuesto=empleado.Puesto_idPuesto inner join usuario on usuario.Empleado_IDEmpleado=empleado.IDEmpleado WHERE concat(NombreEmp,' ',ApellidoEmp) LIKE '%"+buscar+"%';";
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

        
        public void nuevo()
        {
            groupBox1.Enabled = true;
            Nombreemp.Clear();
            Apllidoemp.Clear();
            CURPemp.Clear();
            RFCemp.Clear();
            Telefonoemp.Clear();
            Celuraremp.Clear();
            cmbSexoemp.SelectedItem = "Seleccionar";
            cmbpuestoemp.SelectedItem = "Seleccionar";
            idEmp.Clear();
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            txtxCorreo.Clear();
            txtContraseña.Clear();
            txtUsuario.Clear();
        }
        public void cancelar()
        {
            groupBox1.Enabled = false;
            Nombreemp.Clear();
            Apllidoemp.Clear();
            CURPemp.Clear();
            RFCemp.Clear();
            Telefonoemp.Clear();
            Celuraremp.Clear();
            cmbSexoemp.SelectedItem = "Seleccionar";
            cmbpuestoemp.SelectedItem = "Seleccionar";
            idEmp.Clear();
            btnNuevo.Enabled = true;
            btnCancelar.Enabled =false;
            btnGuardar.Enabled = false;
            txtxCorreo.Clear();
            txtContraseña.Clear();
            txtUsuario.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();       }

        private void btnCancelar_Click(object sender, EventArgs e)
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
            // throw new NotImplementedException();
            string id = Convert.ToString(dataGridView1[0, ps].Value);
            p = id;
            switch (e.ClickedItem.Name.ToString())
            {
                case "Eliminar":
                    //eliminar
                    //eliminar usurio primero y después empleado :v 
                    MySqlCommand c = new MySqlCommand("DELETE FROM usuario WHERE Empleado_IDEmpleado='" + id + "';", Conexion.ObtenerConexion());
                    int rows = c.ExecuteNonQuery();
                    if (rows > 0)
                    {
                      //  MessageBox.Show("Eliminado con exito");
                    }
                    else
                    {
                      //   MessageBox.Show("No se eliminó");
                    }
                    MySqlCommand c2 = new MySqlCommand("DELETE FROM empleado WHERE IDEmpleado='" + id + "';", Conexion.ObtenerConexion());
                    rows = c2.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        //  MessageBox.Show("Eliminado con exito");
                    }
                    else
                    {
                        //   MessageBox.Show("No se eliminó");
                    }
                    datagrid();
                    break;

                case "Modificar":
                    //caregar datos para modificar
                    try
                    {
                        //modificar empleado
                        //modificar usuario
                        MySqlCommand com = new MySqlCommand("select * from empleado inner join puesto on puesto.idPuesto=empleado.Puesto_idPuesto inner join usuario on usuario.Empleado_IDEmpleado=empleado.IDEmpleado WHERE IDEmpleado='"+p+"';", Conexion.ObtenerConexion());
                        MySqlDataReader dr = com.ExecuteReader();

                        if (dr.Read())
                        {
                            nuevo();
                     /*     IDProv.Text = Convert.ToString(dr["IDProveedor"]);
                            */
                            idEmp.Text = Convert.ToString(dr["IDEmpleado"]);
                            Nombreemp.Text = Convert.ToString(dr["NombreEmp"]);
                            Apllidoemp.Text= Convert.ToString(dr["ApellidoEmp"]);
                            //fecha
                            CURPemp.Text = Convert.ToString(dr["CURPEmp"]);
                            RFCemp.Text = Convert.ToString(dr["RFCEmp"]);
                            Telefonoemp.Text = Convert.ToString(dr["TelefonoEmp"]);
                            Celuraremp.Text = Convert.ToString(dr["CelularEmp"]);
                            //fecha
                            cmbSexoemp.SelectedItem = Convert.ToString(dr["Sexo"]); 
                            cmbpuestoemp.SelectedItem = Convert.ToString(dr["Tipo_puesto"]);
                            txtUsuario.Text = Convert.ToString(dr["NombreUsuario"]);
                            txtContraseña.Text = Convert.ToString(dr["Contraseña"]);
                            txtxCorreo.Text = Convert.ToString(dr["CorreoEmp"]);
                            DateTime mf2 = dateTimePicker2.Value.Date;
                            DateTime mf = dateTimePicker1.Value.Date;
                            dateTimePicker1.Text = Convert.ToString(dr["FechaNacEmp"]);
                            dateTimePicker2.Text = Convert.ToString(dr["FechaIngEmp"]);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //guardar :c 
            //2:57 AM
            string correo, id, nombre, apellido, fecnac, curp, rfc, usuario, tel, cel, fecing, sex, puesto, contr;
            id = idEmp.Text;
            correo = txtxCorreo.Text;
            nombre = Nombreemp.Text;
            apellido = Apllidoemp.Text;
            DateTime mf = dateTimePicker1.Value.Date;
            fecnac = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            curp = CURPemp.Text;
            rfc = RFCemp.Text;
            usuario = txtUsuario.Text;
            tel = Telefonoemp.Text;
            cel = Celuraremp.Text;
            DateTime mf2 = dateTimePicker2.Value.Date;
            fecing = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            sex = cmbSexoemp.Text;
            puesto = ""+cmbpuestoemp.SelectedIndex;
            contr = txtContraseña.Text;
            if (correo.Length == 0 ||  nombre.Length == 0 || apellido.Length == 0 || curp.Length == 0 || tel.Length == 0 || cel.Length == 0 || sex.Length == 0 || puesto== "0" || rfc.Length == 0 || contr.Length == 0)
            {
                MessageBox.Show("Campos faltantes");
            }
            else if (id.Length != 0)
            {
                //modificar :v
                //modifcar empleado
                //UPDATE `examen`.`empleado` SET `NombreEmp`='Juan Alfredo', `ApellidoEmp`='Carrillo Zatarain', `FechaNacEmp`='1998-09-07 00:00:00', `CURPEmp`='FAAF980827MSLRYR04', `RFCEmp`='FAAF980827MSLRYR04', `TelefonoEmp`='9837035', `CelularEmp`='6699926827', `FechaIngEmp`='2017-10-10 00:00:00', `Sexo`='Femenino', `Puesto_idPuesto`='1', `CorreoEmp`='juan@hotmail.com' WHERE `IDEmpleado`='2';
                MySqlCommand c = new MySqlCommand("UPDATE `examen`.`empleado` SET `NombreEmp`='"+nombre+ "', `ApellidoEmp`='"+apellido+"', `FechaNacEmp`='"+fecnac+" 00:00:00', `CURPEmp`='"+curp+ "', `RFCEmp`='"+rfc+ "', `TelefonoEmp`='"+tel+ "', `CelularEmp`='"+cel+"', `FechaIngEmp`='"+fecing+" 00:00:00', `Sexo`='"+sex+"', `Puesto_idPuesto`='"+puesto+"', `CorreoEmp`='"+correo+"' WHERE `IDEmpleado`='"+id+"';", Conexion.ObtenerConexion());
                int rows = c.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Modificado con exito");
                }
                else
                {
                    MessageBox.Show("No se modificó");
                }
                //modifcar usuario
                //UPDATE `examen`.`usuario` SET `NombreUsuario`='fer', `Contraseña`='123' WHERE `Empleado_IDEmpleado`='fernanda';
                MySqlCommand c2 = new MySqlCommand("UPDATE `examen`.`usuario` SET `NombreUsuario`='"+usuario+"', `Contraseña`='"+contr+"' WHERE `Empleado_IDEmpleado`='"+id+"';", Conexion.ObtenerConexion());
                rows = c2.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Modificado con exito");
                    SoundPlayer sp3 = new SoundPlayer(@"C:\Audios\audio5.wav");
                    sp3.Play();
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
                //primero en empleados
                //INSERT INTO `examen`.`empleado` (`NombreEmp`, `ApellidoEmp`, `FechaNacEmp`, `CURPEmp`, `RFCEmp`, `TelefonoEmp`, `CelularEmp`, `FechaIngEmp`, `Sexo`, `Puesto_idPuesto`, `CorreoEmp`) VALUES ('Gerardo', 'Contreras', '1998-06-06', 'FAAD986532HSLRYT03', 'FAAD986532HSLRYT03', '6682375', '6699722754', '2017-03-03', 'Masculino', '2', 'gera@hotmail.com');

                MySqlCommand c = new MySqlCommand("INSERT INTO `examen`.`empleado` (`NombreEmp`, `ApellidoEmp`, `FechaNacEmp`, `CURPEmp`, `RFCEmp`, `TelefonoEmp`, `CelularEmp`, `FechaIngEmp`, `Sexo`, `Puesto_idPuesto`, `CorreoEmp`) VALUES ('"+nombre+"', '"+apellido+"', '"+fecnac+"', '"+curp+"', '"+rfc+"', '"+tel+"', '"+cel+"', '"+fecing+"', '"+sex+"', '"+puesto+"', '"+correo+"');", Conexion.ObtenerConexion());

               int rows = c.ExecuteNonQuery();
               if (rows > 0)
                {
                    MessageBox.Show("Agregado con exito");
                    SoundPlayer sp4 = new SoundPlayer(@"C:\Audios\audio6.wav");
                    sp4.Play();
                }
                else
                {
                    MessageBox.Show("No se agregó");
                }
               //OBTENER ID CON EL ULTIMO DATO INGRESADO :O 
                string idempus = "";
                    MySqlCommand com = new MySqlCommand("select * from empleado WHERE concat(NombreEmp,ApellidoEmp)='"+nombre+apellido+"';", Conexion.ObtenerConexion());
                    MySqlDataReader dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        nuevo();
                        /*     IDProv.Text = Convert.ToString(dr["IDProveedor"]);
                               */
                        idempus = Convert.ToString(dr["IDEmpleado"]);
                    }
                
                //:O :O :O :O 
                MySqlCommand c2 = new MySqlCommand("INSERT INTO `examen`.`usuario` (`NombreUsuario`, `Contraseña`, `Empleado_IDEmpleado`) VALUES('"+usuario+"', '"+contr+"', '"+idempus+"');", Conexion.ObtenerConexion());
                // INSERT INTO `examen`.`usuario` (`NombreUsuario`, `Contraseña`, `Empleado_IDEmpleado`) VALUES('gera', 'zxc', '3');

                rows = c2.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Agregado con exito");
                    SoundPlayer sp5 = new SoundPlayer(@"C:\Audios\audio6.wav");
                    sp5.Play();
                }
                else
                {
                    MessageBox.Show("No se agregó");
                }
                //luego usuarios 
                datagrid();
                cancelar();
            }
        }

        private void txtxCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            datagrid();
        }
    }
    //select * from empleado inner join puesto on puesto.idPuesto=empleado.Puesto_idPuesto inner join usuario on usuario.Empleado_IDEmpleado=empleado.IDEmpleado;
   
}
