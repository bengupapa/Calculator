$(function () {
    upperScreen = $('#topScreen');
    lowerScreen = $('#bottomScreen');

    //Displays user input on the upper screen
    displayOnUpperScreen = function (value) {
        upperScreen.text(value);
    };

    //Displays calculated results on the lower screen
    displayOnLowerScreen = function (value) {

        if (lowerScreen.hasClass('bottomScreenError')) {
            lowerScreen.removeClass('bottomScreenError');

            var fontClass = 'bottomScreenDefault';

            if (value.length < 7) {
                fontClass = 'bottomScreenDefault';
            } else if (value.length < 14) {
                fontClass = 'bottomScreenSmall';
            } else if (value.length < 28) {
                fontClass = 'bottomScreenSmaller';
            }

            lowerScreen.addClass(fontClass);
        }

        lowerScreen.text(value);
    };

    //handles displaying of errors
    displayError = function (errorMessage) {
        if (lowerScreen.hasClass('bottomScreenDefault')) {
            lowerScreen.removeClass('bottomScreenDefault');
            lowerScreen.addClass('bottomScreenError');
        }

        lowerScreen.text('ERROR: ' + errorMessage);
    };

    clearLowerScreen = function () {
        lowerScreen.removeClass('bottomScreenDefault');
        lowerScreen.addClass('bottomScreenError');
        lowerScreen.text('');
    };

    //Makes a JQuery http call to the server
    sendKey = function (buttonId, buttonType) {
        $.ajax({
            url: 'home/ProcessKey',
            type: 'GET',
            data: { 'ID': buttonId, 'Type' : buttonType },
            contentType: 'json',
            beforeSend:function(){ clearLowerScreen(); },
            success: function (result) {
                if (buttonType == 4) {
                    if (result.HasError) {
                        displayError(result.Data);
                    }
                    else {
                        displayOnLowerScreen(result.Data);
                    }
                }
                else {              
                    if (result.HasError) {
                        displayError(result.Data);
                    }
                    else {
                        displayOnUpperScreen(result.Data);
                    }
                }
            },
            error: function (error) {
                displayError(error.status + ' ' + error.statusText);
            }
        });
    };

    //Makes the calculator draggable within browser page.
    $('.calcContainer').draggable();
});