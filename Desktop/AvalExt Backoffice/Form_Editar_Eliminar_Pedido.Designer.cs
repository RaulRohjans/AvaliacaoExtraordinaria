
namespace AvalExt_Backoffice
{
    partial class Form_Editar_Eliminar_Pedido
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
            this.lbl_pedido = new System.Windows.Forms.Label();
            this.lbl_aluno = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_aprov = new System.Windows.Forms.Button();
            this.lbl_prof = new System.Windows.Forms.Label();
            this.lbl_modulo = new System.Windows.Forms.Label();
            this.btn_del = new System.Windows.Forms.Button();
            this.dtp_ = new System.Windows.Forms.DateTimePicker();
            this.lbl_dataHoraExame = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.horas = new System.Windows.Forms.NumericUpDown();
            this.minutos = new System.Windows.Forms.NumericUpDown();
            this.txt_preco = new System.Windows.Forms.TextBox();
            this.lbl_preco = new System.Windows.Forms.Label();
            this.lbl_euro = new System.Windows.Forms.Label();
            this.txt_meioPaga = new System.Windows.Forms.TextBox();
            this.lbl_meioPaga = new System.Windows.Forms.Label();
            this.lbl_tipoTaxa = new System.Windows.Forms.Label();
            this.cbb_taxa = new System.Windows.Forms.ComboBox();
            this.lbl_minutos = new System.Windows.Forms.Label();
            this.lbl_Dur = new System.Windows.Forms.Label();
            this.durMins = new System.Windows.Forms.NumericUpDown();
            this.cbb_al = new System.Windows.Forms.ComboBox();
            this.cbb_prof = new System.Windows.Forms.ComboBox();
            this.cbb_modulo = new System.Windows.Forms.ComboBox();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.lbl_nota = new System.Windows.Forms.Label();
            this.txt_nota = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.horas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.durMins)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_pedido
            // 
            this.lbl_pedido.AutoSize = true;
            this.lbl_pedido.Location = new System.Drawing.Point(16, 15);
            this.lbl_pedido.Name = "lbl_pedido";
            this.lbl_pedido.Size = new System.Drawing.Size(72, 13);
            this.lbl_pedido.TabIndex = 71;
            this.lbl_pedido.Text = "ID do Pedido:";
            // 
            // lbl_aluno
            // 
            this.lbl_aluno.AutoSize = true;
            this.lbl_aluno.Location = new System.Drawing.Point(16, 81);
            this.lbl_aluno.Name = "lbl_aluno";
            this.lbl_aluno.Size = new System.Drawing.Size(41, 13);
            this.lbl_aluno.TabIndex = 73;
            this.lbl_aluno.Text = "Aluno:*";
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(12, 429);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 23);
            this.btn_cancel.TabIndex = 14;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(250, 429);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(150, 23);
            this.btn_edit.TabIndex = 15;
            this.btn_edit.Text = "Editar";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_aprov
            // 
            this.btn_aprov.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_aprov.Enabled = false;
            this.btn_aprov.Location = new System.Drawing.Point(235, 15);
            this.btn_aprov.Name = "btn_aprov";
            this.btn_aprov.Size = new System.Drawing.Size(150, 23);
            this.btn_aprov.TabIndex = 1;
            this.btn_aprov.Text = "Aprovar Pedido";
            this.btn_aprov.UseVisualStyleBackColor = true;
            this.btn_aprov.Click += new System.EventHandler(this.btn_aprov_Click);
            // 
            // lbl_prof
            // 
            this.lbl_prof.AutoSize = true;
            this.lbl_prof.Location = new System.Drawing.Point(16, 120);
            this.lbl_prof.Name = "lbl_prof";
            this.lbl_prof.Size = new System.Drawing.Size(58, 13);
            this.lbl_prof.TabIndex = 78;
            this.lbl_prof.Text = "Professor:*";
            // 
            // lbl_modulo
            // 
            this.lbl_modulo.AutoSize = true;
            this.lbl_modulo.Location = new System.Drawing.Point(16, 160);
            this.lbl_modulo.Name = "lbl_modulo";
            this.lbl_modulo.Size = new System.Drawing.Size(49, 13);
            this.lbl_modulo.TabIndex = 80;
            this.lbl_modulo.Text = "Módulo:*";
            // 
            // btn_del
            // 
            this.btn_del.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_del.Location = new System.Drawing.Point(235, 44);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(150, 23);
            this.btn_del.TabIndex = 2;
            this.btn_del.Text = "Eliminar Pedido";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // dtp_
            // 
            this.dtp_.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_.Location = new System.Drawing.Point(138, 193);
            this.dtp_.Name = "dtp_";
            this.dtp_.Size = new System.Drawing.Size(97, 20);
            this.dtp_.TabIndex = 6;
            // 
            // lbl_dataHoraExame
            // 
            this.lbl_dataHoraExame.AutoSize = true;
            this.lbl_dataHoraExame.Location = new System.Drawing.Point(16, 195);
            this.lbl_dataHoraExame.Name = "lbl_dataHoraExame";
            this.lbl_dataHoraExame.Size = new System.Drawing.Size(122, 13);
            this.lbl_dataHoraExame.TabIndex = 83;
            this.lbl_dataHoraExame.Text = "Data e Hora do Exame:*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = ":";
            // 
            // horas
            // 
            this.horas.Location = new System.Drawing.Point(253, 193);
            this.horas.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.horas.Name = "horas";
            this.horas.Size = new System.Drawing.Size(48, 20);
            this.horas.TabIndex = 7;
            // 
            // minutos
            // 
            this.minutos.Location = new System.Drawing.Point(316, 193);
            this.minutos.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minutos.Name = "minutos";
            this.minutos.Size = new System.Drawing.Size(48, 20);
            this.minutos.TabIndex = 8;
            // 
            // txt_preco
            // 
            this.txt_preco.Location = new System.Drawing.Point(138, 268);
            this.txt_preco.MaxLength = 500;
            this.txt_preco.Name = "txt_preco";
            this.txt_preco.Size = new System.Drawing.Size(53, 20);
            this.txt_preco.TabIndex = 10;
            this.txt_preco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_preco_KeyPress);
            // 
            // lbl_preco
            // 
            this.lbl_preco.AutoSize = true;
            this.lbl_preco.Location = new System.Drawing.Point(16, 271);
            this.lbl_preco.Name = "lbl_preco";
            this.lbl_preco.Size = new System.Drawing.Size(38, 13);
            this.lbl_preco.TabIndex = 89;
            this.lbl_preco.Text = "Preço:";
            // 
            // lbl_euro
            // 
            this.lbl_euro.AutoSize = true;
            this.lbl_euro.Location = new System.Drawing.Point(192, 271);
            this.lbl_euro.Name = "lbl_euro";
            this.lbl_euro.Size = new System.Drawing.Size(13, 13);
            this.lbl_euro.TabIndex = 90;
            this.lbl_euro.Text = "€";
            // 
            // txt_meioPaga
            // 
            this.txt_meioPaga.Location = new System.Drawing.Point(138, 303);
            this.txt_meioPaga.MaxLength = 500;
            this.txt_meioPaga.Name = "txt_meioPaga";
            this.txt_meioPaga.Size = new System.Drawing.Size(247, 20);
            this.txt_meioPaga.TabIndex = 11;
            // 
            // lbl_meioPaga
            // 
            this.lbl_meioPaga.AutoSize = true;
            this.lbl_meioPaga.Location = new System.Drawing.Point(16, 306);
            this.lbl_meioPaga.Name = "lbl_meioPaga";
            this.lbl_meioPaga.Size = new System.Drawing.Size(105, 13);
            this.lbl_meioPaga.TabIndex = 92;
            this.lbl_meioPaga.Text = "Meio de Pagamento:";
            // 
            // lbl_tipoTaxa
            // 
            this.lbl_tipoTaxa.AutoSize = true;
            this.lbl_tipoTaxa.Location = new System.Drawing.Point(16, 342);
            this.lbl_tipoTaxa.Name = "lbl_tipoTaxa";
            this.lbl_tipoTaxa.Size = new System.Drawing.Size(73, 13);
            this.lbl_tipoTaxa.TabIndex = 94;
            this.lbl_tipoTaxa.Text = "Tipo de Taxa:";
            // 
            // cbb_taxa
            // 
            this.cbb_taxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_taxa.FormattingEnabled = true;
            this.cbb_taxa.Items.AddRange(new object[] {
            "-",
            "Isento",
            "Época de Recuperações",
            "Fora da Época de Recuperações"});
            this.cbb_taxa.Location = new System.Drawing.Point(138, 339);
            this.cbb_taxa.Name = "cbb_taxa";
            this.cbb_taxa.Size = new System.Drawing.Size(247, 21);
            this.cbb_taxa.TabIndex = 12;
            // 
            // lbl_minutos
            // 
            this.lbl_minutos.AutoSize = true;
            this.lbl_minutos.Location = new System.Drawing.Point(188, 234);
            this.lbl_minutos.Name = "lbl_minutos";
            this.lbl_minutos.Size = new System.Drawing.Size(43, 13);
            this.lbl_minutos.TabIndex = 100;
            this.lbl_minutos.Text = "minutos";
            // 
            // lbl_Dur
            // 
            this.lbl_Dur.AutoSize = true;
            this.lbl_Dur.Location = new System.Drawing.Point(16, 233);
            this.lbl_Dur.Name = "lbl_Dur";
            this.lbl_Dur.Size = new System.Drawing.Size(105, 13);
            this.lbl_Dur.TabIndex = 99;
            this.lbl_Dur.Text = "Duração do Exame:*";
            // 
            // durMins
            // 
            this.durMins.Location = new System.Drawing.Point(138, 230);
            this.durMins.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.durMins.Name = "durMins";
            this.durMins.Size = new System.Drawing.Size(48, 20);
            this.durMins.TabIndex = 9;
            // 
            // cbb_al
            // 
            this.cbb_al.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_al.FormattingEnabled = true;
            this.cbb_al.Location = new System.Drawing.Point(138, 78);
            this.cbb_al.Name = "cbb_al";
            this.cbb_al.Size = new System.Drawing.Size(247, 21);
            this.cbb_al.TabIndex = 3;
            // 
            // cbb_prof
            // 
            this.cbb_prof.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_prof.FormattingEnabled = true;
            this.cbb_prof.Location = new System.Drawing.Point(138, 117);
            this.cbb_prof.Name = "cbb_prof";
            this.cbb_prof.Size = new System.Drawing.Size(247, 21);
            this.cbb_prof.TabIndex = 4;
            // 
            // cbb_modulo
            // 
            this.cbb_modulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_modulo.FormattingEnabled = true;
            this.cbb_modulo.Location = new System.Drawing.Point(138, 157);
            this.cbb_modulo.Name = "cbb_modulo";
            this.cbb_modulo.Size = new System.Drawing.Size(247, 21);
            this.cbb_modulo.TabIndex = 5;
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Location = new System.Drawing.Point(135, 15);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(0, 13);
            this.lbl_ID.TabIndex = 101;
            // 
            // lbl_nota
            // 
            this.lbl_nota.AutoSize = true;
            this.lbl_nota.Location = new System.Drawing.Point(16, 379);
            this.lbl_nota.Name = "lbl_nota";
            this.lbl_nota.Size = new System.Drawing.Size(33, 13);
            this.lbl_nota.TabIndex = 97;
            this.lbl_nota.Text = "Nota:";
            // 
            // txt_nota
            // 
            this.txt_nota.Location = new System.Drawing.Point(138, 376);
            this.txt_nota.MaxLength = 500;
            this.txt_nota.Name = "txt_nota";
            this.txt_nota.Size = new System.Drawing.Size(53, 20);
            this.txt_nota.TabIndex = 13;
            // 
            // Form_Editar_Eliminar_Pedido
            // 
            this.AcceptButton = this.btn_edit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 468);
            this.Controls.Add(this.lbl_ID);
            this.Controls.Add(this.cbb_modulo);
            this.Controls.Add(this.cbb_prof);
            this.Controls.Add(this.cbb_al);
            this.Controls.Add(this.durMins);
            this.Controls.Add(this.lbl_minutos);
            this.Controls.Add(this.lbl_Dur);
            this.Controls.Add(this.txt_nota);
            this.Controls.Add(this.lbl_nota);
            this.Controls.Add(this.cbb_taxa);
            this.Controls.Add(this.lbl_tipoTaxa);
            this.Controls.Add(this.txt_meioPaga);
            this.Controls.Add(this.lbl_meioPaga);
            this.Controls.Add(this.lbl_euro);
            this.Controls.Add(this.txt_preco);
            this.Controls.Add(this.lbl_preco);
            this.Controls.Add(this.minutos);
            this.Controls.Add(this.horas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtp_);
            this.Controls.Add(this.lbl_dataHoraExame);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.lbl_modulo);
            this.Controls.Add(this.lbl_prof);
            this.Controls.Add(this.btn_aprov);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.lbl_aluno);
            this.Controls.Add(this.lbl_pedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Editar_Eliminar_Pedido";
            this.Text = "Editar/Eliminar Pedido";
            this.Load += new System.EventHandler(this.Form_Editar_Eliminar_Pedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.horas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.durMins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_pedido;
        private System.Windows.Forms.Label lbl_aluno;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_aprov;
        private System.Windows.Forms.Label lbl_prof;
        private System.Windows.Forms.Label lbl_modulo;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.DateTimePicker dtp_;
        private System.Windows.Forms.Label lbl_dataHoraExame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown horas;
        private System.Windows.Forms.NumericUpDown minutos;
        private System.Windows.Forms.TextBox txt_preco;
        private System.Windows.Forms.Label lbl_preco;
        private System.Windows.Forms.Label lbl_euro;
        private System.Windows.Forms.TextBox txt_meioPaga;
        private System.Windows.Forms.Label lbl_meioPaga;
        private System.Windows.Forms.Label lbl_tipoTaxa;
        private System.Windows.Forms.ComboBox cbb_taxa;
        private System.Windows.Forms.Label lbl_minutos;
        private System.Windows.Forms.Label lbl_Dur;
        private System.Windows.Forms.NumericUpDown durMins;
        private System.Windows.Forms.ComboBox cbb_al;
        private System.Windows.Forms.ComboBox cbb_prof;
        private System.Windows.Forms.ComboBox cbb_modulo;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label lbl_nota;
        private System.Windows.Forms.TextBox txt_nota;
    }
}