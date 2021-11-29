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
    public partial class Menuprincipal : Form
    {
        string idemple;
        private int childFormNumber = 0;
        string id_user;
        public Menuprincipal(string iduser)
        {
            InitializeComponent();
            id_user = iduser;
            root();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_user == "1")
            {
                Producto a = Producto.ver();
                a.MdiParent = this;
                a.Show();
            }else
            {
                MessageBox.Show("No se puede acceder.");
            }
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_user == "1")
            {
                Empleado a = Empleado.ver();
                a.MdiParent = this;
                a.Show();
            }else
            {
                MessageBox.Show("No se puede acceder.");
            }
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_user == "1")
            {
                Proveedor a = Proveedor.ver();
                a.MdiParent = this;
                a.Show();
            }else
            {
                MessageBox.Show("No se puede acceder.");
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_user == "1")
            {
                Cliente a = Cliente.ver();
                a.MdiParent = this;
                a.Show();
            }else
            {
                MessageBox.Show("No se puede acceder.");
            }
        }
        public void root()
        {
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT IDEmpleado,Puesto_idPuesto FROM examen.empleado WHERE IDEmpleado ='" + id_user+"';", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    id_user = Convert.ToString(dr["Puesto_idPuesto"]);
                    idemple = Convert.ToString(dr["IDEmpleado"]);
                }
            }
            catch (Exception ex)
            {

            }
            MessageBox.Show(idemple);
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Venta a = Venta.ver(idemple);
            a.MdiParent = this;
            a.Show();
        }

        private void consultarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetalleVenta a = DetalleVenta.ver();
            a.MdiParent = this;
            a.Show();
        }

        private void nuevaCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra a = Compra.ver(idemple);
            a.MdiParent = this;
            a.Show();
        }

        private void consultarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetalleCompra a = DetalleCompra.ver();
            a.MdiParent = this;
            a.Show();
        }
    }
}
