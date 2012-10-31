$(document).ready(function ()
{
    $('#privacyLink').click(function (event)
    {
        event.preventDefault();

        var url = $(this).attr('href');

        $('#privacy').load(url);

    });
});

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
        }).error(function (e) {
            alert("error");
        });
    });
});