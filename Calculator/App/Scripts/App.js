/// <reference path="Commons.js" />
/// <reference path="Validations.js" />

//Registers click event on every dynamically created button
$('.buttonContainer').click(function () {
    var button = $(this);
    sendKey(button.attr('id'), button.attr('data-type'));
});