<?php
require_once './function.php';
require_once './ketnoi.php';

if (isset($_POST["txtProId"])) {
    $sp = $_POST["txtProId"];
    $slg = 1;
    setCart($sp, $slg);
    print_r(getCart());
}
?>

<div class="col-md-9" style="float: right">
    <div class="panel panel-default">

        <div class="panel-heading" style="background-color: #FFCCCC">
            <h3 class="panel-title" style="color: blue; text-align: center">10 SẢN PHẨM XEM NHIỀU NHẤT</h3>
        </div>
        <div class="panel-body" style="background-color: Beige">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <!--Ngay đây-->
                <tr>
                    <td class="style12">
                <marquee height="500" behavior="scroll" direction="down" scrolldelay="100" scrollamount="5" onMouseOver="this.stop();" onMouseOut="this.start();">

                    <!--chỉnh kích thước hình trong bảng -->
                    <div class="panel-body" style="background-color: Beige"> <!--cái khung-->
                        <div class="row" >  <!--hình trong khung-->
                            <form id="f" action="" method="post">
                                <input type="hidden" id="txtProId" name="txtProId" />
                            </form>
                            <?php
                            //  require_once './function.php';
                            // require_once './ketnoi.php';
                            $sql = "select * from sanpham  ORDER BY SoLuotXem DESC limit 0,10";
                            $rs = load($sql);
                            if ($rs->num_rows == 0) {
                                echo "KHÔNG CÓ SẢN PHẨM.";
                            }
                            while ($row = $rs->fetch_assoc()) {
                                ?>

                                <div class="col-sm-6">
                                    <div class="thumbnail">

                                        <div class="caption" style="height: 400px">
                                            <img src="img/<?php echo $row["MaSP"]; ?>/a.png" alt="..." style="width: 270px;height: 270px">
                                            <h4><?php echo $row["TenSP"]; ?></h4>
                                            <h4><?php echo number_format($row["GiaSP"]); ?></h4>
                                            <p>
                                                <?php echo $row["MoTa"]; ?>
                                            </p>

                                        </div>
                                        <div style= "margin-bottom: 10px">
                                            <a href="index.php?act=details&id=<?php echo $row["MaSP"]; ?>" class="btn btn-primary" role="button">
                                                Chi tiết
                                            </a>

                                            <?php if (isAuthenticated()) { ?> <!--kiểm tra nếu đăng nhập thành công mới thêm-->
                                                <a href="#" class="btn btn-success" role="button" onclick="setProId(<?php echo $row["MaSP"]; ?>);">
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
                </marquee>
                </td>
                </tr>
            </table>
        </div>
    </div>
</div>


<?php include_once "./lightbox.php"; ?>