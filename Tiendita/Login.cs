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
    public partial class Login : Form
    {
        string id="1";
        int intentos;
        public Login()
        {
            InitializeComponent();
            intentos = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ingresar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void ingresar()
        {
            string user, pass;
            user = txtUsuario.Text;
            pass = txtContra.Text;
            string us = "", pa = "";

            if (user.Length == 0 || pass.Length == 0)
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña. ");
            }
            else
            {
                //se procede a saber si están guardado
                
                    if (("123" == user) && ("123" == pass))
                    {
                        MessageBox.Show("Bienvenido");
                      

                        Menuprincipal m = new Menuprincipal(id);
                        m.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrecto");
                        intentos++;
                    }
              
                if (intentos == 3)
                {
                    SoundPlayer sp2 = new SoundPlayer(@"C:\Audios\audio3.wav");
                    sp2.Play();
                    MessageBox.Show("Excedió intentos");
                    this.Hide();


                }
            }
        }
    }
}
