
$(document).ready(function () {
    
    //Days between 1/1/2017 and the current date
    console.log("Days between 1/1/2017 and the current date");

    const start = new Date("2017-01-01");
    const today = new Date();  
    const days = Math.floor((today - start)/1000/60/60/24);

    console.log(days + " days");

    var dateOptions = {year: 'numeric', month: 'numeric', day: 'numeric'};    
    var timeOptions = {hour: 'numeric', minute: 'numeric', second: 'numeric', hour12: true};

    function dtformatter(options, value, locales = 'en-US') {          
        return new Intl.DateTimeFormat(locales, options).format(value); 
    }

    console.log("Current Date and Time");
    console.log(dtformatter(dateOptions, today) + " " + dtformatter(timeOptions, today)); 

});