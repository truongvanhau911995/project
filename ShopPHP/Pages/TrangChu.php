<?php
include_once '../connect.php';

$query ='SELECT * FROM SanPham';
$result =$database ->query($query);
echo '<h2>TRANG CHỦ</h2>';
while ($row = mysqli_fetch_array($result)){?>
  <div class="box"> <img src="images/<?php echo $row['HinhURL']; ?>" />
                      <div class="pname">Tên: <?php echo $row['TenSanPham']; ?></div>
                      <div class="pprice">Giá:<?php echo $row['GiaSanPham']; ?> </div>
                      <div class="action">
                      <?php if ($_SESSION['flagPermission'] == true){?>
                      	 <a href="index.php?chon=trangchu&themgiohang=<?php echo $row['MaSanPham']; ?>" style="margin-right:4px">Mua Hàng</a>
                     <?php }?>
                     	 <a href="index.php?chon=chitiet&id=<?php echo $row['MaSanPham']; ?>">Chi Tiết</a>
                       </div>
                    </div>
<?php   
}
?>


