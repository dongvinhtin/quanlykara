<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="DanhMucList.aspx.cs" Inherits="QLKARA.QuanLy.DanhMuc.DanhMucList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Quản lí danh mục
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
<h2>Danh sách danh mục</h2>
    <asp:GridView class="table table-bordered" runat="server" ID="GV_DanhMuc" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="GV_DanhMuc_PageIndexChanging" PageSize="5">
        <Columns>
            <asp:BoundField DataField="madanhmuc" HeaderText="ID" />
            <asp:BoundField DataField="tendanhmuc" HeaderText="Tên danh mục" />
            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:Button class="btn btn-danger" ID="xoaDanhMuc" CommandName="xoaDanhMuc" CommandArgument='<%#Bind("madanhmuc") %>' Text="Xóa" OnCommand="xoaDanhMuc_Command" runat="server" OnClientClick="return confirm('Chắc chắn xóa ?')"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cập nhật">
                <ItemTemplate>
                    <asp:Button class="btn btn-info" ID="suaDanhMuc" CommandName="suaDanhMuc" CommandArgument='<%#Bind("madanhmuc") %>' Text="Cập nhật" OnCommand="suaDanhMuc_Command" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="themdanhmuc" class="btn btn-success" runat="server" Text="Thêm danh mục" PostBackUrl="~/QuanLy/DanhMuc/themDanhMuc.aspx" />
</asp:Content>
