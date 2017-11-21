<?php 
    include_once 'connect.php';
    error_reporting(false);
?>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Website BabyShop</title>
<link rel="stylesheet" type="text/css" href="css/style.css?v=<?php echo time(); ?>" />
<link rel="stylesheet" type="text/css" href="style.css?v=<?php echo time(); ?>" />

</head>

<body>
<div id="wrapper">
	<?php include_once 'Pages/top.php';?>
 	<?php include_once 'Pages/Menu.php';?>

  <div id="content">
   	<?php 
   	   
   	    if(isset($_GET['chon'])){
   	        $chon = $_GET['chon'];
   	        switch ($chon) {
   	            case 'hangsanxuat':
   	                include "pages/SanPhamTheoHang.php";
   	                break;
                case 'loaisanpham':
                    include "pages/SanPhamTheoLoai.php";
                    break;
                case 'DangKy':
                    include "pages/ThemTaiKhoan.php";
                    break;
                case 'trangchu':
                    include "pages/TrangChu.php";
                    break;
                case 'qlgiohang':
                    include "pages/QuanLyGioHang.php";
                    break;
                case 'thongbao':
                    include "pages/ThongBaoDatHangThanhCong.php";
                    break;
                case 'chitiet':
                    include "pages/chitiet.php";
                    break;

       	        }
       	        
   	    }else {
   	        include_once "pages/TrangChu.php";
   	    }
   	
   	?>
   	  </div>
	
  <div id="footer"> &copy; Design by student of FIT - HCMUS </div>
</div>
</body>
</html>
