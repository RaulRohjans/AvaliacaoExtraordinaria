using AvalExt_Backoffice.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvalExt_Backoffice
{
    public partial class Form_Criar_Prof : Form
    {
        public Form_Criar_Prof()
        {
            InitializeComponent();
        }
        DAL dal;

        private void Form_Criar_UtilizadorProf_Load(object sender, EventArgs e)
        {
            try
            {
                dal = new DAL();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao buscar dados da DB", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            if (txt_pass1.PasswordChar != '\0')
                txt_pass1.PasswordChar = '\0';
            else
                txt_pass1.PasswordChar = '•';
        }

        private void btn_passRepete_Click(object sender, EventArgs e)
        {
            if (txt_pass2.PasswordChar != '\0')
                txt_pass2.PasswordChar = '\0';
            else
                txt_pass2.PasswordChar = '•';
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Regex telReg = new Regex(@"^\+[1-9]{1}[0-9]{3,14}$");

                if (txt_user.Text != "")
                {
                    if (txt_pass1.Text != "")
                    {
                        if (txt_pass2.Text != "")
                        {
                            if (txt_pass1.Text == txt_pass2.Text)
                            {
                                if (txt_nome.Text != "")
                                {
                                    if (dtp_.Value < System.DateTime.Now)
                                    {
                                        if (txt_cont.Text != "")
                                        {
                                            if (telReg.IsMatch(txt_cont.Text))
                                            {
                                                if (txt_morada.Text != "")
                                                {
                                                    if (chk_ac.Checked || chk_ai.Checked || chk_ef.Checked || chk_fq.Checked || chk_ing.Checked || chk_mat.Checked || chk_psi.Checked || chk_pt.Checked || chk_rc.Checked || chk_so.Checked || chk_tic.Checked)
                                                    {
                                                        if (!dal.checkProfStaff(txt_user.Text))
                                                        {
                                                            ProfStaff profStaff = new ProfStaff();

                                                            profStaff.ProfStaffID = txt_user.Text;
                                                            profStaff.DataCria = System.DateTime.Now;
                                                            profStaff.DataNasc = dtp_.Value;
                                                            profStaff.Morada = txt_morada.Text;
                                                            profStaff.Nome = txt_nome.Text;
                                                            profStaff.Password = dal.sha256(txt_pass1.Text);
                                                            profStaff.Telefone = txt_cont.Text;
                                                            profStaff.Tipo = ProfStaff.enumTipo.Prof;

                                                            if (chk_ac.Checked)
                                                                profStaff.Sigla.Add("AC");

                                                            if (chk_ai.Checked)
                                                                profStaff.Sigla.Add("AI");

                                                            if (chk_ef.Checked)
                                                                profStaff.Sigla.Add("EF");

                                                            if (chk_fq.Checked)
                                                                profStaff.Sigla.Add("FQ");

                                                            if (chk_ing.Checked)
                                                                profStaff.Sigla.Add("ING");

                                                            if (chk_mat.Checked)
                                                                profStaff.Sigla.Add("MAT");

                                                            if (chk_psi.Checked)
                                                                profStaff.Sigla.Add("PSI");

                                                            if (chk_pt.Checked)
                                                                profStaff.Sigla.Add("PT");

                                                            if (chk_rc.Checked)
                                                                profStaff.Sigla.Add("RC");

                                                            if (chk_so.Checked)
                                                                profStaff.Sigla.Add("SO");

                                                            if (chk_tic.Checked)
                                                                profStaff.Sigla.Add("TIC");

                                                            dal.addProfStaff(profStaff);

                                                            this.Close();
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Já existe um utilizador com esse ID!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Por favor selecione pelo menos uma disciplina!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Por favor insira uma morada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Por favor insira um numero de telefone válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Por favor insira um numero de telefone!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Por favor insira uma data de nascimento válida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por favor insira um nome!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("As palavras-passe devem ser iguais!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor repita a palavra-passe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor insira uma palavra-passe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor insira um nome de utilizador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao criar o Professor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem a certeza que pretende cancelar a operação?\nTodos os dados não guardados serão perdidos!", "Cancelar Operação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.Close();
        }

        private void txt_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;                
            }
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
