using AvalExt_Backoffice.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvalExt_Backoffice
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        DAL dal;

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dal = new DAL();

                pb.Image = il.Images[0];
                lbl_state.Visible = true;
                lbl_state.Text = "Connection Successful!";
                btn_login.Enabled = true;
            }
            catch (Exception)
            {
                pb.Image = il.Images[1];
                lbl_state.Visible = true;
                lbl_state.Text = "Connection Failed!";
                btn_login.Enabled = false;
            }
            Cursor.Current = Cursors.Default;
        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            if (txt_pass.PasswordChar != '\0')
                txt_pass.PasswordChar = '\0';
            else
                txt_pass.PasswordChar = '•';
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ProfStaff profStaff = dal.getProfStaff(txt_user.Text);

                if(profStaff.Password == dal.sha256(txt_pass.Text))
                {
                    if (profStaff.Tipo == ProfStaff.enumTipo.Func)
                    {
                        this.Hide();
                        Dashboard dash = new Dashboard();
                        dash.FormClosed += (s, args) => this.Close();
                        dash.Show();
                    }
                    else
                    {
                        MessageBox.Show("Esse utilizador não é um Funcionário!", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Palavra-passe errada!", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Esse funcionário não existe!", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao buscar os dados dos funcionários.\nTente novamente mais tarde. ", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
