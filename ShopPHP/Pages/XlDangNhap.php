<?php
    include_once '../connect.php';
    session_start();

   if (!$database->checkEmpty($_POST['txtUS']) && !$database->checkEmpty($_POST['txtPS'])){// Nhận kết quả từ người dùng nhập vào
       $us = $_POST['txtUS'];
       $ps = $_POST['txtPS'];
       $query = "SELECT * FROM TaiKhoan
                   WHERE BiXoa = 0
                   AND TenDangNhap = '$us'
                   AND MatKhau = '$ps'";
       $result = $database ->query($query);
       $row = mysqli_fetch_array($result);
       if (!empty($row)){
           //Đăng nhập thành công --> Lưu Session
           $_SESSION["MaTaiKhoan"] = $row["MaTaiKhoan"];
           $_SESSION["MaLoaiTaiKhoan"] = $row["MaLoaiTaiKhoan"];
           $_SESSION["TenHienThi"] = $row["TenHienThi"];
           $_SESSION['flagPermission'] = true;// đã đăng nhập
           
           if($row["MaLoaiTaiKhoan"] == 2)
           {
               //Tài khoản Admin
               $database ->redirect('admin.php');
           }
           else
           {
               //Tài khoản User thường         
               $database->redirect('../index.php');
           }
           
           
        }else{
              $database->redirect('../index.php');
         }
   }else {
      $database->redirect('../index.php');
   }
   