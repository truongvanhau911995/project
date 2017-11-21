<html>
<head>
	<script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
	<style type="text/css">
        #loader{
        	width:30px;
        	height:30px;
        	background:url("image/ajax-loader.gif") no-repeat;
        	position: absolute;
        	left: 100px;
        	top: 6px; 
        	display:none; 
        	
        }
    </style>
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
			//	$("#loader").css({"display":"none");
				//$("#loader").hide();
				//return false;
			});
		})
		
	</script>
</head>

<body>
	<div>
		<button id="ok">Load Dữ liệu</button>
		<div id="loader"></div>
		<div id="result"></div>
	</div>
</body>
</html>