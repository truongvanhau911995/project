<?php
 $connect = new mysqli('localhost','root','','tinhthanh');
 if($connect->errno){
     die("FAIL!");
 }
 mysqli_query($connect,"SET NAMES 'utf8'");