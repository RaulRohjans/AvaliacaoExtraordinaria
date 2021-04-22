using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{
    public partial class RejeitPedido_Prof : System.Web.UI.Page
    {

        WebService ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ws = new WebService();
                string pedido = Request.Form["btn"];

                if (pedido != null && pedido != "")
                {
                    ws.editPedido(Convert.ToInt32(pedido), null, null, -1, null, null, null, null, -1, null, null, null, null, null, null, "NaoAprovado", -1, null, null, -1);
                }

                Response.Redirect("Form_ConsultarProf.aspx");
            }
            catch(Exception)
            {
                Response.Write("Ocorreu um erro ao rejeitar o pedido.");
            }
        }
    }
}