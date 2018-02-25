// JavaScript Document

/*ready*/
$(function(){
	setOperate();
	smoothScroll();
	pageTop();
	menu();
	menuReserve();
	menuTab();
	rwdSlide();
	seasonSlide();
	singleFadeSlide();
	setSprash();
	accordionPanel();
	telLink2();
	telLink();
	headerFixed();


	/*
		window resize時に実行する関数
	------------------------------------------*/
	// ユーザーエージェントの判別
	var userAgent = navigator.userAgent;
	
	// スマートフォンの場合はorientationchangeイベントを監視する
	if (userAgent.indexOf("iPhone") >= 0 || userAgent.indexOf("iPad") >= 0 || userAgent.indexOf("Android") >= 0)
	    window.addEventListener("orientationchange", resizeHandler);
	else
	    window.addEventListener("resize", resizeHandler);
	
	function resizeHandler() {
	    setSprash();
	}
	/*------------------------------------------*/

});

$(window).on("load",function(){
	setTimeout(function() {setSlideNavPosition();}, 300);
	setTimeout(function() {setSlideNavPosition2();}, 300);
});

//=========================================================
//
//	jQuery Smart_UA.JS
//
//=========================================================
function setOperate(){
	setView();
	var agent = navigator.userAgent;
	if(agent.search(/iPhone/) != -1){
		$("body").addClass("iphone").addClass("ios"); //iPhoneには「body class="iphone"」追加
		window.onorientationchange = setView;
	}else if(agent.search(/iPad/) != -1){
		$("body").addClass("ipad").addClass("ios"); //iPadには「body class="ipad"」追加
		window.onorientationchange = setView;
	}else if(agent.search(/Android/) != -1){
		$("body").addClass("android"); //Androidには「body class="android"」追加
		window.onresize = setView;
	}else{
		$("body").addClass("other"); //上記以外には「body class="other"」追加
		window.onorientationchange = setView;
	}
}
function setView(){
	var orientation = window.orientation;
	if(orientation === 0){
		$("body").addClass("portrait"); //画面が縦向きの場合は「body class="portrait"」追加
		$("body").removeClass("landscape"); //画面が縦向きの場合は「body class="landscape"」削除
	}else{
		$("body").addClass("landscape"); //画面が横向きの場合は「body class="landscape"」追加
		$("body").removeClass("portrait"); //画面が横向きの場合は「body class="portrait"」削除
	}
}


/* スムーススクロール
-------------------------------------------------- */
function smoothScroll(){
   $('a[href^=#]:not(.non-scroll)').click(function() {
      var speed = 800;
      var href= $(this).attr("href");
      var target = $(href == "#" || href == "" ? 'html' : href);
      var position = target.offset().top-120;

	$('body,html').animate({scrollTop:position}, speed, 'swing');
      return false;
   });
}

/* ページトップ
-------------------------------------------------- */
function pageTop() {
	var topBtn = $('.pagetop');
	topBtn.hide();
	$(window).scroll(function () {
		if ($(this).scrollTop() > 400) {
			topBtn.fadeIn();
		} else {
			topBtn.fadeOut();
		}
		
	});
    topBtn.click(function () {
		$('body,html').animate({
			scrollTop: 0
		}, 500);
		return false;
    });
}


/* ヘッダー固定
-------------------------------------------------- */
function headerFixed() {
	var nav    = $('#header'),
		//h      = nav.height(),
    	offset = nav.offset();

	$(window).scroll(function () {
	　if ($('#menu').css('display') == 'none') {
	  if($(window).scrollTop() > offset.top) {
	    nav.addClass('is-scroll');
	  } else {
	    nav.removeClass('is-scroll');
	  }
	  }
	});	
	$(window).load(function () {
	  if($(window).scrollTop() > offset.top) {
	    nav.addClass('is-scroll');
	  } else {
	    nav.removeClass('is-scroll');
	  }
	});	
}

/*下層MV全画面表示
-------------------------------*/
//全画面
function setSprash(){
	var w = $(window).width();
	var h = $(window).height();
	var h2 = $("#header").height();
	
	if(w <= 768) {
		//sp
		$("#sprash .slide-item").height(h-h2+12);
	}else {
		//pc
		$("#sprash .slide-item").height(h-h2-40);	
	}
}


