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
    public partial class Form_Criar_Al : Form
    {
        public Form_Criar_Al()
        {
            InitializeComponent();
        }
        DAL dal;
        private void Form_Criar_Utilizador_Load(object sender, EventArgs e)
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

        private void cbb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Regex telReg = new Regex(@"^\+[1-9]{1}[0-9]{3,14}$");
                Regex alReg = new Regex(@"^[Ii](?:[0-9]+)*$");

                if (txt_user.Text != "")
                {
                    if (alReg.IsMatch(txt_user.Text) && txt_user.TextLength == 7)
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
                                                        if (txt_turma.Text != "")
                                                        {
                                                            //Ver se ja existe algum aluno com esse id
                                                            if (!dal.checkAluno("I" + txt_user.Text.Substring(1)))
                                                            {
                                                                Aluno aluno = new Aluno();
                                                                aluno.AlunoID = "I" + txt_user.Text.Substring(1);
                                                                aluno.DataCria = System.DateTime.Now;
                                                                aluno.DataNasc = dtp_.Value;
                                                                aluno.Morada = txt_morada.Text;
                                                                aluno.Nome = txt_nome.Text;
                                                                aluno.Password = dal.sha256(txt_pass1.Text);
                                                                aluno.Telefone = txt_cont.Text;
                                                                aluno.Turma = txt_turma.Text;

                                                                dal.addAluno(aluno);
                                                                this.Close();
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Esse aluno já existe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Por favor insira uma turma!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("O nome de utilizador do aluno deve começar com um i, seguido de 6 numeros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor insira um nome de utilizador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao criar o Aluno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem a certeza que pretende cancelar a operação?\nTodos os dados não guardados serão perdidos!", "Cancelar Operação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.Close();
        }
    }
}
