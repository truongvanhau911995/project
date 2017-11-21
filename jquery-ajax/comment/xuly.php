<?php
     $com_mess=$_POST['mess'];
     $com_name=$_POST['name'];
     $com_id  =$_POST['id'];
    
    $connect = new mysqli('localhost','root','','chatajax');
    if($connect ->connect_errno){
        die("!FAIL");
    }
    mysqli_query($connect,"SET NAMES 'utf8'");
    $query="insert into comment(name, message, date, news_id) values('$com_name','$com_mess',now(),'$com_id')";
    $connect->query( $query);
    $connect->close();
   
   echo ' <li>
            <img alt="" src="image/login.png">
            <div>
            <b>'.$com_name.'</b>&nbsp;&nbsp;'.date('d/m/Y').'&nbsp;&nbsp;<a href="#">Reply</a>
            <p>'.nl2br($com_mess).'</p>
            </div>
        </li>';
    ?>