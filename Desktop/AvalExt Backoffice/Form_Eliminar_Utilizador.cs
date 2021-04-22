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
    public partial class Form_Eliminar_Utilizador : Form
    {
        public Form_Eliminar_Utilizador()
        {
            InitializeComponent();
        }

        DAL dal;
        List<Aluno> alunos;
        List<ProfStaff> profStaffs;

        private void Form_Eliminar_Utilizador_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dal = new DAL();                
                LoadCbb();                
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao obter os dados da DB", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void LoadCbb()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Carregar Utilizadores para a cbb
                alunos = dal.getAlunos();
                profStaffs = dal.getProfStaffs();

                if (alunos.Count() > 0)
                {
                    for (int i = 0; i < alunos.Count(); i++)
                    {
                        if(!alunos[i].Oculto)
                            cbb_users.Items.Add(alunos[i].AlunoID);
                    }
                }

                if (profStaffs.Count() > 0)
                {
                    for (int i = 0; i < profStaffs.Count(); i++)
                    {
                        if(!profStaffs[i].Oculto)
                            cbb_users.Items.Add(profStaffs[i].ProfStaffID);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao carregar os dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if(cbb_users.Text != "")
                {
                    //Verificar se o utilizador tem pedidos associados
                    if(dal.getQtdPedidos(cbb_users.Text) > 0)
                    {
                        DialogResult dr = MessageBox.Show("Este utilizador tem pedidos associados, ao eliminá-lo os pedidos irão ser marcados como terminados.\nPretende continuar?", "Eliminar Utilizador", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if(dr == DialogResult.Yes)
                        {
                            dal.delUser(cbb_users.Text);

                            //Colocar os pedidos do user como terminados
                            int[] pedidos = dal.getPedidosFromUser(cbb_users.Text);
                            
                            for(int i = 0; i < pedidos.Count(); i++)
                            {
                                dal.editPedido(pedidos[i], null, null, -1, null, null, null, null, -1, null, null, null, null, null, null, "Terminado", -1, null, null, -1);
                            }
                        }
                    }
                    else
                    {
                        dal.delUser(cbb_users.Text);                        
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor selecione um utilizador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar o utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void cbb_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (cbb_users.Text != "")
            {
                bool aluno = false;
                int i;

                //Determinar o tipo de user
                for (i = 0; i < alunos.Count(); i++)
                {
                    if(alunos[i].AlunoID == cbb_users.Text)
                    {
                        aluno = true;
                        break;
                    }    
                }

                if(aluno)
                {
                    lbl_dataN.Text = "Data de Nascimento: " + alunos[i].DataNasc.ToShortDateString();
                    lbl_nome.Text = "Nome: " + alunos[i].Nome;
                    lbl_tipo.Text = "Tipo: Aluno";
                    lbl_cria.Text = "Data de Criação de Conta: " + alunos[i].DataCria.ToShortDateString();
                    lbl_turma.Visible = true;
                    lbl_turma.Text = "Turma: " + alunos[i].Turma;
                }
                else
                {
                    for(i = 0; i < profStaffs.Count(); i++)
                    {
                        if(profStaffs[i].ProfStaffID == cbb_users.Text)
                        {
                            if(profStaffs[i].Tipo == ProfStaff.enumTipo.Func)
                            {
                                lbl_dataN.Text = "Data de Nascimento: " + profStaffs[i].DataNasc.ToShortDateString();
                                lbl_nome.Text = "Nome: " + profStaffs[i].Nome;
                                lbl_tipo.Text = "Tipo: Funcionário";
                                lbl_cria.Text = "Data de Criação de Conta: " + profStaffs[i].DataCria.ToShortDateString();
                                lbl_turma.Visible = false;
                                lbl_turma.Text = "Turma: ";
                            }
                            else
                            {
                                lbl_dataN.Text = "Data de Nascimento: " + profStaffs[i].DataNasc.ToShortDateString();
                                lbl_nome.Text = "Nome: " + profStaffs[i].Nome;
                                lbl_tipo.Text = "Tipo: Professor";
                                lbl_cria.Text = "Data de Criação de Conta: " + profStaffs[i].DataCria.ToShortDateString();
                                lbl_turma.Visible = false;
                                lbl_turma.Text = "Turma: ";
                            }
                        }
                    }
                }
                
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
