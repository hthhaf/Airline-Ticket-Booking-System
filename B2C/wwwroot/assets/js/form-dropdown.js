var qadult = 1;
var qchild = 0;
var qinfant = 0;

function addValue() {
    const sum = qadult + qchild + qinfant
    $('.final-count').val(`${sum}`);

    $('.qstring').text(`${qadult} Adults - ${qchild} Childs - ${qinfant} Infants`);
}

addValue()

$('.btn-add').on('click touchstart', function () {
    const value = ++qadult;
    $('.pcount').text(`${value}`);
    addValue();
    event.stopPropagation();
    event.preventDefault();
});


$('.btn-subtract').on('click touchstart', function () {
    if (qadult == 1) {
        $('.pcount').text(1);
        addValue();
    } else {
        const value = --qadult;
        $('.pcount').text(`${value}`);
        addValue();
    }
    event.stopPropagation();
    event.preventDefault();
});


$('.btn-add-c').on('click touchstart', function () {
    const value = ++qchild;
    $('.ccount').text(`${value}`);
    addValue();
    event.stopPropagation();
    event.preventDefault();
});


$('.btn-subtract-c').on('click touchstart', function () {
    if (qchild == 0) {
        $('.ccount').text(0);
        addValue();
    } else {
        const value = --qchild;
        $('.ccount').text(`${value}`);
        addValue();
    }
    event.stopPropagation();
    event.preventDefault();
});



$('.btn-add-in').on('click touchstart', function () {
    const value = ++qinfant;
    $('.incount').text(`${value}`);
    addValue();
    event.stopPropagation();
    event.preventDefault();
});


$('.btn-subtract-in').on('click touchstart', function () {
    if (qinfant == 0) {
        $('.incount').text(0);
        addValue();
    } else {
        const value = --qinfant;
        $('.incount').text(`${value}`);
        addValue();
    }
    event.stopPropagation();
    event.preventDefault();
});




$('#search-oneway').on('click', function () {
    var DepartureCode = $('#form-oneway #DepartureCode').val();
    var ArrivalCode = $('#form-oneway #ArrivalCode').val();
    var DepartureDate = $('#form-oneway #DepartureDate').val();
    var Passenger = $('#form-oneway #Passenger').val();
    var Adult = qadult;
    var Children = qchild;
    var Type = "Oneway";

    var href = "/Flight/List?departure=" + DepartureCode;
    href += "&arrival=" + ArrivalCode;
    href += "&departureDate=" + DepartureDate;
    href += "&passenger=" + Passenger
    href += "&adult=" + Adult;
    href += "&children=" + Children;
    href += "&type=" + Type;
    

    window.location = href;

    $.ajax({
        type: 'GET',
        url: '/Flight/List',
        data: {
            departure: DepartureCode,
            arrival: ArrivalCode,
            departureDate: DepartureDate,
            passenger: Passenger,
            adult: Adult,
            children: Children,
            typeof: Type
        },
        success: function (data) {
            
        },
        error: function (error) {
           
            console.error(error);
        }
    });
})

$('#search-booking').on('click', function () {
    var PNR = $('#form-booking #PNR').val();
    var LastName = $('#form-booking #lastName').val();
    

    var href = "/Flight/MyBooking?pnr=" + PNR;
    href += "&lastName=" + LastName;
    
    window.location = href;

    $.ajax({
        type: 'GET',
        url: '/Flight/Booking',
        data: {
            pnr: PNR,
            lastName: LastName,
 
        },
        success: function (data) {

        },
        error: function (error) {

            console.error(error);
        }
    });
})

