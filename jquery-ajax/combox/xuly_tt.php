<?php
include_once 'connect.php';
echo $id = $_POST['id'];
$query = "SELECT * FROM districts WHERE province_id=".$id;
$rs = $connect ->query($query);
while ($row = $rs ->fetch_assoc()){
    echo '<option value="'.$row['district_id'].'">'.$row['district_name'].'</option>';
}