<?php
require_once './ketnoi.php';
require_once './function.php';

if (isset($_POST["btnLogin"])) {
    $uid = $_POST["txtUID"];
    $pwd = $_POST["txtPWD"];
    $enc_pwd = md5($pwd);

    $sql = "select * from taikhoan where TenDN = '$uid' and MatKhau = '$enc_pwd'";
    $rs = load($sql);
    if ($rs->num_rows == 0) {
        $login_fail = 1;
    } else {

        $_SESSION["auth"] = 1;

        $row = $rs->fetch_assoc();
        $u = array();
        $u["TenDN"] = $row["TenDN"];
        $u["MatKhau"] = $row["MatKhau"];
        $u["MaTK"] = $row["MaTK"];
        $u["HoTen"] = $row["TenHienThi"];
        $u["Email"] = $row["Email"];
        $u["DOB"] = $row["DOB"];
        $u["MaLoaiTK"] = $row["MaLoaiTK"];
        //print_r($u);
        $_SESSION["auth_user"] = $u;

        // $_COOKIE["auth_user_id"] = $row["f_ID"];

        $remember = isset($_POST["chkRememberMe"]) ? true : false;
        if ($remember) {
            $expire = time() + 7 * 24 * 60 * 60;
            setcookie("auth_user_id", $row["MaTK"], $expire);
        }
        if ($row['MaLoaiTK'] == 1) {
            redirect("admin.php");
        }
        //$_SESSION["auth_username"] = $row["f_Username"];
        //$_SESSION["auth_id"] = $row["f_ID"];
        else {
            redirect("index.php");
        }
    }
}
?>

<div class="col-md-9">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Đăng nhập</h3>
        </div>
        <div class="panel-body">
            <form class="form-horizontal" action="" method="post" id="loginForm">

                <?php
                if (isset($login_fail) && $login_fail == 1) {
                    ?>
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <span>Login Failed</span>
                    </div>
                    <?php
                }
                ?>

                <div class="row">
                    <div class="col-md-10 col-md-offset-1 title">
                        Thông tin đăng nhập
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-5 col-md-offset-1">
                        <div class="form-group">
                            <div class="col-sm-12">
                                <input type="text" class="form-control" id="txtUID" name="txtUID" placeholder="Tên đăng nhập">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <input type="password" class="form-control" id="txtPWD" name="txtPWD" placeholder="Mật khẩu">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-7">
                                <label style="font-weight: normal">
                                    <input type="checkbox" name="chkRememberMe" /> Ghi nhớ
                                </label>
                            </div>
                            <div class="col-sm-5">
                                <button type="submit" class="btn btn-primary pull-right" name="btnLogin" id="btnLogin">
                                    <i class="fa fa-check"></i> Đăng nhập
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
</div>