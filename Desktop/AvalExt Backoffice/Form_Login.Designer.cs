
namespace AvalExt_Backoffice
{
    partial class Form_Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_pass = new System.Windows.Forms.Button();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.lbl_state = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(197, 151);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 13;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_login
            // 
            this.btn_login.Enabled = false;
            this.btn_login.Location = new System.Drawing.Point(12, 151);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 12;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_pass
            // 
            this.btn_pass.Location = new System.Drawing.Point(251, 76);
            this.btn_pass.Name = "btn_pass";
            this.btn_pass.Size = new System.Drawing.Size(21, 23);
            this.btn_pass.TabIndex = 11;
            this.btn_pass.Text = "۝";
            this.btn_pass.UseVisualStyleBackColor = true;
            this.btn_pass.Click += new System.EventHandler(this.btn_pass_Click);
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(12, 78);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '•';
            this.txt_pass.Size = new System.Drawing.Size(233, 20);
            this.txt_pass.TabIndex = 10;
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(12, 27);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(260, 20);
            this.txt_user.TabIndex = 9;
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.Location = new System.Drawing.Point(12, 62);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(56, 13);
            this.lbl_pass.TabIndex = 15;
            this.lbl_pass.Text = "Password:";
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(12, 11);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(58, 13);
            this.lbl_user.TabIndex = 14;
            this.lbl_user.Text = "Username:";
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Location = new System.Drawing.Point(33, 118);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(126, 13);
            this.lbl_state.TabIndex = 17;
            this.lbl_state.Text = "#CONNECTION_STATE";
            this.lbl_state.Visible = false;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(12, 116);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(16, 16);
            this.pb.TabIndex = 16;
            this.pb.TabStop = false;
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "State-Green.ico");
            this.il.Images.SetKeyName(1, "State-Red.ico");
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 186);
            this.Controls.Add(this.lbl_state);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.btn_pass);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.lbl_pass);
            this.Controls.Add(this.lbl_user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_pass;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label lbl_state;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.ErrorProvider ep;
    }
}

