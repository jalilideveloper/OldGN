// ================================================
// slider recent works & our clients
// ================================================
$(document).ready(function() {
    $('.carousel').carousel({
        interval: 6000
    })
});
// ================================================
// activate pager for testimonials
// ================================================
$(document).ready(function() {
    var current = $('.content-slider-pager a > li');
    $('.content-slider-pager a > li').click(function() {
        current.removeClass("active");
        current = $(this);
        current.addClass("active");
    });
});
// ================================================
// activate slideshow for services
// ================================================
$(document).ready(function() {
    var current = $('.services-shortcut');
    $(".services-shortcut").click(function() {
        current.removeClass("active");
        current = $(this);
        current.addClass("active");
    });
});
// ================================================
// call knob for progress bars in about page
// ================================================
$(document).ready(function() {
    $(".dial").knob();
});
// ================================================
// activate close button for widgets
// ================================================
(function() {
    $(".close-widget").one('click', function(e) {
        e.preventDefault();
        $(this).closest(".widget").fadeOut();
    });
})(jQuery);
// ================================================
// plus and minus sign for accordion widget
// ================================================
$("ul#plus-minus > li > a").click(function() {
    $(this).toggleClass("minus");
});
// ================================================
// call fittext plugin for responsive error 404 text
// ================================================
$(document).ready(function() {
    $("#fittext").fitText(0.2, {
        minFontSize: 30,
        maxFontSize: '240px'
    });
});
// ================================================
// jQuery scroll to up
// ================================================
$('#ScrollTop').on("click", function() {
    $('html,body').animate({
        scrollTop: 0
    }, 'slow', function() {});
});
// ================================================
// testimonials slider
// ================================================
$('.testimonials-slider').bxSlider({
    minSlides: 1,
    maxSlides: 1,
    auto: true,
    autoControls: false,
    pager: false,
    controls: false,
    autoHover: true,
    mode: "vertical"
});
// ================================================
// featured slider
// ================================================
$('#featured-slider').bxSlider({
    pagerCustom: ".featured-slider-pager",
    controls: false,
    minSlides: 1,
    maxSlides: 1,
    auto: true,
    mode: "horizontal",
    controls: true,
    autoHover: true,
    preloadImages: "all",
    prevText: '<i class="icon-angle-left"></i>',
    nextText: '<i class="icon-angle-right"></i>',
    captions: true
});
// ================================================
// new project slider
// ================================================
$('#new-project-carousel').bxSlider({
    pagerCustom: "#bx-pager",
    controls: false,
    minSlides: 1,
    maxSlides: 1,
    auto: true,
    mode: "fade",
    controls: true,
    autoHover: true,
    preloadImages: "all",
    nextSelector: '#slider-next',
    prevSelector: '#slider-prev',
    prevText: '<i class="icon-angle-left"></i>',
    nextText: '<i class="icon-angle-right"></i>',
    captions: false
});
// ================================================
// portfolio entry slideshow
// ================================================
$('#portfolio-entry-slideshow').bxSlider({
    controls: false,
    minSlides: 1,
    maxSlides: 1,
    auto: false,
    mode: "fade",
    pager: false,
    controls: true,
    autoHover: true,
    preloadImages: "all",
    nextSelector: '#slider-next',
    prevSelector: '#slider-prev',
    prevText: '<i class="icon-angle-left"></i>',
    nextText: '<i class="icon-angle-right"></i>',
    captions: false
});
// ================================================
// retina display
// ================================================
$(document).ready(function() {
    $('img').retina();
});
// ================================================
// JQUERY (fancy) Script for the awesome fancybox 
// ==================================================
$(document).ready(function() {
    $(".fancybox").fancybox({
        helpers: {
            overlay: {
                locked: false
            }
        },
        padding: ['5px', '5px', '5px', '5px']
    });
});
// ================================================
// JQUERY nivo slider
// ================================================
$(window).load(function() {
    $('#slider').nivoSlider({
        effect: 'random', // Specify sets like: 'fold,fade,sliceDown'
        slices: 15, // For slice animations
        boxCols: 8, // For box animations
        boxRows: 4, // For box animations
        animSpeed: 500, // Slide transition speed
        pauseTime: 5000, // How long each slide will show
        startSlide: 0, // Set starting Slide (0 index)
        directionNav: true, // Next & Prev navigation
        controlNav: false, // 1,2,3... navigation
        controlNavThumbs: false, // Use thumbnails for Control Nav
        pauseOnHover: true, // Stop animation while hovering
        manualAdvance: false, // Force manual transitions
        prevText: '<i class="icon-angle-left"></i>', // Prev directionNav text
        nextText: '<i class="icon-angle-right"></i>', // Next directionNav text
        randomStart: false, // Start on a random slide
        beforeChange: function() {}, // Triggers before a slide transition
        afterChange: function() {}, // Triggers after a slide transition
        slideshowEnd: function() {}, // Triggers after all slides have been shown
        lastSlide: function() {}, // Triggers when last slide is shown
        afterLoad: function() {} // Triggers when slider has loaded
    });
});
// ================================================
// JQUERY Owl Carousel
// ================================================
$(document).ready(function() {
    var owl = $("#owl-demo");
    owl.owlCarousel({
        items: 6, //10 items above 1000px browser width
        navigation: false,
        pagination: false
    });
    // Custom Navigation Events
    $(".next").click(function() {
        owl.trigger('owl.next');
    })
    $(".prev").click(function() {
        owl.trigger('owl.prev');
    })
});
