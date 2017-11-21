<?php
    require_once 'connect.php';
    if (isset($_POST['cat_id'])){
        $cat_id = $_POST['cat_id'];
    }else{
        echo "FAIL";
    }
    $query = "DELETE FROM category WHERE cat_id=".$cat_id;
    $connect ->query( $query);
    
    echo $cat_id;
    