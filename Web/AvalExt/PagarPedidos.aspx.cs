using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{    
    public partial class PagarPedidos : System.Web.UI.Page
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
                ws = new WebService();

                string temp = Request.Form["chk_pagar"];

                if (temp != "" && temp != null)
                {
                    string[] pagamentos = temp.Split(',');
                    pedidos = ws.getPedidos();
                    for (int i = 0; i < pagamentos.Count(); i++)
                    {
                        for (int i2 = 0; i2 < pedidos.Count(); i2++)
                        {
                            if (Convert.ToInt32(pagamentos[i]) == pedidos[i2].PedidoID)
                            {
                                if (pedidos[i2].Estado == Pedido.enumEstado.Lancado)
                                {
                                    ws.editPedido(pedidos[i2].PedidoID, null, null, -1, null, null, null, null, -1, null, null, DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"), DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00"), DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"), DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00"), "Terminado", -1, null, null, -1);
                                }
                                else
                                {
                                    ws.editPedido(pedidos[i2].PedidoID, null, null, -1, null, null, null, null, -1, null, null, DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"), DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00"), null, null, "Pago", -1, null, null, -1);
                                }
                                Session["Pago"] = "true";
                            }
                        }
                    }
                }


                Response.Redirect("Form_ConsultarAl.aspx");
            }
            catch(Exception)
            {
                Response.Write("Ocorreu um erro ao realizar os pagamentos!");
            }
        }
    }
}