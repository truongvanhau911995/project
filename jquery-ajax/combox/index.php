<?php 
    include_once 'connect.php';
    $province=$dc=$district=NULL;
    if (isset($_POST['ok'])){
        if($_POST['txtdiachi']==NULL){
            echo "Xin vui long nhap dia chi";
        }else{
            echo $dc = $_POST['txtdiachi'];
        }
        if($_POST['province']=='none'){
            echo "Xin vui lòng chọn tỉnh/thành!";
        }else {
            $province = $_POST['province'];
        }
        
        if($_POST['district']=='none'){
            echo "Xin vui lòng chọn quận/huyện!";
        }else {
            $district = $_POST['district'];
        }
        if($dc && $province && $district){
            echo $dc;
            echo '</br>';
            echo $province;
            echo '</br>';
           
            echo $district;
        }
    }
    
?>

<!DOCTYPE html>
<html>
<head>
<script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
<meta charset="${encoding}">
<title>Insert title here</title>
<link rel="stylesheet" href="style.css" type="text/css"/>
<style type="text/css">
    #container{
    	margin:0 auto;
    	width: 600px;
    	margin-top:100px;
    }
</style>
<script type="text/javascript">
	$(document).ready(function(){
		$('#province').change(function(){
			idp = $("#province").val();
			$.ajax({
				url   :"xuly_tt.php",
				type  :"post",
				data  :{id:idp},
				async :true,
				success: function(data){
					$('#district').html(data);
				}
			});
			return false;
		});

	});
</script>
</head>
<body>
	<div id="container">
		<form action="index.php" method="post">
			Địa chỉ: <input type="text" size="25" name="txtdiachi">
			<select id="province" name="province">
				<option value="none">--Tỉnh/Thành--</option>
				<?php 
				    $query = "SELECT * FROM provinces";
				    $rs = $connect ->query( $query);
				    while ($row = $rs ->fetch_assoc()){
				        echo '<option value="'.$row['province_id'].'">'.$row['province_name'].'</option>';
				    }
				
				?>
				
				
			</select>
			<select id="district" name="district">
				<option value="none">--Quận/Huyện--</option>
			</select>
			<div style="margin-top: 20px;">
				<input type="submit" name="ok" value="xác nhận thanh toán">
			</div>
			
		</form>
	</div>
	
</body>
</html>