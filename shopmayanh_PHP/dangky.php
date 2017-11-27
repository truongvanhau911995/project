<?php
require_once './ketnoi.php';
require_once './function.php';

if (isset($_POST["btnRegister"])) {

    //
    // kiểm tra captcha

    if (empty($_SESSION['captcha']) || trim(strtolower($_POST['txtCaptcha'])) != $_SESSION['captcha']) {
        $register_fail1 = 1;
    } else {
        $uid = $_POST["txtUID"];
        $pwd = $_POST["txtPWD"];
        $enc_pwd = md5($pwd);

        $fullname = $_POST["txtFullName"];
        $email = $_POST["txtEmail"];
        $str_dob = $_POST["txtDOB"];
        $str_dob = str_replace('/', '-', $str_dob);
        $dob = strtotime($str_dob); //d-m-Y
        $str_dob = date('Y-m-d H:i:s', $dob);
        
        // echo $str_dob;
        if (empty($fullname) || empty($pwd) || empty($uid) || empty($email) || empty($str_dob) ) {
            $register_fail = 1;
        }
        // echo $str_dob;
        else {
            $register_fail1 = 0;
            $register_fail = 0;
             //   $sql1 = "select * from taikhoan where  MatKhau = '$enc_pwd'";
            $sql = "insert into taikhoan(TenDN, MatKhau, HoTen, Email, DOB, MaLoaiTK) values('$uid', '$enc_pwd', '$fullname', '$email', '$str_dob', 0)";

            $id = save($sql, 0);
        }
        
    }
}
?>

<div class="col-md-9">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Đăng ký người dùng</h3>
        </div>
        <div class="panel-body">
            <form class="form-horizontal" action="" method="post" id="registerForm" onsubmit="return validate();">
                <?php if (isset($register_fail) && $register_fail == 1 || isset($register_fail1) && $register_fail1 == 1){ ?>
			
                <div class="alert alert-warning alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <span>Đăng ký thất bại</span>
                </div>
			
			<?php }  ?>
                         <?php if (isset($register_fail) && $register_fail == 0 || isset($register_fail1) && $register_fail1 == 0){ ?>
                        <div class="alert alert-warning alert-dismissible" role="alert">
                           <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                           <span>Đăng ký Thành công</span>
                       </div>
                    <?php }  ?>
                <div class="row">
                    <div class="col-md-10 col-md-offset-1 title">
                        Thông tin đăng nhập
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10 col-md-offset-1">
                        <div class="form-group">
                            <div class="col-sm-6">
                                <input type="text" class="form-control" name="txtUID" placeholder="Tên đăng nhập">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-6">
                                <input type="password" class="form-control" name="txtPWD" placeholder="Mật khẩu">
                            </div>
                            <div class="col-sm-6">
                                <input type="password" class="form-control" name="txtConfirmPWD" placeholder="Nhập lại mật khẩu">
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-10 col-md-offset-1 title">
                        Thông tin cá nhân
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10 col-md-offset-1">
                        <div class="form-group">
                            <div class="col-sm-6">
                                <input type="text" class="form-control" name="txtFullName" placeholder="Họ tên">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-6">
                                <input type="email" class="form-control" name="txtEmail" placeholder="Email">
                            </div>
                            <div class="col-sm-6">                                                
                                <input type="text" class="form-control datepicker" name="txtDOB" placeholder="Ngày sinh">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-6">
                                <img onclick="this.src = 'cool-php-captcha-0.3.1/captcha.php?' + Math.random();"  style="cursor: pointer" id="captchaImg" src="cool-php-captcha-0.3.1/captcha.php" />
                            </div>
                            <div class="col-sm-6">
                                <input type="text" class="form-control" id="txtCaptcha" name="txtCaptcha" placeholder="Captcha">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <button type="submit" class="btn btn-success pull-right" name="btnRegister">
                                    <i class="fa fa-check"></i> Đăng ký
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
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