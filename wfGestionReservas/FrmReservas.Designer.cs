namespace wfGestionReservas
{
    partial class FrmReservas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.BtnEliminarReserva = new System.Windows.Forms.Button();
            this.BtnAgregarReserva = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaReserva = new System.Windows.Forms.DateTimePicker();
            this.TxtDuracionEstadia = new System.Windows.Forms.TextBox();
            this.TxtNumeroHabitación = new System.Windows.Forms.TextBox();
            this.TxtNombreCliente = new System.Windows.Forms.TextBox();
            this.dtgReservas = new System.Windows.Forms.DataGridView();
            this.BtnActualizarReserva = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPrecioNoche = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(435, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 39;
            this.label8.Text = "Agregar Reserva";
            // 
            // BtnEliminarReserva
            // 
            this.BtnEliminarReserva.Location = new System.Drawing.Point(737, 328);
            this.BtnEliminarReserva.Name = "BtnEliminarReserva";
            this.BtnEliminarReserva.Size = new System.Drawing.Size(102, 40);
            this.BtnEliminarReserva.TabIndex = 35;
            this.BtnEliminarReserva.Text = "Eliminar Reserva";
            this.BtnEliminarReserva.UseVisualStyleBackColor = true;
            this.BtnEliminarReserva.Click += new System.EventHandler(this.BtnEliminarReserva_Click);
            // 
            // BtnAgregarReserva
            // 
            this.BtnAgregarReserva.Location = new System.Drawing.Point(302, 328);
            this.BtnAgregarReserva.Name = "BtnAgregarReserva";
            this.BtnAgregarReserva.Size = new System.Drawing.Size(102, 40);
            this.BtnAgregarReserva.TabIndex = 34;
            this.BtnAgregarReserva.Text = "Agregar Reserva";
            this.BtnAgregarReserva.UseVisualStyleBackColor = true;
            this.BtnAgregarReserva.Click += new System.EventHandler(this.BtnAgregarReserva_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Duración de estadia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Fecha de reserva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Número de habitación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nombre Cliente";
            // 
            // DtpFechaReserva
            // 
            this.DtpFechaReserva.Location = new System.Drawing.Point(425, 195);
            this.DtpFechaReserva.Name = "DtpFechaReserva";
            this.DtpFechaReserva.Size = new System.Drawing.Size(193, 20);
            this.DtpFechaReserva.TabIndex = 26;
            this.DtpFechaReserva.ValueChanged += new System.EventHandler(this.DtpFechaReserva_ValueChanged);
            // 
            // TxtDuracionEstadia
            // 
            this.TxtDuracionEstadia.Location = new System.Drawing.Point(425, 233);
            this.TxtDuracionEstadia.Name = "TxtDuracionEstadia";
            this.TxtDuracionEstadia.Size = new System.Drawing.Size(104, 20);
            this.TxtDuracionEstadia.TabIndex = 27;
            this.TxtDuracionEstadia.TextChanged += new System.EventHandler(this.TxtDuracionEstadia_TextChanged);
            // 
            // TxtNumeroHabitación
            // 
            this.TxtNumeroHabitación.Location = new System.Drawing.Point(425, 151);
            this.TxtNumeroHabitación.Name = "TxtNumeroHabitación";
            this.TxtNumeroHabitación.Size = new System.Drawing.Size(104, 20);
            this.TxtNumeroHabitación.TabIndex = 24;
            this.TxtNumeroHabitación.TextChanged += new System.EventHandler(this.TxtNumeroHabitación_TextChanged);
            // 
            // TxtNombreCliente
            // 
            this.TxtNombreCliente.Location = new System.Drawing.Point(425, 115);
            this.TxtNombreCliente.Name = "TxtNombreCliente";
            this.TxtNombreCliente.Size = new System.Drawing.Size(193, 20);
            this.TxtNombreCliente.TabIndex = 23;
            this.TxtNombreCliente.TextChanged += new System.EventHandler(this.TxtNombreCliente_TextChanged);
            // 
            // dtgReservas
            // 
            this.dtgReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReservas.Location = new System.Drawing.Point(80, 386);
            this.dtgReservas.Name = "dtgReservas";
            this.dtgReservas.Size = new System.Drawing.Size(759, 234);
            this.dtgReservas.TabIndex = 21;
            this.dtgReservas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgReservas_CellClick);
            // 
            // BtnActualizarReserva
            // 
            this.BtnActualizarReserva.Location = new System.Drawing.Point(618, 328);
            this.BtnActualizarReserva.Name = "BtnActualizarReserva";
            this.BtnActualizarReserva.Size = new System.Drawing.Size(113, 40);
            this.BtnActualizarReserva.TabIndex = 42;
            this.BtnActualizarReserva.Text = "Actualizar Reserva";
            this.BtnActualizarReserva.UseVisualStyleBackColor = true;
            this.BtnActualizarReserva.Click += new System.EventHandler(this.BtnActualizarReserva_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(298, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Tipo de habitación";
            // 
            // CmbTipoHabitacion
            // 
            this.CmbTipoHabitacion.FormattingEnabled = true;
            this.CmbTipoHabitacion.Location = new System.Drawing.Point(425, 81);
            this.CmbTipoHabitacion.Name = "CmbTipoHabitacion";
            this.CmbTipoHabitacion.Size = new System.Drawing.Size(193, 21);
            this.CmbTipoHabitacion.TabIndex = 44;
            this.CmbTipoHabitacion.SelectedIndexChanged += new System.EventHandler(this.CmbTipoHabitacion_SelectedIndexChanged);
            this.CmbTipoHabitacion.TextUpdate += new System.EventHandler(this.CmbTipoHabitacion_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Precio/noche habitación";
            // 
            // TxtPrecioNoche
            // 
            this.TxtPrecioNoche.Location = new System.Drawing.Point(425, 270);
            this.TxtPrecioNoche.Name = "TxtPrecioNoche";
            this.TxtPrecioNoche.Size = new System.Drawing.Size(104, 20);
            this.TxtPrecioNoche.TabIndex = 45;
            this.TxtPrecioNoche.TextChanged += new System.EventHandler(this.TxtPrecioNoche_TextChanged);
            // 
            // FrmReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 650);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtPrecioNoche);
            this.Controls.Add(this.CmbTipoHabitacion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BtnActualizarReserva);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnEliminarReserva);
            this.Controls.Add(this.BtnAgregarReserva);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFechaReserva);
            this.Controls.Add(this.TxtDuracionEstadia);
            this.Controls.Add(this.TxtNumeroHabitación);
            this.Controls.Add(this.TxtNombreCliente);
            this.Controls.Add(this.dtgReservas);
            this.Name = "FrmReservas";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmReservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReservas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnEliminarReserva;
        private System.Windows.Forms.Button BtnAgregarReserva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaReserva;
        private System.Windows.Forms.TextBox TxtDuracionEstadia;
        private System.Windows.Forms.TextBox TxtNumeroHabitación;
        private System.Windows.Forms.TextBox TxtNombreCliente;
        private System.Windows.Forms.DataGridView dtgReservas;
        private System.Windows.Forms.Button BtnActualizarReserva;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CmbTipoHabitacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPrecioNoche;
    }
}

