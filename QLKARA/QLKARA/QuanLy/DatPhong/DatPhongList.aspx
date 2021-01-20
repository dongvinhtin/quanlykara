<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="DatPhongList.aspx.cs" Inherits="QLKARA.QuanLy.DatPhong.DatPhongList" %>
<asp:Content ID="title" ContentPlaceHolderID="title" Runat="Server">
	Danh sách đặt phòng
</asp:Content>
<asp:Content ID="contentTable" ContentPlaceHolderID="contentTable" Runat="Server">
    <h2>Danh sách đặt phòng</h2>
		<asp:Button ID="btnSchedules1" class="float-right btn btn-primary marL15" runat="server" Text="DS đặt phòng đã trả" PostBackUrl="~/QuanLy/DatPhong/DatPhongList1.aspx" />
		<asp:Button ID="btnSchedules0" class="float-right btn btn-success " runat="server" Text="DS đặt phòng" PostBackUrl="~/QuanLy/DatPhong/DatPhongList.aspx" />
		<br />
		<br />	
		<asp:GridView class="table table-bordered" ID="GV_DSDatPhong" runat="server" AutoGenerateColumns="False" AllowPaging="True"  PageSize="5" OnPageIndexChanging="GV_DSDatPhong_PageIndexChanging"> 
		<Columns>
			<asp:BoundField DataField="MaDatPhong" HeaderText="Mã đặt phòng" />
			<asp:BoundField DataField="HoTen" HeaderText="Họ và tên" />
			<asp:BoundField DataField="SDT" HeaderText="Điện thoại" />
			<asp:BoundField DataField="TenPhong" HeaderText="Tên phòng" />
			<asp:BoundField DataField="thoigianvao" HeaderText="Giờ đặt phòng" />
			<asp:BoundField DataField="thoigianra" HeaderText="Giờ trả phòng" />
			<asp:BoundField DataField="getDatPhong_TrangThai" HeaderText="Trạng thái" />
			<asp:TemplateField HeaderText="Chức năng">
				<ItemTemplate>				
					<asp:Button ID="sua" class="btn btn-info" CommandName="sua" CommandArgument='<%#Bind("MaDatPhong") %>'
						OnCommand="Sua_Click" runat="server" Text="Sửa"/>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
</asp:Content>
