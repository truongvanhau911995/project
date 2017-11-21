<?php
include_once 'connect.php';
if (isset($_GET['id'])){
    $id = $_GET['id'];
}else {
    header('location : index.php');
}
$query ='SELECT * FROM SanPham WHERE MaHangSanXuat ='.$id.'';
$result =$database ->query($query);
echo '  <h2>DANH SÁCH SẢN PHẨM THEO HÃNG</h2>';
while ($row = mysqli_fetch_array($result)){
    echo '<div class="box"> <img src="images/'.$row['HinhURL'].'" />
                      <div class="pname">'.$row['TenSanPham'].'</div>
                      <div class="pprice">Giá: '.$row['GiaSanPham'].'</div>
                      <div class="action">
                      	 <a href="index.php?chon=trangchu&themgiohang='.$row['MaSanPham'].'" style="margin-right:4px">Mua Hàng</a>
                     	 <a href="index.php?chon=chitiet&id='.$row['MaSanPham'].'">Chi Tiết</a>
                       </div>
                    </div>';
}
?>