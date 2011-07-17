$(function () {
	// Menu Dropdown
	$('#main-nav li ul').hide(); //Hide all sub menus
	$('#main-nav li.current a').parent().find('ul').slideToggle('slow'); // Slide down the current sub menu
	$('#main-nav li a').click(
		function () {
			$(this).parent().siblings().find('ul').slideUp('normal'); // Slide up all menus except the one clicked
			$(this).parent().find('ul').slideToggle('normal'); // Slide down the clicked sub menu
			return false;
		});
	$('#main-nav li a.no-submenu, #main-nav li li a').click(
		function () {
			window.location.href = (this.href); // Open link instead of a sub menu
			return false;
		});

	// jQuery Tipsy
	$('[rel=tooltip], #main-nav span, .loader').tipsy({ gravity: 's', fade: true }); // Tooltip Gravity Orientation: n | w | e | s
});