using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{
    public partial class Form_Passar_Prof : System.Web.UI.Page
    {
        WebService ws;
        List<Pedido> pedidos;
        List<ProfStaff> profStaffs;
        protected void Page_Load(object sender, EventArgs e)
        {           
            try
            {
                if (Session["user"] == null || Session["tipo"] == null || Session["tipo"].ToString() != "Prof")
                {
                    Response.Redirect("Inic.aspx");
                }
                div_user.InnerHtml = Session["user"].ToString();
                ws = new WebService();

                //Inserir os modulos na cbb
                pedidos = ws.getPedidos();
                if (!IsPostBack)
                {
                    try
                    {
                        cbb_pedido.Items.Clear();
                        cbb_pedido.Items.Add("-");
                        for (int i = 0; i < pedidos.Count(); i++)
                        {
                            if (pedidos[i].Prof == Session["user"].ToString() && pedidos[i].Estado == Pedido.enumEstado.PorAprovar)
                                cbb_pedido.Items.Add(pedidos[i].PedidoID.ToString());
                        }
                    }
                    catch (Exception ee)
                    {
                        div_outError.InnerHtml = "<br/>";
                        div_outError.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao carregar os pedidos.</p>" + ee;
                    }
                }


            }
            catch (Exception)
            {
                div_outError.InnerHtml = "<br/>";
                div_outError.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro de ligaç&#227o &#224 DB.</p>";
            }
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbb_pedido.Text != "-")
                {
                    if(cbb_profs.Text != "-")
                    {
                        ws.editPedido(Convert.ToInt32(cbb_pedido.Text), null, cbb_profs.Text.Substring(0, cbb_profs.Text.IndexOf('-') - 1), -1, null, null, null, null, -1, null, null, null, null, null, null, null, -1, null, null, -1);

                        div_labels.InnerHtml = "<p><b>Aluno: </b></p>";
                        div_labels.InnerHtml += "<p><b>M&#243dulo: </b></p>";
                        div_labels.InnerHtml += " <p><b>Data Cria&#231&#227o: </b></p>";
                        cbb_pedido.SelectedIndex = 0;
                        cbb_profs.Items.Clear();

                        div_outError.InnerHtml = "<br/>";
                        div_outError.InnerHtml += "<p style=\"color:green;\">Professor alterado com sucesso!</p>";
                    }
                    else
                    {
                        div_outError.InnerHtml = "<br/>";
                        div_outError.InnerHtml += "<p style=\"color:red;\">Por favor selecione um professor.</p>";
                    }                    
                }
                else
                {
                    div_outError.InnerHtml = "<br/>";
                    div_outError.InnerHtml += "<p style=\"color:red;\">Por favor selecione um pedido.</p>";
                }
            }
            catch (Exception ee)
            {
                div_outError.InnerHtml = "<br/>";
                div_outError.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao alterar o professor." + ee + "</p>";
            }
        }

        protected void cbb_pedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                if (cbb_pedido.Text != "-" && cbb_pedido.Text != "" && cbb_pedido.Text != null)
                {
                    int idx = 0;
                    //Inserir professores dessa disciplina nas labels
                    for (idx = 0; idx < pedidos.Count(); idx++)
                    {
                        if (pedidos[idx].PedidoID == Convert.ToInt32(cbb_pedido.Text) && pedidos[idx].Estado == Pedido.enumEstado.PorAprovar)
                        {
                            div_labels.InnerHtml = "<p><b>Aluno: </b>" + pedidos[idx].Aluno + "</p>";
                            div_labels.InnerHtml += "<p><b>M&#243dulo: </b>" + pedidos[idx].Modulo + "</p>";
                            div_labels.InnerHtml += " <p><b>Data Cria&#231&#227o: </b>" + pedidos[idx].DataCria.ToShortDateString() + "</p>";
                            break;
                        }
                    }

                    //Inserir professores compativeis com esse pedido na cbb
                    profStaffs = ws.getProfStaffs();
                    cbb_profs.Items.Clear();
                    cbb_profs.Items.Add("-");
                    for(int i = 0; i < profStaffs.Count(); i++)
                    {
                        if(profStaffs[i].ProfStaffID != Session["user"].ToString() && !profStaffs[i].Oculto && profStaffs[i].Tipo == ProfStaff.enumTipo.Prof)
                        {
                            //Confirmar se o proff tem a disciplina do pedido                            
                            for(int i2 = 0; i2 < profStaffs[i].Sigla.Count() ; i2++)
                            {
                                Modulo mod = ws.getModulo(pedidos[idx].Modulo);
                                if(profStaffs[i].Sigla[i2] == mod.Sigla && !profStaffs[i].Oculto)
                                {
                                    cbb_profs.Items.Add(profStaffs[i].ProfStaffID + " - " + profStaffs[i].Nome);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                div_outError.InnerHtml = "<br/>";
                div_outError.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao carregar os professores.</p>";
            }
        }
    }
}