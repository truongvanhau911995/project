<?php
  $data = file('options.txt') or die("cannot read file");

  array_shift($data);
 
    $arrOptions = array();
    foreach ($data as $key => $value){
        $tmp = explode("|", $value);// chuyển chuỗi thánh mảng
        $questionID =  $tmp[0];//cho gia trị key 0 vào biến tạm
        $optionID   =  $tmp[1];
        $answer     =  $tmp[2];
        $point      =  $tmp[3];
        
        $arrOptions[$questionID][$optionID]["option"]=$answer;
        $arrOptions[$questionID][$optionID]["point"]=$point;
       
    }
