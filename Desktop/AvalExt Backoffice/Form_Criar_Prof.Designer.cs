
namespace AvalExt_Backoffice
{
    partial class Form_Criar_Prof
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
            this.btn_passRepete = new System.Windows.Forms.Button();
            this.btn_pass = new System.Windows.Forms.Button();
            this.lbl_disc = new System.Windows.Forms.Label();
            this.lbl_pass2 = new System.Windows.Forms.Label();
            this.txt_pass1 = new System.Windows.Forms.TextBox();
            this.lbl_pass1 = new System.Windows.Forms.Label();
            this.txt_pass2 = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_create = new System.Windows.Forms.Button();
            this.dtp_ = new System.Windows.Forms.DateTimePicker();
            this.txt_morada = new System.Windows.Forms.TextBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.lbl_cont = new System.Windows.Forms.Label();
            this.lbl_dataN = new System.Windows.Forms.Label();
            this.lbl_morada = new System.Windows.Forms.Label();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.lbl_user = new System.Windows.Forms.Label();
            this.txt_cont = new System.Windows.Forms.TextBox();
            this.chk_ac = new System.Windows.Forms.CheckBox();
            this.chk_ai = new System.Windows.Forms.CheckBox();
            this.chk_ef = new System.Windows.Forms.CheckBox();
            this.chk_mat = new System.Windows.Forms.CheckBox();
            this.chk_ing = new System.Windows.Forms.CheckBox();
            this.chk_fq = new System.Windows.Forms.CheckBox();
            this.chk_so = new System.Windows.Forms.CheckBox();
            this.chk_rc = new System.Windows.Forms.CheckBox();
            this.chk_psi = new System.Windows.Forms.CheckBox();
            this.chk_pt = new System.Windows.Forms.CheckBox();
            this.chk_tic = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_passRepete
            // 
            this.btn_passRepete.Location = new System.Drawing.Point(370, 97);
            this.btn_passRepete.Name = "btn_passRepete";
            this.btn_passRepete.Size = new System.Drawing.Size(21, 23);
            this.btn_passRepete.TabIndex = 4;
            this.btn_passRepete.Text = "۝";
            this.btn_passRepete.UseVisualStyleBackColor = true;
            this.btn_passRepete.Click += new System.EventHandler(this.btn_passRepete_Click);
            // 
            // btn_pass
            // 
            this.btn_pass.Location = new System.Drawing.Point(370, 56);
            this.btn_pass.Name = "btn_pass";
            this.btn_pass.Size = new System.Drawing.Size(21, 23);
            this.btn_pass.TabIndex = 2;
            this.btn_pass.Text = "۝";
            this.btn_pass.UseVisualStyleBackColor = true;
            this.btn_pass.Click += new System.EventHandler(this.btn_pass_Click);
            // 
            // lbl_disc
            // 
            this.lbl_disc.AutoSize = true;
            this.lbl_disc.Location = new System.Drawing.Point(22, 312);
            this.lbl_disc.Name = "lbl_disc";
            this.lbl_disc.Size = new System.Drawing.Size(70, 13);
            this.lbl_disc.TabIndex = 82;
            this.lbl_disc.Text = "Disciplina(s):*";
            // 
            // lbl_pass2
            // 
            this.lbl_pass2.AutoSize = true;
            this.lbl_pass2.Location = new System.Drawing.Point(22, 101);
            this.lbl_pass2.Name = "lbl_pass2";
            this.lbl_pass2.Size = new System.Drawing.Size(119, 13);
            this.lbl_pass2.TabIndex = 81;
            this.lbl_pass2.Text = "Repetir Palavra-Passe:*";
            // 
            // txt_pass1
            // 
            this.txt_pass1.Location = new System.Drawing.Point(144, 57);
            this.txt_pass1.MaxLength = 50;
            this.txt_pass1.Name = "txt_pass1";
            this.txt_pass1.PasswordChar = '*';
            this.txt_pass1.Size = new System.Drawing.Size(225, 20);
            this.txt_pass1.TabIndex = 1;
            // 
            // lbl_pass1
            // 
            this.lbl_pass1.AutoSize = true;
            this.lbl_pass1.Location = new System.Drawing.Point(22, 59);
            this.lbl_pass1.Name = "lbl_pass1";
            this.lbl_pass1.Size = new System.Drawing.Size(82, 13);
            this.lbl_pass1.TabIndex = 80;
            this.lbl_pass1.Text = "Palavra-Passe:*";
            // 
            // txt_pass2
            // 
            this.txt_pass2.Location = new System.Drawing.Point(144, 98);
            this.txt_pass2.MaxLength = 50;
            this.txt_pass2.Name = "txt_pass2";
            this.txt_pass2.PasswordChar = '*';
            this.txt_pass2.Size = new System.Drawing.Size(225, 20);
            this.txt_pass2.TabIndex = 3;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(12, 418);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 23);
            this.btn_cancel.TabIndex = 20;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(250, 418);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(150, 23);
            this.btn_create.TabIndex = 21;
            this.btn_create.Text = "Criar";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // dtp_
            // 
            this.dtp_.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_.Location = new System.Drawing.Point(144, 182);
            this.dtp_.Name = "dtp_";
            this.dtp_.Size = new System.Drawing.Size(247, 20);
            this.dtp_.TabIndex = 6;
            // 
            // txt_morada
            // 
            this.txt_morada.Location = new System.Drawing.Point(144, 269);
            this.txt_morada.MaxLength = 50;
            this.txt_morada.Name = "txt_morada";
            this.txt_morada.Size = new System.Drawing.Size(247, 20);
            this.txt_morada.TabIndex = 8;
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(144, 140);
            this.txt_nome.MaxLength = 500;
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(247, 20);
            this.txt_nome.TabIndex = 5;
            // 
            // lbl_cont
            // 
            this.lbl_cont.AutoSize = true;
            this.lbl_cont.Location = new System.Drawing.Point(22, 228);
            this.lbl_cont.Name = "lbl_cont";
            this.lbl_cont.Size = new System.Drawing.Size(56, 13);
            this.lbl_cont.TabIndex = 78;
            this.lbl_cont.Text = "Telefone:*";
            // 
            // lbl_dataN
            // 
            this.lbl_dataN.AutoSize = true;
            this.lbl_dataN.Location = new System.Drawing.Point(22, 184);
            this.lbl_dataN.Name = "lbl_dataN";
            this.lbl_dataN.Size = new System.Drawing.Size(111, 13);
            this.lbl_dataN.TabIndex = 77;
            this.lbl_dataN.Text = "Data de Nascimento:*";
            // 
            // lbl_morada
            // 
            this.lbl_morada.AutoSize = true;
            this.lbl_morada.Location = new System.Drawing.Point(22, 272);
            this.lbl_morada.Name = "lbl_morada";
            this.lbl_morada.Size = new System.Drawing.Size(50, 13);
            this.lbl_morada.TabIndex = 76;
            this.lbl_morada.Text = "Morada:*";
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.Location = new System.Drawing.Point(22, 143);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(42, 13);
            this.lbl_nome.TabIndex = 74;
            this.lbl_nome.Text = "Nome:*";
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(144, 16);
            this.txt_user.MaxLength = 100;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(247, 20);
            this.txt_user.TabIndex = 0;
            this.txt_user.TextChanged += new System.EventHandler(this.txt_user_TextChanged);
            this.txt_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_user_KeyPress);
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(22, 18);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(103, 13);
            this.lbl_user.TabIndex = 73;
            this.lbl_user.Text = "Nome de Utilizador:*";
            // 
            // txt_cont
            // 
            this.txt_cont.Location = new System.Drawing.Point(144, 226);
            this.txt_cont.Name = "txt_cont";
            this.txt_cont.Size = new System.Drawing.Size(247, 20);
            this.txt_cont.TabIndex = 7;
            this.txt_cont.Text = "+351";
            // 
            // chk_ac
            // 
            this.chk_ac.AutoSize = true;
            this.chk_ac.Location = new System.Drawing.Point(303, 381);
            this.chk_ac.Name = "chk_ac";
            this.chk_ac.Size = new System.Drawing.Size(40, 17);
            this.chk_ac.TabIndex = 18;
            this.chk_ac.Text = "AC";
            this.chk_ac.UseVisualStyleBackColor = true;
            // 
            // chk_ai
            // 
            this.chk_ai.AutoSize = true;
            this.chk_ai.Location = new System.Drawing.Point(203, 312);
            this.chk_ai.Name = "chk_ai";
            this.chk_ai.Size = new System.Drawing.Size(36, 17);
            this.chk_ai.TabIndex = 10;
            this.chk_ai.Text = "AI";
            this.chk_ai.UseVisualStyleBackColor = true;
            // 
            // chk_ef
            // 
            this.chk_ef.AutoSize = true;
            this.chk_ef.Location = new System.Drawing.Point(252, 312);
            this.chk_ef.Name = "chk_ef";
            this.chk_ef.Size = new System.Drawing.Size(39, 17);
            this.chk_ef.TabIndex = 11;
            this.chk_ef.Text = "EF";
            this.chk_ef.UseVisualStyleBackColor = true;
            // 
            // chk_mat
            // 
            this.chk_mat.AutoSize = true;
            this.chk_mat.Location = new System.Drawing.Point(144, 345);
            this.chk_mat.Name = "chk_mat";
            this.chk_mat.Size = new System.Drawing.Size(49, 17);
            this.chk_mat.TabIndex = 13;
            this.chk_mat.Text = "MAT";
            this.chk_mat.UseVisualStyleBackColor = true;
            // 
            // chk_ing
            // 
            this.chk_ing.AutoSize = true;
            this.chk_ing.Location = new System.Drawing.Point(303, 312);
            this.chk_ing.Name = "chk_ing";
            this.chk_ing.Size = new System.Drawing.Size(45, 17);
            this.chk_ing.TabIndex = 12;
            this.chk_ing.Text = "ING";
            this.chk_ing.UseVisualStyleBackColor = true;
            // 
            // chk_fq
            // 
            this.chk_fq.AutoSize = true;
            this.chk_fq.Location = new System.Drawing.Point(203, 345);
            this.chk_fq.Name = "chk_fq";
            this.chk_fq.Size = new System.Drawing.Size(40, 17);
            this.chk_fq.TabIndex = 14;
            this.chk_fq.Text = "FQ";
            this.chk_fq.UseVisualStyleBackColor = true;
            // 
            // chk_so
            // 
            this.chk_so.AutoSize = true;
            this.chk_so.Location = new System.Drawing.Point(350, 381);
            this.chk_so.Name = "chk_so";
            this.chk_so.Size = new System.Drawing.Size(41, 17);
            this.chk_so.TabIndex = 19;
            this.chk_so.Text = "SO";
            this.chk_so.UseVisualStyleBackColor = true;
            // 
            // chk_rc
            // 
            this.chk_rc.AutoSize = true;
            this.chk_rc.Location = new System.Drawing.Point(252, 381);
            this.chk_rc.Name = "chk_rc";
            this.chk_rc.Size = new System.Drawing.Size(41, 17);
            this.chk_rc.TabIndex = 17;
            this.chk_rc.Text = "RC";
            this.chk_rc.UseVisualStyleBackColor = true;
            // 
            // chk_psi
            // 
            this.chk_psi.AutoSize = true;
            this.chk_psi.Location = new System.Drawing.Point(144, 381);
            this.chk_psi.Name = "chk_psi";
            this.chk_psi.Size = new System.Drawing.Size(43, 17);
            this.chk_psi.TabIndex = 15;
            this.chk_psi.Text = "PSI";
            this.chk_psi.UseVisualStyleBackColor = true;
            // 
            // chk_pt
            // 
            this.chk_pt.AutoSize = true;
            this.chk_pt.Location = new System.Drawing.Point(144, 312);
            this.chk_pt.Name = "chk_pt";
            this.chk_pt.Size = new System.Drawing.Size(40, 17);
            this.chk_pt.TabIndex = 9;
            this.chk_pt.Text = "PT";
            this.chk_pt.UseVisualStyleBackColor = true;
            // 
            // chk_tic
            // 
            this.chk_tic.AutoSize = true;
            this.chk_tic.Location = new System.Drawing.Point(203, 381);
            this.chk_tic.Name = "chk_tic";
            this.chk_tic.Size = new System.Drawing.Size(43, 17);
            this.chk_tic.TabIndex = 16;
            this.chk_tic.Text = "TIC";
            this.chk_tic.UseVisualStyleBackColor = true;
            // 
            // Form_Criar_Prof
            // 
            this.AcceptButton = this.btn_create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 453);
            this.Controls.Add(this.chk_pt);
            this.Controls.Add(this.chk_tic);
            this.Controls.Add(this.chk_so);
            this.Controls.Add(this.chk_rc);
            this.Controls.Add(this.chk_psi);
            this.Controls.Add(this.chk_mat);
            this.Controls.Add(this.chk_ing);
            this.Controls.Add(this.chk_fq);
            this.Controls.Add(this.chk_ef);
            this.Controls.Add(this.chk_ai);
            this.Controls.Add(this.chk_ac);
            this.Controls.Add(this.btn_passRepete);
            this.Controls.Add(this.btn_pass);
            this.Controls.Add(this.lbl_disc);
            this.Controls.Add(this.lbl_pass2);
            this.Controls.Add(this.txt_pass1);
            this.Controls.Add(this.lbl_pass1);
            this.Controls.Add(this.txt_pass2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.dtp_);
            this.Controls.Add(this.txt_morada);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.lbl_cont);
            this.Controls.Add(this.lbl_dataN);
            this.Controls.Add(this.lbl_morada);
            this.Controls.Add(this.lbl_nome);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.txt_cont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Criar_Prof";
            this.Text = "Criar Professor";
            this.Load += new System.EventHandler(this.Form_Criar_UtilizadorProf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_passRepete;
        private System.Windows.Forms.Button btn_pass;
        private System.Windows.Forms.Label lbl_disc;
        private System.Windows.Forms.Label lbl_pass2;
        private System.Windows.Forms.TextBox txt_pass1;
        private System.Windows.Forms.Label lbl_pass1;
        private System.Windows.Forms.TextBox txt_pass2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.DateTimePicker dtp_;
        private System.Windows.Forms.TextBox txt_morada;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Label lbl_cont;
        private System.Windows.Forms.Label lbl_dataN;
        private System.Windows.Forms.Label lbl_morada;
        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.TextBox txt_cont;
        private System.Windows.Forms.CheckBox chk_ac;
        private System.Windows.Forms.CheckBox chk_ai;
        private System.Windows.Forms.CheckBox chk_ef;
        private System.Windows.Forms.CheckBox chk_mat;
        private System.Windows.Forms.CheckBox chk_ing;
        private System.Windows.Forms.CheckBox chk_fq;
        private System.Windows.Forms.CheckBox chk_so;
        private System.Windows.Forms.CheckBox chk_rc;
        private System.Windows.Forms.CheckBox chk_psi;
        private System.Windows.Forms.CheckBox chk_pt;
        private System.Windows.Forms.CheckBox chk_tic;
    }
}