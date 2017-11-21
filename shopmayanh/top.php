<!--đoạn này khong cần quang tâm-->
<nav class="top-menu grid-container hide-on-tablet hide-on-mobile">
    
    <ul style="color: firebrick; text-align: center ">
        <li>Trương Văn Hậu--</li>
        <li>--Nguyễn Quốc Việt</li>
    </ul>

    <div class="top-menu-right">
        <ul>
            <li>
                <a href="log-in.html" class="dark-color" onclick="Global.clickShowToggle('#quick-login');
                        return false;">
                    <i class="icon-off"></i>
                   ...
                </a>
            </li>
        </ul> 
    </div>
   
</nav>
<!--trở lên-->



<nav class="main-menu grid-container" id="main-menu">
<!--thêm cái dòng top cua thay trong nay bắt đàu từ thẻ <nav>....</nav> -->
     <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="index.php?act=trangchu">
                <i class="fa fa-home"></i>
                Trang Chủ
            </a>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
               
                 <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a  href="index.php?act=quanlytaikhoan">Quản lý sản phẩm</a></li>
                        <li><a  href="index.php?act=quanlysanpham">Quản lý hãng</a></li>
                        <li><a  href="index.php?act=quanlyhang">Quản lý đơn hàng</a></li>
                        <li><a  href="index.php?act=quanlydonhang">Quản lý tài khoản</a></li>
                    </ul>
                </li>
            </ul>
            <form class="navbar-form navbar-left" method="GET" action="timkiem.php">
                <div class="form-group">
                    <input name="tukhoa" type="text" class="form-control" placeholder="Search">
                </div>
                
                    <button type="submit" class="btn btn-danger" title="tìm kiếm">
                        <i class="fa fa-search"></i>
                    </button>
       
            </form>
            <ul class="nav navbar-nav navbar-right">

                <?php
                require_once './function.php';
                if (isAuthenticated() == false) {
                    ?>
                    <li><a href="index.php?act=login">Đăng nhập</a></li>
                    <li><a href="index.php?act=register">Đăng ký</a></li>
                    <?php
                } else {
                    ?>
                    
                    <li>
                        <a href="index.php?act=cart">Giỏ hàng có <?php echo cart_sum_items(); ?> sản phẩm!</a>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"><?php echo $_SESSION["auth_user"]["HoTen"]; ?> <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="index.php?act=profile">
                                    <i class="fa fa-user"></i>
                                    Xem thông tin cá nhân
                                </a>
                            </li>
                            <li role="separator" class="divider"></li>
                            <li>
                                <a href="logout.php">
                                    <i class="fa fa-sign-out"></i>
                                    Thoát
                                </a>
                            </li>
                        </ul>
                    </li>
                    <?php
                }
                ?>
            </ul>
        </div><!-- /.navbar-collapse -->
    </div><!-- /.container-fluid -->
</nav>


