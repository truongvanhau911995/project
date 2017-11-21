<?php 
    include_once 'connect.php';
    if(isset($_GET['id'])){
        $id = $_GET['id'];
        $sql = "select a.MaSanPham,a.TenSP , a.GiaSP , a.SoLuotXem,a.SoLuongBan,a.XuatXu , a.MoTa,a.ChiTiet, h.TenHangSX, l.TenLoaiSP  from sanpham a,hangsx h,loaisanpham l where a.MaLoaiSP=l.MaLoaiSP and a.MaHangSX=h.MaHangSX and a.MaSP = $id";
        
    }

?>

			<h1>Thông tin chi tiết sản phẩm</h1>
<div id="chitietsp">
	<div id="chitietleft">
    	<img src="images/Vtech_Bright_Lights_Ball.jpg">
    </div>
    <div id="chitietright">
    	<div>
        	<span class="label">Tên sản phẩm:</span>
            <span class="productname">Bright Lights Ball</span>
        </div>
        <div>
        	<span class="label">Giá:</span>
            <span class="price">150000 đ</span>
        </div>
        <div>
        	<span class="label">Hãng sản xuất:</span>
            <span class="factory">vTech</span>
        </div>
        <div>
        	<span class="label">Loại sản phẩm:</span>
            <span class="data">Đồ chơi nhựa</span>
        </div>
        <div>
        	<span class="label">Số lượng:</span>
            <span class="data">38 sản phẩm</span>
        </div>
        <div>
        	<span class="label">Số lược xem:</span>
            <span class="data">15 lược</span>
        </div>
        <div class="giohang">
        	<a href="index.php?a=5&id=24">
                <img src="img/shopping_cart.png" width="32">
            </a>
		</div>
     </div>
     <div id="mota">
     	Quả cầu thông minh     
     </div>
</div>	