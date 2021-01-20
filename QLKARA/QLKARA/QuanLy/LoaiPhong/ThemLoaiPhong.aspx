<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="ThemLoaiPhong.aspx.cs" Inherits="QLKARA.QuanLy.ThemLoaiPhong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Thêm một loại phòng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
    <h2> Thêm một loại phòng</h2>
    <asp:Table runat="server" ID="tbl">
        <asp:TableRow>
            <asp:TableCell>Tên loại phòng</asp:TableCell>
            <asp:TableCell ><asp:TextBox id="txtTenLoaiPhong" runat="server" required="" /></asp:TableCell></asp:TableRow>
    </asp:Table><br />
    <asp:Button class="btn btn-success" ID="btnaddroom_types" runat="server" Text="Thêm" OnClick="btnThem_Click"/>
    <br /><br />
    <p><asp:Label ID="msg" runat="server" ForeColor="Red"/></p>
</asp:Content>
