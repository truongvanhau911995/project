<?php
if (isset($_POST["txtXProId"])) {
    $id = $_POST["txtXProId"];
    remove_cart_item($id);
}

if (isset($_POST["txtUProId"])) {
    $id = $_POST["txtUProId"];
    $q = $_POST["txtUQ"];
    update_cart_item($id, $q);
}

if (isset($_POST["btnCheckout"])) {
    $total = $_POST["txtTotal"];
    $userid = $_SESSION["auth_user"]["MaTK"];
    $order_date = date('Y-m-d H:i:s', time());

    $sql = "insert into dondathang(NgayLap, MaTK, TongThanhTien) values('$order_date', $userid, $total)";
    $order_id = save($sql, 0);

    foreach ($_SESSION["cart"] as $id => $quantity) {
        $sql = "select * from sanpham where MaSP=$id";
        $rs = load($sql);
        $row = $rs->fetch_assoc();
        $price = $row["GiaSP"];
        $amount = $price * $quantity;
        $sql = "insert into chitietdonDathang(MaDonDatHang, MaSP, SoLuong, GiaBan, TongTien) values($order_id, $id, $quantity, $price, $amount)";
        save($sql, 0);
    }
    unset($_SESSION['cart']);
    if (!isset($_SESSION["cart"])) {
        $_SESSION["cart"] = array();
    }
}
?>
<div class="col-md-9">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Giỏ hàng</h3>
        </div>
        <div class="panel-body">
            <form action="" method="post" name="f">
                <input type="hidden" name="txtXProId" />
                <input type="hidden" name="txtUProId" />
                <input type="hidden" name="txtUQ" />
            </form>
            <table class="table table-hover">
                <thead>
                    <tr style=" color: blue">
                        <th class="col-sm-4">Sản phẩm</th>
                        <th class="col-sm-2">Giá</th>
                        <th class="col-sm-2">Số lượng</th>
                        <th class="col-sm-2">Thành tiền</th>
                        <th class="col-sm-2">&nbsp;</th>
                    </tr>
                </thead>
                <tbody> 
                    <?php
                    $total = 0;
                    foreach ($_SESSION["cart"] as $id => $quantity) {
                        $sql = "select * from sanpham where MaSP=$id";
                        $rs = load($sql);
                        $row = $rs->fetch_assoc();
                        ?>
                        <tr>
                            <td><?php echo $row["TenSP"]; ?></td>
                            <td><?php echo number_format($row["GiaSP"]); ?></td>
                            <td><input id="txtQ_<?php echo $row["MaSP"]; ?>" style="width: 50px" type="text" value="<?php echo $quantity; ?>" /></td>
                            <td><?php echo number_format($row["GiaSP"] * $quantity); ?></td>
                            <td>
                                <a class="btn btn-danger btn-xs" href="javascript:;" role="button" title="Xoá" onclick="setXProId(<?php echo $row["MaSP"]; ?>);">
                                    <i class="fa fa-remove"></i>
                                </a>
                                <a class="btn btn-primary btn-xs" href="javascript:;" role="button" title="Cập nhật" onclick="setUProId(<?php echo $row["MaSP"]; ?>);">
                                    <i class="fa fa-check"></i>
                                </a>
                            </td>
                        </tr>
                        <?php
                        $total += $row["GiaSP"] * $quantity;
                    }
                    ?>
                </tbody>

                <tfoot>

                    <tr>
                        <td >      
                            <form action="" method="post" style=" margin-top: 0px">
                                <input type="hidden" name="txtTotal" value="<?php echo $total; ?>" />
                                <div class="row">
                                    <div class="col-md-12">
                                        <a class="btn btn-success" href="index.php" role="button">
                                            <i class="fa fa-mail-reply"></i> Tiếp tục mua hàng
                                        </a>
                                        </td>
                                        <td > 
                                            <button type="submit" id="btnCheckout" name="btnCheckout" class="btn btn-danger">
                                                <i class="fa fa-check"></i> Thanh toán
                                            </button>
                                    </div>
                                </div>
                            </form>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td><h4>Total:</h4></td>
                        <td class="text-danger" colspan="2">
                            <h4><?php echo number_format($total); ?></h4>                            
                        </td>
                    </tr>
                </tfoot>

            </table>

        </div>
    </div>
</div>

<?php
$js = <<<JS
<script type="text/javascript">
    function setXProId(id) {
        f.txtXProId.value = id;
        f.submit();
    }
        
    function setUProId(id) {
        var idQ = "txtQ_" + id;
        var txtQ = document.getElementById(idQ);
        var q1 = txtQ.value;
        f.txtUProId.value = id;
        f.txtUQ.value = q1;
        
        f.submit();
    }
</script>
JS;
?>