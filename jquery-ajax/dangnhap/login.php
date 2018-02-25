<html>
<head>
	<script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
	<script>
		$(document).ready(function(){
			$('#ok').click(function(){
				var u = $('#username').val();// lấy giá trị trong o text
				var p = $('#password').val();

				$.ajax({
					url  : "xuly.php",
					type : "post",
					data : {user:u, pass:p}, //"user="+ u +"&pass=" + p,
					async:true,
					cache:false,
					success: function(data){
						$("#result").html(data)
					}
				});
				return false;
			});

		});

	</script>
</head>

<body>
	<form>
		<table>
			<tr>
				<td>Username:</td>
				<td><input type="text" size="25" id="username"/></td>
			</tr>
			<tr>
				<td>Password :</td>
				<td><input type="password" size="25" id="password"/></td>
			</tr>
			
			<tr>
				<td></td>
				<td><input type="submit" value="login" name="ok" id="ok"/></td>
			</tr>
		</table>
	</form>
	<div id="result"></div>
</body>
</html>