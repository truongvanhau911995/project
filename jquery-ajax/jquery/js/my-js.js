// Khai báo tên form
var formID = '#contact-form';

// Khai báo vùng hiển thị dữ liệu
var formmessage = '#content-load';

// Khai báo cấu hình

var options = {
					target  :formmessage,
				};
$(document).ready(function(){
        $(formID).submit(function(){
        	$(this).ajaxSubmit(options);
        	return false;
        });
   });