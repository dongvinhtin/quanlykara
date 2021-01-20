<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="HoaDonList1.aspx.cs" Inherits="QLKARA.QuanLy.HoaDon.HoaDonList1" %>
<asp:Content ID="title" ContentPlaceHolderID="title" Runat="Server">
	Danh sách hóa đơn đã thanh toán
</asp:Content>
<asp:Content ID="tableTable" ContentPlaceHolderID="contentTable" Runat="Server">
	<h2>Danh sách hóa đơn đã thanh toán</h2>
	<asp:Button ID="btnBills1" class="float-right btn btn-primary marL15" runat="server" Text="DS hóa đơn đã thanh toán" PostBackUrl="~/QuanLy/HoaDon/HoaDonList1.aspx" />
	<asp:Button ID="btnBills0" class="float-right btn btn-success " runat="server" Text="DS hóa đơn" PostBackUrl="~/QuanLy/HoaDon/HoaDonList.aspx" />
	<br />
	<br />		
	<asp:GridView class="table table-bordered" ID="grvDSHoaDon" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grvDSHoaDon_PageIndexChanging" PageSize="5"> 
		<Columns>
			<asp:BoundField DataField="IDHoaDon" HeaderText="Mã HĐ" />
			<asp:BoundField DataField="MaDatPhong" HeaderText="Mã đặt phòng" />
			<asp:BoundField DataField="HoTen" HeaderText="Tên KH" />
			<asp:BoundField DataField="soGio" HeaderText="Số giờ thuê" />
			<asp:BoundField DataField="giaTien" HeaderText="Tiền phòng" />
			<asp:BoundField DataField="giaDichVu" HeaderText="Tiền dịch vụ" />
			<asp:BoundField DataField="TongTien" HeaderText="Tổng tiền" />
			<asp:BoundField DataField="getTrangThai" HeaderText="Trạng thái" />
		</Columns>
	</asp:GridView>
</asp:Content>