/* メニュー
-------------------------------------------------- */
function menu(){
	var flag = 0;
	var scrollpos = 0;
	var w = 0;
	var h = 0;
	
	$(document).on("click",".header-btn", function(){
		w = $(window).width();
		h = $(window).innerHeight();
		if(flag == 0){
			//open
			scrollpos = $(window).scrollTop();
			//console.log("開く時scrollpos"+scrollpos);
			$(this).addClass("active");
			$(".header-btn2").addClass("none");
			$("#header").removeClass("fixed");
			$("#header").removeClass("is-scroll");
			$("#menu-overlay").fadeIn().height(h);
			$("#menu").fadeIn();
			$('html, body').animate({ scrollTop:0 }, 0);
			$("#contents-wrap").hide();
			if(h <= 640 && w >= 768) {
				$(".menu-body").addClass("scroll");
			}else if(h > 640 && w >= 768){
				$(".menu").height(h);
			}
			flag = 1;
		}else{
			//close
			//console.log("閉じる時scrollpos"+scrollpos);
			$(".menu-body").removeClass("scroll");
			$(".menu").css("height","auto");
			$(this).removeClass("active");
			$(".header-btn2").removeClass("none");
			$("#header").addClass("fixed");
			$("#header").addClass("is-scroll");
			$("#menu-overlay").hide();
			$("#menu").fadeOut();
			$("#contents-wrap").show();
			$('html, body').animate({ scrollTop:scrollpos }, 0);
			flag = 0;
		}
	});
	
	function resizeMenu() {
		if(flag == 1) {
			w = $(window).width();
			h = $(window).innerHeight();
			if(h <= 640 && w >= 768) {
				$(".menu-body").addClass("scroll");
			}else if(h > 640 && w >= 768){
				$(".menu-body").removeClass("scroll");
				$(".menu").height(h);
			}
		}
	}
	
	
	// ユーザーエージェントの判別
	var userAgent = navigator.userAgent;
	
	// スマートフォンの場合はorientationchangeイベントを監視する
	if (userAgent.indexOf("iPhone") >= 0 || userAgent.indexOf("iPad") >= 0 || userAgent.indexOf("Android") >= 0)
	    window.addEventListener("orientationchange", resizeHandler);
	else
	    window.addEventListener("resize", resizeHandler);
	
	function resizeHandler() {
	    resizeMenu();
	}
	
}

/* 申し込みメニュー
-------------------------------------------------- */
function menuReserve(){
	var flag2 = 0;
	var scrollpos2 = 0;
	var w = 0;
	var h = 0;
	
	$(document).on("click",".header-btn2", function(){
		w = $(window).width();
		h = $(window).innerHeight();
		if(flag2 == 0){
			//open
			scrollpos2 = $(window).scrollTop();
			//console.log("開く時scrollpos"+scrollpos);
			$(this).addClass("active");
			$(".header-btn").addClass("none");
			$("#header").removeClass("fixed");
			$("#header").removeClass("is-scroll");
			$("#menu-overlay2").fadeIn().height(h);
			$("#menu2").fadeIn();
			$('html, body').animate({ scrollTop:0 }, 0);
			$("#contents-wrap").hide();
			if(h <= 640 && w >= 768) {
				$(".menu-body2").addClass("scroll");
			}else if(h > 640 && w >= 768){
				$(".menu2").height(h);
			}
			flag2 = 1;
		}else{
			//close
			//console.log("閉じる時scrollpos"+scrollpos);
			$(".menu-body2").removeClass("scroll");
			$(".menu2").css("height","auto");
			$(".header-btn2").removeClass("active");
			$(".header-btn").removeClass("none");
			$("#header").addClass("fixed");
			$("#header").addClass("is-scroll");
			$("#menu-overlay2").hide();
			$("#menu2").fadeOut();
			$("#contents-wrap").show();
			$('html, body').animate({ scrollTop:scrollpos2 }, 0);
			flag2 = 0;
		}
	});
	
	function resizeMenu2() {
		if(flag2 == 1) {
			w = $(window).width();
			h = $(window).innerHeight();
			if(h <= 640 && w >= 768) {
				$(".menu-body2").addClass("scroll");
			}else if(h > 640 && w >= 768){
				$(".menu-body2").removeClass("scroll");
				$(".menu2").height(h);
			}
		}
	}
	
	
	// ユーザーエージェントの判別
	var userAgent = navigator.userAgent;
	
	// スマートフォンの場合はorientationchangeイベントを監視する
	if (userAgent.indexOf("iPhone") >= 0 || userAgent.indexOf("iPad") >= 0 || userAgent.indexOf("Android") >= 0)
	    window.addEventListener("orientationchange", resizeHandler);
	else
	    window.addEventListener("resize", resizeHandler);
	
	function resizeHandler() {
	    resizeMenu2();
	}
	
}


/* メニュー内タブ切替
-------------------------------------------------- */
function menuTab() {
	$(document).on("click",".menu-tab__item", function(){
		var target = $(this).data("menu-tab");
		var myID = $(this).attr("id");
		if(myID == "tab-wed") {
			$(".menu-header").addClass("wedding");
		}else {
			$(".menu-header").removeClass("wedding");
		}
		$(".menu-tab__item, .menu-tab-body").removeClass("is-active");
		$(this).addClass("is-active");
		$("#"+target).addClass("is-active");
	});
}



