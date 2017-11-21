$(document).ready(function(){
	
		$('#login').click(function(){
			var flag= false;// mặc định ban đàu alf không có lỗi
			if($('#username').val() == ""){
				$('#username').next('.err').fadeIn();	// hiện thằng sau nó
				flag = true;//Phát hiện có lỗi
				
			}
			// kiểm tra password
			if($('#password').val() == ""){
				$('#password').next('.err').fadeIn();
				flag = true;// dừng thực thi trang web khi sai
				
			}
			if(flag ==true){
				return false;
			}else{
				u = $('#username').val();
				p = $('#password').val();
				$.ajax({
					url    :"xuly.php",
					type   :"post",
					data   :{user:u,pass:p},
					async  : true,
					success:function(data){
						$("#ok").html(data);
					}
				})
				return false;
			}
		});
		
		$("#username").keyup(function(){
			$('#username').next('.err').fadeOut();
		});
		$("#password").keyup(function(){
			$('#password').next('.err').fadeOut();
		});
	
});