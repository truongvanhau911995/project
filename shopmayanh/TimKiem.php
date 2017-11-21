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


    </head>
    <body class="body-background2 content-font dark-color">
        <?php include_once "./top.php"; ?>
        <div class = "page-block page-block-top light-bg grid-container"></div> <!--dòng mÀU TRẮNG-->
        <div class="container-fluid" style=" height: 500px">
          
                <?php
                require_once './function.php';
                require_once './ketnoi.php';

                if (isset($_POST["txtProId"])) {
                    $sp = $_POST["txtProId"];
                    $slg = 1;
                    setCart($sp, $slg);
                    //print_r(getCart());
                }
                ?>

                <!--Xem danh sách sản phẩm theo hãng-->
                <div class="col-md-9 " style=" margin-left: 166px ">    <!--chỉnh kích thước hình trong bảng -->
                    <div class="panel panel-default">
                        <div class="panel-heading" style="background-color: #FFCCCC">
                            <h3 class="panel-title" style="color: blue; text-align: center"><b>Danh sách sản phẩm </b></h3>
                        </div>

                        <div class="panel-body" style="background-color: Beige"> <!--cái khung-->
                            <?php   
                            if (isset($_GET["tukhoa"])) {
                                $text = $_GET["tukhoa"];
                                $sql = "select * from sanpham where TenSP like '%$text%' or GiaSP like '%$text%' order by GiaSP";
                                $rs = load($sql);
                                if ($rs->num_rows == 0) {
                                    echo "KHÔNG CÓ SẢN PHẨM.";
                                } else {
                                    ?>   
                                    <div class="row">  <!--hình trong khung-->
                                        <form id="f" action="" method="post">
                                            <input type="hidden" id="txtProId" name="txtProId" />
                                        </form>
                                        <?php
                                        while ($row = $rs->fetch_assoc()) {
                                            ?>
                                            <div class="col-sm-4">
                                                <div class="thumbnail">

                                                    <a href="img/<?php echo $row["MaSP"]; ?>/a.png" data-lightbox="<?php echo $row["MaSP"]; ?>" data-title="<?php echo $row["TenSP"]; ?>">
                                                        <img src="img/<?php echo $row["MaSP"]; ?>/a.png" alt="...">
                                                    </a> 
                                                    <div class="caption">
                                                        <h4><?php echo $row["TenSP"]; ?></h4>
                                                        <h4><?php echo number_format($row["GiaSP"]); ?></h4>
                                                        <p>
                                                            <?php echo $row["MoTa"]; ?>
                                                        </p>
                                                        <p>
                                                            <a href="index.php?act=details&id=<?php echo $row["MaSP"]; ?>" class="btn btn-primary" role="button">
                                                                Chi tiết
                                                            </a>
                                                            <?php if (isAuthenticated()) { ?> <!--kiểm tra nếu đăng nhập thành công mới thêm-->
                                                                <a href="#" class="btn btn-success" role="button" onclick="setProId(<?php echo $row["MaSP"]; ?>);"><!--Mới thêm ở đay-->
                                                                    <i class="fa fa-cart-plus"></i>
                                                                    Đặt hàng
                                                                </a>
                                                                <?php
                                                            }
                                                            ?>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>

                                            <?php
                                        }
                                        ?>
                                    </div> 
                                    <?php
                                }
                            } else {
                                redirect("index.php");
                            }
                            ?>
                        </div>

                    </div>
                    
           
                </div>


                <?php include_once "./lightbox.php"; ?>

          
        </div>
         <?php include_once "footer.php"; ?> 
        <script src="assets/jquery-3.1.1.min.js" type="text/javascript"></script>
        <script src="assets/bootstrap-3.3.4-dist/js/bootstrap.min.js" type="text/javascript"></script>
        <?php
        if (isset($js)) {
            echo $js;
        }
        ?>

    </body>

</html>



