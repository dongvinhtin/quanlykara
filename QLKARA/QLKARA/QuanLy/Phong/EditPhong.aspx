<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="EditPhong.aspx.cs" Inherits="QLKARA.QuanLy.Phong.EditPhong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
   Cập nhật thông tin phòng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
	<h2>Cập nhật thông tin phòng</h2>
   <asp:Table ID="tableThemSV" runat="server" class="table table-bordered">
      <asp:TableRow>
         <asp:TableCell>Mã phòng: </asp:TableCell>
         <asp:TableCell>
            <asp:TextBox ID="txtMaPhong" Enabled="false" runat="server" />
         </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
         <asp:TableCell>Tên phòng: </asp:TableCell>
         <asp:TableCell>
            <asp:TextBox ID="txtTenPhong" runat="server" />
         </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
         <asp:TableCell>Trạng thái: </asp:TableCell>
         <asp:TableCell>
            <asp:DropDownList class="ddlAdd" ID="DDL_TrangThai" runat="server">
			  <asp:ListItem Value="False" Text="Còn trống"></asp:ListItem>
			  <asp:ListItem Value="True" Text="Đã thuê"></asp:ListItem>
            </asp:DropDownList>
         </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
         <asp:TableCell>Loại phòng: </asp:TableCell>
         <asp:TableCell>
            <asp:DropDownList class="ddlAdd" ID="DDL_LoaiPhong" runat="server"></asp:DropDownList>
         </asp:TableCell>
      </asp:TableRow>
   <asp:TableRow>
      <asp:TableCell></asp:TableCell>
      <asp:TableCell>
		  <asp:Button ID="btnSuaPhong" class="btn btn-success" runat="server" Text="Cập nhật" OnClick="btnSuaPhong_Click" />
      </asp:TableCell>
   </asp:TableRow>
   </asp:Table>
   <br />
<asp:Label ID="err_msg" class="alert alert-success" runat="server" ForeColor="Red" />
   <p></p>
</asp:Content>
