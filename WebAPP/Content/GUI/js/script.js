! function (a) {
    "use strict";
    var e = {
        Android: function () {
            return navigator.userAgent.match(/Android/i)
        },
        BlackBerry: function () {
            return navigator.userAgent.match(/BlackBerry/i)
        },
        iOS: function () {
            return navigator.userAgent.match(/iPhone|iPad|iPod/i)
        },
        Opera: function () {
            return navigator.userAgent.match(/Opera Mini/i)
        },
        Windows: function () {
            return navigator.userAgent.match(/IEMobile/i)
        },
        any: function () {
            return e.Android() || e.BlackBerry() || e.iOS() || e.Opera() || e.Windows()
        }
    };
    a(document).ready(function () {
        function n() {
            a("#bars").on("click", function () {
                return 0 == a(".navigation").hasClass("nav-active") && a(".navigation").addClass("nav-active"), a("body").css({
                    overflow: "hidden"
                }), !1
            }), a("#bars-close").on("click", function () {
                return a(".navigation").hasClass("nav-active") && a(".navigation").removeClass("nav-active"), a("body").css({
                    overflow: "visible"
                }), !1
            }), a(".nav-l").closest("body").find(".bars").css({
                left: "15px",
                right: "auto"
            }), a(".nav-l").closest("body").find("#header .logo").css("margin-left", "50px")
        }

        function t() {
            var e = a('input[type="search"], input[type="text"], input[type="url"], input[type="number"], input[type="email"], textarea');
            e.each(function () {
                var e = a(this).val();
                a(this).focus(function () {
                    a(this).val() === e && a(this).val("")
                }), a(this).blur(function () {
                    "" === a(this).val() && a(this).val(e)
                })
            })
        }

        function i() {
            a("#menu > li").each(function () {
                a(this).find("> ul").length && (a(this).append('<span><i class="fa fa-angle-down"></i></span>'), a(this).find("li").each(function () {
                    a(this).find("ul").length && a(this).append('<span><i class="fa fa-angle-right"></i></span>')
                }))
            }), a(".navigation ul li").each(function () {
                a(this).find("ul").length && a(this).addClass("menu-parent")
            })
        }

        function s() {
            var e = a(".navigation").data("menu-type"),
                n = window.innerWidth,
                t = a(".navigation"),
                i = a(".header");
            e > n ? (t.addClass("nav").removeClass("nav-desktop").closest(".header"), i.next().css("margin-top", 0), a(".bars, .bars-close, .logo-banner").show(), a(".navigation .sub-menu").each(function () {
                a(this).removeClass("left right")
            })) : (t.removeClass("nav").addClass("nav-desktop").closest(".header"), i.css("background-color", "#fff").find(".logo").css({
                opacity: "1",
                visibility: "visible"
            }), i.next().css("margin-top", 0), a(".bars, .bars-close, .logo-banner").hide(), a(".navigation .sub-menu").each(function () {
                var e = a(this).offset().left,
                    n = a(this).width(),
                    t = D - (e + n);
                60 > t ? a(this).removeClass("left").addClass("right") : a(this).removeClass("right"), 60 > e ? a(this).removeClass("right").addClass("left") : a(this).removeClass("left")
            }))
        }

        function o() {
            var e = a("#menu"),
                n = parseInt(e.attr("data-responsive"), 10),
                t = D,
                i = a(".header");
            e.length && (n > 0 ? n >= t ? i.length && 0 == i.hasClass("header-responsive") && i.addClass("header-responsive") : (i.length && 1 == i.hasClass("header-responsive") && a(".header").removeClass("header-responsive"), a(".menu-active").removeClass("menu-active")) : alert("false"))
        }

        function l() {
            a(".navigation.nav .menu-parent").on("click", " > a", function () {
                var e = a(this);
                return 0 == e.parent().hasClass("active") ? (e.parent("li").addClass("active"), e.parent().find(">ul").slideDown()) : (e.parent("li").removeClass("active"), e.parent("li").find(">ul").slideUp()), !1
            })
        }

        function r() {
            var e = a(".dropdown-cn");
            e.each(function (e, n) {
                var t = a(this),
                    i = t.find(".current > a").text();
                t.find(".dropdown-head").prepend(i)
            }), e.on("click", function (e) {
                a(this).toggleClass("open"), e.stopPropagation()
            }), a(document).click(function () {
                e.removeClass("open")
            })
        }

        function c() {
            a(".select select").change(function () {
                var e = a(this),
                    n = e.parent(".select").find("span"),
                    t = e.find("option:selected").text();
                n.text(t)
            })
        }

        function d() {
            a(".form-field .field-input").on("keydown", function () {
                var e = a(this).parent(".form-field").find("label");
                0 == e.hasClass("forcus") && e.addClass("focus")
            }).on("keyup", function () {
                var e = a(this),
                    n = e.parent(".form-field").find("label");
                "" != e.val() ? 0 == n.hasClass("forcus") && n.addClass("focus") : n.removeClass("focus")
            })
        }

        function h() {
            a(".calendar-input,.caneldar").datepicker({
                showOtherMonths: !0,
                selectOtherMonths: !0,
                dayNamesMin: ["Sun", "Mon", "Tue", "Wen", "Thu", "Fri", "Sta"]
            })
        }

        function u() {
            a("#banner-slide").length > 0 && a("#banner-slide").owlCarousel({
                autoPlay: 3500,
                navigation: !1,
                pagination: !1,
                singleItem: !0,
                mouseDrag: !1,
                touchDrag: !1,
                transitionStyle: "fade",
                afterInit: function (e) {
                    var n = e.closest(".banner").innerHeight();
                    e.find(".owl-item").each(function (e, t) {
                        var i = a(this).find(".banner-slide-item").data("src");
                        a(this).css({
                            "background-image": "url(" + i + ")",
                            height: n
                        })
                    })
                },
                beforeUpdate: function (a) {
                    var e = a.closest(".banner").innerHeight();
                    a.find(".owl-item").css("height", e)
                }
            })
        }

        function p() {
            e.any() ? (a(".banner-video-control").remove(), a("#banner-player").remove()) : a("#banner-player").length && (a("#banner-player").YTPlayer({
                containment: "#banner-video",
                showControls: !1,
                autoPlay: !1,
                mute: !0,
                startAt: 0,
                opacity: 1
            }), a(".icon-play").click(function (e) {
                a(this).hasClass("fa-play") ? (a("#banner-player").YTPPlay(), a(this).removeClass("fa-play").addClass("fa-pause")) : (a("#banner-player").YTPPause(), a(this).removeClass("fa-pause").addClass("fa-play"))
            }))
        }

        function g() {
            if (a("#owl-magazine-ds").length) {
                a("#owl-magazine-ds").owlCarousel({
                    autoPlay: !1,
                    slideSpeed: 500,
                    navigation: !1,
                    pagination: !1,
                    mouseDrag: !1,
                    addClassActive: !0,
                    singleItem: !0,
                    afterAction: function () {
                        var e = a("#magazine-thum");
                        e.find(".active").removeClass("active"), e.find(".thumnail-item").eq(this.currentItem).addClass("active")
                    }
                });
                var e = a("#owl-magazine-ds").data("owlCarousel");
                a("#magazine-thum").on("click", ".thumnail-item", function () {
                    var n = a(this);
                    if (0 == n.hasClass("active")) {
                        var t = a(this).index();
                        n.parent("#magazine-thum").find(".active").removeClass("active"), n.addClass("active"), e.goTo(t)
                    }
                })
            }
        }

        function f() {
            var e = a(window).scrollTop();
            e > 100 ? 0 == a("#header").hasClass("header-stick") && (a("#header").addClass("header-stick"), a(".navigation.nav").closest("body").find("#header").find(".logo").css({
                opacity: "1",
                visibility: "visible"
            })) : (a("#header").removeClass("header-stick"), a(".navigation.nav").closest("body").find("#header").css("background-color", "transparent").find(".logo").css({
                opacity: "0",
                visibility: "hidden"
            }))
        }

        function m() {
            a(".price-slider").length && a(".price-slider").slider({
                min: 0,
                max: 1500,
                step: 1,
                range: !0,
                create: function (e, n) {
                    var t = a(this),
                        i = a(this).find(".range").attr("value").split(",");
                    t.slider("values", i), t.prepend("<label class='label-min'>$" + i[0] + "</label>"), t.append("<label class='label-max'>$" + i[1] + "</label>")
                },
                slide: function (e, n) {
                    var t = a(this),
                        i = n.values;
                    t.find(".label-min").text("$" + i[0]), t.find(".label-max").text("$" + i[1]), t.find(".range").attr("value", i)
                }
            })
        }

        function v() {
            a(".time-slider").length && a(".time-slider").slider({
                min: 0,
                max: 1440,
                step: 1,
                create: function (e, n) {
                    var t = a(this),
                        i = parseInt(t.attr("data-start"), 10),
                        s = parseInt(t.attr("data-end"), 10),
                        o = Math.floor(i / 60);
                    if (0 == isNaN(s)) {
                        t.slider("option", "range", !0), t.slider("values", [i, s]);
                        var l = Math.floor(s / 60),
                            r = b(l, s - 60 * l, !0),
                            c = b(o, i - 60 * o, !0);
                        t.prepend("<label class='label-min'>" + c + "</label>"), t.append("<label class='label-max'>" + r + "</label>"), t.find(".range").attr("value", c + "," + r)
                    } else {
                        var c = b(o, i - 60 * o, !1);
                        t.slider("value", i), t.slider("option", "range", "min"), t.append("<label class='label-max'>" + c + "</label>"), t.find(".range").attr("value", c)
                    }
                },
                slide: function (e, n) {
                    var t, i, s, o, l, r = a(this),
                        c = r.slider("option", "range");
                    1 == c ? (t = n.values, i = Math.floor(t[0] / 60), s = Math.floor(t[1] / 60), o = b(i, t[0] - 60 * i, !0), l = b(s, t[1] - 60 * s, !0), r.find(".label-min").text(o), r.find(".label-max").text(l), r.find(".range").attr("value", o + "," + l)) : (t = n.value, i = Math.floor(t / 60), o = b(i, t - 60 * i, !1), r.find(".label-max").text(o), r.find(".range").attr("value", o))
                }
            })
        }

        function b(a, e, n) {
            var t, i = a,
                s = e,
                o = "";
            return 1 == n ? (1 == i.length && (i = "0" + i), 10 > s && (s = "0" + s), 0 == s && (s = "00"), i >= 12 ? 12 == i ? (i = i, s = s, o = " PM") : (i -= 12, s = s, o = " PM", 12 == i && 0 == s && (i = 11, s = 59)) : (i = i, s = s, o = " AM"), 0 == i && (i = 12, s = s, o = " AM"), t = i + ":" + s + o) : (24 == i && 0 == s && (i = 23, s = "59"), 10 > s && (s = "0" + s), o = "m", t = i + "h " + s + o), t
        }

        function y() {
            var e = a("#slide-room-lg"),
                n = a("#slide-room-sm");
            e.owlCarousel({
                singleItem: !0,
                autoPlay: !1,
                navigation: !1,
                pagination: !1
            }), n.owlCarousel({
                mouseDrag: !1,
                navigation: !0,
                navigationText: ["<span class='prev-next-room prev-room'></span>", "<span class='prev-next-room next-room'></span>"],
                itemsCustom: [
                    [320, 3],
                    [480, 5],
                    [768, 6],
                    [992, 7],
                    [1200, 8]
                ],
                pagination: !1
            }), a("#slide-room-sm").on("click", ".owl-item", function (n) {
                if (n.preventDefault(), a(this).hasClass("synced")) return !1;
                a(".synced").removeClass("synced"), a(this).addClass("synced");
                var t = a(this).data("owlItem");
                e.data("owlCarousel").goTo(t)
            })
        }

        function w() {
            a(".progress-rv").each(function (e, n) {
                var t = a(this).attr("data-value"),
                    i = 10 * t;
                a(this).append("<div style='width:" + i + "%'><span>" + t + "</span></div>")
            })
        }

        function C() {
            a(".post-slide").length > 0 && a(".post-slide").owlCarousel({
                autoPlay: 8e3,
                slideSpeed: 1e3,
                navigation: !0,
                pagination: !1,
                singleItem: !0,
                autoHeight: !0,
                transitionStyle: "fade",
                navigationText: ["<i class='fa  fa-angle-left'></i>", "<i class='fa  fa-angle-right'></i>"]
            })
        }

        function x() {
            a(".page-slide").length > 0 && a(".page-slide").owlCarousel({
                autoPlay: 1e4,
                slideSpeed: 1e3,
                navigation: !1,
                pagination: !0,
                singleItem: !0,
                autoHeight: !0,
                navigationText: ["<i class='fa  fa-angle-left'></i>", "<i class='fa  fa-angle-right'></i>"]
            })
        }

        function k() {
            a(".table-radio tbody tr").on("click", function () {
                var e = a(this);
                0 == e.hasClass("warning") && (e.parents(".table-radio").find(".warning").removeClass("warning"), e.addClass("warning"), e.find(".radio").prop("checked", !0))
            })
        }

        function M() {
            a(".scroll-table").length && (e.any() || a(".scroll-table").niceScroll({
                touchbehavior: !1,
                background: "#e2e2e2",
                cursoropacitymin: 1,
                cursorcolor: "#141414",
                ursoropacitymax: .6,
                cursorwidth: 5,
                cursorborder: "0px solid #fff",
                railalign: "right"
            }))
        }

        function P() {
            if (D >= 1200) {
                var e = a(window).scrollTop(),
                    n = a("#header").outerHeight();
                a(".detail-cn").each(function (t, i) {
                    var s = a(this),
                        o = s.offset().top,
                        l = s.outerHeight(),
                        r = s.find(".scroll-heading"),
                        c = r.outerHeight(),
                        d = e - o + n;
                    d > 0 && l - d >= 0 && l - c > d ? r.css({
                        position: "fixed",
                        top: +n + "px"
                    }) : r.css({
                        position: "static"
                    })
                }), a(".scroll-heading a").on("click", function () {
                    var e = a(this).attr("href");
                    return a("html, body").stop().animate({
                        scrollTop: a(e).offset().top - 70
                    }, 1e3), !1
                })
            }
        }

        function I() {
            a(".bar-cl .fill").each(function () {
                var e = a(this),
                    n = e.attr("data-price"),
                    t = n / 600 * 100;
                e.css({
                    height: t + "%"
                })
            }), a(".ul-bar li").on("click", ".bar-cl", function () {
                a(this).parents(".ul-bar").find(".active").removeClass("active"), a(this).parents("li").addClass("active")
            })
        }

        function A() {
            e.any() ? a(".bg-parallax").removeClass("bg-parallax").addClass("bg-scroll") : a(".bg-parallax").length && a(".bg-parallax").each(function () {
                a(this).parallax("50%", .1)
            })
        }

        function T() {
            if (a("#hotel-maps").length) {
                var e, n = new google.maps.LatLngBounds,
                    t = {
                        zoom: 16,
                        scrollwheel: !1,
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    };
                e = new google.maps.Map(document.getElementById("hotel-maps"), t);
                var i, s, o = [
                        ["Bondi Beach", 41.0237, -73.701239],
                        ["Coogee Beach", 41.005615, -73.69566551],
                        ["Cronulla Beach", 40.9756737, -73.65614],
                        ["Manly Beach", 40.973478, -73.8433],
                        ["Maroubra Beach", 41.04579, -73.7464],
                        ["Maroubra Beach", 41.0563, -73.75618],
                        ["Maroubra Beach", 40.9442, -73.8554]
                ],
                    l = [
                        ["                                        <div class='maps-item'>                                            <a href='#' class='maps-image'>                                                <img src='images/hotel/img-10.jpg' alt=''>                                            </a>                                            <div class='maps-text'>                                                <h2><a href='#'>The Cosmopolitan</a></h2>                                                <span>                                                    <i class='glyphicon glyphicon-star'></i>                                                    <i class='glyphicon glyphicon-star'></i>                                                    <i class='glyphicon glyphicon-star'></i>                                                    <i class='glyphicon glyphicon-star'></i>                                                    <i class='glyphicon glyphicon-star'></i>                                                </span>                                                <address>Great Cumberland Place, London W1H 7DL</address>                                                <p>My stay at cumberland hotel was amazing, loved the location, was close to all the major attraction.. <a href=''>view all 125 reviews</a>                                                </p>                                                <hr class='hr'>                                                <span class='price'>From-<ins>$345</ins>/night</span>                                            </div>                                        </div>                                    "]
                    ],
                    r = new google.maps.InfoWindow({
                        maxWidth: 600
                    }),
                    c = "images/icon-maker.png";
                for (s = 0; s < o.length; s++) {
                    var d = o[s],
                        h = new google.maps.LatLng(d[1], d[2]);
                    n.extend(h), i = new google.maps.Marker({
                        position: h,
                        map: e,
                        icon: c,
                        title: d[0]
                    }), google.maps.event.addListener(i, "click", function (a, n) {
                        return function () {
                            r.setContent(l[0][0]), r.open(e, a)
                        }
                    }(i, s)), e.fitBounds(n)
                }
            }
        }

        function B() {
            if (a("#contact-maps").length) {
                var e = a("#contact-maps"),
                    n = e.data("map-zoom"),
                    t = e.data("map-latlng").split(",")[0],
                    i = e.data("map-latlng").split(",")[1],
                    s = e.data("map-content"),
                    o = new google.maps.LatLng(t, i),
                    l = {
                        center: o,
                        zoom: n,
                        scrollwheel: !1,
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    },
                    r = new google.maps.Map(document.getElementById("contact-maps"), l),
                    c = new google.maps.Marker({
                        position: o
                    });
                c.setMap(r);
                var d = new google.maps.InfoWindow({
                    content: s,
                    maxWidth: 200
                });
                google.maps.event.addListener(c, "click", function () {
                    d.open(r, c)
                })
            }
        }

        function z() {
            if (a("#hotel-detail-map").length) {
                var e = a("#hotel-detail-map"),
                    n = e.data("latlng").split(",")[0],
                    t = e.data("latlng").split(",")[1],
                    i = new google.maps.LatLng(n, t),
                    s = {
                        center: i,
                        zoom: 15,
                        scrollwheel: !1,
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    };
                new google.maps.Map(document.getElementById("hotel-detail-map"), s)
            }
        }

        function S() {
            a("#contact-form").length > 0 && a("#contact-form").validate({
                rules: {
                    name: {
                        required: !0,
                        minlength: 2
                    },
                    email: {
                        required: !0,
                        email: !0
                    },
                    message: {
                        required: !0,
                        minlength: 10
                    }
                },
                messages: {
                    name: {
                        required: "Please enter your first name.",
                        minlength: a.format("At least {0} characters required.")
                    },
                    email: {
                        required: "Please enter your email.",
                        email: "Please enter a valid email."
                    },
                    message: {
                        required: "Please enter a message.",
                        minlength: a.format("At least {0} characters required.")
                    }
                },
                submitHandler: function (e) {
                    return a("#submit-contact").html("Sending..."), a(e).ajaxSubmit({
                        success: function (e, n, t, i) {
                            a("#contact-content").slideUp(600, function () {
                                a("#contact-content").html(e).slideDown(600), a(".submit-contact").html("Submit")
                            })
                        }
                    }), !1
                }
            })
        }

        function L() {
            a(".a-popup-room").length && a(".a-popup-room").magnificPopup({
                type: "ajax",
                mainClass: "mfp-fade"
            })
        }
        var D = a(window).width();
        t(), n(), o(), r(), c(), d(), h(), g(), m(), v(), y(), M(), I(), w(), C(), x(), k(), T(), z(), B(), S(), L(), a(window).load(function (e) {
            a("#preloader").fadeOut(1e3), s(), f(), u(), p(), i(), l(), A()
        }), a(window).resize(function (a) {
            s(), o()
        }), a(window).scroll(function (a) {
            f(), P()
        }), a(window).on("load resize", function () {
            var e = a(window).height();
            a(".page-not-found, .page-comingsoon").css("min-height", e);
            var n = a(".navigation").data("menu-type"),
                t = window.innerWidth,
                i = a(window).scrollTop();
            n > t && 100 > i && a(".header").css("background-color", "transparent").find(".logo").css({
                opacity: "0",
                visibility: "hidden"
            })
        })
    })
}(jQuery);