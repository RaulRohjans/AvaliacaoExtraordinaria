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
    public partial class Form_Criar_Pedido : Form
    {
        public Form_Criar_Pedido()
        {
            InitializeComponent();
        }

        DAL dal;
        List<Aluno> alunos;
        List<ProfStaff> profStaffs;
        List<Modulo> modulos;

        private void Form_Criar_Pedido_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dal = new DAL();

                //Carregar alunos para cbb
                alunos = dal.getAlunos();
                for (int i = 0; i < alunos.Count(); i++)
                {
                    if (!alunos[i].Oculto)
                        cbb_al.Items.Add(alunos[i].AlunoID);
                }

                //Carregar profs para cbb
                profStaffs = dal.getProfStaffs();
                for (int i = 0; i < profStaffs.Count(); i++)
                {
                    if (!profStaffs[i].Oculto && profStaffs[i].Tipo == ProfStaff.enumTipo.Prof)
                        cbb_prof.Items.Add(profStaffs[i].ProfStaffID);
                }

                //Carregar modulos para cbb
                modulos = dal.getModulos();
                for (int i = 0; i < modulos.Count(); i++)
                {
                    cbb_modulo.Items.Add(modulos[i].ModuloID + " - " + modulos[i].Sigla + modulos[i].NumModulo);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao buscar os dados da DB.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btn_criar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if(cbb_al.Text != "")
                {
                    if(cbb_prof.Text != "")
                    {
                        if(cbb_modulo.Text != "")
                        {
                            if(dtp_.Value > System.DateTime.Now)
                            {
                                if(durMins.Value > 30)
                                {
                                    bool erro = false;

                                    Pedido pedido = new Pedido();
                                    pedido.PedidoID = dal.getLastPedido() + 1;
                                    pedido.DataCria = System.DateTime.Now;
                                    pedido.HoraCria = DateTime.Parse(System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute);
                                    pedido.Estado = Pedido.enumEstado.PorAprovar;
                                    pedido.Aluno = cbb_al.Text;
                                    pedido.Prof = cbb_prof.Text;
                                    pedido.Modulo = Convert.ToInt32(cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1).Trim());
                                    pedido.DataExame = dtp_.Value;
                                    pedido.HoraExame = DateTime.Parse(horas.Value.ToString() + ":" + minutos.Value.ToString());
                                    pedido.DurExame = Convert.ToInt32(durMins.Value);

                                    if(txt_preco.Text != "")
                                    {
                                        if(Convert.ToInt32(txt_preco.Text) >= 0)
                                        {
                                            pedido.Preco = Convert.ToDecimal(txt_preco.Text);
                                        }
                                        else
                                        {
                                            erro = true;
                                        }
                                    }

                                    if (txt_meioPaga.Text != "")
                                        pedido.TipoPaga = txt_meioPaga.Text;

                                    switch (cbb_taxa.SelectedIndex)
                                    {
                                        case 0://NULL
                                            pedido.TipoTaxa = Pedido.enumTaxa.NULL;
                                            break;

                                        case 1://Isento
                                            pedido.TipoTaxa = Pedido.enumTaxa.Isento;
                                            break;

                                        case 2://Epoca
                                            pedido.TipoTaxa = Pedido.enumTaxa.Epoca;
                                            break;

                                        case 3://Fora Epoca
                                            pedido.TipoTaxa = Pedido.enumTaxa.ForaEpoca;
                                            break;
                                    }

                                    if (erro == false)
                                    {
                                        dal.addPedido(pedido);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("O preço não pode ser negativo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("O exame deve ter pelo menos 30 minutos de duração!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("A data deve ser superior à atual!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor selecione um modulo da lista!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor selecione um professor da lista!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor selecione um aluno da lista!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("Ocorreu um erro ao criar o pedido." + ee, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tem a certeza que pretende cancelar a operação?\nTodos os dados não guardados serão perdidos!", "Cancelar Operação", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txt_preco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
