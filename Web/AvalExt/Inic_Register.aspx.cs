using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace AvalExt
{
    public partial class Inic_Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["tipo"] = null;
        }

        WebService webs = new WebService();
        Regex alRegex = new Regex(@"^[Ii](?:[0-9]+)*$");
        Regex telReg = new Regex(@"^\+[1-9]{1}[0-9]{3,14}$");
        DateTime dateFinal;

        protected void switch_al_CheckedChanged(object sender, EventArgs e)
        {
            if(switch_al.Checked)
            {
                //adaptação à instrição de um professor
                lbl_switch.Text = "Registar-se como: Professor";
                div_aluno.Visible = false; txt_turma.Text = string.Empty;
                div_prof.Visible = true;
                txt_username.ToolTip = "O seu nome de utilizador tem que respeitar a seguinte estrutura:\n[6 dígitos]";
                //reset dos controlos
                ResetControls();
            }
            else
            {
                //adaptação à instrição de um aluno
                lbl_switch.Text = "Registar-se como: Aluno";
                div_aluno.Visible = true;
                div_prof.Visible = false;
                #region #CBB-CLEARING
                cbb_pt.Checked = false;
                cbb_ai.Checked = false;
                cbb_ef.Checked = false;
                cbb_ing.Checked = false;
                cbb_mat.Checked = false;
                cbb_fq.Checked = false;
                cbb_psi.Checked = false;
                cbb_tic.Checked = false;
                cbb_rc.Checked = false;
                cbb_ac.Checked = false;
                cbb_so.Checked = false;
                #endregion
                txt_username.ToolTip = "O seu nome de utilizador tem que respeitar a seguinte estrutura:\ni [6 dígitos]";
                //reset dos controlos
                ResetControls();
            }
        }
        protected void ResetControls()
        {
            txt_password.Text = string.Empty;
            txt_repeat_password.Text = string.Empty;
            txt_name.Text = string.Empty;
            txt_data_nasc.Text = string.Empty;
            txt_contact.Text = string.Empty;
            txt_morada.Text = string.Empty;
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            if(switch_al.Checked)
            {
                //Adição de um Professor à BD
                if(txt_password.Text != txt_repeat_password.Text)
                {
                    //error - no match pwd
                    div_output.Visible = true;
                    div_output.InnerHtml = "As passwords não coincidem!";
                    txt_password.Text = string.Empty;
                    txt_repeat_password.Text = string.Empty;
                    return;
                }
                else
                {
                    DateTime.TryParse(txt_data_nasc.Text, out dateFinal);
                    if (dateFinal >= DateTime.Now)
                    {
                        //error - data nasc inválida
                        div_output.Visible = true;
                        div_output.InnerHtml = "A data de nascimento não pode ser maior que a atual!";
                        txt_data_nasc.Text = string.Empty;
                        return;
                    }
                    else
                    {
                        if (!telReg.IsMatch(txt_contact.Text))
                        {
                            //error - formato tel n respeitado
                            div_output.Visible = true;
                            div_output.InnerHtml = "O formato do número de telemóvel não foi respeitado!\nConsulte a tooltip da caixa de texto para mais informações.";
                            txt_contact.Text = string.Empty;
                            return;
                        }
                        else
                        {
                            if(!cbb_ac.Checked && !cbb_ai.Checked && !cbb_ef.Checked && !cbb_fq.Checked && !cbb_ing.Checked && !cbb_mat.Checked && !cbb_psi.Checked && !cbb_pt.Checked && !cbb_rc.Checked && !cbb_so.Checked && !cbb_tic.Checked)
                            {
                                //error - 0 disciplinas selected
                                div_output.Visible = true;
                                div_output.InnerHtml = "Tem que ter pelo menos 1 disciplina selecionada!";
                                return;
                            }
                            else
                            {
                                if(webs.checkProfStaff(txt_username.Text))
                                {
                                    //error - user existente
                                    ProfStaff tempProf = webs.getProfStaff(txt_username.Text);
                                    div_output.Visible = true;
                                    switch (tempProf.Tipo)
                                    {
                                        case ProfStaff.enumTipo.Prof:
                                            div_output.InnerHtml = "O id: " + txt_username.Text + " já está atribuído a um Professor.";
                                            break;
                                        case ProfStaff.enumTipo.Func:
                                            div_output.InnerHtml = "O id: " + txt_username.Text + " já está atribuído a um Funcionário.";
                                            break;
                                        case ProfStaff.enumTipo.NULL:
                                            div_output.InnerHtml = "O id: " + txt_username.Text + " já está atribuído a um Utilizador.";
                                            break;
                                        default:
                                            div_output.InnerHtml = "O id: " + txt_username.Text + " já está atribuído a um Utilizador.";
                                            break;
                                    }
                                    txt_username.Text = string.Empty;
                                }
                                else
                                {
                                    ProfStaff prof = new ProfStaff();

                                    prof.ProfStaffID = txt_username.Text;
                                    prof.DataCria = DateTime.Now;
                                    prof.DataNasc = dateFinal;
                                    prof.Morada = txt_morada.Text;
                                    prof.Nome = txt_name.Text;
                                    prof.Password = webs.sha256(txt_password.Text);
                                    prof.Telefone = txt_contact.Text;
                                    prof.Tipo = ProfStaff.enumTipo.Prof;

                                    if (cbb_ac.Checked)
                                        prof.Sigla.Add("AC");
                                    if (cbb_ai.Checked)
                                        prof.Sigla.Add("AI");
                                    if (cbb_ef.Checked)
                                        prof.Sigla.Add("EF");
                                    if (cbb_fq.Checked)
                                        prof.Sigla.Add("FQ");
                                    if (cbb_ing.Checked)
                                        prof.Sigla.Add("ING");
                                    if (cbb_mat.Checked)
                                        prof.Sigla.Add("MAT");
                                    if (cbb_psi.Checked)
                                        prof.Sigla.Add("PSI");
                                    if (cbb_pt.Checked)
                                        prof.Sigla.Add("PT");
                                    if (cbb_rc.Checked)
                                        prof.Sigla.Add("RC");
                                    if (cbb_so.Checked)
                                        prof.Sigla.Add("SO");
                                    if (cbb_tic.Checked)
                                        prof.Sigla.Add("TIC");

                                    webs.addProfStaff(prof);
                                    Response.Redirect("Inic.aspx");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //Adição de um Aluno à DB
                if(!alRegex.IsMatch(txt_username.Text) && txt_username.Text.Length != 7)
                {

                    //error - formato do username para um aluno não respeitado
                    div_output.Visible = true;
                    div_output.InnerHtml = "O formato do username não foi respeitado!\nConsulte a tooltip da caixa de texto username para mais informações.";
                    return;
                }
                else
                {
                    if(txt_password.Text != txt_repeat_password.Text)
                    {
                        //error - no match pwd
                        div_output.Visible = true;
                        div_output.InnerHtml = "As passwords não coincidem!";
                        txt_password.Text = string.Empty;
                        txt_repeat_password.Text = string.Empty;
                        return;
                    }
                    else
                    {
                        DateTime.TryParse(txt_data_nasc.Text, out dateFinal);
                        if (dateFinal >= DateTime.Now)
                        {
                            //error - data nasc invalida
                            div_output.Visible = true;
                            div_output.InnerHtml = "A data de nascimento não pode ser maior que a atual!";
                            txt_data_nasc.Text = string.Empty;
                            return;
                        }
                        else
                        {
                            if(!telReg.IsMatch(txt_contact.Text))
                            {
                                //error - formato tel não respeitado
                                div_output.Visible = true;
                                div_output.InnerHtml = "O formato do número de telemóvel não foi respeitado!\nConsulte a tooltip da caixa de texto para mais informações.";
                                txt_contact.Text = string.Empty;
                                return;
                            }
                            else
                            {
                                if(webs.checkAluno("I"+txt_username.Text.Substring(1)))
                                {
                                    //error - aluno já existe
                                    div_output.Visible = true;
                                    div_output.InnerHtml = "O aluno com o id: " + txt_username.Text + " já existe.";
                                    txt_username.Text = string.Empty;
                                    return;
                                }
                                else
                                {
                                    Aluno al = new Aluno();
                                    al.AlunoID = "I" + txt_username.Text.Substring(1);
                                    al.DataCria = DateTime.Now;
                                    al.DataNasc = dateFinal;
                                    al.Morada = txt_morada.Text;
                                    al.Nome = txt_name.Text;
                                    al.Password = webs.sha256(txt_password.Text);
                                    al.Telefone = txt_contact.Text;
                                    al.Turma = txt_turma.Text;

                                    webs.addAluno(al);
                                    Response.Redirect("Inic.aspx");
                                }
                            }
                        }
                    }
                }
            }
        }
    }

}