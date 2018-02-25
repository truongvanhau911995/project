$(document).ready(function(){
	$("#txtsearch").keyup(function(){
		k = $("#txtsearch").val();
		if(k==""){
			$(".tk").css("display","none");
		}else{
			$.ajax({
				url:"search.php",
				type:"get",
				data:{key:k},
				async:true,
				success: function(data){
					$(".tk").html(data);
					$(".tk").css("display","block");
				}
			});
			
		}
		
		return false;
	});
});