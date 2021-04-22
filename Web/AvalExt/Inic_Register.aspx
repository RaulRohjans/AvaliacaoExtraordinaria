<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inic_Register.aspx.cs" Inherits="AvalExt.Inic_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <link rel="apple-touch-icon" sizes="180x180" href="https://i.morioh.com/favicon/apple-touch-icon.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="https://i.morioh.com/favicon/favicon-32x32.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="https://i.morioh.com/favicon/favicon-16x16.png" />
    <link rel="manifest" href="https://i.morioh.com/favicon/site.webmanifest" />
    <link rel="mask-icon" href="https://i.morioh.com/favicon/safari-pinned-tab.svg" color="#262521" />
    <link rel="shortcut icon" href="https://i.morioh.com/favicon/favicon.ico" />
    <meta name="msapplication-TileColor" content="#faa700" />
    <meta name="msapplication-config" content="https://i.morioh.com/favicon/browserconfig.xml" />
    <meta name="theme-color" content="#ffffff" />


    <meta name="twitter:title" content="Morioh Responsive Template with Bootstrap 4, HTML5 and Vue.js" />
    <meta name="twitter:description" content="Morioh Theme is Bootstrap responsive template free download" />
    <meta name="twitter:image" content="https://i.imgur.com/gWYKl5F.png" />
    <meta property="twitter:card" content="summary_large_image" />


    <meta property="og:title" content="Morioh Responsive Template with Bootstrap 4, HTML5 and Vue.js" />
    <meta property="og:image" content="https://i.imgur.com/gWYKl5F.png" />
    <meta property="og:description" content="Morioh Theme is Bootstrap responsive template free download" />
    <meta property="og:image:width" content="1280" />
    <meta property="og:image:height" content="720" />

    <title>Registo - Avaliações Extraordinárias</title>
    <meta itemprop="description" content="Morioh Theme is Bootstrap responsive template free download" />
    <meta itemprop="image" content="https://i.imgur.com/gWYKl5F.png" />

    <meta name="description" content="Morioh Theme is Bootstrap responsive template free download" />
    <meta name="image" content="https://i.imgur.com/gWYKl5F.png" />



    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.11.2/css/all.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/perfect-scrollbar@1.4.0/css/perfect-scrollbar.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@mdi/font@4.7.95/css/materialdesignicons.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/animate.css@3.7.2/animate.min.css" />

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/morioh/dist/css/morioh.min.css" />
    <!--
    <script>
        window.location = '';
    </script>
        -->
    <script src="js/three.r119.min.js"></script>
    <script src="js/vanta.birds.min.js"></script>
    <script src="js/morioh.js"></script>
    <link href="css/morioh.css" rel="stylesheet" />
    <link href="css/morioh.min.css" rel="stylesheet" />
