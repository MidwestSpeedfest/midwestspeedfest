var marathonStart = new Date("aug 27, 2020 11:00:00").getTime();

var x = setInterval(function () {
    //Update remaining time
    var remaining = marathonStart - new Date().getTime();
    var days = Math.floor(remaining / (1000 * 60 * 60 * 24));
    var hours = Math.floor((remaining%(1000 * 60 * 60 * 24))/(1000 * 60 * 60));
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
    }
}, 1000);