<?php
    include_once '../connect.php';
    session_start();
    session_unset();
    $database ->redirect('../index.php')
?>