</head>
<body id="vanta-bg" style="background-image: url(img/bg1-blurred.png); background-size: auto; width: 1920px; height: 969px; margin: 0px;">
    <div class="" style="display: inline-block; position: fixed; top: 100px; bottom: 0; left: 0; right: 0; width: 400px; height: 800px; margin: auto;">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="mb-20 col"></div>
                </div>
                <div class=" mb-20 col">
                    <h4 class="text-center">Registo</h4>
                </div>
                <form id="form1" class="was-validated" runat="server">
                    <div class="form-check form-switch mb-10 col">
                        <asp:CheckBox CssClass="" runat="server" ID="switch_al" OnCheckedChanged="switch_al_CheckedChanged" AutoPostBack="true" />
                        <asp:Label runat="server" CssClass="form-check-label" for="switch_al" ID="lbl_switch" Text="Registar-se como: Aluno"></asp:Label>
                    </div>
                    <div class="mb-20 col">
                        <asp:TextBox CssClass="form-control" ID="txt_username" runat="server" placeholder="Username" required="" ToolTip="O seu nome de utilizador tem que respeitar a seguinte estrutura:&#013;i [6 dígitos]" />
                    </div>
                    <div class="mb-20 col">
                        <asp:TextBox CssClass="form-control" ID="txt_password" runat="server" placeholder="Password" TextMode="Password" required="" ToolTip=" " />
                    </div>
                    <div class="mb-20 col">
                        <asp:TextBox CssClass="form-control" ID="txt_repeat_password" runat="server" placeholder="Repetir Password" TextMode="Password" required="" ToolTip=" " />
                    </div>
                    <div class="mb-20 col">
                        <asp:TextBox CssClass="form-control" ID="txt_name" runat="server" placeholder="Nome" required="" ToolTip="Indique o seu primeiro e último nome." />
                    </div>
                    <div class="mb-20 col">
                        <asp:TextBox CssClass="form-control" ID="txt_data_nasc" runat="server" placeholder="Data de Nascimento" TextMode="Date" required="" ToolTip=" " />
                    </div>
                    <div class="mb-20 col">
                        <asp:TextBox CssClass="form-control" ID="txt_contact" runat="server" placeholder="Contacto" TextMode="Phone" required="" ToolTip=" " />
                    </div>
                    <div class="mb-20 col">
                        <asp:TextBox CssClass="form-control" ID="txt_morada" runat="server" placeholder="Morada" TextMode="SingleLine" required="" ToolTip=" " />
                    </div>
                    <div class="mb-20 col" id="div_aluno" runat="server" visible="true">
                        <asp:TextBox CssClass="form-control" ID="txt_turma" runat="server" placeholder="Turma" TextMode="SingleLine" required="" ToolTip=" " />
                    </div>
                    <div class="mb-20 col" id="div_prof" runat="server" visible="false">
                        <div class="mb-0 row col">
                            <p class="text-info">Selecione a(s) sua(s) disciplina(s):</p>
                        </div>
                        <div class="row mb-10">
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_pt" runat="server"/>
                                <asp:Label Text="PT" CssClass="form-check-label" runat="server" />
                            </div>
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_ai" runat="server"/>
                                <asp:Label Text="AI" CssClass="form-check-label" runat="server" />
                            </div>
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_ef" runat="server"/>
                                <asp:Label Text="EF" CssClass="form-check-label" runat="server" />
                            </div>
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_ing" runat="server"/>
                                <asp:Label Text="ING" CssClass="form-check-label" runat="server" />
                            </div>
                        </div>
                        <div class="row mb-10">
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_mat" runat="server"/>
                                <asp:Label Text="MAT" CssClass="form-check-label" runat="server" />
                            </div>
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_fq" runat="server"/>
                                <asp:Label Text="FQ" CssClass="form-check-label" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_psi" runat="server"/>
                                <asp:Label Text="PSI" CssClass="form-check-label" runat="server" />
                            </div>
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_tic" runat="server"/>
                                <asp:Label Text="TIC" CssClass="form-check-label" runat="server" />
                            </div>
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_rc" runat="server"/>
                                <asp:Label Text="RC" CssClass="form-check-label" runat="server" />
                            </div>
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_ac" runat="server"/>
                                <asp:Label Text="AC" CssClass="form-check-label" runat="server" />
                            </div>
                            <div class="col col-auto">
                                <input type="checkbox" class="form-check-input" id="cbb_so" runat="server"/>
                                <asp:Label Text="SO" CssClass="form-check-label" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="alert alert-warning" id="div_output" runat="server" visible="false"></div>
                    <div class="mb-10 col">
                        <asp:Button CssClass="btn btn-block btn-info" Text="Register" runat="server" ID="btn_register" OnClick="btn_register_Click" />
                    </div>
                    <!-- Button trigger modal 
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#staticBackdrop">
                        Launch static backdrop modal
                    </button> -->
                    <!-- Modal 
                    <div class="modal fade" id="staticBackdrop" data-backdrop="static" tabindex="-1" role="dialog"
                        aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    I will not close if you click outside me. Don't even try to press escape key.
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                    <button type="button" class="btn btn-primary">Understood</button>
                                </div>
                            </div>
                        </div>
                    </div> -->
                </form>
                <div class="mb-0 col" runat="server" id="div_regist">
                    <a class="btn btn-block btn-outline-primary" href="Inic.aspx" id="btn_login">Login</a>
                </div>
            </div>
        </div>
    </div>
</body>
<script>
    VANTA.BIRDS({
        el: "#vanta-bg",
        mouseControls: true,
        touchControls: true,
        gyroControls: false,
        minHeight: 200.00,
        minWidth: 200.00,
        scale: 1.00,
        scaleMobile: 1.00,
        backgroundColor: 0xffffff,
        color1: 0xff8888,
        color2: 0xff2222,
        birdSize: 1.20,
        speedLimit: 7.00,
        separation: 10.00,
        backgroundAlpha: 0.15,
        colorMode: "lerp"
    })
</script>
</html>
