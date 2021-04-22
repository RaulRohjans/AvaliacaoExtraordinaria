using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{
    public partial class AvalPedidos_Prof : System.Web.UI.Page
    {
        WebService ws;
        List<Pedido> pedidos;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] == null || Session["tipo"] == null || Session["tipo"].ToString() != "Prof")
                {
                    Response.Redirect("Inic.aspx");
                }
                ws = new WebService();
                pedidos = ws.getPedidos();

                double[] avals = new double[pedidos.Count()];

                //inserir avals no array
                for (int i = 0; i < pedidos.Count(); i++)
                {
                    if (Request.Form[pedidos[i].PedidoID.ToString()] != null && Request.Form[pedidos[i].PedidoID.ToString()].ToString() != "" && Convert.ToDouble(Request.Form[pedidos[i].PedidoID.ToString()]) > 0.0 && Convert.ToDouble(Request.Form[pedidos[i].PedidoID.ToString()]) <= 20.0)
                    {
                        string s = Request.Form[pedidos[i].PedidoID.ToString()];
                        int temp = (int)(Convert.ToDouble(s) * 100);
                        avals[i] = temp / 100.0;
                    }
                    else
                    {
                        avals[i] = -1;
                    }
                }

                //Atualizar avaliacoes dos pedidos
                for (int i = 0; i < pedidos.Count(); i++)
                {
                    if (avals[i] != -1)
                    {
                        if (pedidos[i].Estado == Pedido.enumEstado.Pago)
                        {
                            ws.editPedido(pedidos[i].PedidoID, null, null, -1, null, null, null, null, -1, null, null, null, null, DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"), DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00"), "Terminado", -1, null, null, avals[i]);
                        }
                        else
                        {
                            ws.editPedido(pedidos[i].PedidoID, null, null, -1, null, null, null, null, -1, null, null, null, null, null, null, "Lancado", -1, null, null, avals[i]);
                        }
                    }
                }

                Response.Redirect("Form_ConsultarProf.aspx");
            }
            catch(Exception ee)
            {
                Response.Write("Ocorreu um ao avaliar os pedidos! " + ee + "");
            }
        }
    }
}