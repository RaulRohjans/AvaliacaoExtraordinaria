! function (e) {
    var n = {};

    function t(o) {
        if (n[o]) return n[o].exports;
        var r = n[o] = {
            i: o,
            l: !1,
            exports: {}
        };
        return e[o].call(r.exports, r, r.exports, t), r.l = !0, r.exports
    }
    t.m = e, t.c = n, t.d = function (e, n, o) {
        t.o(e, n) || Object.defineProperty(e, n, {
            enumerable: !0,
            get: o
        })
    }, t.r = function (e) {
        "undefined" != typeof Symbol && Symbol.toStringTag && Object.defineProperty(e, Symbol.toStringTag, {
            value: "Module"
        }), Object.defineProperty(e, "__esModule", {
            value: !0
        })
    }, t.t = function (e, n) {
        if (1 & n && (e = t(e)), 8 & n)
            return e;

        if (4 & n && "object" == typeof e && e && e.__esModule)
            return e;

        var o = Object.create(null);
        if (t.r(o), Object.defineProperty(o, "default", {
            enumerable: !0,
            value: e
        }), 2 & n && "string" != typeof e)
            for (var r in e) t.d(o, r, function (n) {
                return e[n]
            }.bind(null, r));
        return o
    }, t.n = function (e) {
        var n = e && e.__esModule ? function () {
            return e.default
        } : function () {
            return e
        };
        return t.d(n, "a", n), n
    }, t.o = function (e, n) {
        return Object.prototype.hasOwnProperty.call(e, n)
    }, t.p = "/", t(t.s = 0)
}([function (e, n, t) {
    t(1), e.exports = t(2)
}, function (e, n) {
    $(() => {
        $("#version").text("v1.1.0");
        const e = new PerfectScrollbar(".menubar-body", {
            suppressScrollX: !0
        });
        $('.menu-link[data-toggle="collapse"]').on("click", (function (n) {
            e.update()
        })), $(".perfect-scrollbar").length && new PerfectScrollbar(".perfect-scrollbar", {
            suppressScrollX: !0
        }), $("#navbar-toggler").on("click", (function () {
            $("body").toggleClass("menubar-collapsed"), $("body").hasClass("menubar-collapsed") ? $(".menubar").on("mouseover").hover((function () {
                //$("body").toggleClass("menubar-collapsed")
            })) : $(".menubar").unbind()
        })), $("a[data-toggle=collapse]").on("click", (function () {
            $(this).toggleClass("active")
        })), $("#modal-code").on("show.bs.modal", (function (e) {
            var n = $(e.relatedTarget),
                t = $(n.data("content")).clone().html();
            $(this).find(".modal-body").html(t)
        }))
    })
}, function (e, n, t) { }]);