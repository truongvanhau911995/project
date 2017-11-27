<?php 
	session_start();
	ob_start();
 ?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8" />
        <title>CAMERA SHOP</title>
        <link rel="stylesheet" href="./css/unsemantic.css" type="text/css" />
        <link rel="stylesheet" href="./css/font-awesome/css/font-awesome.min.css" type="text/css" />
        <link rel="stylesheet" href="./css/colors.css" type="text/css" />
        <link rel="stylesheet" href="./css/base.css" type="text/css" />
        <link rel="stylesheet" href="./css/layout.css" type="text/css" />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

        <link href="assets/bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
        <link href="assets/font-awesome-4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
        <link href="assets/lightbox2/css/lightbox.min.css" rel="stylesheet" type="text/css"/>
        <link href="assets/bootstrap-datepicker/css/bootstrap-datepicker3.min.css" rel="stylesheet" type="text/css"/>

        <style type="text/css">
            .title {
                font-family: 'Open Sans';
                font-size: 16pt;
                padding-top: 10px;
                padding-bottom: 10px;
                border-bottom: 1px solid #cccccc;
                margin-bottom: 35px;
            }
        </style>

        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <script type="text/javascript" src="jquery.js"></script>
        <script type="text/javascript" src="object.js"></script>
        <link rel="stylesheet" type="text/css" href="css.css"/>
    </head>
    <body class="body-background2 content-font dark-color">
        <?php include_once "./top.php"; ?>

        <div class="container-fluid">
            <div class="row">
                <?php
                include_once './DanhmucSP.php';
              
                if(isset($_GET["act"]))
                {
                    $act=$_GET["act"];
                    switch($act){
                        case "SanPhamTheoHang":
                              include_once './SanPhamTheoHang.php';
                            break;
                         case "SanPhamTheoLoai":
                              include_once './SanPhamTheoLoai.php';
                            break;
                        case "details":
                            include_once './chitiet.php';
                            break;
                        
                        case "login":
                            include_once './dangnhap.php';
                            break;
                        
                        case "register":
                            include_once './dangky.php';
                            break;
                        
                        case "profile":
                            include_once './profile.php';
                            break;
                        
                        case "cart":
                            include_once './inc_cart.php';
                            break;
                        case "Search":
                            include_once './TimKiem.php';
                            break;
                        case "quanlyhang":
                            include_once './inc_admin_qlhang.php';
                            break;
                        default:
                            include_once './thongbao.php';
                            break;
                    }
                }
                else {
                    include_once 'thongbao.php';
                }
                
                ?>

            </div>
        </div>
        <script src="assets/jquery-3.1.1.min.js" type="text/javascript"></script>
        <script src="assets/bootstrap-3.3.4-dist/js/bootstrap.min.js" type="text/javascript"></script>
        <?php
        if (isset($js)) {
            echo $js;
        }
        ?>
        
        <?php include_once "footer.php"; ?> 
    </body>
</html>

