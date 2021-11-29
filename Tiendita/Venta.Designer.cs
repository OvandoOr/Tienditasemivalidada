namespace Tiendita
{
    partial class Venta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Venta));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtrecargoventa = new System.Windows.Forms.TextBox();
            this.Recargo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbformadepago = new System.Windows.Forms.ComboBox();
            this.groupBoxRedondeo = new System.Windows.Forms.GroupBox();
            this.rBredondeono = new System.Windows.Forms.RadioButton();
            this.rbredondeosi = new System.Windows.Forms.RadioButton();
            this.txtdescuentovent = new System.Windows.Forms.TextBox();
            this.txtpagcantventa = new System.Windows.Forms.TextBox();
            this.txtIvavent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtttpagar = new System.Windows.Forms.TextBox();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxRedondeo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(177, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCliente.Location = new System.Drawing.Point(236, 28);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(262, 20);
            this.txtCliente.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.Precio,
            this.Cantidad,
            this.Total});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(41, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(603, 120);
            this.dataGridView1.TabIndex = 3;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // txtrecargoventa
            // 
            this.txtrecargoventa.Location = new System.Drawing.Point(226, 281);
            this.txtrecargoventa.Name = "txtrecargoventa";
            this.txtrecargoventa.Size = new System.Drawing.Size(100, 20);
            this.txtrecargoventa.TabIndex = 4;
            // 
            // Recargo
            // 
            this.Recargo.AutoSize = true;
            this.Recargo.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.Recargo.Location = new System.Drawing.Point(105, 286);
            this.Recargo.Name = "Recargo";
            this.Recargo.Size = new System.Drawing.Size(61, 15);
            this.Recargo.TabIndex = 5;
            this.Recargo.Text = "Recargo";
            this.Recargo.Click += new System.EventHandler(this.Recargo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(105, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Forma de Pago:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(105, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descuento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(105, 394);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pago(Cantidad):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(105, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "IVA (16%)";
            // 
            // cmbformadepago
            // 
            this.cmbformadepago.FormattingEnabled = true;
            this.cmbformadepago.Items.AddRange(new object[] {
            "Seleccionar",
            "Efectivo",
            "Tarjeta"});
            this.cmbformadepago.Location = new System.Drawing.Point(226, 249);
            this.cmbformadepago.Name = "cmbformadepago";
            this.cmbformadepago.Size = new System.Drawing.Size(121, 21);
            this.cmbformadepago.TabIndex = 10;
            this.cmbformadepago.SelectedIndexChanged += new System.EventHandler(this.cmbformadepago_SelectedIndexChanged);
            // 
            // groupBoxRedondeo
            // 
            this.groupBoxRedondeo.Controls.Add(this.rBredondeono);
            this.groupBoxRedondeo.Controls.Add(this.rbredondeosi);
            this.groupBoxRedondeo.Location = new System.Drawing.Point(385, 260);
            this.groupBoxRedondeo.Name = "groupBoxRedondeo";
            this.groupBoxRedondeo.Size = new System.Drawing.Size(158, 44);
            this.groupBoxRedondeo.TabIndex = 13;
            this.groupBoxRedondeo.TabStop = false;
            this.groupBoxRedondeo.Text = "Redondeo";
            // 
            // rBredondeono
            // 
            this.rBredondeono.AutoSize = true;
            this.rBredondeono.Location = new System.Drawing.Point(100, 19);
            this.rBredondeono.Name = "rBredondeono";
            this.rBredondeono.Size = new System.Drawing.Size(39, 17);
            this.rBredondeono.TabIndex = 1;
            this.rBredondeono.TabStop = true;
            this.rBredondeono.Text = "No";
            this.rBredondeono.UseVisualStyleBackColor = true;
            // 
            // rbredondeosi
            // 
            this.rbredondeosi.AutoSize = true;
            this.rbredondeosi.Location = new System.Drawing.Point(23, 20);
            this.rbredondeosi.Name = "rbredondeosi";
            this.rbredondeosi.Size = new System.Drawing.Size(34, 17);
            this.rbredondeosi.TabIndex = 0;
            this.rbredondeosi.TabStop = true;
            this.rbredondeosi.Text = "Si";
            this.rbredondeosi.UseVisualStyleBackColor = true;
            // 
            // txtdescuentovent
            // 
            this.txtdescuentovent.Location = new System.Drawing.Point(226, 313);
            this.txtdescuentovent.Name = "txtdescuentovent";
            this.txtdescuentovent.Size = new System.Drawing.Size(100, 20);
            this.txtdescuentovent.TabIndex = 14;
            // 
            // txtpagcantventa
            // 
            this.txtpagcantventa.Location = new System.Drawing.Point(227, 393);
            this.txtpagcantventa.Name = "txtpagcantventa";
            this.txtpagcantventa.Size = new System.Drawing.Size(100, 20);
            this.txtpagcantventa.TabIndex = 15;
            // 
            // txtIvavent
            // 
            this.txtIvavent.Location = new System.Drawing.Point(226, 339);
            this.txtIvavent.Name = "txtIvavent";
            this.txtIvavent.Size = new System.Drawing.Size(100, 20);
            this.txtIvavent.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(103, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Total a pagar*";
            // 
            // txtttpagar
            // 
            this.txtttpagar.Location = new System.Drawing.Point(226, 365);
            this.txtttpagar.Name = "txtttpagar";
            this.txtttpagar.Size = new System.Drawing.Size(100, 20);
            this.txtttpagar.TabIndex = 18;
            // 
            // txtCambio
            // 
            this.txtCambio.Location = new System.Drawing.Point(228, 420);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(100, 20);
            this.txtCambio.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(138, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "Cambio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Quicksand Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(286, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 30);
            this.label8.TabIndex = 23;
            this.label8.Text = "Ventas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCambio);
            this.groupBox1.Controls.Add(this.txtttpagar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIvavent);
            this.groupBox1.Controls.Add(this.txtpagcantventa);
            this.groupBox1.Controls.Add(this.txtdescuentovent);
            this.groupBox1.Controls.Add(this.groupBoxRedondeo);
            this.groupBox1.Controls.Add(this.cmbformadepago);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Recargo);
            this.groupBox1.Controls.Add(this.txtrecargoventa);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 517);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Tiendita.Properties.Resources.if_thefreeforty_receipt_12436951;
            this.button1.Location = new System.Drawing.Point(485, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 86);
            this.button1.TabIndex = 22;
            this.button1.Text = "Generar ticket";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::Tiendita.Properties.Resources.if___Cross_1904654__2_;
            this.btnCancelar.Location = new System.Drawing.Point(337, 40);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 65);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.FlatAppearance.BorderSize = 0;
            this.btnNuevaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaVenta.Image = global::Tiendita.Properties.Resources.if___Plus_1904677__1_;
            this.btnNuevaVenta.Location = new System.Drawing.Point(213, 40);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(122, 65);
            this.btnNuevaVenta.TabIndex = 0;
            this.btnNuevaVenta.UseVisualStyleBackColor = true;
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Wheat;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(385, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 41);
            this.button2.TabIndex = 23;
            this.button2.Text = "Total a pagar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(385, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 42);
            this.button3.TabIndex = 24;
            this.button3.Text = "Cambio";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(105, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 25;
            this.label9.Text = "Sub total";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(226, 217);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 26;
            // 
            // Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 627);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevaVenta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Venta";
            this.Text = "Venta";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Venta_FormClosing);
            this.Load += new System.EventHandler(this.Venta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxRedondeo.ResumeLayout(false);
            this.groupBoxRedondeo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtrecargoventa;
        private System.Windows.Forms.Label Recargo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbformadepago;
        private System.Windows.Forms.GroupBox groupBoxRedondeo;
        private System.Windows.Forms.RadioButton rBredondeono;
        private System.Windows.Forms.RadioButton rbredondeosi;
        private System.Windows.Forms.TextBox txtdescuentovent;
        private System.Windows.Forms.TextBox txtpagcantventa;
        private System.Windows.Forms.TextBox txtIvavent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtttpagar;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}