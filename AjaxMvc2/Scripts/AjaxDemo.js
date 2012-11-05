//********************************************************************************************************************************************
// Uzycie funkcji $('').LOAD - pobranie elementu z servera(GET) - pobranie danych HTML
//********************************************************************************************************************************************
// Funkcja load automatyzuje pobranie elementu z servera i wstawienie elementu w odpowiednie miejsce(odpowiedni np <div>)
//-----------------------------------------------------------------------------------------------------------------------------------------
$(document).ready(function ()
{
    $('#privacyLink').click(function (event)
    {
        event.preventDefault();

        var url = $(this).attr('href');

        $('#privacy').load(url);

    });
});

//********************************************************************************************************************************************
// Uzycie funkcji $('').POST - wyslanie elementow do servera(POST) - pobranie danych HTML
//********************************************************************************************************************************************
// 
//-----------------------------------------------------------------------------------------------------------------------------------------
$(document).ready(function ()
{
    $('#commentForm').submit(function (event)
    {
        event.preventDefault();

        var data = $(this).serialize();

        var url = $(this).attr('action');

        $.post(url, data, function (response)
        {
            $('#comments').append(response);
        }).error(function (e)
        {
            alert("error");
        });
    });
});

//********************************************************************************************************************************************
// Uzycie funkcji $.GET - pobranie asynchroniczne(GET) - pobranie danych HTML
//********************************************************************************************************************************************
// 
//-----------------------------------------------------------------------------------------------------------------------------------------
$(document).ready(function ()
{
    $('#testLink').click(function (event) {
        event.preventDefault();

        var url = $(this).attr('href');

        $.get(url, function (data)
        {
            //wstawienie pobranych danych w element id='test'
            //$('#testDiv').html(data);
            
            //dopisanie do konca elementu pobranych danych
            $('#testDiv').append(data);
        });
    });
});

