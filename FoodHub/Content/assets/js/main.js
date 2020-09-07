//Bootsrap slider carousel
$('#carousel-slider').carousel();

$('a[data-slide="prev"]').click(function () {
    $('#carousel-slider').carousel('prev');
});

$('a[data-slide="next"]').click(function () {
    $('#carousel-slider').carousel('next');
});

//CounterUp
jQuery(document).ready(function( $ ) {
  $('.counter').counterUp({
    delay: 1,
    time: 500
  });
});

/* ==========================================================================
   Touch Owl Carousel
   ========================================================================== */
$(".touch-slider").owlCarousel({
    navigation: true,
    pagination: false,
    slideSpeed: 1000,
    stopOnHover: true,
    autoPlay: true,
    items: 1,
    itemsDesktopSmall: [1024, 1],
    itemsTablet: [600, 1],
    itemsMobile: [479, 1]
});

/* ==========================================================================
   Team
   ========================================================================== */
$(".team-carousel").owlCarousel({
    navigation: true,
    pagination: false,
    slideSpeed: 1000,
    stopOnHover: true,
    autoPlay: true,
    items: 3,
    itemsDesktopSmall: [1024, 2],
    itemsTablet: [640, 1],
    itemsMobile: [479, 1]
});
$(".featured-carousel").owlCarousel({
    navigation: true,
    pagination: false,
    slideSpeed: 1000,
    stopOnHover: true,
    autoPlay: true,
    items: 4,
    itemsDesktopSmall: [1024, 2],
    itemsTablet: [640, 1],
    itemsMobile: [479, 1]
});

$('.touch-slider').find('.owl-prev').html('<i class="fa fa-chevron-left"></i>');
$('.touch-slider').find('.owl-next').html('<i class="fa fa-chevron-right"></i>');

$('.team-carousel').find('.owl-prev').html('<i class="prev fa fa-chevron-left"></i>');
$('.team-carousel').find('.owl-next').html('<i class="next fa fa-chevron-right"></i>');
$('.featured-carousel').find('.owl-prev').html('<i class="prev fa fa-chevron-left"></i>');
$('.featured-carousel').find('.owl-next').html('<i class="next fa fa-chevron-right"></i>');

//  Back Top Link
  var offset = 200;
  var duration = 500;
  $(window).scroll(function() {
    if ($(this).scrollTop() > offset) {
      $('.back-to-top').fadeIn(400);
    } else {
      $('.back-to-top').fadeOut(400);
    }
  });
  $('.back-to-top').click(function(event) {
    event.preventDefault();
    $('html, body').animate({
      scrollTop: 0
    }, 600);
    return false;
  })

  /**
 * Slick Nav 
 */

$('.wpb-mobile-menu').slicknav({
  prependTo: '.navbar-header',
  parentTag: 'span',
  allowParentLinks: true,
  duplicate: false,
  label: '',
  closedSymbol: '<i class="fa fa-angle-right"></i>',
  openedSymbol: '<i class="fa fa-angle-down"></i>',
});