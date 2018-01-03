<?php session_start(); ?>
<!DOCTYPE html>

<html>
    <head>
        <meta charset="UTF-8">
        <title>Site bán hàng online</title>
        <link href="assets/bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
        <link href="assets/font-awesome-4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
        <link href="assets/lightbox2/css/lightbox.min.css" rel="stylesheet" type="text/css"/>
        <link href="assets/bootstrap-datepicker/css/bootstrap-datepicker3.min.css" rel="stylesheet" type="text/css"/>

        <link rel="stylesheet" href="assets/flexslider.css" type="text/css" media="screen" />
        <link href="assets/slider/thumbs2.css" rel="stylesheet" />
        <link href="assets/slider/thumbnail-slider.css" rel="stylesheet" />
        <script src="assets/slider/thumbnail-slider.js" type="text/javascript"></script>
        <style>
            .lg{
                color:white;
            }
            .list-item{
                background-color:#222222;border:none;
            }
            .spbc{
                border: 1px solid #222222;
                background-color: #222222;
                width: 187px;
                font-size: 17px;
                color: #959595;
                text-align: center;
                border-radius: 3px;

            }
            .showproduct{
                width: 1226px;	
            }
            #container{
                margin: 0 auto;
               width:1100px;
            }
        </style>

    </head>
    <body>
        <div id="container">
            <?php
            include_once 'admin\inc_admin_top.php';
            if (isset($_GET["act"])) {
                $act = $_GET["act"];
                switch ($act) {
                    case "quanlytaikhoan":
                        include_once 'admin\inc_admin_qltaikhoan.php';
                        break;
                    case "quanlyhang":
                        include_once 'admin\inc_admin_qlhang.php';
                        break;
                    case "quanlysanpham":
                        include_once 'admin\inc_admin_qlsp.php';
                        break;
                    case "quanlydonhang":
                        include_once 'admin\inc_admin_qldonhang.php';
                        break;
                    case "updatesanpham":
                        include_once 'admin\inc_admin_updatesp.php';
                        break;
                    case "updatehang":
                        include_once 'admin\inc_admin_updatehang.php';
                        break;
                    case "updatedonhang":
                        include_once 'admin\inc_admin_updatedonhang.php';
                        break;
                    case "updatetaikhoan":
                        include_once 'admin\inc_admin_updatetaikhoan.php';
                        break;
                    case "themsanpham":
                        include_once 'admin\inc_themsp.php';
                        break;
                    case "themhang":
                        include_once 'admin\inc_themhang.php';
                        break;
                    case "themtaikhoan":
                        include_once 'admin\inc_themtk.php';
                        break;
                    case "themdonhang":
                        include_once 'admin\inc_themdonhang.php';
                        break;
                    default:
                        include_once 'admin.php';
                        break;
                }
            }
            ?>


            <script src="assets/jquery-3.1.1.min.js" type="text/javascript"></script>
            <script src="assets/bootstrap-3.3.4-dist/js/bootstrap.min.js" type="text/javascript"></script>

        </div>
        <?php
        if (isset($js)) {
            echo $js;
        }
        ?>

    </body>
</html>
