
namespace CapaPresentacion
{
    partial class PresentacionImpuestos
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
            this.txtHabitacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idHotel = new System.Windows.Forms.Label();
            this.dgvHabitacion = new System.Windows.Forms.DataGridView();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdImpuesto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbImpuesto = new System.Windows.Forms.ComboBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvImpuestos = new System.Windows.Forms.DataGridView();
            this.btnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHabitacion
            // 
            this.txtHabitacion.Enabled = false;
            this.txtHabitacion.Location = new System.Drawing.Point(65, 92);
            this.txtHabitacion.Name = "txtHabitacion";
            this.txtHabitacion.Size = new System.Drawing.Size(114, 20);
            this.txtHabitacion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // idHotel
            // 
            this.idHotel.AutoSize = true;
            this.idHotel.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idHotel.Location = new System.Drawing.Point(61, 69);
            this.idHotel.Name = "idHotel";
            this.idHotel.Size = new System.Drawing.Size(64, 20);
            this.idHotel.TabIndex = 12;
            this.idHotel.Text = "ID ROOM";
            // 
            // dgvHabitacion
            // 
            this.dgvHabitacion.AllowUserToAddRows = false;
            this.dgvHabitacion.AllowUserToDeleteRows = false;
            this.dgvHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitacion.Location = new System.Drawing.Point(206, 12);
            this.dgvHabitacion.Name = "dgvHabitacion";
            this.dgvHabitacion.ReadOnly = true;
            this.dgvHabitacion.Size = new System.Drawing.Size(557, 205);
            this.dgvHabitacion.TabIndex = 14;
            this.dgvHabitacion.DoubleClick += new System.EventHandler(this.dgvHabitaciones_DoubleClick);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertar.Location = new System.Drawing.Point(65, 203);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(114, 65);
            this.btnInsertar.TabIndex = 15;
            this.btnInsertar.Text = "INSERTAR";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "ID IMPUESTO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 17;
            // 
            // txtIdImpuesto
            // 
            this.txtIdImpuesto.Enabled = false;
            this.txtIdImpuesto.Location = new System.Drawing.Point(65, 35);
            this.txtIdImpuesto.Name = "txtIdImpuesto";
            this.txtIdImpuesto.Size = new System.Drawing.Size(114, 20);
            this.txtIdImpuesto.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "IMPUESTO";
            // 
            // cmbImpuesto
            // 
            this.cmbImpuesto.FormattingEnabled = true;
            this.cmbImpuesto.Location = new System.Drawing.Point(65, 151);
            this.cmbImpuesto.Name = "cmbImpuesto";
            this.cmbImpuesto.Size = new System.Drawing.Size(114, 21);
            this.cmbImpuesto.TabIndex = 20;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(65, 291);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(114, 65);
            this.btnEliminar.TabIndex = 21;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvImpuestos
            // 
            this.dgvImpuestos.AllowUserToAddRows = false;
            this.dgvImpuestos.AllowUserToDeleteRows = false;
            this.dgvImpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImpuestos.Location = new System.Drawing.Point(206, 244);
            this.dgvImpuestos.Name = "dgvImpuestos";
            this.dgvImpuestos.ReadOnly = true;
            this.dgvImpuestos.Size = new System.Drawing.Size(557, 194);
            this.dgvImpuestos.TabIndex = 22;
            this.dgvImpuestos.DoubleClick += new System.EventHandler(this.dgvImpuestos_DoubleClick);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(65, 373);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(114, 65);
            this.btnRegresar.TabIndex = 23;
            this.btnRegresar.Text = "REGRESAR";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // PresentacionImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.dgvImpuestos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.cmbImpuesto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdImpuesto);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.dgvHabitacion);
            this.Controls.Add(this.idHotel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHabitacion);
            this.Name = "PresentacionImpuestos";
            this.Text = "PresentacionImpuestos";
            this.Load += new System.EventHandler(this.PresentacionImpuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImpuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtHabitacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label idHotel;
        private System.Windows.Forms.DataGridView dgvHabitacion;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdImpuesto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbImpuesto;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvImpuestos;
        private System.Windows.Forms.Button btnRegresar;
    }
}