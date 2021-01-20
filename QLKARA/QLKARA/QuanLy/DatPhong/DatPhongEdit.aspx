<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="DatPhongEdit.aspx.cs" Inherits="QLKARA.QuanLy.DatPhong.DatPhongEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
	Cập nhật thông tin đặt phòng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
	<h2>Cập nhật thông tin đặt phòng</h2>
	<asp:Table ID="tableThemSV" runat="server" class="table table-bordered">
      <asp:TableRow>
         <asp:TableCell>Mã đặt phòng: </asp:TableCell>
         <asp:TableCell>
            <asp:TextBox ID="txtMaDatPhong" Enabled="false" runat="server" />
         </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
         <asp:TableCell>Họ và tên: </asp:TableCell>
         <asp:TableCell>
            <asp:TextBox ID="txtHoTen" runat="server" required="" />
         </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
         <asp:TableCell>Số điện thoại: </asp:TableCell>
         <asp:TableCell>
            <asp:TextBox ID="txtSDT" runat="server" required="" />
         </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
         <asp:TableCell>Chọn phòng: </asp:TableCell>
         <asp:TableCell>
            <asp:DropDownList class="ddlAdd" ID="DDL_MaPhong" runat="server"></asp:DropDownList>
            <asp:TextBox ID="txtPhongCu" runat="server"  />
         </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
         <asp:TableCell>Thời gian vào: </asp:TableCell>
         <asp:TableCell>
            <asp:TextBox ID="txtTimeIn" runat="server"  required="" />
         </asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
         <asp:TableCell>Thời gian ra: </asp:TableCell>
         <asp:TableCell>
            <asp:TextBox ID="txtTimeOut" runat="server"  required="" />
         </asp:TableCell>
      </asp:TableRow>
   <asp:TableRow>
      <asp:TableCell></asp:TableCell>
      <asp:TableCell>
		  <asp:Button ID="btnSuaDatPhong" class="btn btn-success" runat="server" Text="Cập nhật" OnClick="btnSuaDatPhong_Click" />
      </asp:TableCell>
   </asp:TableRow>
   </asp:Table>
   <br />
<asp:Label ID="err_msg" class="alert alert-success" runat="server"/>
   <p></p>
</asp:Content>


