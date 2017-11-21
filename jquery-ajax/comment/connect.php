<?php
    $connect = new mysqli('localhost','root','','chatajax');
    if($connect ->connect_errno){
        die("!FAIL");
    }
    mysqli_query($connect,"SET NAMES 'utf8'");