/* アコーディオン
-------------------------------------------------- */
function accordionPanel(){
	$('.js-acrTitle').next().hide();
	$('.js-acrTitle.op').next().show();
      
	$('.js-acrTitle').click(function(){
			if($('+.js-acrBody',this).css('display') == 'none'){
				$(this).addClass('op');
				$('+.js-acrBody',this).slideDown();
			} else {
				$(this).removeClass('op');
				$('+.js-acrBody',this).slideUp();
			}
	});	
}


/* 電話番号リンク（SP用）
-------------------------------------------------- */
function telLink2() {
    var ua = navigator.userAgent;
    if(ua.indexOf('iPhone') > 0 && ua.indexOf('iPod') == -1 || ua.indexOf('Android') > 0 && ua.indexOf('Mobile') > 0 && ua.indexOf('SC-01C') == -1 && ua.indexOf('A1_07') == -1 ){
        $('.tel-link-g').each(function(){
            var str = $(this).text();
            $(this).html($('<a>').attr('href', 'tel:' + str.replace(/-/g, '')).append(str + '</a>'));
        });
    }	
}

/* 電話番号リンク（SPCV用）
-------------------------------------------------- */
function telLink() {
    var ua = navigator.userAgent;
    if(ua.indexOf('iPhone') > 0 && ua.indexOf('iPod') == -1 || ua.indexOf('Android') > 0 && ua.indexOf('Mobile') > 0 && ua.indexOf('SC-01C') == -1 && ua.indexOf('A1_07') == -1 ){
        $('.tel-link').each(function(){
            var str = $(this).text();
            $(this).html($('<a>').attr('href', 'tel:' + str.replace(/-/g, '')).append(str + '</a>'));
        });
    }	
}

/* RWD スライダー（3個以上）
-------------------------------------------------- */
function rwdSlide(){
	var w = $(window).width();
	var size = 768;
	if (w <= size) {
		if(!$(this).hasClass('slick-initialized')) {
				initRwdSlide();
			}	
	} else {
		if($(this).hasClass('slick-initialized')) {
				resetRwdSlide();
			}
	}
}
function initRwdSlide() {
	var $slide = $(".rwd-slider");
	var $slide2 = $(".rwd-slider-item2");

	$slide.slick({
		infinite: true,
		slidesToShow: 1,
		slidesToScroll: 1,
		dots: true,
		arrows: false,
		autoplay: true,
		swipe: true
	});
	
	$slide2.slick({
		infinite: true,
		slidesToShow: 1,
		slidesToScroll: 1,
		dots: true,
		arrows: false,
		autoplay: true,
		swipe: true
	});
}
function resetRwdSlide() {
	$(".rwd-slider").unslick();
	$(".rwd-slider-item2").unslick();
}
var timer = false;
$(window).resize(function() {
	if (timer !== false) {
		clearTimeout(timer);
	}
	timer = setTimeout(function() {
		rwdSlide();
	}, 200);
});


/* 季節のおすすめスライダー（season-slide）
-------------------------------------------------- */
function seasonSlide() {
	$(".season-slide").slick({
		dots: true,
		infinite: true,
		centerMode: true,
		centerPadding: '60px',
		slidesToShow: 3,
	  slidesToScroll: 3,
	  responsive: [
	    {
	      breakpoint: 1060,
	      settings: {
	        slidesToShow: 2,
	        slidesToScroll: 2
	      }
	    },
	    {
	      breakpoint: 640,
	      settings: {
	        slidesToShow: 1,
	        slidesToScroll: 1,
	        centerPadding: '30px'
	      }
	    }
	  ]
	});
}

/* 一枚画像フェードスライダー（single-fade-slide）
-------------------------------------------------- */
function singleFadeSlide() {
	var $slide = $(".single-fade-slide");
		$slide.slick({
			autoplay: true,
			dots: true,
			arrows: true,
			infinite: true,
			swipe: true,
			autoplaySpeed: 3000,
			speed: 2000,
			fade: true,
			slidesToShow: 1,
			slidesToScroll: 1
		});	
}


/* スライダー矢印位置調整
-------------------------------------------------- */
function setSlideNavPosition() {
	var $slide = $(".season-slide");
	var h = $slide.find(".season-list__ph img").height();
	$slide.find(".slick-prev").css("top",h/2-20);
	$slide.find(".slick-next").css("top",h/2-20);
}
function setSlideNavPosition2() {
	var $slide2 = $(".single-fade-slide");
	var h2 = $slide2.find("img").height();
	$slide2.find(".slick-prev").css("top",h2/2-20);
	$slide2.find(".slick-next").css("top",h2/2-20);
}