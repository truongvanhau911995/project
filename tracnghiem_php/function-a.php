<?php
  $data = file('question.txt') or die("cannot read file");

  // xóa giá trị đàu tiên trog mảng
  
  array_shift($data);
  /*
        array( [12] => {
                            [question] => "ddddddddd"
                        }
        )
        
   */
    $arrQuestions = array();
    foreach ($data as $key => $value){
        $tmp = explode("|", $value); 
        
        $id       = $tmp[0];
        $question = $tmp[1];
        $arrQuestions[$id] =array("question" => $question) ;
    }
    