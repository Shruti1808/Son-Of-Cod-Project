//jQuery.fn.extend({
//    listrap: function () {
//        var listrap = this;
//        listrap.getSelection = function () {
//            var selection = new Array();
//            listrap.children("li.active").each(function (ix, el) {
//                selection.push($(el)[0]);
//            });
//            return selection;
//        }
//        var toggle = "li .listrap-toggle ";
//        var selectionChanged = function () {
//            $(this).parent().parent().toggleClass("active");
//            listrap.trigger("selection-changed", [listrap.getSelection()]);
//        }
//        $(listrap).find(toggle + "img").on("click", selectionChanged);
//        $(listrap).find(toggle + "span").on("click", selectionChanged);
//        return listrap;
//    }
//});
//$(document).ready(function () {
//    $(".listrap").listrap().on("selection-changed", function (event, selection) {
//        console.log(selection);
//    });
//});

$(document).ready(function () {
    $('#myCarousel').carousel({
        interval: 4000
    });

    var clickEvent = false;
    $('#myCarousel').on('click', '.nav a', function () {
        clickEvent = true;
        $('.nav li').removeClass('active');
        $(this).parent().addClass('active');
    }).on('slid.bs.carousel', function (e) {
        if (!clickEvent) {
            var count = $('.nav').children().length - 1;
            var current = $('.nav li.active');
            current.removeClass('active').next().addClass('active');
            var id = parseInt(current.data('slide-to'));
            if (count == id) {
                $('.nav li').first().addClass('active');
            }
        }
        clickEvent = false;
    });
});