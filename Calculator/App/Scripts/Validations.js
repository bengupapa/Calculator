/// <reference path="Commons.js" />

$(function () {
    operatorsValiation = function () {
        if (upperScreen.text() == undefined
            || upperScreen.text() == '') {
            displayError('invalid operation');

            return false;
        }
        else {
            return true;
        }
    };
});