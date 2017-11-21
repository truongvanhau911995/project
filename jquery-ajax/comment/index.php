<html>
<head>
	<meta charset="UTF-8">
	<script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
	<script>
		$(document).ready(function(){
			//$("#loader").show();
			$("#ok").click(function(){
				$("#loader").css({"display":"block"});
				$.ajax({
					url  : "xuly.php",
					type : "post",
					timeout:3000,
					data : {key:'xanh'}, //"user="+ u +"&pass=" + p,
					async:false,// load 
					//cache:false,
					success: function(kq){
						$("#result").html(kq);
					}
				})			
			});
		})
		
	</script>
</head>

<body>
	<p><a href="detail.php?id=1"> Tiêu đề bài viết a</a></p>
	<p><a href="detail.php?id=2"> Tiêu đề bài viết b</a></p>
	<p><a href="detail.php?id=3"> Tiêu đề bài viết c</a></p>
</body>
</html>