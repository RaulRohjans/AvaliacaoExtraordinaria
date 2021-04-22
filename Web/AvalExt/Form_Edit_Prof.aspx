<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_Edit_Prof.aspx.cs" Inherits="AvalExt.Form_Edit_Prof" EnableEventValidation="false" %>

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

    <title>Editar Perfil - Avaliações Extraordinárias</title>
    <meta itemprop="description" content="Morioh Theme is Bootstrap responsive template free download" />
    <meta itemprop="image" content="https://i.imgur.com/gWYKl5F.png" />

    <meta name="description" content="Morioh Theme is Bootstrap responsive template free download" />
    <meta name="image" content="https://i.imgur.com/gWYKl5F.png" />


    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.11.2/css/all.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/perfect-scrollbar@1.4.0/css/perfect-scrollbar.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@mdi/font@4.7.95/css/materialdesignicons.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/animate.css@3.7.2/animate.min.css" />

    <link rel="stylesheet" href="../../css/morioh.css" />
</head>
<body class="menubar-enabled navbar-top-fixed">
    <form runat="server">
        <div class="wrapper">

            <div class="main-navbar navbar-expand-md navbar-light bg-white fixed-top shadow-sm">

                <button class="btn d-md-none" type="button" data-toggle="collapse" data-target="#main-menu"
                    aria-controls="main-menu" aria-expanded="false" aria-label="Toggle navigation">
                    <i class="fas fa-bars"></i>
                </button>


                <img src="https://i.imgur.com/QTZ8pU1.png" title="Morioh" class="navbar-logo d-md-none"
                    style="height: 36px;" />


                <button class="btn d-md-none" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                    aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <i class="fas fa-bars"></i>
                </button>


                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto hidden-sm-down">

                        <li class="nav-item mr-5">
                            <a href="javascript://" class="nav-icon font-2xl" id="navbar-toggler">
                                <!-- <i class="fas fa-bars"></i> -->
                                <!-- <i class="mdi mdi-view-sequential font-2xl"></i> -->

                                <i class="mdi mdi-menu"></i>
                            </a>
                        </li>                        

                    </ul>


                    <ul class="navbar-nav my-2 my-lg-0">
                        <li class="nav-item mr-10 dropdown">
                            <div id="div_user" runat="server"></div>
                            <a href="#" class="nav-icon avatar rounded-circle" id="PJXN7R" role="button"
                                data-toggle="dropdown" aria-expanded="false">
                                <img src="img/prof.png" title="Default Student Name" />
                            </a>

                            <div class="dropdown-menu dropdown-menu-right" aria-labelledby="PJXN7R">
                                <a class="dropdown-item" href="Form_Prof_Dashboard.aspx">
                                    <i class="mdi mdi-view-dashboard-outline"></i>Dashboard</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="Form_Edit_Prof.aspx">
                                    <i class="mdi mdi-account-circle-outline"></i>Perfil</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="Inic.aspx"><i class="mdi mdi-exit-to-app"></i>Logout</a>
                            </div>
                        </li>                        
                    </ul>
                </div>
            </div>

            <div class="menubar menubar-dark" id="main-menu">

                <div class="menubar-header text-center bg-primary">
                    <a class="menubar-brand" href="Form_Prof_Dashboard.aspx">
                        <img src="img/book-icon-modded.png" title="Avaliações Extraordinárias" class="menubar-logo" style="height: 50px;" />
                    </a>
                </div>

                <div class="menubar-body">
                    <ul class="menu accordion">

                        <li class="menu-item">
                            <a href="Form_Prof_Dashboard.aspx" class="menu-link">
                                <i class="menu-icon mdi mdi-view-dashboard-outline" title="Dashboard"></i>
                                <span class="menu-label">Dashboard</span>
                            </a>
                        </li>
                        <li class="menu-item">
                            <a href="javascript://" class="menu-link" data-toggle="collapse" data-target="#menu-90ba1a"
                                aria-expanded="true" aria-controls="menu-90ba1a">
                                <i class="menu-icon mdi mdi-newspaper-variant-multiple" title="Avaliações"></i>
                                <span class="menu-label">Avaliações</span>
                                <i class="menu-arrow mdi mdi-chevron-right"></i>
                            </a>

                            <ul class="menu collapse" data-parent="#main-menu" id="menu-90ba1a">
                                <li class="menu-item">
                                    <a href="Form_Passar_Prof.aspx" class="menu-link">
                                        <i class="menu-icon mdi mdi-lead-pencil" title="Atribuir Professor"></i>
                                        <span class="menu-label">Atribuir Professor</span>
                                    </a>
                                </li>

                                <li class="menu-item">
                                    <a href="Form_ConsultarProf.aspx" class="menu-link">
                                        <i class="menu-icon mdi mdi-magnify" title="Consultar"></i>
                                        <span class="menu-label">Consultar</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <div class="menubar-footer bg-dark p-10">
                    <a href="#" class="d-block text-truncate"><i class="menu-icon mdi mdi-search-web"></i> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Webgrafia</a>
                </div>
            </div>

            <div class="container mt-30">
                <br/>
            <div class="card mb-15">
                <div class="card-body">
                    <h4 class="card-title">Editar Perfil</h4>

                    <div class="row">
                        <div class="col-md-6">
                            
                                <div class="mb-15">
                                    <label>Palavra-Passe Nova</label>
                                    <asp:TextBox class="form-control" ID="txt_newPass1" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                                
                                <div class="mb-15">
                                    <label>Nome*</label>
                                    <asp:TextBox class="form-control" ID="txt_nome" runat="server"></asp:TextBox>
                                    <span class="font-13 text-muted">e.x "Tiago Silva"</span>
                                </div>

                                <div class="mb-15">
                                    <label>Data de Nascimento*</label>
                                    <asp:TextBox class="form-control" ID="txt_dataNasc" maxlength="10" runat="server"></asp:TextBox>
                                    <span class="font-13 text-muted">e.x "DD/MM/YYYY"</span>
                                </div>
                                
                                <br/>
                                <asp:Button ID="btn_ok" class="btn btn-primary" runat="server" Text="Editar Perfil" OnClick="btn_ok_Click" CausesValidation="False" UseSubmitBehavior="false"/>

                                <div id="div_outError" runat="server">

                                </div>
                           
                        </div> <!-- end col -->

                        <div class="col-md-6">
                            
                                <div class="mb-15">
                                    <label>Repetir Palavra-Passe Nova</label>
                                    <asp:TextBox class="form-control" ID="txt_newPass2" runat="server" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="mb-15">
                                    <label>Telefone*</label>
                                    <asp:TextBox class="form-control" ID="txt_tele" runat="server"></asp:TextBox>
                                    <span class="font-13 text-muted">e.x "+351963258741"</span>
                                </div>   

                                <div class="mb-15">
                                    <label>Morada*</label>
                                    <asp:TextBox class="form-control" ID="txt_morada" runat="server"></asp:TextBox>
                                    <span class="font-13 text-muted">e.x "Rua das Flores"</span>
                                </div>        
                                
                                

                           
                        </div> <!-- end col -->
                    </div>

                </div>
            </div>

        </div>
            
        </div>


        <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.min.js"></script>

        <script src="https://cdn.jsdelivr.net/npm/perfect-scrollbar@1.4.0/dist/perfect-scrollbar.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/highcharts@8.0.0/highcharts.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/jquery-knob@1.2.11/dist/jquery.knob.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/jquery-sparkline@2.4.0/jquery.sparkline.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/peity@3.3.0/jquery.peity.min.js"></script>

        <!-- Global site tag (gtag.js) - Google Analytics -->
        <script async="" src="https://www.googletagmanager.com/gtag/js?id=UA-50750921-19"></script>
        <script>
            window.dataLayer = window.dataLayer || [];
            function gtag() { dataLayer.push(arguments); }
            gtag('js', new Date());

            gtag('config', 'UA-50750921-19');
        </script>



        <script src="../../js/morioh.js"></script>

        <script>

            $(function () {

                $(".bar").peity("bar");


                // knob

                $(".knob").knob();


                // sparkline bar
                $('.sparkline-bar').sparkline('html', {
                    type: 'bar',
                    barWidth: 10,
                    height: 65,
                    barColor: '#3b73da',
                    chartRangeMax: 12
                });

                $('.sparkline-line').sparkline('html', {
                    width: 120,
                    height: 65,
                    lineColor: '#3b73da',
                    fillColor: false
                });
            })

        </script>
    </form>
</body>
</html>