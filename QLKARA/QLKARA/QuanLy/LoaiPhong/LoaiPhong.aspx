<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="LoaiPhong.aspx.cs" Inherits="QLKARA.QuanLy.LoaiPhong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Danh sách loại phòng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
    <h2>Danh sách loại phòng</h2>
    <asp:GridView class="table table-bordered" runat="server" ID="GV_LoaiPhong" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="MaLoaiPhong" HeaderText="ID" />
            <asp:BoundField DataField="TenLoaiPhong" HeaderText="Tên loại phòng" />

            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:Button class="btn btn-danger" ID="xoa" CommandName="xoa" CommandArgument='<%#Bind("MaLoaiPhong") %>' Text="Xóa" OnCommand="Xoa_Click" runat="server" OnClientClick="return confirm('Bạn Chắc chắn xóa ?')"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:templatefield headertext="Cập nhật">
                <itemtemplate>
                    <asp:button class="btn btn-info" id="sua" commandname="sua" commandargument='<%#Bind("MaLoaiPhong") %>' text="cập nhật" oncommand="Sua_Click" runat="server" />
                </itemtemplate>
            </asp:templatefield>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="addroom_types" class="btn btn-success" runat="server" Text="Thêm loại phòng" PostBackUrl="~/QuanLy/LoaiPhong/ThemLoaiPhong.aspx" />
</asp:Content>
