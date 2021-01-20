<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="SuaDanhMuc.aspx.cs" Inherits="QLKARA.QuanLy.DanhMuc.SuaDanhMuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Cập nhật danh mục
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
<h2>Cập nhật danh mục</h2>

    <asp:Table runat="server" ID="tblupdateCategory">
        <asp:TableRow>
            <asp:TableCell>Tên danh mục</asp:TableCell>
            <asp:TableCell><asp:TextBox id="txtTenDanhMuc" runat="server"/></asp:TableCell></asp:TableRow></asp:Table><br />
    <asp:Button class="btn btn-success" ID="btnupdatecategory" runat="server" Text="Cập nhật" OnClick="btnupdatecategory_Click"/>
    <asp:Button class="btn btn-info" runat="server" Text="Quản lí danh mục" PostBackUrl="~/QuanLy/DanhMuc/DanhMucList.aspx" />
    <br /><br />
    <p><asp:Label ID="msgudpatecategory" runat="server" ForeColor="Red"/></p>

</asp:Content>