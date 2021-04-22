using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{
    public partial class AprovPedido_Func : System.Web.UI.Page
    {
        WebService ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["user"] == null || Session["tipo"] == null || Session["tipo"].ToString() != "Func")
                {
                    Response.Redirect("Inic.aspx");
                }
                ws = new WebService();
                string pedido = Request.Form["btn"];

                if (pedido != null && pedido != "")
                {
                    ws.editPedido(Convert.ToInt32(pedido), null, null, -1, null, null, null, null, -1, DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"), DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00"), null, null, null, null, "Aprovado", -1, null, null, -1);
                }

                Response.Redirect("Form_ConsultarFunc.aspx");
            }
            catch (Exception)
            {
                Response.Write("Ocorreu um erro ao aprovar os pedidos!");
            }
        }
    }
}