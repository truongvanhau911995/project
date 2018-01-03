



<?php
require_once 'function.php';
require_once 'ketnoi.php';

if (isAuthenticated() == false) {
    
}
?>
<?php
$id = $_GET["id"];
$sql = "select * from DonDatHang where MaDonDatHang=$id ";
$rs = load($sql);
if (isset($_POST["btnUpdate"])) {
    $name = $_POST["txtIDKH"];

    $tt = $_POST["txtProID"];
    echo $tt;
    $sql = "update DonDatHang
			set MaTK = '$name',tongthanhtien='$tt'
			where MaDonDatHang= $id ";

    $id = save($sql, 0);
    echo $id;

    redirect("admin.php?act=quanlydonhang");
}
?> 
<div class="col-md-9">
    <div class="panel panel-default" style="height: 324px;">
        <div class="panel-heading" style="background-color:#333;margin-bottom: 20px;">
            <h3 class="panel-title" style="color:#9d9d9d;">Cập nhật sản phẩm</h3>
        </div>

        <form class="form-horizontal" action="" method="post" id="registerForm" onsubmit="return validate();">

<?php
while ($row = $rs->fetch_assoc()) {
    ?>

                <div class="row">
                    <div class="col-md-10 col-md-offset-1">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon1">Mã đơn đặt hàng: </span>
                                <input value="<?php echo $row['MaTK'] ?>" type="text" class="form-control" name="txtIDKH" placeholder="OrderID">
                            </div>
                        </div>

                    </div>
                </div>



                <div class="row">
                    <div class="col-md-10 col-md-offset-1">

                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon1">Tong Thanh Tien: </span>
                                <input value="<?php echo $row['TongThanhTien'] ?>" type="text" class="form-control" name="txtProID" placeholder="ProID">
                            </div>
                        </div>


<?php } ?>
                    <div class="form-group">
                        <div class="col-sm-2" style="margin-left: -25px;">
                            <button  type="submit" class="btn btn-success pull-right" name="btnUpdate">
                                <i class="fa fa-check"></i> Cập Nhật
                            </button>
                        </div>
                        <div class="col-sm-2">
                            <a class="btn btn-danger" href="admin.php?act=quanlysanpham" role="button">
                                <i class="fa fa-mail-reply"></i> Huỷ bỏ
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</div>
<?php
$js = <<<JS
<script src="assets/bootstrap-datepicker/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function validate() {
        //
        // sinh viên tự cài đặt hàm kiểm tra form
        
        return true;
    }
    
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        startDate: '-3d',
        autoclose: true,
    });
</script>
JS;
?>