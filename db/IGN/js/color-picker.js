    (function($) {
        "use strict";
        // With the element initially hidden, we can show it slowly:
        $("#open-cp").click(function() {
            $("#cp").fadeIn();
        });

        $("#close-cp").click(function() {
            $(this).closest("#cp").fadeOut();
        });

        $(".orange").click(function() {
            $("#color-style").attr("href", "css/styles.css");
            return false;
        });

        $(".green").click(function() {
            $("#color-style").attr("href", "css/colors/green.css");
            return false;
        });

        $(".blue").click(function() {
            $("#color-style").attr("href", "css/colors/blue.css");
            return false;
        });

        $(".purple").click(function() {
            $("#color-style").attr("href", "css/colors/purple.css");
            return false;
        });


    }(jQuery));
