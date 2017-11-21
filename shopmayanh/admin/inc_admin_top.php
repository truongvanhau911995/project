
<nav class="navbar navbar-inverse" >
    <div class="container-fluid" style="background-color: papayawhip">
			<ul class="nav navbar-nav">
				<li>
                                    <a  href="admin.php?act=quanlytaikhoan" style="color: navy">Quản lý tài khoản</a>
				</li>
				<li>
					<a  href="admin.php?act=quanlysanpham" style="color: navy">Quản lý sản phẩm</a>
				</li>
				<li>
					<a  href="admin.php?act=quanlyhang" style="color: navy">Quản lý hãng</a>
				</li>
				<li>
					<a  href="admin.php?act=quanlydonhang" style="color: navy">Quản lý đơn hàng</a>
				</li>
			</ul>

			<ul class="nav navbar-nav navbar-right">
				  <?php
                require_once 'function.php';
                 
                    ?>
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
                   
             </ul>
  </div>
</nav>




