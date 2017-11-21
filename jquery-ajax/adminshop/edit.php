<?php
    require_once 'connect.php';
    if (isset($_POST['cat_id'])){
        $cat_id = $_POST['cat_id'];
    }else{
        echo "FAIL";
    }
    $query = "SELECT * FROM category WHERE cat_id =".$cat_id;
    $result = $connect ->query( $query);
    $row = $result ->fetch_assoc();
    echo $row['cat_name'];
    

    
    
    
    