using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{
    public partial class Form_AL_Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["tipo"] == null || Session["tipo"].ToString() != "Aluno")
            {
                Response.Redirect("Inic.aspx");
            }
            div_user.InnerHtml = Session["user"].ToString();
        }

        protected void btn_marcar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Form_PedirAl.aspx");
        }

        protected void btn_consultar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Form_ConsultarAl.aspx");
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Form_Cancelar_PedidoAl.aspx");
        }
    }
}