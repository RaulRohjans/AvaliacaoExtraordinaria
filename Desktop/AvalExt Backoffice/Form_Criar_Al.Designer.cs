
namespace AvalExt_Backoffice
{
    partial class Form_Criar_Al
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
            this.lbl_pass2 = new System.Windows.Forms.Label();
            this.txt_pass1 = new System.Windows.Forms.TextBox();
            this.lbl_pass1 = new System.Windows.Forms.Label();
            this.txt_pass2 = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_create = new System.Windows.Forms.Button();
            this.dtp_ = new System.Windows.Forms.DateTimePicker();
            this.txt_morada = new System.Windows.Forms.TextBox();
            this.txt_turma = new System.Windows.Forms.TextBox();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.lbl_cont = new System.Windows.Forms.Label();
            this.lbl_dataN = new System.Windows.Forms.Label();
            this.lbl_morada = new System.Windows.Forms.Label();
            this.lbl_turma = new System.Windows.Forms.Label();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.lbl_user = new System.Windows.Forms.Label();
            this.txt_cont = new System.Windows.Forms.TextBox();
            this.btn_pass = new System.Windows.Forms.Button();
            this.btn_passRepete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_pass2
            // 
            this.lbl_pass2.AutoSize = true;
            this.lbl_pass2.Location = new System.Drawing.Point(22, 100);
            this.lbl_pass2.Name = "lbl_pass2";
            this.lbl_pass2.Size = new System.Drawing.Size(119, 13);
            this.lbl_pass2.TabIndex = 56;
            this.lbl_pass2.Text = "Repetir Palavra-Passe:*";
            // 
            // txt_pass1
            // 
            this.txt_pass1.Location = new System.Drawing.Point(144, 56);
            this.txt_pass1.MaxLength = 50;
            this.txt_pass1.Name = "txt_pass1";
            this.txt_pass1.PasswordChar = '*';
            this.txt_pass1.Size = new System.Drawing.Size(225, 20);
            this.txt_pass1.TabIndex = 2;
            // 
            // lbl_pass1
            // 
            this.lbl_pass1.AutoSize = true;
            this.lbl_pass1.Location = new System.Drawing.Point(22, 58);
            this.lbl_pass1.Name = "lbl_pass1";
            this.lbl_pass1.Size = new System.Drawing.Size(82, 13);
            this.lbl_pass1.TabIndex = 55;
            this.lbl_pass1.Text = "Palavra-Passe:*";
            // 
            // txt_pass2
            // 
            this.txt_pass2.Location = new System.Drawing.Point(144, 97);
            this.txt_pass2.MaxLength = 50;
            this.txt_pass2.Name = "txt_pass2";
            this.txt_pass2.PasswordChar = '*';
            this.txt_pass2.Size = new System.Drawing.Size(225, 20);
            this.txt_pass2.TabIndex = 4;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(12, 353);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(150, 23);
            this.btn_cancel.TabIndex = 11;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(250, 353);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(150, 23);
            this.btn_create.TabIndex = 12;
            this.btn_create.Text = "Criar";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // dtp_
            // 
            this.dtp_.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_.Location = new System.Drawing.Point(144, 181);
            this.dtp_.Name = "dtp_";
            this.dtp_.Size = new System.Drawing.Size(247, 20);
            this.dtp_.TabIndex = 7;
            // 
            // txt_morada
            // 
            this.txt_morada.Location = new System.Drawing.Point(144, 268);
            this.txt_morada.MaxLength = 50;
            this.txt_morada.Name = "txt_morada";
            this.txt_morada.Size = new System.Drawing.Size(247, 20);
            this.txt_morada.TabIndex = 9;
            // 
            // txt_turma
            // 
            this.txt_turma.Location = new System.Drawing.Point(144, 311);
            this.txt_turma.MaxLength = 50;
            this.txt_turma.Name = "txt_turma";
            this.txt_turma.Size = new System.Drawing.Size(247, 20);
            this.txt_turma.TabIndex = 10;
            // 
            // txt_nome
            // 
            this.txt_nome.Location = new System.Drawing.Point(144, 139);
            this.txt_nome.MaxLength = 500;
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(247, 20);
            this.txt_nome.TabIndex = 6;
            // 
            // lbl_cont
            // 
            this.lbl_cont.AutoSize = true;
            this.lbl_cont.Location = new System.Drawing.Point(22, 227);
            this.lbl_cont.Name = "lbl_cont";
            this.lbl_cont.Size = new System.Drawing.Size(56, 13);
            this.lbl_cont.TabIndex = 53;
            this.lbl_cont.Text = "Telefone:*";
            // 
            // lbl_dataN
            // 
            this.lbl_dataN.AutoSize = true;
            this.lbl_dataN.Location = new System.Drawing.Point(22, 183);
            this.lbl_dataN.Name = "lbl_dataN";
            this.lbl_dataN.Size = new System.Drawing.Size(111, 13);
            this.lbl_dataN.TabIndex = 52;
            this.lbl_dataN.Text = "Data de Nascimento:*";
            // 
            // lbl_morada
            // 
            this.lbl_morada.AutoSize = true;
            this.lbl_morada.Location = new System.Drawing.Point(22, 271);
            this.lbl_morada.Name = "lbl_morada";
            this.lbl_morada.Size = new System.Drawing.Size(50, 13);
            this.lbl_morada.TabIndex = 51;
            this.lbl_morada.Text = "Morada:*";
            // 
            // lbl_turma
            // 
            this.lbl_turma.AutoSize = true;
            this.lbl_turma.Location = new System.Drawing.Point(22, 313);
            this.lbl_turma.Name = "lbl_turma";
            this.lbl_turma.Size = new System.Drawing.Size(44, 13);
            this.lbl_turma.TabIndex = 50;
            this.lbl_turma.Text = "Turma:*";
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.Location = new System.Drawing.Point(22, 142);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(42, 13);
            this.lbl_nome.TabIndex = 49;
            this.lbl_nome.Text = "Nome:*";
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(144, 15);
            this.txt_user.MaxLength = 100;
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(247, 20);
            this.txt_user.TabIndex = 1;
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(22, 17);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(103, 13);
            this.lbl_user.TabIndex = 48;
            this.lbl_user.Text = "Nome de Utilizador:*";
            // 
            // txt_cont
            // 
            this.txt_cont.Location = new System.Drawing.Point(144, 225);
            this.txt_cont.Name = "txt_cont";
            this.txt_cont.Size = new System.Drawing.Size(247, 20);
            this.txt_cont.TabIndex = 8;
            this.txt_cont.Text = "+351";
            // 
            // btn_pass
            // 
            this.btn_pass.Location = new System.Drawing.Point(370, 55);
            this.btn_pass.Name = "btn_pass";
            this.btn_pass.Size = new System.Drawing.Size(21, 23);
            this.btn_pass.TabIndex = 3;
            this.btn_pass.Text = "۝";
            this.btn_pass.UseVisualStyleBackColor = true;
            this.btn_pass.Click += new System.EventHandler(this.btn_pass_Click);
            // 
            // btn_passRepete
            // 
            this.btn_passRepete.Location = new System.Drawing.Point(370, 96);
            this.btn_passRepete.Name = "btn_passRepete";
            this.btn_passRepete.Size = new System.Drawing.Size(21, 23);
            this.btn_passRepete.TabIndex = 5;
            this.btn_passRepete.Text = "۝";
            this.btn_passRepete.UseVisualStyleBackColor = true;
            this.btn_passRepete.Click += new System.EventHandler(this.btn_passRepete_Click);
            // 
            // Form_Criar_UtilizadorAl
            // 
            this.AcceptButton = this.btn_create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 390);
            this.Controls.Add(this.btn_passRepete);
            this.Controls.Add(this.btn_pass);
            this.Controls.Add(this.lbl_pass2);
            this.Controls.Add(this.txt_pass1);
            this.Controls.Add(this.lbl_pass1);
            this.Controls.Add(this.txt_pass2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.dtp_);
            this.Controls.Add(this.txt_morada);
            this.Controls.Add(this.txt_turma);
            this.Controls.Add(this.txt_nome);
            this.Controls.Add(this.lbl_cont);
            this.Controls.Add(this.lbl_dataN);
            this.Controls.Add(this.lbl_morada);
            this.Controls.Add(this.lbl_turma);
            this.Controls.Add(this.lbl_nome);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.txt_cont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Criar_UtilizadorAl";
            this.Text = "Criar Aluno";
            this.Load += new System.EventHandler(this.Form_Criar_Utilizador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_pass2;
        private System.Windows.Forms.TextBox txt_pass1;
        private System.Windows.Forms.Label lbl_pass1;
        private System.Windows.Forms.TextBox txt_pass2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.DateTimePicker dtp_;
        private System.Windows.Forms.TextBox txt_morada;
        private System.Windows.Forms.TextBox txt_turma;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.Label lbl_cont;
        private System.Windows.Forms.Label lbl_dataN;
        private System.Windows.Forms.Label lbl_morada;
        private System.Windows.Forms.Label lbl_turma;
        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.TextBox txt_cont;
        private System.Windows.Forms.Button btn_passRepete;
        private System.Windows.Forms.Button btn_pass;
    }
}