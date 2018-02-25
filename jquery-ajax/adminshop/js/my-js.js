
$(document).ready(function(){
    function move_center(div){
    	// canh giữa chiều rộng
    	window_width = $(window).width();
    	obj_width = $(div).width();
    	$(div).css('left',(window_width/2)-(obj_width/2));
    }
    move_center('#popup');
    
});