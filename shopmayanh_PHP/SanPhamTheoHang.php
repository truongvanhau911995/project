<!--<div class="page-tabs-holder">
    <div class="page-tab" id="tab-recomend">

        <div class="grid-25 tablet-grid-50"><!-nhap anh trong nay->
            <div class="grid-100 margin-bottom"></div>
            <div class="grid-100 margin-bottom"></div>        
            nha
<!--Nhập trong này-->
<!--        </div> 

        <div class="grid-25 tablet-grid-50"></div> 

        <div class="grid-25 tablet-grid-50"></div> 

        <div class="grid-25 tablet-grid-50"></div> 
        <div class="grid-100 clear-before"></div>
    </div>  
</div>  -->
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
<div class="col-md-9">    <!--chỉnh kích thước hình trong bảng -->
    <div class="panel panel-default">
        <div class="panel-heading" style="background-color: #FFCCCC">
            <h3 class="panel-title" style="color: blue; text-align: center">Danh sách sản phẩm theo hãng</h3>
        </div>
        
        <div class="panel-body" style="background-color: Beige"> <!--cái khung-->


            <?php
            //  require_once './function.php';
            // require_once './ketnoi.php';

            if (isset($_GET["id"])) {
                $id = $_GET["id"];
                $sql = "select * from sanpham where MaHangSX = $id";
                $rs = load($sql);
                if ($rs->num_rows == 0) {
                    echo "KHÔNG CÓ SẢN PHẨM.";
                } else {
                    ?>

                    <div class="row">    <!--hình trong khung-->
                        <form id="f" action="" method="post">
                            <input type="hidden" id="txtProId" name="txtProId" />
                        </form>
                        <?php
                        while ($row = $rs->fetch_assoc()) {
                            ?>
                            <div class="col-sm-6">
                                <div class="thumbnail">

                                   

                                    <div class="caption" style="height: 400px" >
                                         <a href="img/<?php echo $row["MaSP"]; ?>/a.png" data-lightbox="<?php echo $row["MaSP"]; ?>" data-title="<?php echo $row["TenSP"]; ?>" style="">
                                             <img src="img/<?php echo $row["MaSP"]; ?>/a.png" alt="..." style="width: 270px;height: 270px">
                                          </a> 
                                        <h4><?php echo $row["TenSP"]; ?></h4>
                                        <h4><?php echo number_format($row["GiaSP"]); ?></h4>
                                        <p>
                                            <?php echo $row["MoTa"]; ?>
                                        </p>
                                     
                                    </div>
                                    <div style=" margin-bottom: 10px">
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
