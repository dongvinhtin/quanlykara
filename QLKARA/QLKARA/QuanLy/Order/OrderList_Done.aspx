<%@ Page Title="" Language="C#" MasterPageFile="~/QuanLy/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="OrderList_Done.aspx.cs" Inherits="QLKARA.QuanLy.Order.OrderList_Done" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Danh sách dịch vụ đã hoàn thành
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentTable" Runat="Server">
    <h2>Danh sách dịch vụ đã hoàn thành</h2>
    <p>Chọn phòng:
        <asp:DropDownList ID="drporderdone" runat="server" class="ddlAdd"></asp:DropDownList>
        <asp:Button ID="btnhienthiorderdone" runat="server" class="btn btn-info" Text="Hiển thị" OnClick="btnhienthiorderdone_Click" />
        <asp:Button runat="server" class="btn btn-success" Text="Danh sách dịch vụ khách đặt" PostBackUrl="~/QuanLy/Order/OrderList.aspx" />
    </p>
    <asp:GridView class="table table-bordered" AutoGenerateColumns="false" ID="grdOrderdonelistAdmin" runat="server">
        <Columns>
            <asp:BoundField DataField="madatdv" HeaderText="ID" />
            <asp:BoundField DataField="TenDichVu" HeaderText="Tên dịch vụ" />
            <asp:BoundField DataField="soLuong" HeaderText="Số lượng" />
            <asp:BoundField DataField="Order_Gia" HeaderText="Đơn giá" />
            <asp:TemplateField HeaderText="Xác nhận">
                <ItemTemplate>
                    <asp:Label Text="Đã hoàn thành" ForeColor="Green" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
