<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="Phong.aspx.cs" Inherits="QLKARA.QuanLy.Phong.Phong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
	Quản lý phòng
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
    <h2>Quản lý phòng</h2>
	<asp:GridView class="table table-bordered" ID="GV_DSDatPhong" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="GV_DSDatPhong_PageIndexChanging"> 
		<Columns>
			<asp:BoundField DataField="MaPhong" HeaderText="Mã phòng" />
			<asp:BoundField DataField="TenPhong" HeaderText="Tên phòng" />
			<asp:BoundField DataField="getPhong_TrangThai" HeaderText="Trạng thái" />
			<asp:BoundField DataField="TenLoaiPhong" HeaderText="Loại phòng" />
			<asp:TemplateField HeaderText="Chức năng">
				<ItemTemplate>
					<asp:Button ID="xoa" class="btn btn-danger" CommandName="xoa" CommandArgument='<%#Bind("MaPhong") %>'
						OnCommand="Xoa_Click" runat="server" Text="Xóa" 
						OnClientClick="return confirm('Bạn có chắc muốn xóa phòng này?')" />
				
					<asp:Button ID="sua" class="btn btn-info" CommandName="sua" CommandArgument='<%#Bind("MaPhong") %>'
						OnCommand="Sua_Click" runat="server" Text="Sửa"/>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
	<p></p>
	<asp:Button ID="btnRoomAdd" class="float-right btn btn-success" runat="server" Text="Thêm phòng" PostBackUrl="~/QuanLy/Phong/ThemPhong.aspx" />

</asp:Content>
