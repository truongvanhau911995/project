<?php
require_once './function.php';
require_once './ketnoi.php';

if (isset($_POST["btnAddToCart"])) {
    $sp = $_GET["id"];
    $slg = $_POST["txtQuantity"];
    setCart($sp, $slg);
    //print_r(getCart());
}
?>


<div class="col-md-9">
    <div class="panel panel-default">
        <div class="panel-heading" style="background-color: #FFCCCC">
            <h3 class="panel-title" style="color: blue; text-align: center">Chi tiết sản phẩm</h3>
        </div>
        <div class="panel-body" style="background-color: Beige">
            <?php
            if (isset($_GET["id"])) {
                $id = $_GET["id"];
                $sql = "select a.MaSP,a.TenSP , a.GiaSP , a.SoLuotXem,a.SoLuongBan,a.XuatXu , a.MoTa,a.ChiTiet, h.TenHangSX, l.TenLoaiSP  from sanpham a,hangsx h,loaisanpham l where a.MaLoaiSP=l.MaLoaiSP and a.MaHangSX=h.MaHangSX and a.MaSP = $id";
                $rs = load($sql);
                if ($rs->num_rows == 0) {
                    echo "KHÔNG CÓ SẢN PHẨM.";
                } else {
                    $row = $rs->fetch_assoc();
                    ?>
                    <div class="row" >
                        <div style="text-align: center">
                            <div class="col-md-12">
                                <img src="img/<?php echo $row["MaSP"]; ?>/a.png" 
                                     title="<?php echo $row["TenSP"]; ?>"
                                     alt="<?php echo $row["TenSP"]; ?>" />
                                     <?php if (isAuthenticated()) {
                                         ?>
                                    <form class="form-horizontal" id="cartAdd-form" method="post" action="" style="margin-left:295px  ">
                                        <div class="form-group">
                                            <div class="col-sm-3">
                                                <div class="input-group" style="margin-left: 70px ">
                                                    <input type="text" id="txtQuantity" name="txtQuantity" class="form-control" placeholder="Slg" value="1" style="width: 40px; color:red ">
                                                    <span class="input-group-btn">
                                                        <button class="btn btn-primary" type="submit" name="btnAddToCart" >
                                                            <i class="fa fa-cart-plus"></i>
                                                        </button>
                                                    </span>
                                                </div><!-- /input-group -->
                                            </div>
                                        </div>
                                    </form>
                                    <?php
                                }
                                ?>
                            </div>

                        </div>

                        <div style="margin-left: 200px">  
                            <div class="col-md-12 caption-lg">
                                >Tên sản phẩm: <span style="color: #D04028;font-size: 16px "><?php echo $row["TenSP"]; ?></span> 
                            </div>
                            <div class="col-md-12">
                                >Giá:<span class="caption-sm" style="color: #D04028;font-size: 16px "><?php echo number_format($row["GiaSP"]); ?> VNĐ</span>
                            </div>
                            <div class="col-md-12 caption-lg">
                                <div>>Số Lược xem:<?php echo $row["SoLuotXem"] + 1; ?></div> 
                            </div>
                            <div class="col-md-12 caption-lg">
                                <div>>Số Lượng bán:<?php echo $row["SoLuongBan"]; ?></div> 
                            </div>

                            <div class="col-md-12 caption-lg">
                                <div>>Xuất Xứ:<?php echo $row["XuatXu"]; ?></div> 
                            </div>
                            <div class="col-md-12 caption-lg">
                                <div>>Hãng Sản Xuất:<?php echo $row["TenHangSX"]; ?></div> 
                            </div>
                            <div class="col-md-12 caption-lg">
                                <div>>Loại Sản phẩm:<?php echo $row["TenLoaiSP"]; ?></div> 
                            </div>

                            <div class="col-md-12 padding">
                                <h4 style="color: #780000">Thông tin chi tiết</h4>
                                <?php echo $row["ChiTiet"]; ?>
                            </div>
                        </div>

                    </div>
                    <?php
                }
            } else {
                redirect("index.php");
            }
            ?>
        </div>
        
    </div> 
    
    <!--Sản Phẩm bán cùng loại-->
    <div class="panel panel-default">
        <div class="panel-heading" style="background-color: #FFCCCC">
            <h3 class="panel-title" style="color: blue; text-align: center">5 SẢN PHẨM CÙNG LOẠI</h3>
        </div>
        <div class="panel-body" style="background-color: Beige">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <!--Ngay đây-->
                <tr>
                    <td class="style12">
                <marquee height="400" behavior="scroll" direction="down" scrolldelay="100" scrollamount="5" onMouseOver="this.stop();" onMouseOut="this.start();">

                    <!--chỉnh kích thước hình trong bảng -->
                    <div class="panel-body" style="background-color: Beige"> <!--cái khung-->
                        <div class="row" >  <!--hình trong khung-->
                             <form id="f" action="" method="post">
                            <input type="hidden" id="txtProId" name="txtProId" />
                        </form>
                            <?php
                          //  require_once './function.php';
                           // require_once './ketnoi.php';
                          $sql = "select* from sanpham WHERE MaLoaiSP=1  LIMIT 0,5";
                            $rs = load($sql);
                            if ($rs->num_rows == 0) {
                                echo "KHÔNG CÓ SẢN PHẨM.";
                            }
                            while ($row = $rs->fetch_assoc()) {
                                ?>

                                <div class="col-sm-5">
                                    <div class="thumbnail">
                                       
                                        <div class="caption" style="height: 400px">
                                             <img src="img/<?php echo $row["MaSP"]; ?>/a.png" alt="..." >
                                            <h4><?php echo $row["TenSP"]; ?></h4>
                                            <h4><?php echo number_format($row["GiaSP"]); ?></h4>
                                            <p>
                                                <?php echo $row["MoTa"]; ?>
                                            </p>
                                            <p>
                                                <a href="index.php?act=details&id=<?php echo $row["MaSP"]; ?>" class="btn btn-primary" role="button">
                                                    Chi tiết
                                                </a>

                                                <?php if (isAuthenticated()) { ?> <!--kiểm tra nếu đăng nhập thành   công mới thêm-->
                                                    <a href="#" class="btn btn-success" role="button" onclick="setProId(<?php echo $row["MaSP"]; ?>);">
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
                </marquee>
                </td>
                </tr>
            </table>
        </div>
    </div>
        
        
          <!--Sản Phẩm bán cùng xuất xứ-->
    <div class="panel panel-default">
        <div class="panel-heading" style="background-color: #FFCCCC">
            <h3 class="panel-title" style="color: blue; text-align: center">5 SẢN PHẨM CÙNG XUẤT XỨ</h3>
        </div>
        <div class="panel-body" style="background-color: Beige">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <!--Ngay đây-->
                <tr>
                    <td class="style12">
                <marquee height="400" behavior="scroll" direction="down" scrolldelay="100" scrollamount="5" onMouseOver="this.stop();" onMouseOut="this.start();">

                    <!--chỉnh kích thước hình trong bảng -->
                    <div class="panel-body" style="background-color: Beige"> <!--cái khung-->
                        <div class="row" >  <!--hình trong khung-->
                             <form id="f" action="" method="post">
                            <input type="hidden" id="txtProId" name="txtProId" />
                        </form>
                            <?php
                          //  require_once './function.php';
                           // require_once './ketnoi.php';
                            $sql = "select* from sanpham WHERE XuatXu = 'Nhật Bản' LIMIT 5 ";
                            $rs = load($sql);
                            if ($rs->num_rows == 0) {
                                echo "KHÔNG CÓ SẢN PHẨM.";
                            }
                            while ($row = $rs->fetch_assoc()) {
                                ?>

                                <div class="col-sm-5">
                                    <div class="thumbnail">
                                       
                                        <div class="caption" style="height: 400px">
                                             <img src="img/<?php echo $row["MaSP"]; ?>/a.png" alt="..." >
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
                                                    <a href="#" class="btn btn-success" role="button" onclick="setProId(<?php echo $row["MaSP"]; ?>);">
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
                </marquee>
                </td>
                </tr>
            </table>
        </div>
    </div>
 
   </div>
<!--thêm so luot xem vào csdl-->
<?php
//Cập nhật lại số lược xem vào CSDL
$SoLuocXem = $row["SoLuotXem"] + 1;
$sql1 = "UPDATE SanPham SET SoLuotXem = $SoLuocXem 
			WHERE MaSP = $id";
echo load($sql1);
//DataProvider::ExecuteQuery($sql);
?>


