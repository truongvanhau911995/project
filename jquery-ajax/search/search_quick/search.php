<?php 
    include_once 'connect.php';
    if (isset($_GET['key'])){
        $key = $_GET['key'];
    }
    
    $query = "SELECT * FROM sanpham WHERE tensp like '%$key%'";
    $result = $connect->query( $query);
    if(mysqli_num_rows($result)==0){
        echo "<li>Không tìm thấy kết quả nào!</li>";
    }else{
        while ($row= $result->fetch_assoc()){
            echo '<li>
    				<a href="#">'.$row['tensp'].'</a>
    				<img style="width: 30px;height:30px;" alt="" src="images/'.$row['hinhanh'].'">
    			</li>';
        
        }
            
    }
    
?>