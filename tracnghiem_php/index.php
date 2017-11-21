<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<link rel="stylesheet" href="style.css">
<title>Trắc Nghiệm tính cách</title>
    <style type="text/css">
   
    </style>
</head>
    <body>
    <?php 
         require_once 'function-a.php';// lấy được mảng $arrQuestions
         require_once 'function-b.php';
         
         $newArr = array();
         foreach ($arrQuestions as $key => $value){
             $newArr[$key]["question"] =$value["question"];//
             $newArr[$key]["sentences"] =$arrOptions[$key];//gán key bên câu hỏi tương ứng với câu trả lời
             
         }
         echo "<pre>";
         print_r($newArr);
         echo "</pre>";
    ?>
    	<div class="content">
    	<h1>Trắc nghiệm tính cách</h1>
    	<form action="result.php" method = "pOST" name="mainForm">
    	<?php 
    	   $i =1;
    	   foreach ($newArr as $key => $value){
    	      
    	       echo '<div class= "question">';
    	       echo '<p>
                        <span>Câu hỏi '.$i.': </span> '.$value["question"].'
    			     </p>';
    	       echo '<ul>';
    		      foreach ($value["sentences"] as $keyC => $valueC){
    		          echo '<li><label><input type="radio" name="'.$key.'" value ="'.$valueC["point"].'">'.$valueC["option"].'</label></li>';
    		          
    		      }
    	       echo '</ul>';
    	       $i++;
    	   }
    	?>
    	
<!--     		<div class= "question"> -->
<!--     			<p> -->
<!--     				<span>Câu hỏi 2: </span> Bạn thường bước đi? -->
<!--     			</p> -->
<!--     			<ul> -->
<!--     				<li><label><input type="radio" name="12" value ="6">Khá nhanh với bước đi dài</label></li> -->
<!--     				<li><label><input type="radio" name="12" value ="4">Khá nhanh với bước chân ngắn</label></li> -->
<!--     				<li><label><input type="radio" name="12" value ="7">Không nhanh lắm, đầu ngẩng cao, hướng mặt ra xa</label></li> -->
<!--     				<li><label><input type="radio" name="12" value ="2">Không nhanh lắm , đàu cuối xuống</label></li> -->
<!--        				<li><label><input type="radio" name="12" value ="1">Rất chậm</label></li> -->
    				
<!--     			</ul> -->
<!--     		</div> -->
    		<input type="submit" value="Kiểm tra" name="submit"></input>
    	</form>
    	</div>
    </body>
</html>
 
