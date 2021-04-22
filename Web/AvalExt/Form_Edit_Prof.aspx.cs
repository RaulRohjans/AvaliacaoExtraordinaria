using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{
    public partial class Form_Edit_Prof : System.Web.UI.Page
    {
        ProfStaff prof;
        WebService ws;
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
                if (!IsPostBack)
                {               
                    //Carregar dados do prof para os controlos
                    prof = ws.getProfStaff(Session["user"].ToString());
                    txt_dataNasc.Text = prof.DataNasc.Year.ToString("0000") + "/" + prof.DataNasc.Month.ToString("00") + "/" + prof.DataNasc.Day.ToString("00");                    
                    txt_morada.Text = prof.Morada;
                    txt_nome.Text = prof.Nome;
                    txt_tele.Text = prof.Telefone;
                }
            }
            catch(Exception)
            {
                div_outError.InnerHtml = "<br />";
                div_outError.InnerHtml = "<p style=\"Color: red;\">Ocorreu um erro ao carregar os dados do professor.</p>";
            }
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            Regex regTele = new Regex(@"^\+[1-9]{1}[0-9]{3,14}$");
            Regex regData = new Regex(@"^([0-9]{4}[-/]?((0[13-9]|1[012])[-/]?(0[1-9]|[12][0-9]|30)|(0[13578]|1[02])[-/]?31|02[-/]?(0[1-9]|1[0-9]|2[0-8]))|([0-9]{2}(([2468][048]|[02468][48])|[13579][26])|([13579][26]|[02468][048]|0[0-9]|1[0-6])00)[-/]?02[-/]?29)$");

            try
            {
                if(txt_tele.Text != "" && regTele.IsMatch(txt_tele.Text))
                {
                    if(txt_nome.Text != "")
                    {
                        if(txt_morada.Text != "")
                        {
                            if(txt_dataNasc.Text != "" && regData.IsMatch(txt_dataNasc.Text))
                            {
                                if(txt_newPass1.Text != "")
                                {
                                    if(txt_newPass1.Text == txt_newPass2.Text)
                                    {
                                        ws.editProfStaff(Session["user"].ToString(), ws.sha256(txt_newPass1.Text), txt_nome.Text, txt_dataNasc.Text, txt_tele.Text, txt_morada.Text, null, null);
                                    }
                                    else
                                    {
                                        div_outError.InnerHtml = "<br />";
                                        div_outError.InnerHtml = "<p style=\"Color: red;\">As palavras-passe devem ser iguais.</p>";
                                    }
                                }
                                else
                                {
                                    ws.editProfStaff(Session["user"].ToString(), null, txt_nome.Text, txt_dataNasc.Text, txt_tele.Text, txt_morada.Text, null, null);
                                }
                                div_outError.InnerHtml = "<br />";
                                div_outError.InnerHtml = "<p style=\"Color: green;\">Utilizador editado com sucesso!</p>";
                            }
                            else
                            {
                                div_outError.InnerHtml = "<br />";
                                div_outError.InnerHtml = "<p style=\"Color: red;\">Por favor insira uma data v&#225lida.</p>";
                            }
                        }
                        else
                        {
                            div_outError.InnerHtml = "<br />";
                            div_outError.InnerHtml = "<p style=\"Color: red;\">Por favor insira uma morada.</p>";
                        }
                    }
                    else
                    {
                        div_outError.InnerHtml = "<br />";
                        div_outError.InnerHtml = "<p style=\"Color: red;\">Por favor insira um nome.</p>";
                    }
                }
                else
                {
                    div_outError.InnerHtml = "<br />";
                    div_outError.InnerHtml = "<p style=\"Color: red;\">Por favor insira um numero de telefone v&#225lido.</p>";
                }
            }
            catch(Exception ee )
            {
                div_outError.InnerHtml = "<br />";
                div_outError.InnerHtml = "<p style=\"Color: red;\">Ocorreu um erro ao editar o perfil." + ee + "</p>";
            }
        }
    }
}