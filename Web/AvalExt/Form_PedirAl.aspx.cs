using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{
    public partial class Form_PedirAl : System.Web.UI.Page
    {
        WebService ws;
        List<Modulo> modulos;
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
                if (!IsPostBack)
                {                
                    try
                    {
                        modulos = ws.getModulos();
                        cbb_moduloo.Items.Clear();
                        cbb_moduloo.Items.Add("-");
                        for (int i = 0; i < modulos.Count(); i++)
                        {
                            cbb_moduloo.Items.Add(modulos[i].ModuloID + " - " + modulos[i].Sigla + modulos[i].NumModulo);
                        }
                    }
                    catch (Exception ee)
                    {
                        div_outError.InnerHtml = "<br/>";
                        div_outError.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao carregar os modulos.</p>" + ee;
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
            Regex regData = new Regex(@"^([0-9]{4}[-/]?((0[13-9]|1[012])[-/]?(0[1-9]|[12][0-9]|30)|(0[13578]|1[02])[-/]?31|02[-/]?(0[1-9]|1[0-9]|2[0-8]))|([0-9]{2}(([2468][048]|[02468][48])|[13579][26])|([13579][26]|[02468][048]|0[0-9]|1[0-6])00)[-/]?02[-/]?29)$");
            Regex regHora = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
            try
            {
                if (cbb_moduloo.Text != "-")
                {
                    if (cbb_profs.Text != "" && cbb_profs.Text != "-")
                    {
                        if (txt_dataExame.Text != "" && regData.IsMatch(txt_dataExame.Text))
                        {
                            if (txt_horaExame.Text != "" && regHora.IsMatch(txt_horaExame.Text))
                            {
                                Pedido pedido = new Pedido();
                                pedido.Aluno = Session["user"].ToString();
                                pedido.DataCria = System.DateTime.Now;
                                pedido.HoraCria = System.DateTime.Now;
                                pedido.DataExame = DateTime.Parse(txt_dataExame.Text);
                                pedido.HoraExame = DateTime.Parse(txt_horaExame.Text);
                                pedido.Estado = Pedido.enumEstado.PorAprovar;
                                pedido.Modulo = Convert.ToInt32(cbb_moduloo.Text.Substring(0, cbb_moduloo.Text.IndexOf('-') - 1));
                                pedido.PedidoID = ws.getLastPedido() + 1;
                                pedido.Prof = cbb_profs.Text.Substring(0, cbb_moduloo.Text.IndexOf('-') + 1);

                                ws.addPedido(pedido);

                                txt_dataExame.Text = "";
                                txt_horaExame.Text = "";
                                cbb_moduloo.SelectedIndex = 0;
                                cbb_profs.Items.Clear();

                                div_outError.InnerHtml = "<br/>";
                                div_outError.InnerHtml += "<p style=\"color:green;\">Pedido efetuado com sucesso!</p>";
                            }
                            else
                            {
                                div_outError.InnerHtml = "<br/>";
                                div_outError.InnerHtml += "<p style=\"color:red;\">Por favor verifique a sua hora.</p>";
                            }
                        }
                        else
                        {
                            div_outError.InnerHtml = "<br/>";
                            div_outError.InnerHtml += "<p style=\"color:red;\">Por favor verifique a sua data.</p>";
                        }
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
                    div_outError.InnerHtml += "<p style=\"color:red;\">Por favor selecione um m&#243dulo.</p>";
                }
            }
            catch (Exception ee)
            {
                div_outError.InnerHtml = "<br/>";
                div_outError.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao criar o pedido." + ee + "</p>";
            }
        }

        protected void cbb_moduloo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                if (cbb_moduloo.Text != "-" && cbb_moduloo.Text != "" && cbb_moduloo.Text != null)
                {
                    cbb_profs.Items.Clear();
                    cbb_profs.Items.Add("-");
                    Modulo mod = ws.getModulo(Convert.ToInt32(cbb_moduloo.Text.Substring(0, cbb_moduloo.Text.IndexOf('-') - 1).Trim()));
                    int[] ids = ws.getProfStaffsFromDisc(mod.Sigla);

                    for (int i = 0; i < ids.Count(); i++)
                    {
                        ProfStaff profStaff = ws.getProfStaff(ids[i].ToString());
                        if (!profStaff.Oculto)
                            cbb_profs.Items.Add(profStaff.ProfStaffID + " - " + profStaff.Nome);
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