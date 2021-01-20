<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="TKDV.aspx.cs" Inherits="QLKARA.QuanLy.ThongKe.TKDV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" runat="server">
        <h2>Thống kê báo cáo doanh thu</h2>
   <asp:Table ID="tableThemSV" runat="server" class="table table-bordered">
    <asp:TableRow>
         <asp:TableCell>Dịch vụ</asp:TableCell><asp:TableCell>
             <asp:DropDownList ID="DDL_DichVu" runat="server" CssClass="form-control" Width="200px"></asp:DropDownList>
         </asp:TableCell></asp:TableRow><asp:TableRow>
      <asp:TableCell></asp:TableCell><asp:TableCell>
		  <asp:Button ID="btnHienthi" class="btn btn-success" runat="server" OnClick="btnHienthi_Click" Text="Hiển thị" />
          <br /><p></p>
          <asp:Label ID="err_msg" class="alert" runat="server" ForeColor="Red" /><p></p>
      </asp:TableCell></asp:TableRow></asp:Table><asp:GridView class="table table-bordered" AutoGenerateColumns="false" ID="GV_HoaDon" runat="server" AllowPaging="True" PageSize="5" ShowFooter="True"><Columns>
            <asp:BoundField DataField="MaDichVu" HeaderText="Mã dịch vụ" />
            <asp:BoundField DataField="soLuong" HeaderText="Số lượng" />
            <asp:BoundField DataField="Gia" HeaderText="Giá" />
        </Columns>
    <FooterStyle BackColor="White" /></asp:GridView>
   <br />
        <asp:Label ID="lb" runat="server" Text="Số lượng: " ForeColor="#CC3300" Visible="false"></asp:Label><asp:Label ID="txtsoLuong" runat="server" ForeColor="#CC3300" Visible="false"></asp:Label><br />
        <asp:Label ID="lb1" runat="server" Text="Tổng tiền: " ForeColor="#CC3300" Visible="false"></asp:Label><asp:Label ID="txtTongTien" runat="server" Text="" ForeColor="#CC3300" Visible="false"></asp:Label></asp:Content>