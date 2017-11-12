<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/General_Inicio.Master" CodeBehind="Web_Login.aspx.vb" Inherits="ElectroSystem_Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
@charset "utf-8";
html, body, div, span, applet, object, iframe,
h1, h2, h3, h4, h5, h6, p, blockquote, pre,
a, abbr, acronym, address, big, cite, code,
del, dfn, em, img, ins, kbd, q, s, samp,
small, strike, strong, sub, sup, tt, var,
b, u, i, center,
dl, dt, dd, ol, ul, li,
fieldset, form, label, legend,
table, caption, tbody, tfoot, thead, tr, th, td,
article, aside, canvas, details, embed, 
figure, figcaption, footer, header, hgroup, 
menu, nav, output, ruby, section, summary,
time, mark, audio, video {
	margin: 0;
	padding: 0;
	border: 0;
	font-size: 100%;
	font: inherit;
	vertical-align: baseline;
}
article, aside, details, figcaption, figure, 
footer, header, hgroup, menu, nav, section {
	display: block;
}
body {
	line-height: 1;
}
ol, ul {
	list-style: none;
}
blockquote, q {
	quotes: none;
}
blockquote:before, blockquote:after,
q:before, q:after {
	content: '';
	content: none;
}
table {
	border-collapse: collapse;
	border-spacing: 0;
}

/* ---------- FONTAWESOME ---------- */

[class*="fontawesome-"]:before {
  font-family: 'FontAwesome', sans-serif;
}

/* ---------- GENERAL ---------- */

body {
	background-color: #C0C0C0;
	color: #000;
	font-family: "Varela Round", Arial, Helvetica, sans-serif;
	font-size: 16px;
	line-height: 1.5em;
}

input {
	border: none;
	font-family: inherit;
	font-size: inherit;
	font-weight: inherit;
	line-height: inherit;
	-webkit-appearance: none;
}

/* ---------- LOGIN ---------- */

#login {
	margin: 50px auto;
	width: 400px;
}

#login h2 {
	background-color: #252222;
	-webkit-border-radius: 20px 20px 0 0;
	-moz-border-radius: 20px 20px 0 0;
	border-radius: 20px 20px 0 0;
	color: #fff;
	font-size: 28px;
	padding: 8px 30px;
}


#login fieldset {
	background-color: #fff;
	-webkit-border-radius: 0 0 20px 20px;
	-moz-border-radius: 0 0 20px 20px;
	border-radius: 0 0 20px 20px;
	padding: 20px 26px;
}

#login fieldset p {
	color: #777;
	margin-bottom: 14px;
}

#login fieldset p:last-child {
	margin-bottom: 0;
}

#login fieldset input {
	-webkit-border-radius: 3px;
	-moz-border-radius: 3px;
	border-radius: 3px;
}

#login fieldset input[type="email"], #login fieldset input[type="password"] {
	background-color: #eee;
	color: #777;
	padding: 4px 10px;
	width: 328px;
}

#login fieldset input[type="submit"] {
	background-color: #33cc77;
	color: #fff;
	display: block;
	margin: 0 auto;
	padding: 4px 0;
	width: 100px;
}

#login fieldset input[type="submit"]:hover {
	background-color: #28ad63;
}

</style>
  
    
     <script lang="javascript">
          function isespacio(evt) {
              var charCode = (evt.which) ? evt.which : evt.keyCode;
              if (charCode == 32) return false;
              return true;
          }        
</script>
     



   

	<div id="login">

		<h2>
            <div>
                <div style="position: relative;left: 0px; top:12px">
                    <img src="Imagenes/logo_empresa.png" alt="Imagen logo ElectroSystem" style="height:45px;">
                </div>
                <div style="position: relative;left:60px; top:-25px;">Electrosystem Web</div>
		    </div>
		</h2>

		<form id="form1" runat="server">

			<fieldset>

				<p><asp:Label ID="label_nombredeusuario" runat="server" Text="Label"></asp:Label></p>
				<p><asp:TextBox ID="txt_usuario" TextMode="Email" runat="server" MaxLength="50" onkeypress="return isespacio(event)"></asp:TextBox></p> 
				<p><asp:Label ID="label_contrasena" runat="server" Text="Label"></asp:Label></p>
				<p><asp:TextBox ID="txt_contraseña" runat="server" TextMode="Password" MaxLength="15" onkeypress="return isespacio(event)"></asp:TextBox></p> 
				<p><asp:Label ID="lbl_idioma" runat="server" Text="Label" ></asp:Label></p>
				<p><asp:DropDownList ID="cmb_idioma" runat="server" AutoPostBack="True" ></asp:DropDownList></p>

                <p><asp:Button ID="btn_ingresar" runat="server" Text="Button"/></p>

			</fieldset>

		</form>
	</div> 





</asp:Content>
