$(document).ready(function(){
	//THÊM
	$("#popup-bg").hide();
	$("#add").click(function(){
		/*$("#table-ajax h3").html("Thêm chuyên mục");
		$(".submit").attr({
			value:"Thêm",
			id   :"add-ajax"
		});*/
		$("#popup-bg").show();
	});
	
	$("#table-ajax img").click(function(){
		$("#popup-bg").hide();
	});
	$("#canel").click(function(){
		$("#popup-bg").hide();
	});
	$("#add-ajax").click(function(){// xử lý thêm category
		name = $("#txtname").val();
		$.ajax({
			url    :"xuly_cat.php",
			type   :"post",
			data   :{cat_name:name},
			async  :true,
			success:function(data){
				stt = $("#content table tr:last td:first").text();// lấy giá trị trong ô đó ra
				stt++;
				$("#popup-bg").fadeOut("fast",function(){// trước khi hiện kết quả cho ẩn BOX nhập liệu đi
					$("#content table ").append("<tr><td>"+stt+"</td><td>"+data+"</td><td><span  class='icon-e'></span><a href='javascript:void(0)'>Exit</a></td><td><span  class='icon-d'></span><a href='javascript:void(0)'>Delete</a></td></tr>");
				});
				$("#txtname").val("");
			}
		});
		return false;
	});
	//XÓA
	$(".del").click(function(){
		if(confirm("Bạn có chắc xóa dòng dữ liệu này! ") == true){
			id = $(this).attr('data-id');// lấy dòng chính nó thì dùng this
			$.ajax({
				url    :"del_cat.php",
				type   :"post",
				data   :{cat_id:id},
				async  :true,
				success:function(data){
					$("a[data-id='"+data+"']").closest("tr").fadeOut("fast");// chon thẻ tr bên ngoài thẻ a ẩn nó đi
				}
			});
		}
	});
	
	
	//CHỈNH SỬA
	$("#popup-bg2").hide();
	$(".edit").click(function(){
		/*
		$("#table-ajax h3").html("Chỉnh sửa chuyên mục");
		$(".submit").attr({
			value:"Chỉnh sửa",
			id   :"edit-ajax"
		});*/
		$("#popup-bg2").show();
	});

	$("#table-ajax img").click(function(){
		$("#popup-bg2").hide();
	});
	$("#huy").click(function(){
		$("#popup-bg2").hide();
	});
	
	// load dữ liệu
	$(".edit").click(function(){
		id = $(this).attr('data-id');// lấy dòng chính nó thì dùng this
		$.ajax({
			url    :"edit.php",
			type   :"post",
			data   :{cat_id:id},
			async  :true,
			success:function(data){
				$("#txtname1").val(data);
			}
		});

		// UPDATE
		$("#edit-ajax").click(function(){
			name = $("#txtname1").val();;// lấy dòng chính nó thì dùng this
			$.ajax({
				url    :"update.php",
				type   :"post",
				data   :{cat_id:id,cat_name:name},
				dataType: "json",
				async  :true,
				success:function(data){
					
					$("#popup-bg2").fadeOut("fast",function(){// trước khi hiện kết quả cho ẩn BOX nhập liệu đi
						$("a[data-id='"+data.cat_id+"']").closest("tr").find("td:eq(1)").html(data.cat_name);// lấy dòng hiện tại và cập nhật nó
					});
				}
			});

		});
	});
	
	
	
	
	
});