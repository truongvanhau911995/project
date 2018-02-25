<?php 
    include_once 'connect.php';
    if (isset($_GET['id'])){
        $id = $_GET['id'];
    }
    
?>

<html>
<head>
	<meta charset="UTF-8">
	<script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
	<link href="style.css" rel="stylesheet" type="text/css"/>
	<script src="js/my-js.js">
		/*$(document).ready(function(){
			$(".com-submit").click(function(){
				m  = $(".txtare").val();
				n  = $(".txt").val();
				idd = <php echo $id;?>;
				$.ajax({
					url  : "xuly.php",
					type : "post",
					data :{mess:m,name:n,id:idd},//{mess:"xanh"},
					async:true,// load 
					cache:false,
					success: function(data){
						$("ul li:eq(0)").before(data);
					}
				})
				return false;	
			});
		});*/
		
	</script>
</head>

<body>
		<div id="result"></div>
    	<div>
    		<p>Nội dung bài viết</p>
    		<p>Nội dung bài viết</p>
    		<p>Nội dung bài viết</p>
    	</div>
    	
    	<fieldset >
    		<legend>YOUR COMMENT</legend>
    		<form >
    			<table>
    				<tr>
    					<td>Content</td>
    					<td><textarea rows="" cols="" class="txtare"></textarea></td>
    				</tr>
    				<tr>
    					<td>Name</td>
    					<td>
    						<input type="text" class="txt"/>
    					</td>
    				</tr>
    				<tr>
    					<td></td>
    					<td>
    						<input type="submit" value="Content" class="com-submit" data-id="<?php echo $id;?>"/>
    					</td>
    				</tr>
    				
    			</table>
    		</form>
    	</fieldset>
    	<fieldset>
    		<legend>Old Comment</legend>
    		<?php 
    		echo $query ="SELECT * FROM comment WHERE news_id='$id' ORDER BY id DESC ";
    		$result = $connect->query($query);
    		if(mysqli_num_rows($result)==0){
    		    echo '<span style="color:#CCC;">Chưa có bình luận nào!</span>';
    		}else{
    		    while($row = $result ->fetch_assoc()){
    		        echo '<ul id="ul-list">
            			<li>
            				<img alt="" src="image/login.png">
            				<div>
            					<b>'.$row['name'].'</b>&nbsp;&nbsp;'.$row['date'].'&nbsp;&nbsp;<a href="#">Reply</a>
            					<p>'.nl2br($row['message']).'</p>
            				</div>
    		    
            				<ul>
                    			<li>
                    				<img alt="" src="image/login.png">
                    				<div>
                    					<b>Trương Văn Hậu</b>&nbsp;&nbsp;10/1/2017
                    					<p> Noij dung reply</p>
                    				</div>
                    			</li>
            
                    		</ul>
                    		<fieldset id="fild">
                        		<legend>YOUR REPLY</legend>
                        		<form >
                        			<table>
                        				<tr>
                        					<td>Content</td>
                        					<td><textarea rows="" cols="" class="rep-txtare"></textarea></td>
                        				</tr>
                        				<tr>
                        					<td>Name</td>
                        					<td>
                        						<input type="text" class="rep-txt"/>
                        					</td>
                        				</tr>
                        				<tr>
                        					<td></td>
                        					<td>
                        						<input type="submit" value="Content"/>
                        					</td>
                        				</tr>
    		    
                        			</table>
                        		</form>
                        	</fieldset>
            			</li>
        
            		</ul>';
    		    }
    		}
    		
    	
    		?>
    		
    		
    	</fieldset>
    		
</body>
</html>


















