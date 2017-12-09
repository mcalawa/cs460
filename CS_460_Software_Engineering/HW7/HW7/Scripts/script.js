//tells the HTML what to do when the button is clicked
$("#submitButton").click(search);

//the function that runs when you click on the search button
function search()
{
    /* This puts the query into a form that the Giphy API can parse by removing all punctuation 
     * and multiple spaces and replacing each space with a + */
    var query = $("#searchTerm").val().replace(/[\u2000-\u206F\u2E00-\u2E7F\\'!"#$%&()*+,\-.\/:;<=>?@\[\]^_`{|}~]/, "").replace(/\s+/g, "+");
    var limit = $("#resultNum").val();

    //the source of the of the url
    var source = "search?q=" + query + "&limit=" + limit;
    //the ajax call to get the results of the query
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayResults,
        error: errorOnAjax
    });
}

/* the function to receive the results of the search, 
 * empty the div that will display them, and then append
 * the results of the function that creates the HTML to display
 * the results */
function displayResults(results)
{
    //this value is still needed because it decides how many results to display
    var limit = $("#resultNum").val();

    $("#searchResults").empty(); //remove the results of previous searches
    //display the results of the current search
    $("#searchResults").append(displayGifs(results, limit));
}

//the function to create the HTML that will display all the gifs
function displayGifs(results, limit)
{
    "use strict";
    //the initial tag the rest of the code attaches to
    var resultContainer = $("<div>");
    /* the div to hold the image and the 
     * image url; currently null since it
     * will be assigned later */
    var divContainer = null;
    /* For the image itself; currently null
     * since it will be assigned later */
    var gifImg = null;
    /**
     * To hold the input text box where we'll have
     * the url of the image's direct link so that
     * the user can access it easily; currently null
     * since it will be assigned later
     */
    var bitly = null;
    //for any br we might need to have
    var brPoint = $("<br>");
    /* Reset the limit to the number of actual results
     * if we end up with fewer results than requested */
    if (results.pagination.count < limit)
    {
        limit = results.pagination.count;
    }

    /* for each of the results we came up with that 
     * are less than or equal to the number of results
     * requested... */
    for (var i = 0; i < limit; i++)
    {
        //create the div to hold the image and url
        divContainer = $("<div>").attr('class', "gifContainer");
        //create the image tag itself with the correct src
        gifImg = $("<img>").attr('src', results.data[i].images.fixed_width.url);
        //append the image to the image/url div
        gifImg.appendTo(divContainer);
        //append the break point to that
        brPoint.appendTo(divContainer);
        //create an input tag for the gif url and assign it a class
        bitly = $("<input>").attr({
            value: results.data[i].bitly_url,
            class: "shortUrl"
        });
        //append the url input to the div
        bitly.appendTo(divContainer);
        //append the img/url div to the container div
        divContainer.appendTo(resultContainer);
    }
    //return the complete result so that it can be displayed
    return resultContainer;
}

// lets the user know if there has been an error
function errorOnAjax()
{
    //write an error message to the console
    console.log("Ajax error");
}

