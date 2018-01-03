
<?php
require_once './ketnoi.php';
require_once './function.php';

if (isAuthenticated() == false) {
    redirect("index.php?act=login");
}
if (isset($_POST["btnRegister"])) {
    //
    // kiểm tra captcha

    if (empty($_SESSION['captcha']) || trim(strtolower($_POST['txtCaptcha'])) != $_SESSION['captcha']) {
        $register_fail1 = 1;
    } else {
        $uid = $_POST["txtUID"];
        $pwd = $_POST["txtPWD"];
        $enc_pwd = md5($pwd);
        $MKMOI = $_POST["txtConfirmPWD"];
        $MKMOI = md5($MKMOI);
        $fullname = $_POST["txtFullName"];
        $email = $_POST["txtEmail"];
        $str_dob = $_POST["txtDOB"];
        $str_dob = str_replace('/', '-', $str_dob);
        $dob = strtotime($str_dob); //d-m-Y
        $str_dob = date('Y-m-d H:i:s', $dob);
        // echo $str_dob;
        //   $Mk = $_SESSION["auth_user"]["MatKhau"];
        if (empty($fullname) || empty($pwd) || empty($uid) || empty($email) || empty($str_dob) || empty($enc_pwd)) {
            $register_fail = 1;
        }
        // echo $str_dob;
        else {
            if ($_SESSION["auth_user"]["MatKhau"] == $enc_pwd) {
                $register_fail1 = 0;
                $register_fail = 0;
                $Matk = $_SESSION["auth_user"]["MaTK"];
                $sql = "update  taikhoan set TenDN='$uid',MatKhau='$MKMOI', TenHienThi='$fullname',DOB= '$str_dob', Email='$email',MaLoaiTK= 0 where  MaTK= $Matk";
                $rs = load($sql);
                $id = save($sql, 1);
            } else {
                $register_fail = 1;
            }
        }
    }
}
?>

<div class="col-md-9" >

    <div class="panel panel-default">

        <div class="panel-heading ">
            <h3  style="color: #780000; text-align: center">Cập Nhật Thông tin cá nhân</h3>
        </div>
        <div class="panel-body">
            <?php
            $u = $_SESSION["auth_user"];
// print_r($u);
            ?>
            <div class="panel body-background2 content-font dark-color" id="home" > 
                <div class="image_wrapper image_fl"><img src="images/viet.jpg" alt="image" style="width: 200px; height: 200px; margin-top: 30px;margin-left: 100px"></div>
                <div style=" size: 20px" >

                    <ul style=" margin-left: 50px; margin-bottom: 10px;list-style-type: circle;">
                        <div class="panel-body">
                            <form class="form-horizontal" action="" method="post" id="registerForm" onsubmit="return validate();">
                                <?php if (isset($register_fail) && $register_fail == 1 || isset($register_fail1) && $register_fail1 == 1) { ?>

                                    <div class="alert alert-warning alert-dismissible" role="alert">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <span>Cập nhật thất bại</span>
                                    </div>

                                <?php } ?>
                                <?php if (isset($register_fail) && $register_fail == 0 || isset($register_fail1) && $register_fail1 == 0) { ?>
                                    <div class="alert alert-warning alert-dismissible" role="alert">
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <span>Cập Nhật Thành công</span>
                                    </div>
                                <?php } ?>
                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1 title"  style="color: #780000">
                                        Thông tin đăng nhập
                                    </div>
                                </div>
                                <div class="row" style="color: navy;">
                                    <div class="col-md-10 col-md-offset-1">
                                        <label for="user_name">Tên Đăng Nhập:</label>
                                        <div class="form-group">   
                                            <div class="col-sm-6">                      
                                                <input type="text" value="<?php echo $_SESSION["auth_user"]["TenDN"]; ?>" class="form-control" name="txtUID" placeholder="Tên đăng nhập">
                                            </div>
                                        </div>
                                        <label for="user_name">Mật Khẩu Củ:</label>

                                        <label for="user_name" style="margin-left: 150px"> Mật Khẩu Mới:</label>
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
                                    <div class="col-md-10 col-md-offset-1 title"  style="color: #780000">
                                        Thông tin cá nhân
                                    </div>
                                </div>
                                <div class="row" style="color: navy;">
                                    <div class="col-md-10 col-md-offset-1">
                                        <label for="user_name">Họ Tên:</label>
                                        <div class="form-group">
                                            <div class="col-sm-6">
                                                <input type="text" value=" <?php echo $_SESSION["auth_user"]["HoTen"]; ?> " class="form-control" name="txtFullName" placeholder="Họ tên">
                                            </div>

                                        </div>
                                        <label for="user_name">Email:</label>
                                        <label for="user_name" style=" margin-left: 200px">Ngày Sinh:</label>
                                        <div class="form-group">   
                                            <div class="col-sm-6">
                                                <input type="email" value="<?php echo $_SESSION["auth_user"]["Email"]; ?>" class="form-control" name="txtEmail" placeholder="Email">
                                            </div>

                                            <div class="col-sm-6">                                                  
                                                <input   type="text" value="<?php echo $_SESSION["auth_user"]["DOB"]; ?>" class="form-control datepicker" name="txtDOB" placeholder="Ngày sinh">
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
                                                    <i class="fa fa-check"></i> Cập Nhật
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </ul>                          
                </div>

            </div>
        </div>
    </div>
</div>

<?php
$js = <<<JS
<script src="assets/bootstrap-datepicker/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function validate() {
        //
        // 
        
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