<?php 
    include_once 'connect.php';
    session_start();
    if (isset($_GET['masp'])){
        echo $id = $_GET['masp'];
    }else {
        header('location : index.php');
    }
    if (!isset($_SESSION["cart"])) {
        $_SESSION["cart"] = array();
    }
    
    if (isset($_GET['masp'])) {
        $id = $_GET["masp"];
        if (array_key_exists($id, $_SESSION["cart"])) {
            $_SESSION["cart"][$id] += 1;
        } else {
            $_SESSION["cart"][$id] = 1;
        }
    }
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
	<div id="content-cart">
		<table>
    		<tr>
    			<th>Xóa</th>
    			<th>Sản Phẩm</th>
    			<th>Số lượng</th>
    			<th>Đơn Giá</th>
    			<th>Thành Tiền</th>
    		</tr>
    		<?php 
    		  foreach ( $_SESSION["cart"] as $key=>$value){
    		      $query = "SELECT * FROM sanpham WHERE masp=".$key;
    		      $result = $connect ->query($query);
    		      while ($row=$result -> fetch_assoc()){
    		          echo '<tr>
                			<td><a href="#">Xóa</a></td>
                			<td>'.$row['tensp'].'</td>
                			<td><input type="number" min="1" max="100" value="'.$value.'"/></td>
                			<td>'.$row['dongia'].'</td>
                			<td>'.$row['dongia']*$value.'</td>
                		</tr>';
    		      }
    		     
    		  }
    		?>
    		
    		<tr >
    			<td colspan='4'>Tổng Tiền</td>
    			<td>300000</td>
    		</tr>
		</table>
		<a href="index.php">Mua tiếp sản phẩm</a>
		<a href="#" style="float:right;">Mua thêm sản phẩm</a>
	</div>	
</div>
</body>
</html>
