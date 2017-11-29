$("#submitButton").click(search);

function search()
{
    var query = $("#searchTerm").val().replace(/[\u2000-\u206F\u2E00-\u2E7F\\'!"#$%&()*+,\-.\/:;<=>?@\[\]^_`{|}~]/, "").replace(/\s+/g, "+");
    var limit = $("#resultNum").val();

    var source = "search?q=" + query + "&limit=" + limit;
    console.log(source);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayResults,
        error: errorOnAjax
    });
}

function displayResults(results)
{
    var limit = $("#resultNum").val();

    $("#searchResults").empty();
    $("#searchResults").append(displayGifs(results, limit));
}

function displayGifs(results, limit)
{
    "use strict";
    var resultContainer = $("<div>");
    var divContainer = null;
    var gifImg = null;
    var bitly = null;
    var brPoint = $("<br>");
    if (results.pagination.count < limit)
    {
        limit = results.pagination.count;
    }

    for (var i = 0; i < limit; i++)
    {
        divContainer = $("<div>").attr('class', "gifContainer");
        gifImg = $("<img>").attr('src', results.data[i].images.fixed_width.url);
        gifImg.appendTo(divContainer);
        brPoint.appendTo(divContainer);
        bitly = $("<input>").attr({
            value: results.data[i].bitly_url,
            class: "shortUrl"
        });
        bitly.appendTo(divContainer);
        divContainer.appendTo(resultContainer);
    }
    console.log(resultContainer);
    return resultContainer;
}

function errorOnAjax()
{
    console.log("Ajax error");
}

