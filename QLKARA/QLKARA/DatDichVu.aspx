<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatDichVu.aspx.cs" Inherits="QLKARA.DatDichVu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
      <title>Đặt dịch vụ</title>
      <link href="assets/css/style.css" rel="stylesheet" />
      <link href="assets/css/bootstrap.css" rel="stylesheet" />
      <script src="assets/js/bootstrap.js"></script>
      <script src="assets/js/jquery-2.1.4.min.js"></script>
      <style type="text/css">
         img#imgSlide {
         position: absolute;
         max-width: 100%;
         height: 100%;
         }
         .footer-w3 {margin-top: 3px;}
         h5 { font-family: verdana;}
		 .ddlAdd {
		    width: 80%;
			padding: 10px;
		 }
      </style>
   </head>
   <body>
      <form id="form1" runat="server">
         <!-- header -->
         <div class="header">
            <div class="agile-top-header">
               <div class="banner-agile-top">
                  <div class="number">
                     <h3><i class="fa fa-phone" aria-hidden="true"></i> +84 827 99 0766</h3>
                  </div>
                  <div class="clearfix"></div>
               </div>
               <div class="logo">
                  <h1><a href="Dichvu.aspx"><span>DỊCH VỤ</span></a></h1>
               </div>
               <!-- navigation -->
               <div class="top-left">
                  <div class="top-nav">
                     <nav class="navbar navbar-default">
                        <!-- navbar-header -->
                        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                           <nav class="linkEffects linkHoverEffect_2">
                              <ul>
                                 <li><a href="#" data-link-alt="Trang chủ" class="scroll"><span>Trang chủ</span></a></li>
                                 <li><a href="index.aspx" data-link-alt="Đặt phòng" class="scroll"><span>Đặt phòng</span></a></li>
                                 <li><a href="DatDichvu.aspx" data-link-alt="Dịch vụ" class="active"><span>Dịch vụ</span></a></li>
                                 <li><a href="DangNhap.aspx" data-link-alt="Admin" class="scroll"><span>Admin</span></a></li>
                              </ul>
                           </nav>
                        </div>
                     </nav>
                     <div class="clearfix"> </div>
                  </div>
               </div>
               <div class="clearfix"> </div>
               <!-- //navigation -->
            </div>
         </div>
         <!--Slider-->
         <div class="slider">
            <div class="callbacks_container">
               <ul class="rslides" id="slider">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Timer ID="Timer2" runat="server" Interval="5000" OnTick="Timer2_Tick"></asp:Timer>
                        <asp:Image ID="imgSlide" runat="server" ImageUrl="assets/images/ban1.jpg" CssClass="auto-style2" />
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
         <!--//Slider-->
         <!--//main-->
         <div class="main" id="main" style="top: 22%;width: 35%;">
            <div class="w3layouts_main_grid">
               <div class="booking-form-head-agile">
                  <h3>Đặt dịch vụ tại phòng</h3>
               </div>
               <div class="agileits_main_grid w3_agileits_main_grid">
                  <div class="wthree_grid">
                     <h5>Chọn phòng </h5>
                     <asp:DropDownList class="ddlAdd" ID="DDL_Phong" required="" runat="server">
                     </asp:DropDownList>
                  </div>
               </div>
               <div class="agileits_main_grid w3_agileits_main_grid">
                  <div class="wthree_grid">
                     <h5>Chọn dịch vụ</h5>
                     <asp:DropDownList class="ddlAdd" ID="DDL_SanPham" required="" runat="server">
                     </asp:DropDownList>
                  </div>
               </div>
               <div class="agileits_w3layouts_main_grid w3ls_main_grid">
                  <div class="agileinfo_grid">
                     <h5>Số lượng</h5>
                     <div class="agileits_w3layouts_main_gridl">
                        <asp:TextBox ID="txtpickquantity" runat="server" required="" />
                     </div>
                     <div class="clearfix"> </div>
                  </div>
               </div>
               <div class="w3_main_grid">
                  <asp:Label ID="err_msg" runat="server" />
                  <div class="w3_main_grid_right">
                     <asp:Button ID="btnOderUser" runat="server" Text="Đặt ngay" OnClientClick="return confirm('Chắc chắn đặt dịch vụ ?')" OnClick="btnOderUser_Click"/>
                  </div>
                  <div class="clearfix"> </div>
               </div>
            </div>
         </div>
         <!-- //header -->
		  
         <!-- /services -->
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
         <!-- //services-->
         <!--footer-->
         <div class="footer-w3">
            <p>© 2021 Website Karaoke | ASP.NET</p>
         </div>
         <a href="#" id="toTop" style="display: block;"> <span id="toTopHover" style="opacity: 1;"> </span></a>
      </form>
   </body>
</html>
