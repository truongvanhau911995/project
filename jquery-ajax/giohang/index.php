<?php 
    include_once 'connect.php';
    $query = "SELECT * FROM sanpham";

?>

<!DOCTYPE html>
<html>
<head>
<meta charset="${encoding}">
<title>TRANG CHỦ</title>
<link rel="stylesheet" href="style.css?t=<?php time();?>" type="text/css" />
</head>
<body>
<div id="container">
	<p>0 sản phẩm trong giỏ hàng</p>
	<?php 
	   $result = $connect->query($query);
	   while ($row = $result ->fetch_assoc()){
    	   echo '<div class="row">
            		<a href="detail.php?id='.$row['masp'].'">
            			<img style="width: 140px;height:140px;" src="images/'.$row['hinhanh'].'" />
            		</a>
            		<h2><a style="text-decoration: none;" href="detail.php?id='.$row['masp'].'">'.$row['tensp'].'<a/></h2>
            		<p class="money">Giá: '.number_format($row['dongia']).' VND</p>
            	</div>';   
	   }
	?>
	
</div>
</body>
</html>