$('#search-roundtrip').on('click', function () {
    var DepartureCode = $('#form-roundtrip #DepartureRound').val();
    var ArrivalCode = $('#form-roundtrip #ArrivalRound').val();
    var DepartureDate = $('#form-roundtrip #DepartureDateRou').val();
    var returnDate = $('#form-roundtrip #return').val();
    var Passenger = $('#form-roundtrip #Pax').val();
    var Adult = qadult;
    var Children = qchild;
    var Type = "Roundtrip";

    var href = "/Flight/Roundtrip?departure=" + DepartureCode;
    href += "&arrival=" + ArrivalCode;
    href += "&departureDate=" + DepartureDate;
    href += "&returnDate=" + returnDate;
    href += "&passenger=" + Passenger;
    href += "&adult=" + Adult;
    href += "&children=" + Children;
    href += "&type=" + Type;


    window.location = href;

    $.ajax({
        type: 'GET',
        url: '/Flight/Roundtrip',
        data: {
            departure: DepartureCode,
            arrival: ArrivalCode,
            departureDate: DepartureDate,
            arrival: ArrivalDate,
            passenger: Passenger,
            adult: Adult,
            children: Children,
            typeof: Type
        },
        success: function (data) {

        },
        error: function (error) {

            console.error(error);
        }
    });
})




$(document).ready(function () {
    $('.cabin-list button').click(function (event) {
        event.stopPropagation();
        event.preventDefault();
        $('.cabin-list button.active').removeClass("active");
        $(this).addClass("active");
    });


    $('#ArrivalCode').change(function () {
        var selectedOption = $(this).find('option:selected');
        var selectedCode = selectedOption.val();
        var selectedName = selectedOption.data('name');
        var combinedValue = selectedCode + ' - ' + selectedName;
        $('#selectedArrivalCode').text(combinedValue);
    });

    $('#DepartureCode').change(function () {
        var selectedOption = $(this).find('option:selected');
        var selectedCode = selectedOption.val();
        var selectedName = selectedOption.data('name');
        var combinedValue = selectedCode + ' - ' + selectedName;
        $('#selectedDepartureCode').text(combinedValue);
    });

    $('#DepartureDate').change(function () {
        var selectedDate = new Date($(this).val());
        var dayOfWeek = getDayOfWeek(selectedDate);
        $('#dayOfWeek').text(dayOfWeek);
    });


    $('#DepartureDateRou').change(function () {
        var selectedDate = new Date($(this).val());
        var dayOfWeek = getDayOfWeek(selectedDate);
        $('#DepartureDateRoundtrip').text(dayOfWeek);
    });

    $('#return').change(function () {
        var selectedDate = new Date($(this).val());
        var dayOfWeek = getDayOfWeek(selectedDate);
        $('#returnDate').text(dayOfWeek);
    });

    function getDayOfWeek(date) {
        const daysOfWeek = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
        return daysOfWeek[date.getDay()];
    }

    var returndate = new Date($("#return").val());
    $("#returnDate").text(getDayOfWeek(returndate));

    var returndateRou = new Date($("#DepartureDateRou").val());
    $("#DepartureDateRoundtrip").text(getDayOfWeek(returndateRou));

    var initialDate = new Date($("#DepartureDate").val());
    var initialDayOfWeek = getDayOfWeek(initialDate);
    $("#dayOfWeek").text(initialDayOfWeek);
    
    var initialArrival = $('#ArrivalCode option:selected');
    $('#selectedArrivalCode').text(initialArrival.val() + ' - ' + initialArrival.data('name'));

    var initialDeparture = $('#DepartureCode option:selected');
    $('#selectedDepartureCode').text(initialDeparture.val() + ' - ' + initialDeparture.data('name'));

    var initialArr = $('#ArrivalRound option:selected');
    $('#selectedArr').text(initialArr.val() + ' - ' + initialArr.data('name'));

    var initialDep = $('#DepartureRound option:selected');
    $('#selectedDep').text(initialDep.val() + ' - ' + initialDep.data('name'));

    $('#ArrivalRound').change(function () {
        var selectedOption = $(this).find('option:selected');
        var selectedCode = selectedOption.val();
        var selectedName = selectedOption.data('name');
        var combinedValue = selectedCode + ' - ' + selectedName;
        $('#selectedArr').text(combinedValue);
    });

    $('#DepartureRound').change(function () {
        var selectedOption = $(this).find('option:selected');
        var selectedCode = selectedOption.val();
        var selectedName = selectedOption.data('name');
        var combinedValue = selectedCode + ' - ' + selectedName;
        $('#selectedDep').text(combinedValue);
    });
});

