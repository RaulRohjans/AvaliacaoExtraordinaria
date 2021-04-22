
namespace AvalExt_Backoffice
{
    partial class Form_Eliminar_Utilizador
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
            this.lbl_user = new System.Windows.Forms.Label();
            this.lbl_nome = new System.Windows.Forms.Label();
            this.cbb_users = new System.Windows.Forms.ComboBox();
            this.lbl_dataN = new System.Windows.Forms.Label();
            this.lbl_turma = new System.Windows.Forms.Label();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_tipo = new System.Windows.Forms.Label();
            this.lbl_cria = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(12, 15);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(53, 13);
            this.lbl_user.TabIndex = 0;
            this.lbl_user.Text = "Utilizador:";
            // 
            // lbl_nome
            // 
            this.lbl_nome.AutoSize = true;
            this.lbl_nome.Location = new System.Drawing.Point(12, 54);
            this.lbl_nome.Name = "lbl_nome";
            this.lbl_nome.Size = new System.Drawing.Size(38, 13);
            this.lbl_nome.TabIndex = 1;
            this.lbl_nome.Text = "Nome:";
            // 
            // cbb_users
            // 
            this.cbb_users.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_users.FormattingEnabled = true;
            this.cbb_users.Location = new System.Drawing.Point(71, 12);
            this.cbb_users.Name = "cbb_users";
            this.cbb_users.Size = new System.Drawing.Size(188, 21);
            this.cbb_users.TabIndex = 0;
            this.cbb_users.SelectedIndexChanged += new System.EventHandler(this.cbb_users_SelectedIndexChanged);
            // 
            // lbl_dataN
            // 
            this.lbl_dataN.AutoSize = true;
            this.lbl_dataN.Location = new System.Drawing.Point(12, 70);
            this.lbl_dataN.Name = "lbl_dataN";
            this.lbl_dataN.Size = new System.Drawing.Size(107, 13);
            this.lbl_dataN.TabIndex = 3;
            this.lbl_dataN.Text = "Data de Nascimento:";
            // 
            // lbl_turma
            // 
            this.lbl_turma.AutoSize = true;
            this.lbl_turma.Location = new System.Drawing.Point(12, 117);
            this.lbl_turma.Name = "lbl_turma";
            this.lbl_turma.Size = new System.Drawing.Size(40, 13);
            this.lbl_turma.TabIndex = 4;
            this.lbl_turma.Text = "Turma:";
            this.lbl_turma.Visible = false;
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(184, 147);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 2;
            this.btn_del.Text = "Eliminar";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(15, 147);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_tipo
            // 
            this.lbl_tipo.AutoSize = true;
            this.lbl_tipo.Location = new System.Drawing.Point(12, 102);
            this.lbl_tipo.Name = "lbl_tipo";
            this.lbl_tipo.Size = new System.Drawing.Size(31, 13);
            this.lbl_tipo.TabIndex = 5;
            this.lbl_tipo.Text = "Tipo:";
            // 
            // lbl_cria
            // 
            this.lbl_cria.AutoSize = true;
            this.lbl_cria.Location = new System.Drawing.Point(12, 87);
            this.lbl_cria.Name = "lbl_cria";
            this.lbl_cria.Size = new System.Drawing.Size(133, 13);
            this.lbl_cria.TabIndex = 6;
            this.lbl_cria.Text = "Data de Criação de Conta:";
            // 
            // Form_Eliminar_Utilizador
            // 
            this.AcceptButton = this.btn_del;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 182);
            this.Controls.Add(this.lbl_cria);
            this.Controls.Add(this.lbl_tipo);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.lbl_turma);
            this.Controls.Add(this.lbl_dataN);
            this.Controls.Add(this.cbb_users);
            this.Controls.Add(this.lbl_nome);
            this.Controls.Add(this.lbl_user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Eliminar_Utilizador";
            this.Text = "Eliminar Utilizador";
            this.Load += new System.EventHandler(this.Form_Eliminar_Utilizador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label lbl_nome;
        private System.Windows.Forms.ComboBox cbb_users;
        private System.Windows.Forms.Label lbl_dataN;
        private System.Windows.Forms.Label lbl_turma;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_tipo;
        private System.Windows.Forms.Label lbl_cria;
    }
}