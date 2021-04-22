using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{
    public partial class Inic : System.Web.UI.Page
    {
        WebService ws;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["tipo"] = null;
            div_output.Visible = false;
            try
            {
                div_err_db.Visible = false;
                ws = new WebService();
            }
            catch (Exception)
            {
                div_err_db.Visible = true;
                div_regist.Visible = false;
                txt_username.Visible = false;
                txt_password.Visible = false;
                btn_login.Visible = false;
                btn_regist.Visible = false;
                div_err_db.InnerHtml = "Ocorreu um erro ao carregar os dados da DB.";
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_username.Text != "" && txt_password.Text != "")
                {
                    if (txt_username.Text.Substring(0, 1) == "I" || txt_username.Text.Substring(0, 1) == "i")
                    {
                        Aluno aluno = ws.getAluno(txt_username.Text);

                        if (aluno.Password == ws.sha256(txt_password.Text))
                        {
                            Session["user"] = txt_username.Text;
                            Session["tipo"] = "Aluno";
                            Response.Redirect("Form_AL_Dashboard.aspx");

                        }
                        else
                        {
                            div_output.Visible = true;
                            div_output.InnerHtml = "Palavra-passe errada!";
                        }
                    }
                    else
                    {
                        ProfStaff profStaff = ws.getProfStaff(txt_username.Text);

                        if (profStaff.Password == ws.sha256(txt_password.Text))
                        {
                            if (profStaff.Tipo == ProfStaff.enumTipo.Prof)
                            {
                                Session["user"] = txt_username.Text;
                                Session["tipo"] = "Prof";
                                Response.Redirect("Form_Prof_Dashboard.aspx"); //Levar para a Dashboard Prof
                            }
                            else
                            {
                                Session["user"] = txt_username.Text;
                                Session["tipo"] = "Func";
                                Response.Redirect("Form_Func_Dashboard.aspx"); //Levar para a Dashboard Func
                            }
                        }
                        else
                        {
                            div_output.Visible = true;
                            div_output.InnerHtml = "Palavra-passe errada!";
                        }
                    }
                }
                else
                {
                    div_output.Visible = true;
                    div_output.InnerHtml = "Por favor preencha todos os campos!";
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                div_output.Visible = true;
                div_output.InnerHtml = "Esse utilizador não existe!";
            }
            catch (Exception ee)
            {
                div_output.Visible = true;
                div_output.InnerHtml = "Ocorreu um erro ao efetuar o login.<br/>" + ee.Message + "<br/>" + ee.InnerException;
            }
        }
    }
}