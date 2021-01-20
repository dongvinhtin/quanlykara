<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="DichVuList.aspx.cs" Inherits="QLKARA.QuanLy.DichVu.DichVuList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Quản lí dịch vụ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
    <h2>Danh sách dịch vụ</h2>
    <br />
    <p>
        Chọn danh mục:
    <asp:DropDownList class=ddlAdd ID="DDL_Danhmuc" runat="server">

    </asp:DropDownList>
    
    <asp:Button ID="btnhienthi" class="btn btn-info" runat="server" OnClick="btnhienthi_Click" Text="Hiển thị" />
    <asp:Button runat="server" class="btn btn-success" Text="Thêm dịch vụ" PostBackUrl="~/QuanLy/DichVu/DichVuAdd.aspx" />
    </p>
    <br />
    <asp:GridView ID="GV_DSDichVu" runat="server" AutoGenerateColumns="false" class="table table-bordered">
        <Columns>
            <asp:BoundField DataField="MaDichVu" HeaderText="ID" />
            <asp:BoundField DataField="TenDichVu" HeaderText="Tên dịch vụ" />
            <asp:BoundField DataField="Gia" HeaderText="Giá" />
            <asp:BoundField DataField="danhmuc" HeaderText="Danh mục" />
            <asp:BoundField DataField="MoTa" HeaderText="Mô tả" />
            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:Button class="btn btn-danger" ID="xoaDichVu" CommandName="deleteservices" CommandArgument='<%#Bind("MaDichVu") %>' Text="Xóa" OnCommand="deleteservices_Command" runat="server" OnClientClick="return confirm('Chắc chắn xóa ?')"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sửa">
                <ItemTemplate>
                    <asp:Button class="btn btn-info" ID="suaDichVu" CommandName="updateservices" CommandArgument='<%#Bind("MaDichVu") %>' Text="Cập nhật" OnCommand="updateservices_Command" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>