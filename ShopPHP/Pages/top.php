 
 
 
 
  <?php 
      include_once '../connect.php';
      session_start();
    
      if (!isset($_SESSION["cart"])) {
          $_SESSION["cart"] = array();
      }
      if (isset($_GET['themgiohang'])){
          $id = $_GET['themgiohang'];
           if (array_key_exists($id, $_SESSION["cart"])) {
                $_SESSION["cart"][$id] += 1;
            } else {
                $_SESSION["cart"][$id] = 1;
            }
          
      }
      echo '<pre>';
      print_r( $_SESSION["cart"]);
      echo '</pre>';
  ?>
  
  <div id="header"> <a href="index.php?chon=trangchu"> <img src="img/logo.gif" width="519" height="63"> </a>
    <div id="login_nav">
       <?php
          if ($_SESSION['flagPermission'] == true)
            {
                //Đã đăng nhập
                ?>
                    Hello, <?php echo $_SESSION["TenHienThi"]; ?>
                    <a href="Pages/xlDangXuat.php">Đăng xuất</a>
                    <a href="index.php?chon=qlgiohang" style="margin-left: 10px">
                        <img src="img/manage_shopping.png" height="20" />
                        <span ><?php if(isset($_SESSION["cart"])){ echo count($_SESSION["cart"]);} else { echo '0';} ;?></span>
                        <span>
                       		ITEMS
                       	</span>
                    </a>
                <?php
            }
            else
            {
                //Chưa đăng nhập
                ?>
                    <form name="frmLogin" action="Pages/XLDangNhap.php" method="post" onsubmit="return KiemTraDangNhap()">
                        Tài khoản: <input name="txtUS" type="text" id="txtUS" size="12" maxlength="20" width="15">
                        Mật khẩu: <input name="txtPS" type="password" id="txtPS" size="12" maxlength="20" width="15">
                        <input type="submit" value="Đăng nhập">
                        <input type="button" value="Đăng ký" onclick="ChuyenTrangDangKy()" />
                    </form>
                    <script type="text/javascript">
                        function ChuyenTrangDangKy () {
                            location = "index.php?chon=DangKy";
                        }
                    </script>
                <?php
            }
        ?>        
    </div>
    <img src="img/bay.jpg" width="1000" height="200"> <img src="img/header_2.png" width="1000"> </div>
 