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
    public partial class Form_Edit_Func : Form
    {
        public Form_Edit_Func()
        {
            InitializeComponent();
        }

        DAL dal;
        List<ProfStaff> profStaffs;

        private void Form_Edit_UtilizadorFunc_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dal = new DAL();

                //Inserir itens na cbb
                profStaffs = dal.getProfStaffs();
                if (profStaffs.Count > 0)
                {
                    cbb_users.Items.Clear();
                    for (int i = 0; i < profStaffs.Count(); i++)
                    {
                        if (profStaffs[i].Tipo == ProfStaff.enumTipo.Func && !profStaffs[i].Oculto)
                            cbb_users.Items.Add(profStaffs[i].ProfStaffID);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao buscar dados da DB", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem a certeza que pretende cancelar a operação?\nTodos os dados não guardados serão perdidos!", "Cancelar Operação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Regex telReg = new Regex(@"^\+[1-9]{1}[0-9]{3,14}$");

                if (cbb_users.Text != "")
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
                                        if (txt_pass1.Text != "" && txt_pass2.Text != "")
                                        {
                                            if (txt_pass1.Text == txt_pass2.Text)
                                            {
                                                dal.editProfStaff(cbb_users.Text, txt_pass1.Text, txt_nome.Text, dtp_.Value.ToShortDateString(), txt_cont.Text, txt_morada.Text, null, null);
                                                this.Close();
                                            }
                                            else
                                            {
                                                MessageBox.Show("As palavras-passe devem ser iguais!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            if (txt_pass1.Text == "" && txt_pass2.Text == "")
                                            {
                                                dal.editProfStaff(cbb_users.Text, null, txt_nome.Text, dtp_.Value.ToShortDateString(), txt_cont.Text, txt_morada.Text, null, null);
                                                this.Close();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Por favor preencha o campo de palavra-passe ou deixe em branco!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
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
                    MessageBox.Show("Por favor selecione um utilizador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao editar o Aluno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void cbb_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (cbb_users.Text != "")
            {
                for (int i = 0; i < profStaffs.Count(); i++)
                {
                    if (profStaffs[i].ProfStaffID == cbb_users.Text)
                    {
                        txt_cont.Text = profStaffs[i].Telefone;
                        txt_morada.Text = profStaffs[i].Morada;
                        txt_nome.Text = profStaffs[i].Nome;
                        dtp_.Value = profStaffs[i].DataNasc;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
