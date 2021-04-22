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
    public partial class Form_Editar_Eliminar_Pedido : Form
    {
        public Form_Editar_Eliminar_Pedido()
        {
            InitializeComponent();
        }

        DAL dal;
        Pedido pedidos;
        List<Aluno> alunos;
        List<ProfStaff> profStaffs;
        List<Modulo> modulos;
        int id = 0;

        public void Passa(int ID)
        {
            id = ID;
        }

        private void Form_Editar_Eliminar_Pedido_Load(object sender, EventArgs e)
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

                //Atualizar os dados dos controlos
                pedidos = dal.getPedido(id);

                //Ativar botao aprovar se o estado for por aprovar
                if (pedidos.Estado == Pedido.enumEstado.PorAprovar)
                    btn_aprov.Enabled = true;
                else
                    btn_aprov.Enabled = false;

                //Preencher os campos com os dados correspondentes ao id selecionado
                lbl_ID.Text = pedidos.PedidoID.ToString();
                cbb_al.SelectedItem = pedidos.Aluno;
                txt_meioPaga.Text = pedidos.TipoPaga;

                Modulo modulo = dal.getModulo(pedidos.Modulo);
                cbb_modulo.SelectedItem = pedidos.Modulo.ToString() + " - " + modulo.Sigla + modulo.NumModulo;

                if(pedidos.Nota != -1)
                    txt_nota.Text = pedidos.Nota.ToString();

                txt_preco.Text = pedidos.Preco.ToString();
                cbb_prof.SelectedItem = pedidos.Prof;
                dtp_.Value = pedidos.DataExame;
                horas.Value = pedidos.HoraExame.Hour;
                minutos.Value = pedidos.HoraExame.Minute;
                durMins.Value = pedidos.DurExame;

                switch (pedidos.TipoTaxa)
                {
                    case Pedido.enumTaxa.NULL:
                        cbb_taxa.SelectedIndex = 0;
                        break;

                    case Pedido.enumTaxa.Isento:
                        cbb_taxa.SelectedIndex = 1;
                        break;

                    case Pedido.enumTaxa.Epoca:
                        cbb_taxa.SelectedIndex = 2;
                        break;

                    case Pedido.enumTaxa.ForaEpoca:
                        cbb_taxa.SelectedIndex = 0;
                        break;
                }


                
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao buscar os dados da DB.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btn_aprov_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dal.editPedido(Convert.ToInt32(pedidos.PedidoID), null, null, -1, null, null, null, null, -1, null, null, null, null, null, null, "Aprovado", -1, null, null, -1);
                Cursor.Current = Cursors.Default;
                this.Close();                
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao aprovar o pedido selecionado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (pedidos.Estado == Pedido.enumEstado.PorAprovar)
                {
                    DialogResult res = MessageBox.Show("Tem a certeza que pretende eliminar o pedido selecionado?\nNão poderá voltar atrás após a operação ter sido executada!", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (res == DialogResult.Yes)
                    {
                        dal.delPedido(Convert.ToInt32(pedidos.PedidoID));

                        Cursor.Current = Cursors.Default;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Apenas pode eliminar pedidos que ainda não tenham sido aprovados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao eliminar o pedido selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void cbb_pedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tem a certeza que pretende cancelar a operação?\nTodos os dados não guardados serão perdidos!", "Cancelar Operação", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if(res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
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
                            if(dtp_.Value > pedidos.DataCria)
                            {
                                bool erro = false;

                                Pedido pedido = new Pedido();
                                pedido.PedidoID = Convert.ToInt32(pedidos.PedidoID);
                                pedido.Aluno = cbb_al.Text;
                                pedido.Prof = cbb_prof.Text;
                                pedido.Modulo = Convert.ToInt32(cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1).Trim());
                                pedido.DataExame = dtp_.Value;
                                pedido.HoraExame = DateTime.Parse(horas.Value.ToString() + ":" + minutos.Value.ToString());
                                pedido.DurExame = Convert.ToInt32(durMins.Value);
                                    
                                if(txt_preco.Text != "")
                                {
                                    if (Convert.ToInt32(txt_preco.Text) >= 0)
                                        pedido.Preco = Convert.ToDecimal(txt_preco.Text);
                                    else
                                        erro = true;
                                }
                                else
                                {
                                    pedido.Preco = -1;
                                }

                                if(txt_meioPaga.Text != "")
                                {
                                    pedido.TipoPaga = txt_meioPaga.Text;
                                }
                                else
                                {
                                    pedido.TipoPaga = null;
                                }

                                pedido.Nota = Convert.ToDouble(txt_nota.Text);

                                if (erro == false)
                                {
                                    switch (cbb_taxa.SelectedIndex)
                                    {
                                        case 0://NULL
                                            dal.editPedido(pedido.PedidoID, pedido.Aluno, pedido.Prof, pedido.Modulo, null, null, pedido.DataExame.ToShortDateString(), pedido.HoraExame.ToShortTimeString(), pedido.DurExame, null, null, null, null, null, null, null, pedido.Preco, pedido.TipoPaga, "", pedido.Nota);
                                            break;

                                        case 1://Isento
                                            dal.editPedido(pedido.PedidoID, pedido.Aluno, pedido.Prof, pedido.Modulo, null, null, pedido.DataExame.ToShortDateString(), pedido.HoraExame.ToShortTimeString(), pedido.DurExame, null, null, null, null, null, null, null, pedido.Preco, pedido.TipoPaga, "Isento", pedido.Nota);
                                            break;

                                        case 2://Epoca
                                            dal.editPedido(pedido.PedidoID, pedido.Aluno, pedido.Prof, pedido.Modulo, null, null, pedido.DataExame.ToShortDateString(), pedido.HoraExame.ToShortTimeString(), pedido.DurExame, null, null, null, null, null, null, null, pedido.Preco, pedido.TipoPaga, "Epoca", pedido.Nota);
                                            break;

                                        case 3://Fora Epoca
                                            dal.editPedido(pedido.PedidoID, pedido.Aluno, pedido.Prof, pedido.Modulo, null, null, pedido.DataExame.ToShortDateString(), pedido.HoraExame.ToShortTimeString(), pedido.DurExame, null, null, null, null, null, null, null, pedido.Preco, pedido.TipoPaga, "ForaEpoca", pedido.Nota);
                                            break;
                                    }

                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("O preco nao pode ser negativo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("A data do exame deve ser posterior à do pedido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao guardar as alterações do pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void txt_preco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
