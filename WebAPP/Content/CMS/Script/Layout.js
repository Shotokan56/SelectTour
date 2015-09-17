$(document).ready(function () {
    //message cuscess
    if (document.getElementById('Success').value == 'True') {
        $("#success-alert").fadeTo(500, 500).fadeOut(2000);
    }
});

$(function () {
    var match = document.cookie.match(new RegExp('color=([^;]+)'));
    if (match) var color = match[1];
    if (color) {
        $('body').removeClass(function (index, css) {
            return (css.match(/\btheme-\S+/g) || []).join(' ');
        });
        $('body').addClass('theme-' + color);
    }

    $('[data-popover="true"]').popover({ html: true });

});

$(function () {
    var uls = $('.sidebar-nav > ul > *').clone();
    uls.addClass('visible-xs');
    $('#main-menu').append(uls.clone());
});