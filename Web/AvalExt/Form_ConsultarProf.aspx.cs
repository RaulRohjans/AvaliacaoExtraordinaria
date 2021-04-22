using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AvalExt
{    
    public partial class Form_ConsultarProf : System.Web.UI.Page
    {
        WebService ws;
        List<Aluno> alunos;
        List<Modulo> modulos;
        List<Pedido> pedidos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["tipo"] == null || Session["tipo"].ToString() != "Prof")
            {
                Response.Redirect("Inic.aspx");
            }

            div_user.InnerHtml = Session["user"].ToString();
            try
            {
                
                ws = new WebService();

                /*-----------------Colocar colunas na tabela----------------*/

                div_outTitulo.InnerHtml = "";
                div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                div_outTitulo.InnerHtml += "ID";
                div_outTitulo.InnerHtml += "</th>";

                div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                div_outTitulo.InnerHtml += "Aluno";
                div_outTitulo.InnerHtml += "</th>";

                div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                div_outTitulo.InnerHtml += "M&#243dulo";
                div_outTitulo.InnerHtml += "</th>";

                div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                div_outTitulo.InnerHtml += "Data do Exame";
                div_outTitulo.InnerHtml += "</th>";

                div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                div_outTitulo.InnerHtml += "Estado";
                div_outTitulo.InnerHtml += "</th>";

                div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                div_outTitulo.InnerHtml += "Nota";
                div_outTitulo.InnerHtml += "</th>";

                div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                div_outTitulo.InnerHtml += "Tipo de Taxa";
                div_outTitulo.InnerHtml += "</th>";

                div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                div_outTitulo.InnerHtml += "Pre&#231o";
                div_outTitulo.InnerHtml += "</th>";

                if(rdb_aval.Checked)
                    div_button.InnerHtml = "<input class=\"btn btn-primary\" type=\"submit\" value=\"Avaliar\" runat=\"server\" formmethod=\"post\" formaction=\"AvalPedidos_Prof.aspx\"/>";
                else
                    div_button.InnerHtml = "";
                /*--------------------------Fim da colocacao--------------------------*/

                if (!IsPostBack)
                {
                    rdb_consulta.Checked = true;
                    txt_dataFim.Enabled = false;
                    txt_dataInic.Enabled = false;

                    //Carregar datas das txt
                    if (System.DateTime.Now.Day.ToString().Length > 1)
                    {
                        txt_dataInic.Text = System.DateTime.Now.Day + "/";
                        txt_dataFim.Text = System.DateTime.Now.Day + "/";
                    }
                    else
                    {
                        txt_dataInic.Text = "0" + System.DateTime.Now.Day + "/";
                        txt_dataFim.Text = "0" + System.DateTime.Now.Day + "/";
                    }

                    if (System.DateTime.Now.Month.ToString().Length > 1)
                    {
                        txt_dataInic.Text += System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
                        txt_dataFim.Text += System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
                    }
                    else
                    {
                        txt_dataInic.Text += "0" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
                        txt_dataFim.Text += "0" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
                    }
                    LoadCbb();
                    LoadList();
                }

            }
            catch (Exception)
            {
                div_out.InnerHtml = "<br />";
                div_out.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao carregar os dados.</p>";
            }
        }

        public void LoadCbb()
        {
            alunos = ws.getAlunos();
            cbb_al.Items.Clear();
            cbb_al.Items.Add("-");
            for (int i = 0; i < alunos.Count(); i++)
            {
                if (!alunos[i].Oculto)
                {
                    cbb_al.Items.Add(alunos[i].AlunoID);
                }
            }

            modulos = ws.getModulos();
            cbb_modulo.Items.Clear();
            cbb_modulo.Items.Add("-");
            for (int i = 0; i < modulos.Count(); i++)
            {
                cbb_modulo.Items.Add(modulos[i].ModuloID + " - " + modulos[i].Sigla + modulos[i].NumModulo);
            }

            cbb_estado.Items.Clear();
            cbb_estado.Items.Add("-");
            cbb_estado.Items.Add("Criado");
            cbb_estado.Items.Add("Por Aprovar");
            cbb_estado.Items.Add("Não Aprovado");
            cbb_estado.Items.Add("Aprovado");
            cbb_estado.Items.Add("Pago");
            cbb_estado.Items.Add("Modulo Lançado");
            cbb_estado.Items.Add("Terminado");
        }

        public void LoadList()
        {
            div_outDados.InnerHtml = "";
            Regex dateReg = new Regex(@"(^(((0[1-9]|1[0-9]|2[0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)");

            //Obter lista com os pedidos filtrados
            //Verificacao e necessaria pois se a combo box nao tiver nada vai dar uma excessao
            if (txt_dataFim.Text != "" && txt_dataInic.Text != "" && dateReg.IsMatch(txt_dataInic.Text) && dateReg.IsMatch(txt_dataFim.Text))
            {
                if (cbb_modulo.Text != "-")
                {
                    switch (cbb_estado.SelectedIndex)
                    {
                        case 0:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido(null, null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            else
                                pedidos = ws.queryPedido(null, null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), "-", Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            break;

                        case 1:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido(null, "DataCria", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), cbb_al.Text, Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            else
                                pedidos = ws.queryPedido(null, "DataCria", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), "-", Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            break;

                        case 2:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("PorAprovar", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            else
                                pedidos = ws.queryPedido("PorAprovar", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), "-", Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            break;

                        case 3:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("NaoAprovado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            else
                                pedidos = ws.queryPedido("NaoAprovado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), "-", Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            break;

                        case 4:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("Aprovado", "DataAprov", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), cbb_al.Text, Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            else
                                pedidos = ws.queryPedido("Aprovado", "DataAprov", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), "-", Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            break;

                        case 5:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("Pago", "DataPago", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), cbb_al.Text, Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            else
                                pedidos = ws.queryPedido("Pago", "DataPago", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), "-", Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            break;

                        case 6:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("Lancado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            else
                                pedidos = ws.queryPedido("Lancado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), "-", Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            break;

                        case 7:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("Terminado", "DataTermin", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), cbb_al.Text, Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            else
                                pedidos = ws.queryPedido("Terminado", "DataTermin", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), "-", Session["user"].ToString(), cbb_modulo.Text.Substring(0, cbb_modulo.Text.IndexOf('-') - 1));
                            break;
                    }
                }
                else
                {
                    switch (cbb_estado.SelectedIndex)
                    {
                        case 0:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido(null, null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, Session["user"].ToString(), "-");
                            else
                                pedidos = ws.queryPedido(null, null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), "-", Session["user"].ToString(), "-");
                            break;

                        case 1:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido(null, "DataCria", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), cbb_al.Text, Session["user"].ToString(), "-");
                            else
                                pedidos = ws.queryPedido(null, "DataCria", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), "-", Session["user"].ToString(), "-");
                            break;

                        case 2:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("PorAprovar", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, Session["user"].ToString(), "-");
                            else
                                pedidos = ws.queryPedido("PorAprovar", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), "-", Session["user"].ToString(), "-");
                            break;

                        case 3:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("NaoAprovado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, Session["user"].ToString(), "-");
                            else
                                pedidos = ws.queryPedido("NaoAprovado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), "-", Session["user"].ToString(), "-");
                            break;

                        case 4:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("Aprovado", "DataAprov", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), cbb_al.Text, Session["user"].ToString(), "-");
                            else
                                pedidos = ws.queryPedido("Aprovado", "DataAprov", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), "-", Session["user"].ToString(), "-");
                            break;

                        case 5:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("Pago", "DataPago", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), cbb_al.Text, Session["user"].ToString(), "-");
                            else
                                pedidos = ws.queryPedido("Pago", "DataPago", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), "-", Session["user"].ToString(), "-");
                            break;

                        case 6:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("Lancado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), cbb_al.Text, Session["user"].ToString(), "-");
                            else
                                pedidos = ws.queryPedido("Lancado", null, DateTime.Parse("999-1-1"), DateTime.Parse("999-1-1"), "-", Session["user"].ToString(), "-");
                            break;

                        case 7:
                            if (cbb_al.Text != "-")
                                pedidos = ws.queryPedido("Terminado", "DataTermin", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), cbb_al.Text, Session["user"].ToString(), "-");
                            else
                                pedidos = ws.queryPedido("Terminado", "DataTermin", DateTime.Parse(txt_dataInic.Text), DateTime.Parse(txt_dataFim.Text), "-", Session["user"].ToString(), "-");
                            break;
                    }
                }



                /*--------------Inserir dados na lsv---------------------*/
                if (rdb_consulta.Checked)
                {
                    for (int i = 0; i < pedidos.Count(); i++)
                    {
                        if (pedidos[i].Prof == Session["user"].ToString())
                        {
                            div_outDados.InnerHtml += "<tr>";

                            div_outDados.InnerHtml += "<td>" + pedidos[i].PedidoID.ToString() + "</td>";

                            div_outDados.InnerHtml += "<td>" + pedidos[i].Aluno + "</td>";

                            Modulo modulo = ws.getModulo(pedidos[i].Modulo);
                            div_outDados.InnerHtml += "<td>" + modulo.Sigla + modulo.NumModulo + "</td>";

                            div_outDados.InnerHtml += "<td>" + pedidos[i].DataExame.ToShortDateString() + "</td>";

                            switch (pedidos[i].Estado)
                            {
                                case Pedido.enumEstado.Aprovado:
                                    div_outDados.InnerHtml += "<td>Aprovado</td>";
                                    break;

                                case Pedido.enumEstado.Pago:
                                    div_outDados.InnerHtml += "<td>Pago</td>";
                                    break;

                                case Pedido.enumEstado.PorAprovar:
                                    div_outDados.InnerHtml += "<td>Por Aprovar</td>";
                                    break;

                                case Pedido.enumEstado.Terminado:
                                    div_outDados.InnerHtml += "<td>Terminado</td>";
                                    break;

                                case Pedido.enumEstado.Lancado:
                                    div_outDados.InnerHtml += "<td>Lan&#231ado</td>";
                                    break;

                                case Pedido.enumEstado.NaoAprovado:
                                    div_outDados.InnerHtml += "<td>N&#227o Aprovado</td>";
                                    break;
                            }

                            if (pedidos[i].Nota != -1)
                                div_outDados.InnerHtml += "<td>" + pedidos[i].Nota.ToString("00") + "</td>";
                            else
                                div_outDados.InnerHtml += "<td>-</td>";

                            switch (pedidos[i].TipoTaxa)
                            {
                                case Pedido.enumTaxa.NULL:
                                    div_outDados.InnerHtml += "<td>-</td>";
                                    break;

                                case Pedido.enumTaxa.Epoca:
                                    div_outDados.InnerHtml += "<td>Dentro da &#201poca</td>";
                                    break;

                                case Pedido.enumTaxa.ForaEpoca:
                                    div_outDados.InnerHtml += "<td>Fora da &#201poca</td>";
                                    break;

                                case Pedido.enumTaxa.Isento:
                                    div_outDados.InnerHtml += "<td>Isento</td>";
                                    break;
                            }

                            if (pedidos[i].Preco != -1)
                                div_outDados.InnerHtml += "<td>" + pedidos[i].Preco.ToString("0.00") + "€</td>";
                            else
                                div_outDados.InnerHtml += "<td>-</td>";

                            div_outDados.InnerHtml += "</tr>";
                        }
                    }
                }
                else
                {
                    if (rdb_aprov.Checked)
                    {
                        for (int i = 0; i < pedidos.Count(); i++)
                        {
                            if (pedidos[i].Estado == Pedido.enumEstado.PorAprovar && pedidos[i].Prof == Session["user"].ToString())
                            {
                                div_outDados.InnerHtml += "<tr>";

                                div_outDados.InnerHtml += "<td>" + pedidos[i].PedidoID.ToString() + "</td>";

                                div_outDados.InnerHtml += "<td>" + pedidos[i].Aluno + "</td>";

                                Modulo modulo = ws.getModulo(pedidos[i].Modulo);
                                div_outDados.InnerHtml += "<td>" + modulo.Sigla + modulo.NumModulo + "</td>";

                                div_outDados.InnerHtml += "<td>" + pedidos[i].DataExame.ToShortDateString() + "</td>";                               

                                if (pedidos[i].Nota != -1)
                                    div_outDados.InnerHtml += "<td>" + pedidos[i].Nota.ToString("00") + "</td>";
                                else
                                    div_outDados.InnerHtml += "<td>-</td>";

                                switch (pedidos[i].TipoTaxa)
                                {
                                    case Pedido.enumTaxa.NULL:
                                        div_outDados.InnerHtml += "<td>-</td>";
                                        break;

                                    case Pedido.enumTaxa.Epoca:
                                        div_outDados.InnerHtml += "<td>Dentro da &#201poca</td>";
                                        break;

                                    case Pedido.enumTaxa.ForaEpoca:
                                        div_outDados.InnerHtml += "<td>Fora da &#201poca</td>";
                                        break;

                                    case Pedido.enumTaxa.Isento:
                                        div_outDados.InnerHtml += "<td>Isento</td>";
                                        break;


                                }

                                if (pedidos[i].Preco != -1)
                                    div_outDados.InnerHtml += "<td>" + pedidos[i].Preco.ToString("0.00") + "€</td>";
                                else
                                    div_outDados.InnerHtml += "<td>-</td>";

                                //Colocar os botoes aqui
                                
                                div_outDados.InnerHtml += "<td width=\"100px\"><input formmethod=\"post\" style=\"color: rgba(255,255,255,00);\" formaction=\"AprovPedido_Prof.aspx\" id=\"A" + pedidos[i].PedidoID + "\" name=\"btn\" class=\"btn btn-xs btn-success\" type=\"submit\" value=\"" + pedidos[i].PedidoID + "\" /><input id=\"N" + pedidos[i].PedidoID + "\" formmethod=\"post\" formaction=\"RejeitPedido_Prof.aspx\" class=\"btn btn-xs btn-danger\" type=\"submit\" style=\"margin-left: 16px; color: rgba(255,255,255,00);\" name=\"btn\" value=\"" + pedidos[i].PedidoID + "\" /></td>";                               

                                div_outDados.InnerHtml += "</tr>";

                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < pedidos.Count(); i++)
                        {
                            if (pedidos[i].Estado == Pedido.enumEstado.Aprovado || pedidos[i].Estado == Pedido.enumEstado.Pago && pedidos[i].Prof == Session["user"].ToString())
                            {
                                div_outDados.InnerHtml += "<tr>";

                                div_outDados.InnerHtml += "<td>" + pedidos[i].PedidoID.ToString() + "</td>";

                                div_outDados.InnerHtml += "<td>" + pedidos[i].Aluno + "</td>";

                                Modulo modulo = ws.getModulo(pedidos[i].Modulo);
                                div_outDados.InnerHtml += "<td>" + modulo.Sigla + modulo.NumModulo + "</td>";

                                div_outDados.InnerHtml += "<td>" + pedidos[i].DataExame.ToShortDateString() + "</td>";

                                switch (pedidos[i].Estado)
                                {
                                    case Pedido.enumEstado.Aprovado:
                                        div_outDados.InnerHtml += "<td>Aprovado</td>";
                                        break;

                                    case Pedido.enumEstado.Pago:
                                        div_outDados.InnerHtml += "<td>Pago</td>";
                                        break;

                                    case Pedido.enumEstado.PorAprovar:
                                        div_outDados.InnerHtml += "<td>Por Aprovar</td>";
                                        break;

                                    case Pedido.enumEstado.Terminado:
                                        div_outDados.InnerHtml += "<td>Terminado</td>";
                                        break;

                                    case Pedido.enumEstado.Lancado:
                                        div_outDados.InnerHtml += "<td>Lan&#231ado</td>";
                                        break;

                                    case Pedido.enumEstado.NaoAprovado:
                                        div_outDados.InnerHtml += "<td>N&#227o Aprovado</td>";
                                        break;
                                }                                

                                switch (pedidos[i].TipoTaxa)
                                {
                                    case Pedido.enumTaxa.NULL:
                                        div_outDados.InnerHtml += "<td>-</td>";
                                        break;

                                    case Pedido.enumTaxa.Epoca:
                                        div_outDados.InnerHtml += "<td>Dentro da &#201poca</td>";
                                        break;

                                    case Pedido.enumTaxa.ForaEpoca:
                                        div_outDados.InnerHtml += "<td>Fora da &#201poca</td>";
                                        break;

                                    case Pedido.enumTaxa.Isento:
                                        div_outDados.InnerHtml += "<td>Isento</td>";
                                        break;
                                }

                                if (pedidos[i].Preco != -1)
                                    div_outDados.InnerHtml += "<td>" + pedidos[i].Preco.ToString("0.00") + "€</td>";
                                else
                                    div_outDados.InnerHtml += "<td>-</td>";

                                //Meter caixas de texto
                               
                                div_outDados.InnerHtml += "<td width=\"120px\"><input id=\"" + pedidos[i].PedidoID.ToString() + "\" name=\"" + pedidos[i].PedidoID.ToString() + "\" type=\"number\" min=\"0\" max=\"20\" class=\"form-control\" /></td>";
                                
                                div_outDados.InnerHtml += "</tr>";

                            }
                        }
                    }
                }

            }
            else
            {
                div_out.InnerHtml = "<br />";
                div_out.InnerHtml += "<p style=\"color:red;\">Formato da data invalido.</p>";
            }
            /*------------------------------------------------------*/
        }


        protected void cbb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cbb_estado.SelectedIndex)
                {
                    case 0:
                        txt_dataFim.Enabled = false;
                        txt_dataInic.Enabled = false;
                        break;

                    case 1:
                        txt_dataFim.Enabled = true;
                        txt_dataInic.Enabled = true;
                        break;

                    case 2:
                        txt_dataFim.Enabled = false;
                        txt_dataInic.Enabled = false;
                        break;

                    case 3:
                        txt_dataFim.Enabled = false;
                        txt_dataInic.Enabled = false;
                        break;

                    case 4:
                        txt_dataFim.Enabled = true;
                        txt_dataInic.Enabled = true;
                        break;

                    case 5:
                        txt_dataFim.Enabled = true;
                        txt_dataInic.Enabled = true;
                        break;

                    case 6:
                        txt_dataFim.Enabled = false;
                        txt_dataInic.Enabled = false;
                        break;

                    case 7:
                        txt_dataFim.Enabled = true;
                        txt_dataInic.Enabled = true;
                        break;

                }
            }
            catch (Exception)
            {
                div_out.InnerHtml = "<br />";
                div_out.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao carregar os pedidos por pagar.</p>";
            }
        }

        protected void rdb_aprov_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdb_aprov.Checked)
                {
                    div_outTitulo.InnerHtml = "";
                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "ID";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Aluno";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "M&#243dulo";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Data do Exame";
                    div_outTitulo.InnerHtml += "</th>";                    

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Nota";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Tipo de Taxa";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Pre&#231o";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Aprovar";
                    div_outTitulo.InnerHtml += "</th>";

                    cbb_estado.SelectedIndex = 0;
                    cbb_estado.Enabled = false;
                    txt_dataFim.Enabled = false;
                    txt_dataInic.Enabled = false;
                    div_button.InnerHtml = "";
                }
                LoadCbb();
                LoadList();
            }
            catch (Exception)
            {
                div_out.InnerHtml = "<br />";
                div_out.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao carregar os pedidos por aprovar.</p>";
            }

        }

        protected void rdb_aval_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdb_aval.Checked)
                {
                    div_outTitulo.InnerHtml = "";
                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "ID";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Aluno";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "M&#243dulo";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Data do Exame";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Estado";
                    div_outTitulo.InnerHtml += "</th>";                    

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Tipo de Taxa";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Pre&#231o";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Nota";
                    div_outTitulo.InnerHtml += "</th>";

                    cbb_estado.SelectedIndex = 0;
                    cbb_estado.Enabled = false;
                    txt_dataFim.Enabled = false;
                    txt_dataInic.Enabled = false;
                    div_button.InnerHtml = "<input class=\"btn btn-primary\" type=\"submit\" value=\"Avaliar\" runat=\"server\" formmethod=\"post\" formaction=\"AvalPedidos_Prof.aspx\"/>";
                }
                LoadCbb();
                LoadList();
            }
            catch (Exception)
            {
                div_out.InnerHtml = "<br />";
                div_out.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao carregar os pedidos por avaliar.</p>";
            }

        }

        protected void rdb_consulta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdb_consulta.Checked)
                {
                    div_outTitulo.InnerHtml = "";
                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "ID";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Aluno";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "M&#243dulo";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Data do Exame";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Estado";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Nota";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Tipo de Taxa";
                    div_outTitulo.InnerHtml += "</th>";

                    div_outTitulo.InnerHtml += "<th class=\"text - center\">";
                    div_outTitulo.InnerHtml += "Pre&#231o";
                    div_outTitulo.InnerHtml += "</th>";

                    cbb_estado.SelectedIndex = 0;
                    cbb_estado.Enabled = true;
                    txt_dataFim.Enabled = false;
                    txt_dataInic.Enabled = false;

                    div_button.InnerHtml = "";
                }
                LoadCbb();
                LoadList();
            }
            catch (Exception)
            {
                div_out.InnerHtml = "<br />";
                div_out.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao carregar os pedidos por pagar.</p>";
            }

        }

        protected void AtualizaDados(object sender, EventArgs e)
        {
            try
            {
                LoadCbb();
                LoadList();
            }
            catch (Exception)
            {
                div_out.InnerHtml = "<br />";
                div_out.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao atualizar os dados.</p>";
            }
        }


        protected void btn_aplicar_Click(object sender, EventArgs e)
        {
            try
            {
                
                LoadList();
            }
            catch (Exception)
            {
                div_out.InnerHtml = "<br />";
                div_out.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao aplicar os filtros.</p>";
            }
        }

        protected void btn_pagar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("PagarPedidos.aspx");
            }
            catch (Exception)
            {
                div_out.InnerHtml = "<br />";
                div_out.InnerHtml += "<p style=\"color:red;\">Ocorreu um erro ao pagar as recupera&#231&#245es.</p>";
            }
        }
    }
}