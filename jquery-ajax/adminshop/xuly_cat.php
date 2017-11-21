<?php
    require_once 'connect.php';
    if(isset($_POST['cat_name'])){
        $name = $_POST['cat_name'];
    }else {
        echo "Fail!";
    }
    $query = "INSERT INTO category(cat_name) VALUES('$name')";
    $connect ->query( $query);
    echo $name;

    

