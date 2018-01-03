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
        <script src="jquery-1.10.2.min.js" type="text/javascript"></script>
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
        <?php include_once "./controllers/top.php"; ?>

        <div class="container-fluid">
            <div class="row">
                <?php
                include_once './controllers/DanhmucSP.php';

                if (isset($_GET["act"])) {
                    $act = $_GET["act"];
                    switch ($act) {
                        case "SanPhamTheoHang":
                            include_once './controllers/SanPhamTheoHang.php';
                            break;
                        case "SanPhamTheoLoai":
                            include_once './controllers/SanPhamTheoLoai.php';
                            break;
                        case "details":
                            include_once './controllers/chitiet.php';
                            break;

                        case "login":
                            include_once './controllers/dangnhap.php';
                            break;

                        case "register":
                            include_once './controllers/dangky.php';
                            break;

                        case "profile":
                            include_once './controllers/profile.php';
                            break;

                        case "cart":
                            include_once './controllers/inc_cart.php';
                            break;
                        case "Search":
                            include_once './controllers/TimKiem.php';
                            break;
                        case "quanlyhang":
                            include_once './controllers/inc_admin_qlhang.php';
                            break;
                        default:
                            include_once './controllers/sanphammoinhat.php';
                            break;
                    }
                } else {
                    include_once 'controllers/sanphammoinhat.php';
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

        <?php include_once "controllers/footer.php"; ?> 
    </body>
</html>

