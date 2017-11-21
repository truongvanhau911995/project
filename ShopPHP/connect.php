<?php
    require_once 'class/Database.class.php';
    $params = array(
        'server'   => 'localhost',
        'username' => 'root',
        'password' => '',
        'database' => 'babyshop',
        'table' => 'sanpham'
    );
    $database = new Database($params);