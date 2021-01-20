<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QLKARA.DatPhong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <title>ASP | Website Karaoke</title>
      <link rel="stylesheet" href="assets/css/bootstrap.css"/>
      <link rel="stylesheet" href="assets/css/style.css" type="text/css" media="all" />
      <script type="text/javascript" src="assets/js/jquery-2.1.4.min.js"></script>
      <script type="text/javascript" src="assets/js/bootstrap.js"></script> 
      <style type="text/css">
         img#imgSlide {
         position: absolute;
         max-width: 100%;
         height: 100%;
         }
         .footer-w3 {margin-top: 3px;}
         h5 { font-family: verdana;
              color:white;
          }
      </style>
   </head>
   <body>
      <form id="form1" runat="server">
         <div class="header">
            <div class="agile-top-header">
               <div class="banner-agile-top">
                  <div class="number">
                     <h3><i class="fa fa-phone" aria-hidden="true"></i> +84 827 99 0766</h3>
                     <div class="top-icons">
                        <ul>
                        </ul>
                     </div>
                  </div>
                  <div class="clearfix"></div>
               </div>
               <div class="logo">
                  <h1><a href="index.aspx"><span>Welcome Xuân Diệu Luxury</span></a></h1>
               </div>
               <div class="top-left">
                  <div class="top-nav">
                     <nav class="navbar navbar-default">
                        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                           <nav class="linkEffects linkHoverEffect_2">
                              <ul>
                                 <li><a href="#" data-link-alt="Trang chủ" class="scroll"><span>Trang chủ</span></a></li>
                                 <li><a href="index.aspx" data-link-alt="Đặt phòng" class="active"><span>Đặt phòng</span></a></li>
                                 <li><a href="DatDichVu.aspx" data-link-alt="Dịch vụ" class="scroll"><span>Dịch vụ</span></a></li>
                                 <li><a href="DangNhap.aspx" data-link-alt="Admin" class="scroll"><span>Admin</span></a></li>
                              </ul>
                           </nav>
                        </div>
                     </nav>
                     <div class="clearfix"> </div>
                  </div>
               </div>
               <div class="clearfix"> </div>
            </div>
         </div>
         <div class="slider">
            <div class="callbacks_container">
               <ul class="rslides" id="slider">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick"></asp:Timer>
                        <asp:Image ID="imgSlide" runat="server" ImageUrl="assets/images/ban2.jpg" CssClass="auto-style1"/>
                     </ContentTemplate>
                  </asp:UpdatePanel>
                  <li>
                     <div class="slider-info">
                        <h3>Welcome!</h3>
                        <p style="color:#fff; font-size: 18px;">Karaoke Xuân Diệu Luxury là nơi đầu tiên tại Quy Nhơn với đầy đủ tiện nghi, hiện đại và sang trọng.</p>
                     </div>
                  </li>
               </ul>
            </div>
            <div class="clearfix"></div>
         </div>
         <div class="main" id="main"">
            <div class="w3layouts_main_grid">
               <div class="booking-form-head-agile">
                  <h3>Đặt phòng Karaoke</h3>
               </div>
               <div class="w3_agileits_main_grid w3l_main_grid">
                  <div class="agileits_grid">
                     <h5>Họ và tên * </h5>
                     <asp:TextBox ID="txtFullname" runat="server" placeholder="Họ và tên" required="" />
                  </div>
               </div>
               <div class="w3_agileits_main_grid w3l_main_grid">
                  <div class="agileits_grid">
                     <h5>Số điện thoại * </h5>
                     <asp:TextBox ID="txtPhone" runat="server" placeholder="Số điện thoại" required="" />
                  </div>
               </div>
               <div class="agileits_main_grid w3_agileits_main_grid">
                  <div class="wthree_grid">
                     <h5>Chọn Phòng</h5>
                     <asp:DropDownList ID="DDL_Phong" CssClass="form-control" required="" runat="server" Width="404px" AutoPostBack="True">
                     </asp:DropDownList>
                  </div>
               </div>
               <div class="w3_agileits_main_grid w3l_main_grid">
                  <div class="agileits_grid">
                     <h5>Thời gian vào</h5>
                      <asp:TextBox ID="txtTimeStart" runat="server" placeholder="Thời gian bắt đầu" TextMode="Time" format="HH:mm" CssClass="form-control" Width="380px"/>
                  </div>
               </div>
               <div class="w3_agileits_main_grid w3l_main_grid">
                  <div class="agileits_grid">
                     <h5>Thời gian ra</h5>
                      <asp:TextBox ID="txtTimeEnd" runat="server" placeholder="Thời gian kết thúc" TextMode="Time" format="HH:mm" CssClass="form-control" Width="380px"/>
                  </div>
               </div>
               <div class="w3_main_grid">
                  <asp:Label ID="err_msg" runat="server" />
                  <div class="w3_main_grid_right">
                     <asp:Button ID="btn_BookRoom" runat="server" Text="Đặt ngay" OnClick="btn_BookRoom_Click" OnClientClick="return confirm('Bạn có chắc chắn muốn đặt phòng?')" />
                  </div>
                  <div class="clearfix"> </div>
               </div>
            </div>
         </div>
         <div class="services" id="services">
            <div class="container">
               <div class="services-agile-head">
                  <h3>Dịch vụ</h3>
               </div>
               <div class="w3-agile-grids">
                  <div class="col-md-6 w3-agile-services-left">
                     <div class="w3-services-text">
                        <ul class="services-head">
                           <li>
                              <h3>Uy tín</h3>
                           </li>
                           <li>
                              <h5>Chất lượng</h5>
                           </li>
                           <li>
                              <h5>Trang trọng</h5>
                           </li>
                        </ul>
                        <p style="font-size: 15px;padding-right:15px;">Karaoke Xuân Diệu Luxury là nơi đầu tiên tại Quy Nhơn với đầy đủ tiện nghi, hiện đại và sang trọng. Đặc biệt, với vị trí nằm trong trung tâm thành phố, đây là điểm dừng chân lý tưởng của du khách trong và ngoài nước mỗi khi có chuyến công tác hay du lịch cùng bạn bè và người thân..</p>
                        <p style="font-size: 15px;padding-right:15px;">Hơn nữa, Xuân Diệu Luxury đã được nổi danh là địa chỉ đứng đầu của Quy Nhơn về dịch vụ giải trí hoàn hảo và phong phú. Đến với Xuân Diệu Luxury, chúng tôi hy vọng sẽ đem lại cho quý khách những trải nghiệm thú vị và hài lòng nhất.</p>
                     </div>
                  </div>
                  <div class="col-md-6 w3-agile-services-right">
                     <img src="assets/images/ab1.jpg" alt="services"/>
                  </div>
                  <div class="clearfix"></div>
               </div>
            </div>
         </div>
         <div class="footer-w3">
            <p>XUÂN DIỆU LUXURY</p>
         </div>
         <a href="#" id="toTop" style="display: block;"> <span id="toTopHover" style="opacity: 1;"> </span></a>
      </form>
   </body>
</html>