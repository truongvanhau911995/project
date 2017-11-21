 <div id="sidebar">
<?php   include_once 'connect.php';?>
	<dl>
        <dt>HÃNG SẢN XUẤT</dt>
        <?php
   
        $query ='SELECT * FROM hangsanxuat';
        $result =$database ->query($query);
        while ($row = mysqli_fetch_array($result)){
            echo ' <dd> <a href="index.php?chon=hangsanxuat&id='.$row['MaHangSanXuat'].'"> '.$row['TenHangSanXuat'].' </a> </dd>';
        }
    ?>
     
    </dl>
    <dl>
      <dt>LOẠI SẢN PHẨM</dt>
        <?php 
        $query ='SELECT * FROM loaisanpham';
        $result =$database ->query($query);
        while ($row = mysqli_fetch_array($result)){        
            echo ' <dd> <a href="index.php?chon=loaisanpham&id='.$row['MaLoaiSanPham'].'"> '.$row['TenLoaiSanPham'].' </a> </dd>';
        }
      ?>  
    </dl>
</div>