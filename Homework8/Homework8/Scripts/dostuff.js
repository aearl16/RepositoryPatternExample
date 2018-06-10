//Javascript that loads page things and routes Ajax calls

function displayStuff(data) {
    $("#displayResults").empty();
    $.each(data, function (i, field) {
        $("#displayResults").append("<p>" + field["Title"] + " by " + field["FullName"] +"</p>")
    });
    $("#DisplayArea").css("display", "block");
}

function genreClicked(genreID)
{
    console.log(genreID)
    var source = "/Home/GenreResult?id=" + genreID;
    console.log(source);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: function (data) {
            displayStuff(data);
        },
        error: function(data) {
            alert("There was an error. Try again please!");
        }
    });
}
