<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="DichVuEdit.aspx.cs" Inherits="QLKARA.QuanLy.DichVu.DichVuEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Cập nhật dịch vụ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
    <h2>Cập nhật dịch vụ</h2>
    <asp:Table class="table table-borderless" runat="server" ID="tblupdateService">
        <asp:TableRow>
            <asp:TableCell>Tên dịch vụ</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="txtTenDichVu" /></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Giá</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="txtGia" /></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Danh mục</asp:TableCell>
            <asp:TableCell><asp:DropDownList class="ddlAdd" ID="DDL_Danhmuc" runat="server"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>Mô tả</asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="txtMoTa" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <br />
    <asp:Button class="btn btn-success" runat="server" ID="btnupdateService" Text="Cập nhật" OnClick="btnupdateService_Click"/>
    <asp:Button class="btn btn-info" runat="server" Text="Danh sách dịch vụ" PostBackUrl="~/QuanLy/DichVu/DichVuList.aspx"/>
    <br />
    <p><asp:Label ID="lbmsgupdateservice" runat="server" ForeColor="Red"></asp:Label></p>
</asp:Content>
