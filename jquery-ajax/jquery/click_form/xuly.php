<?php
echo '<pre>';
print_r($_POST);
echo '</pre>';
if (isset($_POST['user']) && isset($_POST['pass'])){
    $u = $_POST['user'];
    $p = $_POST['pass'];
    if ($u == "admin"  && $p == "1234"){
        echo "xin chao admin";
    }else {
        echo "usernam hoặc passwword không đúng";
    }
}
 