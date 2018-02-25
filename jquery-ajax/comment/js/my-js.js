$(document).ready(function(){
	$(".com-submit").click(function(){
		m  = $(".txtare").val();
		n  = $(".txt").val();
		idd = $(".com-submit").attr("data-id");
		$.ajax({
			url  : "xuly.php",
			type : "post",
			data :{mess:m,name:n,id:idd},//{mess:"xanh"},
			async:true,// load 
			cache:false,
			success: function(data){
				if($("#ul-list").length() == 0){
					$("ul li").html(data);
				}else{
					$("ul li:eq(0)").before(data);
				}
				$(".txtare").val("");
				$(".txt").val("");
			}
		})
		return false;	
	});
});