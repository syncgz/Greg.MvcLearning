//********************************************************************************************************************************************
// Wywolanie funkcj GET i pobranie danych w formacie JSON.
//********************************************************************************************************************************************
// Przerabianie danych otrzymanych z servera - recznie.
//-----------------------------------------------------------------------------------------------------------------------------------------
$(document).ready(function ()
{
    $('#testA').bind('click', function (event)
    {
        alert("click");
        event.preventDefault();
        
        

        $.get("/Json/JsonAuction/10", function (result)
        {
            debugger;
            $('#Id').html(result.Id);
            $('#Name').html(result.Name);
            
        }).error(function (err)
        {
            alert("err" + err);
        });
    });
});

//********************************************************************************************************************************************
// Wywolanie funkcj POST.
//********************************************************************************************************************************************
// Wyslanie danych do servera.
//-----------------------------------------------------------------------------------------------------------------------------------------
$(document).ready(function () {
    $('#testA').bind('click', function (event) {
        alert("click");
        event.preventDefault();

        var person =
            {
                "Id": "2",
                "Name": "PersonName"
            };

        $.post('/Json/JsonAuction', person).success(function () {
            alert("Success");
        });
    });
});

