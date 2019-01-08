$(document).ready(function () {
	$('#keycode').click(function () {
		$(this).parents().next('.hide').toggle();
	});
	$('#keycode2').click(function () {
		$(this).parents().next('.hide').toggle();
	});
	$('.hide').toggle();
});