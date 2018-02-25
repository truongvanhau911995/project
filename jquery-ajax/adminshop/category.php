<?php 
    require_once 'connect.php';
?>

<!DOCTYPE html>
<html>
<head>
<script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
<meta charset="${encoding}">
<title>Insert title here</title>
<link rel="stylesheet" href="css/style.css?t=<?php echo time();?>" type="text/css"/>
<script type="text/javascript" src="js/my-js.js"></script>
<script type="text/javascript" src="js/category.js"></script>
</head>
<body>
	<div id="popup-bg">
		<div id="popup">
			<div id="table-ajax">
				<div>
					<h3>Thêm chuyên mục</h3>
					<img alt="" src="images/close.png">
				</div>
				<form action="">
					<table>
						<tr>
							<td>Tên mới</td>
							<td><input type="text" id="txtname"></td>
						</tr>
						<tr>
							<td></td>
							<td><input type="submit" value="Thêm" id="add-ajax"><input type="submit" value="Thoát" id="canel"></td>
						</tr>
					</table>
				</form>
			</div>
		</div>
	</div>
	<!-- CHỨC NĂNG CHỈNH SỬA -->
	<div id="popup-bg2">
		<div id="popup">
			<div id="table-ajax">
				<div>
					<h3>Chỉnh sửa chuyên mục</h3>
					<img alt="" src="images/close.png">
				</div>
				<form action="">
					<table>
						<tr>
							<td>Tên mới</td>
							<td><input type="text" id="txtname1"></td>
						</tr>
						<tr>
							<td></td>
							<td><input type="submit" value="chỉnh sửa" id="edit-ajax"><input type="submit" value="Thoát" id="huy"></td>
						</tr>
					</table>
				</form>
			</div>
		</div>
	</div>
	<!-- Hét -->
	
	
	<div id="container">
		<div class="top"><img alt="" src="images/icon-add.png"></div>
		<div class="menu">phần menu</div>
		<div id="content">
			<div>
				<h3>Quản lý chuyên mục</h3>
				<button id="add"><span class="icon"></span>Thêm</button>
			</div>
			<table>
				<tr>
					<th>STT</th>
					<th>Chuyên mục</th>
					<th>Exit</th>
					<th>Delete</th>
				</tr>
				<?php 
				    $query = "SELECT * FROM category";
				    $result = $connect ->query( $query);
				    $stt = 1;
				    while($row = $result ->fetch_assoc()){
				        //<a href="del_cat.php?id='.$row['cat_id'].'"
				        echo '<tr>
        					<td>'.$stt++.'</td>
        					<td>'.$row['cat_name'].'</td>
        					<td><span  class="icon-e"></span><a href="javascript:void(0)" data-id="'.$row['cat_id'].'" class="edit">Exit</a></td>
        					<td><span  class="icon-d"></span><a href="javascript:void(0)" data-id="'.$row['cat_id'].'" class="del">Delete</a></td>
        				</tr>'; 
				    }
				    $connect ->close();
				?>
				
				
			</table>
		</div>
		<div class="footer">phần bootton</div>
	</div>	
</body>
</html>