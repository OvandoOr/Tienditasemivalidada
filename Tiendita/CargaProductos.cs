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
    /*
     * m1: 1 venta, 2 compra
     * m2: 1 agregar, 2 modificar
     * m3: nombre
     * m4: cantidad 
     */
    public partial class CargaProductos : Form
    {
        string M1, M2, Nombre, Cantidad, pos, id, precio, stock,ide,costo;
        public CargaProductos(string m1, string m2, string nombre, string cantidad, string ot, string idem)
        {
            InitializeComponent();
            M1 = m1;
            M2 = m2;
            Nombre = nombre;
            Cantidad = cantidad;
            pos = ot;
            ide = idem;
            cargardatos();
        }

        public void cargardatos()
        {
            if (M2 == "2")
            {
                txtcantidad.Text = Cantidad;
                txtnombre.Text = Nombre;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            comprobarcantidad();
            string nom="", can="";
            nom = txtnombre.Text;
            can = txtcantidad.Text;
            int cant = Convert.ToInt32(can), st = Convert.ToInt32(stock);
            if (M1.Equals("1"))
            {
                //agregar
                    if (nom.Length!=0 && can.Length!=0)
                    {
                    //regresar a ventas
                    Venta v = Venta.ver(ide);
                    /*
                    v.agregardata();
                    */
                    if (cant > st)
                    {
                        MessageBox.Show("Sólo contamos con "+(st)+" en inventario");
                    }
                    else
                    {
                        v.agregardata(id, Nombre, can, precio, pos);
                        this.Hide();
                    }
                    }
                    else
                    {
                        MessageBox.Show("Llenar campos vacios");
                    }
                
            }
            else
            {
                //comprar
                if (nom.Length != 0 && can.Length != 0)
                {
                    //regresar a ventas
                    Compra v = Compra.ver(ide);
                    /*
                    v.agregardata();
                    */
                    if (cant > st)
                    {
                        MessageBox.Show("Sólo contamos con " + (st) + " en inventario");
                    }
                    else
                    {
                        v.agregardata(id, Nombre, can, costo, pos);
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Llenar campos vacios");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CargaProductos_Load(object sender, EventArgs e)
        {
            autompletar(txtnombre);
        }
        public void autompletar(TextBox cliente)
        {

            try
            {
                MySqlCommand com = new MySqlCommand("SELECT * FROM examen.productos;", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    cliente.AutoCompleteCustomSource.Add(dr["NombreProd"].ToString());
                }
                dr.Close();
            }
            catch
            {

            }
        }
        public void comprobarcantidad()
        {
            //string stock ="";
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT * FROM examen.productos WHERE NombreProd='"+txtnombre.Text+"';", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    stock = Convert.ToString(dr["Existencia"]);
                    id = Convert.ToString(dr["IDProductos"]);
                    Nombre = Convert.ToString(dr["NombreProd"]);
                    precio = Convert.ToString(dr["Precio"]);
                    costo = Convert.ToString(dr["Costo"]);
                }
                dr.Close();
            }
            catch
            {

            }
            //return stock;
        }
    }
}
