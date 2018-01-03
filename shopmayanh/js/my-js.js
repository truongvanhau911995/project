 $(document).ready(function(){
         function start(){
            interval=setInterval(function(){
                $('#slide ul').animate({'margin-left':'-=900'},1000,function(){
                $('#slide ul li:first').appendTo('#slide ul');// thêm vào cuối lại
                $('#slide ul').css('margin-left',0);// set nó lại từ đàu
            });
        }, 3000);
        }
        function pause(){
            clearInterval(interval);
        }
        $('#slide ul').on('mouseenter',pause).on('mouseleave',start);
      
       start();
    });

