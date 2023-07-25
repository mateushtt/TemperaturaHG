namespace TemperaturaHG
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnPesquisar = new Button();
            label1 = new Label();
            label2 = new Label();
            weatherBindingSource = new BindingSource(components);
            weatherBindingSource1 = new BindingSource(components);
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)weatherBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)weatherBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(412, 463);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(193, 65);
            btnPesquisar.TabIndex = 1;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.MenuHighlight;
            label1.Location = new Point(285, 32);
            label1.Name = "label1";
            label1.Size = new Size(447, 81);
            label1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(417, 58);
            label2.Name = "label2";
            label2.Size = new Size(183, 28);
            label2.TabIndex = 5;
            label2.Text = "CLIMA DE JALES-SP";
            // 
            // weatherBindingSource
            // 
            weatherBindingSource.DataSource = typeof(Model.Weather);
            // 
            // weatherBindingSource1
            // 
            weatherBindingSource1.DataSource = typeof(Model.Weather);
            // 
            // dataGridView1
            // 
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(105, 130);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(806, 284);
            dataGridView1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 564);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnPesquisar);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)weatherBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)weatherBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPesquisar;
        private Label label1;
        private Label label2;
        private BindingSource weatherBindingSource;
        private BindingSource weatherBindingSource1;
        private DataGridView dataGridView1;
    }
}