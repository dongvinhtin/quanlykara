<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/css/font.css" rel="stylesheet" />
    <link href="assets/css/giaodien.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
	<div class="header-w3l">

	</div>
	<div class="main-content-agile">
		<div class="sub-main-w3">
			<h2>Đăng nhập</h2>
				<div class="pom-agile">
					<span class="fa fa-user-o" aria-hidden="true"></span>
                    <asp:TextBox placeholder="Tài khoản" ID="txtTK" runat="server"></asp:TextBox>
				</div>
				<div class="pom-agile">
					<span class="fa fa-key" aria-hidden="true"></span>
                    <asp:TextBox placeholder="Mật khẩu" ID="txtMK" runat="server" TextMode="Password"></asp:TextBox>
				</div>

				<div class="right-w3l" style="padding-top:20px">
                    <asp:Button ID="Button1" runat="server" Text="Đăng nhập" OnClick="Button1_Click" />
					<br/>
				</div>
				<div style="padding-top:30px">
					<asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
				</div>
		</div>
	</div>
    </form>
</body>
</html>
