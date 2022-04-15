
$(document).ready(function () {

    $('.datepicker').datepicker({
        format: 'mm-dd-yyyy'
    });

    var url = $(location).attr('href'),
    parts = url.split("/"),
    last_part = parts[parts.length - 2];

    var company_id = 1;

    var afterlastslash = window.location.href.substring(window.location.href.lastIndexOf('/') + 1);

    if (last_part.toLowerCase() === 'index') {
        if (!isNaN(afterlastslash) && afterlastslash) {
            company_id = parseInt(afterlastslash);
        }
    }

    //Note ajax call to new nodejs project so run node api.js if using 'http://localhost:8090/api/companyorders/' + company_id,
    var $orders = $('#orders');
    $.ajax({
        'url': '/api/order/' + company_id,  // 'http://localhost:8090/api/companyorders/' + company_id, // 
        'type': 'GET',
        headers: { "Authorization": "demo Token" },

        'success': function (data) {

            var $orderList = $('<ul/>');

            if (data) {
                
                var json_data = JSON.parse(data);
                
                if (json_data.Company.isinDatabase) {
                    $('#companyname').append(json_data.Company.CompanyName);
                    //_companyOrders
                    $('#OrderReport').append("<a href='" + json_data.ReportFile + "' target='_blank'>Company Order Report File" + "</a>");
                }
                else {
                    $('#companyOrders').hide();
                    $('#companyOrdersAlert').html('[Error: ' + json_data.Company.ErrorMessage + ']').show();

                }

                var formatter = new Intl.NumberFormat('en-US', {
                    style: 'currency',
                    currency: 'USD',
                    maximumFractionDigits: 2,
                });

                var $template = $(".template");
                
                if (json_data.Orders != undefined) {
                    $.each(json_data.Orders,
                        function (i) {

                            var $newPanel = $template.clone();

                            $newPanel.find(".collapse").removeClass("in");
                            $newPanel.find(".accordion-toggle").attr("href", "#" + (i))
                                     .text(this.Description + ' (Total: ' + formatter.format(this.OrderTotal) + ')');

                            var $li = $('<li/>').text(this.Description + ' (Total: ' + formatter.format(this.OrderTotal) + ')')
                                .appendTo($orderList);

                            var $productList = $('<ul/>');


                            $.each(this.OrderProducts, function (j) {
                                var $li2 = $('<li/>').text(this.Product.Name + ' (' + this.Quantity + ' @ ' + formatter.format(this.Price) + '/ea)')
                                    .appendTo($productList);
                            });


                            $newPanel.find(".panel-body").html($productList);

                            $newPanel.find(".panel-collapse").attr("id", i).addClass("collapse").removeClass("in");
                            $("#accordion").append($newPanel.fadeIn());

                        });
                }

                $('#accordion .collapse').collapse('show');
                

            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);

            $('#companyOrders').hide();
            $('#companyOrdersAlert').html('[Error: ' + errorThrown + ']').show();
        }
    });
       

});


function FindSearchForm() {
    var strdpdate = "";  // 01/01/2013
    var jsDate = $('.datepicker').datepicker('getDate');
    if (jsDate !== null) { // if any date selected in datepicker
        jsDate instanceof Date; // -> true

        strdpdate = (jsDate.getMonth() + 1) + "-" + jsDate.getDate() + "-" + jsDate.getFullYear();
        
        //var $orders = $('#orders');
        $.ajax({
            type: 'GET',
            headers: { "Authorization": "demo Token" },
            url: '/api/order/GetPersonOrders/' + strdpdate, // JSON.stringify(jsDate),

            success: function (data) {

                var $orderList = $('<ul/>');

                if (data) {

                    var json_data = JSON.parse(data);
                    console.log(json_data);
                    console.log(json_data.length);

                    if (json_data.length > 0) {  //.Company.isinDatabase
                        //$('#companyname').append(json_data.Company.CompanyName);
                        $('#personOrders').show();
                        $('#personOrdersAlert').html('').hide();                        
                    }
                    else {
                        //$('#companyOrders').hide();
                        //$('#companyOrdersAlert').html('[Error: ' + json_data.Company.ErrorMessage + ']').show();
                        $('#personOrders').hide();
                        $('#personOrdersAlert').html('No Person Orders for that date.').show();
                    }
                    
                    //[{"PersonId":1,"NameFirst":"James","NameLast":"Doe"}]

                    var $template = $(".templatePerson").first();

                    $("#accordionPerson").html('');
                    $("#accordionPerson").html($template.clone());

                    $.each(json_data,
                        function (i) {
                            var $newPanel = $template.clone();
                            //alert(this.PersonId);
                            $newPanel.find(".collapse").removeClass("in");
                            $newPanel.find(".accordion-toggle").attr("href", "#Person" + (i))
                                .text('' + this.PersonId + ' : ' + this.NameFirst + ' : ' + this.NameLast);

                            //.text('PersonId:' + this.PersonId + ' First Name: ' + this.NameFirst + ' Last Name: ' + this.NameLast);

                            //var $li = $('<li/>').text(this.PersonId + ' ').appendTo($orderList);

                            //var $productList = $('<ul/>');

                            /*                 
                            $.each(this.OrderProducts, function (j) {
                                var $li2 = $('<li/>').text(this.Product.Name + ' (' + this.Quantity + ' @ ' + formatter.format(this.Price) + '/ea)')
                                    .appendTo($productList);
                            });
                            */

                            //alert(this.PersonId);

                            //$newPanel.find(".panel-body").html($productList);

                            $newPanel.find(".panel-collapse").attr("id", 'Person' + i).addClass("collapse").removeClass("in");
                            $("#accordionPerson").append($newPanel.fadeIn());

                        });


                    $('#accordionPerson .collapse').collapse('show');

                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
                console.log(textStatus);
                console.log(errorThrown);

                //$('#companyOrders').hide();
                //$('#companyOrdersAlert').html('[Error: ' + errorThrown + ']').show();
            }
        });

    }

}