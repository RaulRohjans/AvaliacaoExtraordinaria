using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{
    public partial class AvalPedidos_Func : System.Web.UI.Page
    {        
        WebService ws;
        List<Pedido> pedidos;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] == null || Session["tipo"] == null || Session["tipo"].ToString() != "Func")
                {
                    Response.Redirect("Inic.aspx");
                }
                ws = new WebService();
                pedidos = ws.getPedidos();

                decimal[] precos = new decimal[pedidos.Count()];

                //inserir precos no array
                for (int i = 0; i < pedidos.Count(); i++)
                {
                    if (Request.Form[pedidos[i].PedidoID.ToString()] != null && Request.Form[pedidos[i].PedidoID.ToString()].ToString() != "")
                    {
                        string s = Request.Form[pedidos[i].PedidoID.ToString()];
                        int temp = (int)(Convert.ToDouble(s) * 100);
                        precos[i] = Convert.ToDecimal(temp / 100.0);
                    }
                    else
                    {
                        precos[i] = -1;
                    }
                }

                //Atualizar avaliacoes dos pedidos
                for (int i = 0; i < pedidos.Count(); i++)
                {
                    if (precos[i] != -1)
                    {
                        ws.editPedido(pedidos[i].PedidoID, null, null, -1, null, null, null, null, -1, null, null, null, null, null, null, null, precos[i], null, null, -1);
                    }
                }

                Response.Redirect("Form_ConsultarFunc.aspx");
            }
            catch (Exception ee)
            {
                Response.Write("Ocorreu um ao avaliar os pedidos!" + ee);
            }
        }
    }
}