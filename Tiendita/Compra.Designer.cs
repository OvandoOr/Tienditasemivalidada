namespace Tiendita
{
    partial class Compra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compra));
            this.cmbformadepagocomp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtProveedorcomp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNuevacompra = new System.Windows.Forms.Button();
            this.btncancelarcompra = new System.Windows.Forms.Button();
            this.txtttpagarcomp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btngenerarrecibocomp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbformadepagocomp
            // 
            this.cmbformadepagocomp.FormattingEnabled = true;
            this.cmbformadepagocomp.Items.AddRange(new object[] {
            "Seleccionar",
            "Efectivo",
            "Terjeta"});
            this.cmbformadepagocomp.Location = new System.Drawing.Point(221, 215);
            this.cmbformadepagocomp.Name = "cmbformadepagocomp";
            this.cmbformadepagocomp.Size = new System.Drawing.Size(121, 21);
            this.cmbformadepagocomp.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(97, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Forma de Pago:";
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
            this.dataGridView1.Location = new System.Drawing.Point(8, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(636, 120);
            this.dataGridView1.TabIndex = 20;
            // 
            // txtProveedorcomp
            // 
            this.txtProveedorcomp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProveedorcomp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProveedorcomp.Location = new System.Drawing.Point(117, 20);
            this.txtProveedorcomp.Name = "txtProveedorcomp";
            this.txtProveedorcomp.Size = new System.Drawing.Size(262, 20);
            this.txtProveedorcomp.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(35, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Proveedor";
            // 
            // btnNuevacompra
            // 
            this.btnNuevacompra.FlatAppearance.BorderSize = 0;
            this.btnNuevacompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevacompra.Image = global::Tiendita.Properties.Resources.if___Plus_1904677__1_;
            this.btnNuevacompra.Location = new System.Drawing.Point(203, 48);
            this.btnNuevacompra.Name = "btnNuevacompra";
            this.btnNuevacompra.Size = new System.Drawing.Size(122, 41);
            this.btnNuevacompra.TabIndex = 17;
            this.btnNuevacompra.UseVisualStyleBackColor = true;
            this.btnNuevacompra.Click += new System.EventHandler(this.btnNuevacompra_Click);
            // 
            // btncancelarcompra
            // 
            this.btncancelarcompra.FlatAppearance.BorderSize = 0;
            this.btncancelarcompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancelarcompra.Image = global::Tiendita.Properties.Resources.if___Cross_1904654__2_;
            this.btncancelarcompra.Location = new System.Drawing.Point(331, 48);
            this.btncancelarcompra.Name = "btncancelarcompra";
            this.btncancelarcompra.Size = new System.Drawing.Size(122, 41);
            this.btncancelarcompra.TabIndex = 32;
            this.btncancelarcompra.UseVisualStyleBackColor = true;
            this.btncancelarcompra.Click += new System.EventHandler(this.btncancelarcompra_Click);
            // 
            // txtttpagarcomp
            // 
            this.txtttpagarcomp.Location = new System.Drawing.Point(220, 258);
            this.txtttpagarcomp.Name = "txtttpagarcomp";
            this.txtttpagarcomp.Size = new System.Drawing.Size(100, 20);
            this.txtttpagarcomp.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand Bold", 9.749999F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(97, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "Total a pagar";
            // 
            // btngenerarrecibocomp
            // 
            this.btngenerarrecibocomp.FlatAppearance.BorderSize = 0;
            this.btngenerarrecibocomp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngenerarrecibocomp.Image = global::Tiendita.Properties.Resources.if_thefreeforty_receipt_12436951;
            this.btngenerarrecibocomp.Location = new System.Drawing.Point(382, 222);
            this.btngenerarrecibocomp.Name = "btngenerarrecibocomp";
            this.btngenerarrecibocomp.Size = new System.Drawing.Size(152, 51);
            this.btngenerarrecibocomp.TabIndex = 37;
            this.btngenerarrecibocomp.UseVisualStyleBackColor = true;
            this.btngenerarrecibocomp.Click += new System.EventHandler(this.btngenerarrecibocomp_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Quicksand Book", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(278, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 30);
            this.label4.TabIndex = 38;
            this.label4.Text = "Compra";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btngenerarrecibocomp);
            this.groupBox1.Controls.Add(this.txtttpagarcomp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbformadepagocomp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.txtProveedorcomp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 305);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
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
            // Compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(663, 408);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btncancelarcompra);
            this.Controls.Add(this.btnNuevacompra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Compra";
            this.Text = "Compra";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Compra_FormClosing);
            this.Load += new System.EventHandler(this.Compra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbformadepagocomp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtProveedorcomp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNuevacompra;
        private System.Windows.Forms.Button btncancelarcompra;
        private System.Windows.Forms.TextBox txtttpagarcomp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btngenerarrecibocomp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}