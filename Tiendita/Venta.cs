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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Tiendita
{
    public partial class Venta : Form
    {
        int ps;
        string empleado;
        public Venta(string emp)
        {
            InitializeComponent();
            empleado = emp;
            MessageBox.Show(empleado);
            cancelar();
        }
        /*
        public Venta()
        {
        }*/

        public static Venta mostrar;

        public static Venta ver(string ide)
        {
            if (mostrar == null)
            {
                mostrar = new Venta(ide);
            }
            return mostrar;
        }

        private void Venta_FormClosing(object sender, FormClosingEventArgs e)
        {
            mostrar = null;
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            autompletar(txtCliente);
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
                ps = poss;
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
            //string id = Convert.ToString(dataGridView1[0, ps].Value);
            
            switch (e.ClickedItem.Name.ToString())
            {
                case "Agregar":
                    //agregar
                    CargaProductos c = new CargaProductos("1","1","","","",empleado);
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
                    CargaProductos c2 = new CargaProductos("1", "2",uno,dos,""+ps,empleado);
                    c2.ShowDialog();
                    break;
            }
        }

        private void Recargo_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }
        public void cancelar()
        {
            groupBox1.Enabled = false;
            btnNuevaVenta.Enabled = true;
            btnCancelar.Enabled = false;
            txtCliente.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            //
            txtrecargoventa.Clear();
            cmbformadepago.SelectedItem = "Seleccionar";
            txtdescuentovent.Clear();
            txtIvavent.Clear();
            txtttpagar.Clear();
            txtpagcantventa.Clear();
            txtCambio.Clear();
            rBredondeono.Checked = true;
            textBox1.Clear();

        }

        public void nuevo()
        {
            groupBox1.Enabled = true;
            btnNuevaVenta.Enabled = false;
            btnCancelar.Enabled = true;
            dataGridView1.Rows.Clear();
            txtCliente.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Add();
            //
            txtrecargoventa.Clear();
            textBox1.Clear();
            cmbformadepago.SelectedItem = "Seleccionar";
            txtdescuentovent.Clear();
            txtIvavent.Clear();
            txtttpagar.Clear();
            txtpagcantventa.Clear();
            txtCambio.Clear();
            rBredondeono.Checked = true;
        }

        public void autompletar(TextBox cliente)
        {
            
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT concat(NombreClie,' ',ApellidoClie) as nombre FROM examen.cliente;", Conexion.ObtenerConexion());
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

        public void agregardata(string id, string nombre, string cantidad,string precio, string ps)
        {
            double can = Double.Parse(cantidad), pre =  Double.Parse(precio);
            double res = can * pre;
            if (ps.Equals(""))
            {
                //agregar
                
                dataGridView1.Rows.Insert(0,id, nombre, precio,cantidad, ""+res);
            }
            else
            {
                //modificar
                int posi = Convert.ToInt32(ps);
                dataGridView1.Rows[posi].Cells[0].Value = id;
                dataGridView1.Rows[posi].Cells[1].Value = nombre;
                dataGridView1.Rows[posi].Cells[3].Value = cantidad;
                dataGridView1.Rows[posi].Cells[2].Value = precio;
                dataGridView1.Rows[posi].Cells[4].Value = ""+res;
            }
            subtottal();
        }
        public  void subtottal()
        {
            double totaltemp, suma;
            int data = dataGridView1.RowCount;
            suma = 0;
            //MessageBox.Show("Kheeee"+(data));
            for (int i=0; i<(data-1);i++)
            {
                totaltemp = Double.Parse(Convert.ToString(dataGridView1[4, i].Value));
                 suma = suma + totaltemp;
               // MessageBox.Show((i)+"Kheeee" + (Convert.ToString(dataGridView1[4, i].Value)));
            }
            textBox1.Text = "" + suma;
        }

        private void cmbformadepago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmb = cmbformadepago.Text;
            if (cmb.Equals("Tarjeta"))
            {
                txtrecargoventa.Text = ""+((double.Parse(textBox1.Text))*.2);
            }
            else
            {
                txtrecargoventa.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //tottal a pagar
            //rescargo :v 
            string cmb = cmbformadepago.Text;
            if (cmb.Equals("Tarjeta"))
            {
                txtrecargoventa.Text = "" + ((double.Parse(textBox1.Text))*.2);
            }
            else
            {
                txtrecargoventa.Text = "0";
            }
            //buscar cuantas compras tiene el cliente 
            //  primero id del cliente
            string idcliente = "";
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT IDCliente FROM cliente where concat(NombreClie,' ',ApellidoClie)='"+txtCliente.Text+"';", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    idcliente = Convert.ToString(dr["IDCliente"]);

                }
            }
            catch (Exception ex)
            {

            }
            //   segundo obtener el numero de compras 
            string numven = "";
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT COUNT(*) AS ventas FROM venta where Cliente_IDCliente='"+idcliente+"';", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    numven = Convert.ToString(dr["ventas"]);
                }
            }
            catch (Exception ex)
            {

            }
            //  ver si se le hará descuento con un switch :o 
            
            switch (numven)
            {
                case "9":
                    txtdescuentovent.Text = "" + ((double.Parse(textBox1.Text))*(.1));
                    break;
                case "19":
                    txtdescuentovent.Text = "" + ((double.Parse(textBox1.Text))*(.2));

                    break;
                case "49":
                    txtdescuentovent.Text = "" + ((double.Parse(textBox1.Text))*(.5));
                    break;
                default:
                    txtdescuentovent.Text = "0";
                    break;
                
            }
            //calcular el iva y el redondeo 
            txtIvavent.Text = "" + ((double.Parse(textBox1.Text))*.16);
            double tt = double.Parse(textBox1.Text) + double.Parse(txtrecargoventa.Text) - double.Parse(txtdescuentovent.Text)+ double.Parse(txtIvavent.Text);
            if (rbredondeosi.Checked)
            {
                //se redondea
                tt = Math.Round(tt)+5;
            }
            txtttpagar.Text = ""+tt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //calcular cambio 
            txtCambio.Text = "" + ((Double.Parse(txtpagcantventa.Text))-(Double.Parse(txtttpagar.Text)));

        }

        DateTime dt = DateTime.Now;

        private void button1_Click(object sender, EventArgs e)
        {
            //INSERT INTO `examen`.`compra` (`FechaCompra`, `Monto`, `Empleado_IDEmpleado`, `Proveedor_IDProveedor`, `Tipodepago`) VALUES ('2017-10-18', '100', '1', '1', 'Efectivo');
            //UPDATE `examen`.`compra` SET `FechaCompra`='2017-10-17 00:00:00', `Monto`='10', `Empleado_IDEmpleado`='2', `Proveedor_IDProveedor`='3', `Tipodepago`='Tarjeta' WHERE `IDCompra`='1';

            //string fecha = dt.ToString("yyyy-MM-dd")+" "+dt.ToString("hh:mm:ss");
            string fecha = dt.ToString("yyyy-MM-dd");
            //id cliente 
            string idcliente = "";
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT IDCliente FROM cliente where concat(NombreClie,' ',ApellidoClie)='" + txtCliente.Text + "';", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    idcliente = Convert.ToString(dr["IDCliente"]);

                }
            }
            catch (Exception ex)
            {

            }
            //guardar en venta primero 
            //conocer hora y fecha exacta :v it's very importatnt 
            MySqlCommand c = new MySqlCommand("INSERT INTO `examen`.`venta` (`FechaVenta`, `Monto`, `Empleado_IDEmpleado`, `Cliente_IDCliente`, `IVA`, `Descuento`, `Recarga`, `Redondeo`, `Tipodepago`) VALUES ('"+fecha+"', '"+txtttpagar.Text+"', '"+empleado+"', '"+idcliente+"', '"+txtIvavent.Text+"', '"+txtdescuentovent.Text+"', '"+txtrecargoventa.Text+"', '5', '"+cmbformadepago.Text+"');", Conexion.ObtenerConexion());
            int rows = c.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("Agregado con exito venta");
            }
            else
            {
                MessageBox.Show("No se agregó");
            }
            //Obtener id del que se caba de guardar 
            string idventa = "";
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT IDVenta FROM examen.venta order by IDVenta DESC;", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    idventa = Convert.ToString(dr["IDVenta"]);
                    MessageBox.Show("ID de la venta: "+idventa);
                }
            }
            catch (Exception ex)
            {

            }
            //después guardar en detalle de venta todos los de data grid view :o 
            int data = dataGridView1.RowCount;
            for (int i = 0; i < (data - 1); i++)
            {
                /* totaltemp = Double.Parse(Convert.ToString(dataGridView1[4, i].Value));
                 suma = suma + totaltemp;*/
                // MessageBox.Show((i)+"Kheeee" + (Convert.ToString(dataGridView1[4, i].Value)));
                //INSERT INTO `examen`.`detalleventa` (`Venta_IDVenta`, `Productos_IDProductos`, `PrecioDeVenta`, `CantidadVenta`) VALUES ('""', '6', '100', '5');
                MySqlCommand c2 = new MySqlCommand("INSERT INTO `examen`.`detalleventa` (`Venta_IDVenta`, `Productos_IDProductos`, `PrecioDeVenta`, `CantidadVenta`) VALUES ('"+idventa+"', '"+Convert.ToString(dataGridView1[0, i].Value)+ "', '"+Convert.ToString(dataGridView1[2, i].Value)+"', '"+Convert.ToString(dataGridView1[3, i].Value)+ "');", Conexion.ObtenerConexion());
                int rows2 = c2.ExecuteNonQuery();
                if (rows2 > 0)
                {
                    MessageBox.Show("Agregado con exito");
                    SoundPlayer sp12 = new SoundPlayer(@"C:\Audios\audio6.wav");
                    sp12.Play();
                }
                else
                {
                    MessageBox.Show("No se agregó");
                }
                //conocer la cantidad de cada id de producto 
                //SELECT Existencia FROM examen.productos WHERE IDProductos=8;
                double de = 0, en=0;
                try
                {
                    MySqlCommand com = new MySqlCommand("SELECT Existencia FROM examen.productos WHERE IDProductos="+Convert.ToString(dataGridView1[0, i].Value)+";", Conexion.ObtenerConexion());
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
                en = de - double.Parse(Convert.ToString(dataGridView1[3, i].Value));
                //guardar en base de datos
                //UPDATE `examen`.`productos` SET `Existencia`='2000' WHERE `IDProductos`='6';
                MySqlCommand c4 = new MySqlCommand("UPDATE `examen`.`productos` SET `Existencia`='"+en+"' WHERE `IDProductos`='"+ Convert.ToString(dataGridView1[0, i].Value) + "';", Conexion.ObtenerConexion());
                int rows4 = c4.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Modificado con exito");
                    SoundPlayer sp13 = new SoundPlayer(@"C:\Audios\audio5.wav");
                    sp13.Play();
                }
                else
                {
                    MessageBox.Show("No se modificó");
                }
            }

            //generar el tikeck coon la información
            crearticket(idventa);
            cancelar();
        }
        //INSERT INTO `examen`.`venta` (`FechaVenta`, `Monto`, `Empleado_IDEmpleado`, `Cliente_IDCliente`, `IVA`, `Descuento`, `Recarga`, `Redondeo`, `Tipodepago`) VALUES ('2017-10-18', '50', '1', '3', '8', '0', '0', '0', 'Efectivo');
        public void crearticket(string idventa)
        {
            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\Audios\venta"+idventa+".pdf", FileMode.Create));
            //C:\
            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Venta "+idventa);
            doc.AddCreator("\nTotal a pagar: " + txtttpagar.Text);

            // Abrimos el archivo
            doc.Open();
            string vendedor = "";
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT concat(NombreEmp, ' ' , ApellidoEmp) as nombre FROM examen.empleado WHERE IDEmpleado="+empleado+";", Conexion.ObtenerConexion());
                MySqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    vendedor =Convert.ToString(dr["nombre"]);

                }
            }
            catch (Exception ex)
            {

            }
            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Venta: " + idventa));
            doc.Add(new Paragraph("Total a pagar: " + txtttpagar.Text));
            doc.Add(new Paragraph("Cliente: "+txtCliente.Text));
            doc.Add(new Paragraph("Vendedor"+ vendedor));
            string fecha=dt.ToString("yyyy-MM-dd"), hora=dt.ToString("hh:mm:ss");
            doc.Add(new Paragraph("Fecha: " + fecha));
            doc.Add(new Paragraph("Hora: " + hora));
            doc.Add(Chunk.NEWLINE);

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Creamos una tabla que contendrá el nombre, apellido y país 
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(5);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clid = new PdfPCell(new Phrase("ID", _standardFont));
            clid.BorderWidth = 0;
            clid.BorderWidthBottom = 0.75f;

            PdfPCell clnom = new PdfPCell(new Phrase("Nombre", _standardFont));
            clnom.BorderWidth = 0;
            clnom.BorderWidthBottom = 0.75f;

            PdfPCell clprecio = new PdfPCell(new Phrase("Precio", _standardFont));
            clprecio.BorderWidth = 0;
            clprecio.BorderWidthBottom = 0.75f;

            PdfPCell clcan = new PdfPCell(new Phrase("Cantidad", _standardFont));
            clcan.BorderWidth = 0;
            clcan.BorderWidthBottom = 0.75f;

            PdfPCell cltotal = new PdfPCell(new Phrase("Total", _standardFont));
            cltotal.BorderWidth = 0;
            cltotal.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
           /* tblPrueba.AddCell(clid);
            tblPrueba.AddCell(clnom);
            tblPrueba.AddCell(clprecio);
            tblPrueba.AddCell(clcan);
            tblPrueba.AddCell(cltotal);*/
            //FOR PARA LLENAR TODO EL DATA GRID VIEW

            // Llenamos la tabla con información
            /*
            clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
            clNombre.BorderWidth = 0;

            clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
            clApellido.BorderWidth = 0;

            clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
            clPais.BorderWidth = 0;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);*/
            int data = dataGridView1.RowCount;
            for (int i = 0; i < (data); i++)
            {
                tblPrueba.AddCell(clid);
                tblPrueba.AddCell(clnom);
                tblPrueba.AddCell(clprecio);
                tblPrueba.AddCell(clcan);
                tblPrueba.AddCell(cltotal);

                clid = new PdfPCell(new Phrase(Convert.ToString(dataGridView1[0, i].Value), _standardFont));
                clid.BorderWidth = 0;

                clnom = new PdfPCell(new Phrase(Convert.ToString(dataGridView1[1, i].Value), _standardFont));
                clnom.BorderWidth = 0;

                clprecio = new PdfPCell(new Phrase(Convert.ToString(dataGridView1[2, i].Value), _standardFont));
                clprecio.BorderWidth = 0;

                clcan = new PdfPCell(new Phrase(Convert.ToString(dataGridView1[3, i].Value), _standardFont));
                clcan.BorderWidth = 0;

                cltotal = new PdfPCell(new Phrase(Convert.ToString(dataGridView1[4, i].Value), _standardFont));
                cltotal.BorderWidth = 0;
            }
                

            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();

            MessageBox.Show("¡PDF creado!");
        }
    }
}
