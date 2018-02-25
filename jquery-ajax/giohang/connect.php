<?php
 $connect = new mysqli('localhost','root','','shopajax');
 if($connect->errno){
     die("FAIL!");
 }
 mysqli_query($connect,"SET NAMES 'utf8'");