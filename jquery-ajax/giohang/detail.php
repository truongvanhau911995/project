<?php 
    include_once 'connect.php';
    if (isset($_GET['id'])){
        $id = $_GET['id'];
    }else {
        header('location : index.php');
    }
     $query = "SELECT * FROM sanpham WHERE masp=".$id; 
     $result = $connect->query($query);
     $row = $result ->fetch_assoc();
     echo '<pre>';
     print_r($row);
     echo '</pre>';

?>

<!DOCTYPE html>
<html>
<head>
<meta charset="${encoding}">
<title>CHI TIẾT SẢN PHẦM</title>
<link rel="stylesheet" href="style.css?t=<?php time();?>" type="text/css" />
</head>
<body>
<div id="container">
	<div id="content">
	</div>
	<div id="left">
		<img alt="" src="images/<?php echo $row['hinhanh'];?>">
	</div>
	<div id="right">
		<h1><?php echo $row['tensp'];?></h1>
		<p>Giá: <?php echo $row['dongia'];?> VNĐ</p>
		<p><a href="cart.php?masp=<?php echo $row['masp'];?>">Mua Hàng</a></p>
	</div>
	<div id="footer">
		<div>chi tiet của san phẩm</div>
	</div>
	
</div>
</body>
</html>
