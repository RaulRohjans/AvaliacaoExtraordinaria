<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inic.aspx.cs" Inherits="AvalExt.Inic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="apple-touch-icon" sizes="180x180" href="https://i.morioh.com/favicon/apple-touch-icon.png">
    <link rel="icon" type="image/png" sizes="32x32" href="https://i.morioh.com/favicon/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="16x16" href="https://i.morioh.com/favicon/favicon-16x16.png">
    <link rel="manifest" href="https://i.morioh.com/favicon/site.webmanifest">
    <link rel="mask-icon" href="https://i.morioh.com/favicon/safari-pinned-tab.svg" color="#262521">
    <link rel="shortcut icon" href="https://i.morioh.com/favicon/favicon.ico">
    <meta name="msapplication-TileColor" content="#faa700">
    <meta name="msapplication-config" content="https://i.morioh.com/favicon/browserconfig.xml">
    <meta name="theme-color" content="#ffffff">


    <meta name="twitter:title" content="Morioh Responsive Template with Bootstrap 4, HTML5 and Vue.js">
    <meta name="twitter:description" content="Morioh Theme is Bootstrap responsive template free download">
    <meta name="twitter:image" content="https://i.imgur.com/gWYKl5F.png">
    <meta property="twitter:card" content="summary_large_image">


    <meta property="og:title" content="Morioh Responsive Template with Bootstrap 4, HTML5 and Vue.js">
    <meta property="og:image" content="https://i.imgur.com/gWYKl5F.png">
    <meta property="og:description" content="Morioh Theme is Bootstrap responsive template free download">
    <meta property="og:image:width" content="1280">
    <meta property="og:image:height" content="720">

    <title>Login - Avaliações Extraordinárias</title>
    <meta itemprop="description" content="Morioh Theme is Bootstrap responsive template free download">
    <meta itemprop="image" content="https://i.imgur.com/gWYKl5F.png">

    <meta name="description" content="Morioh Theme is Bootstrap responsive template free download">
    <meta name="image" content="https://i.imgur.com/gWYKl5F.png">



    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.11.2/css/all.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/perfect-scrollbar@1.4.0/css/perfect-scrollbar.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@mdi/font@4.7.95/css/materialdesignicons.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/animate.css@3.7.2/animate.min.css">

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/morioh/dist/css/morioh.min.css">
    <!--
    <script>
        window.location = '';
    </script>
        -->
    <script src="js/three.r119.min.js"></script>
    <script src="js/vanta.birds.min.js"></script>

</head>
<body id="vanta-bg" style="background-image: url(img/bg1-blurred.png); background-size: auto; width: 1920px; height: 969px; margin: 0px;">
    <div class="" style="display: inline-block; position: fixed; top: 300px; bottom: 0; left: 0; right: 0; width: 400px; height: 800px; margin: auto;">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="mb-20 col">
                        <img src="img/login-icon-border-x3.png" class=" img-fluid" style="width: 400px;" />
                    </div>
                </div>
                <div class=" mb-20 col">
                    <h4 class="text-center">Login</h4>
                </div>
                <form id="form1" class="" runat="server">
                    <div class="alert alert-warning" id="div_err_db" runat="server"></div>
                    <div class="mb-20 col">
                        <asp:TextBox CssClass="form-control" ID="txt_username" runat="server" placeholder="Username"/>
                    </div>
                    <div class="mb-20 col">
                        <asp:TextBox CssClass="form-control" ID="txt_password" runat="server" placeholder="Password" TextMode="Password"/>
                    </div>
                    <div class="alert alert-warning" id="div_output" runat="server"></div>
                    <div class="mb-10 col">
                        <asp:Button CssClass="btn btn-block btn-primary" Text="Login" runat="server" ID="btn_login" OnClick="btn_login_Click" />
                    </div>
                </form>
                <div class="mb-0 col" runat="server" id="div_regist">
                    <a class="btn btn-block btn-outline-info" href="Inic_Register.aspx" id="btn_regist" runat="server">Registar</a>
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
<!--<script lang="javascript">
    function state_convert() {
        var form = this.getElementById('form1');
        var txtId = this.getElementById('txt_username')
        if (txtId.text == "") {
            form.className = "was-validated";
        }
        else {
            form.className = "";
        }
        }
</script>-->
</html>


