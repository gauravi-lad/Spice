$(function () {
    $("#header").load("header.html");
    $("#footer").load("footer.html");
});

$('.info-slider').owlCarousel({
    autoplay: false,
    smartSpeed: 1000,
    nav: true,
    loop: true,
    dots: false,
    items: 4,
    margin: 0,
    responsive: {
        0: {
            items: 1,
            autoplay: true,
            loop: true,
        },
        360: {
            items: 1,
            autoplay: true,
            loop: true,
        },
        576: {
            items: 1,
            autoplay: true,
            loop: true,

        },
        768: {
            items: 1,
        },
        992: {
            items: 1,
        },
        1200: {
            items: 1,
        }
    }
});