<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="LoaiPhongEdit.aspx.cs" Inherits="QLKARA.QuanLy.LoaiPhongEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Cập nhật loại phòng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
    <h2>Cập nhật loại phòng</h2>
    <asp:Table runat="server" ID="tbl">
        <asp:TableRow>
            <asp:TableCell>ID</asp:TableCell>
            <asp:TableCell><asp:TextBox id="txtMaLoaiPhong" runat="server" Enabled="false"/></asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Tên loại phòng</asp:TableCell>
            <asp:TableCell><asp:TextBox id="txtTenLoaiPhong" runat="server" required="" /></asp:TableCell></asp:TableRow>
        </asp:Table>

    <br />
    <asp:Button class="btn btn-success" ID="btneditroom_types" runat="server" Text="Sửa" OnClick="btnSua_Click"/>
    <br /><br />
    <p><asp:Label ID="msg" runat="server" ForeColor="Red"/></p>
</asp:Content>
