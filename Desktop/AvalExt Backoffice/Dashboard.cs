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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            //inicializar o sorter e associa-lo à lsv
            lvwColumnSorter = new ListViewColumnSorter();
            this.lsv_pedidos.ListViewItemSorter = lvwColumnSorter;
        }

        DAL dal;
        List<Pedido> pedidos = new List<Pedido>();
        ListViewColumnSorter lvwColumnSorter;
        List<ProfStaff> profStaffs = new List<ProfStaff>();
        List<Aluno> alunos = new List<Aluno>();
        List<Modulo> modulos = new List<Modulo>();

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                dal = new DAL();
                RefreshCbb();
                RefreshList();

                cbb_modulo.SelectedIndex = 0;
                cbb_prof.SelectedIndex = 0;
                cbb_al.SelectedIndex = 0;
                cbb_estado.SelectedIndex = 0;                
            }
            catch(Exception ee)
            {
                MessageBox.Show("Ocorreu um erro ao adquirir os dados da DB." + ee , "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshCbb()
        {
            /*--------------Popular as Listas e cbbs---------------------*/
            //Alunos
            alunos.Clear();
            alunos = dal.getAlunos();
            cbb_al.Items.Clear();
            cbb_al.Items.Add("-");
            foreach (Aluno al in alunos)
            {
                if (!al.Oculto)
                    cbb_al.Items.Add(al.AlunoID);
                else
                    cbb_al.Items.Add(al.AlunoID + "(Eliminado)");
            }
            

            //Profs
            profStaffs.Clear();
            profStaffs = dal.getProfStaffs();
            cbb_prof.Items.Clear();
            cbb_prof.Items.Add("-");
            foreach (ProfStaff prof in profStaffs)
            {
                if (prof.Tipo == ProfStaff.enumTipo.Prof)
                {
                    if (!prof.Oculto)
                        cbb_prof.Items.Add(prof.ProfStaffID);
                    else
                        cbb_prof.Items.Add(prof.ProfStaffID + "(Eliminado)");
                }
            }            

            //Modulos
            modulos.Clear();
            modulos = dal.getModulos();
            cbb_modulo.Items.Clear();
            cbb_modulo.Items.Add("-");
            foreach (Modulo mod in modulos)
            {
                cbb_modulo.Items.Add(mod.ModuloID.ToString() + " - " + mod.Sigla + mod.NumModulo.ToString());
            }

            cbb_modulo.SelectedIndex = 0;
            cbb_prof.SelectedIndex = 0;
            cbb_al.SelectedIndex = 0;
            cbb_estado.SelectedIndex = 0;
            //*-----------------Fim da populacao---------------------*/
        }

        public void RefreshList()
        {
            Cursor.Current = Cursors.WaitCursor;
            lsv_pedidos.Items.Clear();

            alunos.Clear();
            alunos = dal.getAlunos();

            profStaffs.Clear();
            profStaffs = dal.getProfStaffs();

            modulos.Clear();
            modulos = dal.getModulos();

            //Obter lista com os pedidos filtrados
                //Verificacao e necessaria pois se a combo box nao tiver nada vai dar uma excessao
            if (cbb_modulo.Text != "-")
            {
                switch (cbb_estado.SelectedIndex)
                {
                    case 0:
                        pedidos = dal.queryPedido(null, null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, cbb_prof.Text, cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                        break;

                    case 1:
                        pedidos = dal.queryPedido(null, "DataCria", dtp_inic.Value, dtp_fim.Value, cbb_al.Text, cbb_prof.Text, cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                        break;

                    case 2:
                        pedidos = dal.queryPedido("PorAprovar", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, cbb_prof.Text, cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                        break;

                    case 3:
                        pedidos = dal.queryPedido("NaoAprovado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, cbb_prof.Text, cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                        break;

                    case 4:
                        pedidos = dal.queryPedido("Aprovado", "DataAprov", dtp_inic.Value, dtp_fim.Value, cbb_al.Text, cbb_prof.Text, cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                        break;

                    case 5:
                        pedidos = dal.queryPedido("Pago", "DataPago", dtp_inic.Value, dtp_fim.Value, cbb_al.Text, cbb_prof.Text, cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                        break;

                    case 6:
                        pedidos = dal.queryPedido("Lancado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, cbb_prof.Text, cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                        break;

                    case 7:
                        pedidos = dal.queryPedido("Terminado", "DataTermin", dtp_inic.Value, dtp_fim.Value, cbb_al.Text, cbb_prof.Text, cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                        break;
                }
            }
            else
            {
                switch (cbb_estado.SelectedIndex)
                {
                    case 0:
                        pedidos = dal.queryPedido(null, null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, cbb_prof.Text, "-");
                        break;

                    case 1:
                        pedidos = dal.queryPedido(null, "DataCria", dtp_inic.Value, dtp_fim.Value, cbb_al.Text, cbb_prof.Text, "-");
                        break;

                    case 2:
                        pedidos = dal.queryPedido("PorAprovar", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, cbb_prof.Text,"-");
                        break;

                    case 3:
                        pedidos = dal.queryPedido("NaoAprovado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, cbb_prof.Text, "-");
                        break;

                    case 4:
                        pedidos = dal.queryPedido("Aprovado", "DataAprov", dtp_inic.Value, dtp_fim.Value, cbb_al.Text, cbb_prof.Text, "-");
                        break;

                    case 5:
                        pedidos = dal.queryPedido("Pago", "DataPago", dtp_inic.Value, dtp_fim.Value, cbb_al.Text, cbb_prof.Text, "-");
                        break;

                    case 6:
                        pedidos = dal.queryPedido("Lancado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, cbb_prof.Text, "-");
                        break;

                    case 7:
                        pedidos = dal.queryPedido("Terminado", "DataTermin", dtp_inic.Value, dtp_fim.Value, cbb_al.Text, cbb_prof.Text, "-");
                        break;
                }
            }


            /*--------------Inserir dados na lsv---------------------*/
            for (int i = 0; i < pedidos.Count(); i++)
            {               
                ListViewItem lvi = new ListViewItem(pedidos[i].PedidoID.ToString());
                lvi.SubItems.Add(pedidos[i].Aluno);
                lvi.SubItems.Add(pedidos[i].Prof);

                Modulo modulo = dal.getModulo(pedidos[i].Modulo);
                lvi.SubItems.Add(modulo.Sigla + modulo.NumModulo);

                switch(pedidos[i].Estado)
                {
                    case Pedido.enumEstado.Aprovado:
                        lvi.SubItems.Add("Aprovado");
                        break;

                    case Pedido.enumEstado.Pago:
                        lvi.SubItems.Add("Pago");
                        break;

                    case Pedido.enumEstado.PorAprovar:
                        lvi.SubItems.Add("Por Aprovar");
                        break;

                    case Pedido.enumEstado.Terminado:
                        lvi.SubItems.Add("Terminado");
                        break;

                    case Pedido.enumEstado.Lancado:
                        lvi.SubItems.Add("Lançado");
                        break;

                    case Pedido.enumEstado.NaoAprovado:
                        lvi.SubItems.Add("Não Aprovado");
                        break;
                }

                if(pedidos[i].Preco != -1)
                    lvi.SubItems.Add(pedidos[i].Preco.ToString("0.00") + "€");
                else
                    lvi.SubItems.Add("-");

                if(pedidos[i].TipoPaga != "")
                    lvi.SubItems.Add(pedidos[i].TipoPaga);
                else
                    lvi.SubItems.Add("-");                               

                switch(pedidos[i].TipoTaxa)
                {
                    case Pedido.enumTaxa.NULL:
                        lvi.SubItems.Add("-");
                        break;

                    case Pedido.enumTaxa.Epoca:
                        lvi.SubItems.Add("Dentro da Época");
                        break;

                    case Pedido.enumTaxa.ForaEpoca:
                        lvi.SubItems.Add("Fora da Época");
                        break;

                    case Pedido.enumTaxa.Isento:
                        lvi.SubItems.Add("Isento");
                        break;
                }

                lvi.Tag = pedidos[i].PedidoID;

                lsv_pedidos.Items.Add(lvi);
            }
            /*------------------------------------------------------*/
            Cursor.Current = Cursors.Default;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            //Fazer logout com verificação
            DialogResult result = MessageBox.Show("Tem a certeza que pretende efetuar o logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form_Login login = new Form_Login();
                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }
        }

        private void btn_refresh_apoios_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshCbb();
                RefreshList();
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar os dados da lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsv_pedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                /*--------------Mostrar info na groupbox------------------------*/
                for (int i = 0; i < pedidos.Count(); i++)
                {
                    if (Convert.ToInt32(lsv_pedidos.SelectedItems[0].Tag) == pedidos[i].PedidoID)
                    {
                        gpb_.Text = "Pedido: " + pedidos[i].PedidoID;

                        lbl_outDataCria.Text = pedidos[i].DataCria.ToShortDateString();
                        lbl_outHoraCria.Text = pedidos[i].HoraCria.ToShortTimeString();

                        if (pedidos[i].DataExame != DateTime.Parse("999-1-1") && pedidos[i].HoraExame != DateTime.Parse("999-1-1"))
                        {
                            lbl_outDataExame.Text = pedidos[i].DataExame.ToShortDateString();
                            lbl_outHoraExame.Text = pedidos[i].HoraExame.ToShortTimeString();
                        }
                        else
                        {
                            lbl_outDataExame.Text = "-";
                            lbl_outHoraExame.Text = "-";
                        }

                        if (pedidos[i].DurExame != -1)
                        {
                            lbl_outDurExame.Text = pedidos[i].DurExame.ToString() + " minutos";
                        }
                        else
                        {
                            lbl_outDurExame.Text = "-";
                        }

                        if (pedidos[i].DataPago != DateTime.Parse("999-1-1") && pedidos[i].HoraPago != DateTime.Parse("999-1-1"))
                        {
                            lbl_outDataPaga.Text = pedidos[i].DataPago.ToShortDateString();
                            lbl_outHoraPaga.Text = pedidos[i].HoraPago.ToShortTimeString();
                        }
                        else
                        {
                            lbl_outDataPaga.Text = "-";
                            lbl_outHoraPaga.Text = "-";
                        }

                        if (pedidos[i].DataTermin != DateTime.Parse("999-1-1") && pedidos[i].HoraTermin != DateTime.Parse("999-1-1"))
                        {
                            lbl_outDataConc.Text = pedidos[i].DataTermin.ToShortDateString();
                            lbl_outHoraConc.Text = pedidos[i].HoraTermin.ToShortTimeString();
                        }
                        else
                        {
                            lbl_outDataConc.Text = "-";
                            lbl_outHoraConc.Text = "-";
                        }
                    }
                }
                /*-----------------------------------------------------------*/
            }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao obter a informação do pedido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void smi_aprovar_Click(object sender, EventArgs e)
        {
            //Abrir form eliminar utilizador
            Form_Eliminar_Utilizador delUser = new Form_Eliminar_Utilizador();
            delUser.Show();
        }

        private void smi_ApAprov_Click(object sender, EventArgs e)
        {

        }

        private void smi_criar_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmi_criarAl_Click(object sender, EventArgs e)
        {
            //Abrir form criar aluno
            Form_Criar_Al criarAL = new Form_Criar_Al();
            criarAL.Show();
        }

        private void tsmi_criarProf_Click(object sender, EventArgs e)
        {
            //Abrir form criar professor
            Form_Criar_Prof criarProf = new Form_Criar_Prof();
            criarProf.Show();
        }

        private void tsmi_criarFunc_Click(object sender, EventArgs e)
        {
            //Abrir form criar funcionario
            Form_Criar_Func criarFunc = new Form_Criar_Func();
            criarFunc.Show();
        }

        private void tsmi_editAl_Click(object sender, EventArgs e)
        {
            //Abrir form editar aluno
            Form_Edit_Al editAl = new Form_Edit_Al();
            editAl.Show();
        }

        private void tsmi_editProf_Click(object sender, EventArgs e)
        {
            //Abrir form editar professor
            Form_Edit_Prof editProf = new Form_Edit_Prof();
            editProf.Show();
        }

        private void tsmi_editFunc_Click(object sender, EventArgs e)
        {
            //Abrir form editar funcionario
            Form_Edit_Func editFunc = new Form_Edit_Func();
            editFunc.Show();
        }

        private void smi_tP_Click(object sender, EventArgs e)
        {
            //Quantiade de pedidos
            MessageBox.Show("Quantidade total de pedidos realizados: " + dal.getQtdPedidos().ToString(), "Quantidade de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void smi_tU_Click(object sender, EventArgs e)
        {
            //Quantidade de users
            MessageBox.Show("Quantidade total de utilizadores: " + dal.getQtdUsers().ToString(), "Quantidade de Utilizadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lsv_pedidos_DoubleClick(object sender, EventArgs e)
        {
            //Abrir form de editar pedido
            Form_Editar_Eliminar_Pedido delEditPed = new Form_Editar_Eliminar_Pedido();
            delEditPed.Passa(Convert.ToInt32(lsv_pedidos.SelectedItems[0].Tag));
            delEditPed.Show();
        }

        private void btn_addPed_Click(object sender, EventArgs e)
        {
            //Abrir form de criar pedido
            Form_Criar_Pedido criarPedido = new Form_Criar_Pedido();
            criarPedido.Show();
        }

        private void lsv_pedidos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            /*---------Ordenar a Listview--------------*/
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            lsv_pedidos.Sort();
            /*-----------------------------------------*/
        }

        private void cbb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            /*-----------Desativar os dtp para os estados que nao tem data--------------*/
            switch(cbb_estado.SelectedIndex)
            {
                case 0:
                    dtp_inic.Enabled = false;
                    dtp_fim.Enabled = false;
                    break;

                case 1:
                    dtp_inic.Enabled = true;
                    dtp_fim.Enabled = true;
                    break;

                case 2:
                    dtp_inic.Enabled = false;
                    dtp_fim.Enabled = false;
                    break;

                case 3:
                    dtp_inic.Enabled = false;
                    dtp_fim.Enabled = false;
                    break;

                case 4:
                    dtp_inic.Enabled = true;
                    dtp_fim.Enabled = true;
                    break;

                case 5:
                    dtp_inic.Enabled = true;
                    dtp_fim.Enabled = true;
                    break;

                case 6:
                    dtp_inic.Enabled = false;
                    dtp_fim.Enabled = false;
                    break;

                case 7:
                    dtp_inic.Enabled = true;
                    dtp_fim.Enabled = true;
                    break;

            }
            /*----------------------------------------------------------------------------*/
            Cursor.Current = Cursors.Default;
        }

        private void btn_aplicar_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshList();
            }
            catch(Exception ee)
            {
                MessageBox.Show("Ocorreu um erro ao aplicar os filtros." + ee, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_limparFiltros_Click(object sender, EventArgs e)
        {
            try
            {
                /*-------------Colocar o controlos no estado default-----------------*/
                cbb_estado.SelectedIndex = 0;
                cbb_al.SelectedIndex = 0;
                cbb_prof.SelectedIndex = 0;
                cbb_modulo.SelectedIndex = 0;
                dtp_inic.Value = System.DateTime.Now;
                dtp_fim.Value = System.DateTime.Now;
                dtp_fim.Enabled = false;
                dtp_inic.Enabled = false;
                RefreshList();
                /*--------------------------------------------------------------------*/
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao limpar os filtros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
