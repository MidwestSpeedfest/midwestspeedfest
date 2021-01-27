var TimerEnd = new Date("21 February, 2021 23:59:59 CST").getTime();
var remaining = TimerEnd - new Date().getTime();

var swapLogoAndStream = function () {
    $("#NonTwitchContent").toggle();
    $("#omgWeAreLive").toggle();
}

//Run on document ready - see which elements to show
$(function() {
    if (remaining < 0) {
        swapLogoAndStream();
    } else {
        $("#NonTwitchContent").show();
        $('#countDown').show();
    }
});

if (remaining > 0) {
    var x = setInterval(function () {
        //Update remaining time
        var days = Math.floor(remaining / (1000 * 60 * 60 * 24));
        var hours = Math.floor((remaining % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((remaining % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((remaining % (1000 * 60)) / 1000);

        //Update display
        $("#day").html(days);
        $("#hour").html(hours);
        $("#minute").html(minutes);
        $("#second").html(seconds);

        //Hide countdown display and stop timer when expired
        if (remaining < 0) {
            clearInterval(x);
            $("#countDown").hide();
            swapLogoAndStream();
        }
        remaining -= 1000;
    }, 1000);
}


