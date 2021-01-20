<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="DatPhongList1.aspx.cs" Inherits="QLKARA.QuanLy.DatPhong.DatPhongList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
	Danh sách đặt phòng đã trả phòng
</asp:Content>
<asp:Content ID="contentTable" ContentPlaceHolderID="contentTable" Runat="Server">
    <h2>Danh sách đặt phòng đã trả phòng</h2>
	<asp:Button ID="btnSchedules1" class="float-right btn btn-primary marL15" runat="server" Text="DS đặt phòng đã trả" PostBackUrl="~/QuanLy/DatPhong/DatPhongList1.aspx" />
	<asp:Button ID="btnSchedules0" class="float-right btn btn-success " runat="server" Text="DS đặt phòng" PostBackUrl="~/QuanLy/DatPhong/DatPhongList.aspx" />
	<br />
	<br />		
	<asp:GridView class="table table-bordered" ID="GV_DSDatPhong" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GV_DSDatPhong_PageIndexChanging" PageSize="5"> 
		<Columns>
			<asp:BoundField DataField="MaDatPhong" HeaderText="Mã đặt phòng" />
			<asp:BoundField DataField="HoTen" HeaderText="Họ và tên" />
			<asp:BoundField DataField="SDT" HeaderText="Điện thoại" />
			<asp:BoundField DataField="TenPhong" HeaderText="Tên phòng" />
			<asp:BoundField DataField="thoigianvao" HeaderText="Ngày đặt phòng" />
			<asp:BoundField DataField="thoigianra" HeaderText="Ngày trả phòng" />
			<asp:BoundField DataField="getDatPhong_TrangThai" HeaderText="Trạng thái" />
		</Columns>
	</asp:GridView>
</asp:Content>
