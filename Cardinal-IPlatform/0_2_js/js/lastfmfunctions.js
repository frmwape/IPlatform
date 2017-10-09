"use strict";

var _parenturl = "http://ws.audioscrobbler.com/2.0/?method=artist.search&artist=";
var _parentkey = "&api_key=18fe148b510a9409923195592727d7d8&format=json";
var _inputvalue = "";
var _performon = "";
var _perform = "";
var _id = "";

function searchAPI()
{
    
    var _url = _parenturl + _inputvalue + _parentkey;
    
    $.get(_url, display)
        .fail(function (e) {
            alert("API error: " + e);
        });
}

function display(data)
{

    switch (_perform.toUpperCase())
    {
        case "SEARCH":
            var artistlist = data.results.artistmatches.artist;
           
            $("#" + _performon).empty();
            
            $(artistlist).each(function (i) {
                $("#" + _performon).append("<li id='" + i + "' data-val='" + artistlist[i].name + "'><a href=\"#\" onclick=\"processrequest('" + i + "', '', 'favourite', 'favourite-list', false)\">add to list </a>" + artistlist[i].name + "</li>");              
            });

            break;

        case "FAVOURITE":
            
            $("#" + _performon).append("<li>" + $("#" + _id).attr("data-val") + "</li>");
            $("#" + _id).remove();

            break;

        default:
            break;
    }
}

function processrequest(id, controlname, perform, performon, validateinputentered) {
    _performon = performon;
    _perform = perform;
    _id = id;

    try {
                
        if (validateinputentered)
            if (!$("#" + _id).val().trim()) {
                alert("Please provide " + controlname + " value.");
                $("#" + _id).focus();
                return;
            }

        switch (_perform.toUpperCase())
        {
            case "SEARCH":
                _inputvalue = $("#" + _id).val().trim();
                searchAPI();
                break;

            case "FAVOURITE":
                
                display(null);
                break;

            default:
                break;
        }
    }
    catch(e)
    {
        alert(e.message);
    }
}