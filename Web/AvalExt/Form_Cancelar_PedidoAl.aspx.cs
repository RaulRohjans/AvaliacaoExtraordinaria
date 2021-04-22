using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{
    public partial class Form_Cancelar_PedidoAl : System.Web.UI.Page
    {
        WebService ws;
        List<Pedido> pedidos;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] == null || Session["tipo"] == null || Session["tipo"].ToString() != "Aluno")
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
                            if (pedidos[i].Aluno == Session["user"].ToString() && pedidos[i].Estado == Pedido.enumEstado.PorAprovar)
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
                    ws.delPedido(Convert.ToInt32(cbb_pedido.Text));

                    div_labels.InnerHtml = "<p><b>Professor: </b></p>";
                    div_labels.InnerHtml += "<p><b>M&#243dulo: </b></p>";
                    div_labels.InnerHtml += " <p><b>Data Cria&#231&#227o: </b></p>";
                    cbb_pedido.SelectedIndex = 0;

                    div_outError.InnerHtml = "<br/>";
                    div_outError.InnerHtml += "<p style=\"color:green;\">Pedido cancelado com sucesso!</p>";
                }
                else
                {
                    div_outError.InnerHtml = "<br/>";
                    div_outError.InnerHtml += "<p style=\"color:red;\">Por favor selecione um pedido.</p>";
                }
            }
            catch (Exception)
            {
                div_outError.InnerHtml = "<br/>";
                div_outError.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao cancelar o pedido.</p>";
            }
        }

        protected void cbb_pedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Inserir professores dessa disciplina nas labels
                if (cbb_pedido.Text != "-" && cbb_pedido.Text != "" && cbb_pedido.Text != null)
                {
                    for (int i = 0; i < pedidos.Count(); i++)
                    {
                        if (pedidos[i].PedidoID == Convert.ToInt32(cbb_pedido.Text) && pedidos[i].Estado == Pedido.enumEstado.PorAprovar)
                        {
                            div_labels.InnerHtml = "<p><b>Professor: </b>" + pedidos[i].Prof + "</p>";
                            div_labels.InnerHtml += "<p><b>M&#243dulo: </b>" + pedidos[i].Modulo + "</p>";
                            div_labels.InnerHtml += " <p><b>Data Cria&#231&#227o: </b>" + pedidos[i].DataCria.ToShortDateString() + "</p>";
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                div_outError.InnerHtml = "<br/>";
                div_outError.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao carregar os professores." + ee + "</p>";
            }
        }
    }
}