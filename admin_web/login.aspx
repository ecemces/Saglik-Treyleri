 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="saglik_treyleri.web1.WebForm2" %>

<!DOCTYPE HTML>
<html>
<head>
<title>Giriş yap </title>
	<link rel="icon" type="image/x-icon" href="technopc-logo-png-6858-d.png">
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Glance Design Dashboard Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
SmartPhone Compatible web template, free WebDesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>

<!-- Bootstrap Core CSS -->
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />

<!-- Custom CSS -->
<link href="css/style.css" rel="stylesheet" />


<!-- font-awesome icons CSS-->
<link href="css/font-awesome.css" rel="stylesheet"> 
<!-- //font-awesome icons CSS-->

 <!-- side nav css file -->
 <link href='css/SidebarNav.min.css' media='all' rel='stylesheet' type='text/css'/>
 <!-- side nav css file -->
 
 <!-- js-->
<script src="js/jquery-1.11.1.min.js"></script>
<script src="js/modernizr.custom.js"></script>

<!--webfonts-->
<link href="//fonts.googleapis.com/css?family=PT+Sans:400,400i,700,700i&amp;subset=cyrillic,cyrillic-ext,latin-ext" rel="stylesheet">
<!--//webfonts-->
 
<!-- main content start-->
<body>
		<div id="page-wrapper">
			<div class="main-page login-page ">

					<center><img alt="" src="technopc-logo-png-6858-d.png" width="301" 
	 height="130"  /></center> <!--YENİDEN BOYUTLANDIRILACAK-->
				<div class="widget-shadow">
				<form runat="server">
					<div class="login-body">
							<asp:Textbox ID="usernametxt" runat="server" type="password" class="user" placeholder="Kullanıcı adı" required="" />
							<br />
							<asp:Textbox ID="passwordtxt" runat="server" type="password" class="lock" placeholder="Şifre" required="" />
							<div class="forgot-grid">
								<div class="clearfix"> 
								</div>
							</div>
							<br />
							<asp:Label ID="InvalidLoginLabel" runat="server"></asp:Label>
							<asp:Button id="loginbutton" runat="server" type="submit" text="Giriş" OnClick="loginbutton_Click" background-color="##0382C7" BackColor="#2596BE"></asp:Button>
						</div>
						</form>					
				</div>
			</div>
		</div>
		<!--footer-->
		<!--//footer-->
	</div>
	</body>
</html>