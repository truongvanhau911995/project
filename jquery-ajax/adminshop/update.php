<?php
require_once 'connect.php';
if (isset($_POST['cat_name']) && isset($_POST['cat_id'])){
    $cat_name = $_POST['cat_name'];
    $cat_id = $_POST['cat_id'];
}else{
    echo "FAIL";
}
$query = "UPDATE category set cat_name = '$cat_name' WHERE cat_id =".$cat_id;
$result = $connect ->query( $query);

$query2 = "SELECT * FROM category WHERE cat_id =".$cat_id;
$result = $connect ->query( $query2);
$row = $result ->fetch_assoc();
$id   = $row['cat_id'];
$name = $row['cat_name']; 
echo json_encode(array(
    "cat_id"   =>"$id",
    "cat_name" =>"$name",
));




