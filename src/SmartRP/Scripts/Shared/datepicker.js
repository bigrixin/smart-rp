jQuery(function ($) {
    // format date
    var currentTime = new Date();
    var currentMonth = currentTime.getMonth();
    var currentDate = currentTime.getDate();
    var currentYear = currentTime.getFullYear();

    $('input[type=datetime]').datepicker({
        dateFormat: "dd/M/yy",
        changeMonth: true,
        changeYear: true,
        minDate: new Date(currentYear, currentMonth, currentDate)
    });
});