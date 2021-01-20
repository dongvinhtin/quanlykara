<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="DSTK.aspx.cs" Inherits="QLKARA.QuanLy.ThongKe.DSTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
   Thống kê báo cáo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
    <h2>Thống kê báo cáo doanh thu</h2>
   <asp:Table ID="tableThemSV" runat="server" class="table table-bordered">
      <asp:TableRow>
         <asp:TableCell>Ngày bắt đầu: </asp:TableCell><asp:TableCell>
             <asp:Calendar ID="Calendar1" runat="server" Visible="false" VisibleDate="01/01/2021" SelectedDate="01/01/2021" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            <asp:TextBox ID="txtDateIn" runat="server"  />
             <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Chọn</asp:LinkButton>
         </asp:TableCell></asp:TableRow><asp:TableRow>
         <asp:TableCell>Ngày kết thúc: </asp:TableCell><asp:TableCell>
             <asp:Calendar ID="Calendar2" runat="server" Visible="false" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
            <asp:TextBox ID="txtDateOut" runat="server"></asp:TextBox>
             <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Chọn</asp:LinkButton>
         </asp:TableCell></asp:TableRow><asp:TableRow>
      <asp:TableCell></asp:TableCell><asp:TableCell>
		  <asp:Button ID="btnHienthi" class="btn btn-success" runat="server" OnClick="btnHienthi_Click" Text="Hiển thị" />
          <br /><p></p>
          <asp:Label ID="err_msg" class="alert" runat="server" ForeColor="Red" /><p></p>
      </asp:TableCell></asp:TableRow></asp:Table><asp:GridView class="table table-bordered" AutoGenerateColumns="false" ID="GV_HoaDon" runat="server" AllowPaging="True" OnPageIndexChanging="GV_HoaDon_PageIndexChanging" PageSize="5" ShowFooter="True"><Columns>
            <asp:BoundField DataField="IDHoaDon" HeaderText="Mã hóa đơn" />
            <asp:BoundField DataField="MaDatPhong" HeaderText="Mã đặt phòng" />
            <asp:BoundField DataField="getDate_in" HeaderText="Ngày tạo đơn" />
            <asp:BoundField DataField="TongTien" HeaderText="Tổng tiền" />
        </Columns>
    <FooterStyle BackColor="White" /></asp:GridView>
   <br />
        <asp:Label ID="lb" runat="server" Text="Số lượng hóa đơn: " ForeColor="#CC3300" Visible="false"></asp:Label><asp:Label ID="txtsoLuong" runat="server" ForeColor="#CC3300" Visible="false"></asp:Label><br />
        <asp:Label ID="lb1" runat="server" Text="Tổng tiền: " ForeColor="#CC3300" Visible="false"></asp:Label><asp:Label ID="txtTongTien" runat="server" Text="" ForeColor="#CC3300" Visible="false"></asp:Label>
    </asp:Content>