// SCROLL TO TOP ===============================================================================
$(function() {
	$(window).scroll(function() {
		if($(this).scrollTop() != 0) {
			$('#toTop').fadeIn();	
		} else {
			$('#toTop').fadeOut();
		}
	});
 
	$('#toTop').click(function() {
		$('body,html').animate({scrollTop:0},500);
	});	
	
});


<!-- Toggle -->			
	$('.togglehandle').click(function()
	{
		$(this).toggleClass('active')
		$(this).next('.toggledata').slideToggle()
	});

// alert close 
	$('.clostalert').click(function()
	{
	$(this).parent('.alert').fadeOut ()
	});	
	

<!-- Tooltip -->	
$('.tooltip-test').tooltip();


 //accordion v.2.1
function toggleChevron(e) {
    $(e.target)
        .prev('.panel-heading')
        .find(".indicator")
        .toggleClass('toggle_plus toggle_minus');
}
$('#accordion').on('hidden.bs.collapse shown.bs.collapse', toggleChevron);
//End accordion v.2.1			

<!-- News stip clickable-->				   
$(".news-strip ul li").click(function(){
    window.location=$(this).find("a").attr("href");return false;
});
 
 
// HOVER IMAGE MAGNIFY V.1.4 ===============================================================================
$(document).ready(function(){
	 "use strict";
    //Set opacity on each span to 0%
    $(".photo_icon").css({'opacity':'0'});

	$('.picture a').hover(
		function() {
			$(this).find('.photo_icon').stop().fadeTo(800, 1);
		},
		function() {
			$(this).find('.photo_icon').stop().fadeTo(800, 0);
		}
	),
	$(".video_icon_youtube").css({'opacity':'0'});

	$('.picture a').hover(
		function() {
			$(this).find('.video_icon_youtube').stop().fadeTo(800, 1);
		},
		function() {
			$(this).find('.video_icon_youtube').stop().fadeTo(800, 0);
		}
	),
	
	$(".video_icon_vimeo").css({'opacity':'0'});

	$('.picture a').hover(
		function() {
			$(this).find('.video_icon_vimeo').stop().fadeTo(800, 1);
		},
		function() {
			$(this).find('.video_icon_vimeo').stop().fadeTo(800, 0);
		}
	)
});	


	
	
