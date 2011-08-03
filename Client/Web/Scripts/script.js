$(function () {
	// jQuery Facebox Modal
	$('.open-modal').nyroModal();

	// jQuery jWYSIWYG Editor
	$('.wysiwyg').wysiwyg({ iFrameClass: 'wysiwyg-iframe' });

	// jQuery dataTables
	$('.datatable').dataTable();

	// jQuery Custome File Input
	$('.fileupload').customFileInput();

	// jQuery DateInput
	$('.datepicker').datepick({ pickerClass: 'jq-datepicker' });

	// Check all checkboxes
	$('.check-all').click(
		function () {
			$(this).parents('form').find('input:checkbox').attr('checked', $(this).is(':checked'));
		});

	

	// Widget Close Button
	$('.close-widget').click(
	function () {
		$(this).parent().fadeTo(350, 0, function () { $(this).slideUp(600); }); // Hide widgets
		return false;
	});

	// Table actions
	$('.table-switch').hide();
	$('.toggle-table-switch').click(
	function () {
		$(this).parent().parent().siblings().find('.toggle-table-switch').removeClass('active').next().slideUp(); // Hide all menus expect the one clicked
		$(this).toggleClass('active').next().slideToggle(); // Toggle clicked menu
		$(document).click(function () { // Hide menu when clicked outside of it
			$('.table-switch').slideUp();
			$('.toggle-table-switch').removeClass('active');
		});
		return false;
	});

	// Image actions
	$('.image-frame').hover(
		function () { $(this).find('.image-actions').css('display', 'none').fadeIn('fast').css('display', 'block'); }, // Show actions menu
		function () { $(this).find('.image-actions').fadeOut(100); } // Hide actions menu
	);

	// Tickets
	$('.tickets .ticket-details').hide(); // Hide all ticket details
	$('.tickets .ticket-open-details').click( // On click hide all ticket details content and open clicked one
	function () {
		//$('.tickets .ticket-details').slideUp()
		$(this).parent().parent().parent().parent().siblings().find('.ticket-details').slideUp(); // Hide all ticket details expect the one clicked
		$(this).parent().parent().parent().parent().find('.ticket-details').slideToggle();
		return false;
	});

	// Wizard
	$('.wizard-content').hide(); // Hide all steps
	$('.wizard-content:first').show(); // Show default step
	$('.wizard-steps li:first-child').find('a').addClass('current');
	$('.wizard-steps a').click(
	function () {
		var step = $(this).attr('href'); // Set variable 'step' to the value of href of clicked wizard step
		$('.wizard-steps a').removeClass('current');
		$(this).addClass('current');
		$(this).parent().prevAll().find('a').addClass('done'); // Mark all prev steps as done
		$(this).parent().nextAll().find('a').removeClass('done'); // Mark all next steps as undone
		$(step).siblings('.wizard-content').hide(); // Hide all content divs
		$(step).fadeIn(); // Show the content div with the id equal to the id of clicked step
		return false;
	});
	$('.wizard-next').click(
	function () {
		var step = $(this).attr('href'); // Set variable 'step' to the value of href of clicked wizard step
		$('.wizard-steps a').removeClass('current');
		$('.wizard-steps a[href="' + step + '"]').addClass('current');
		$('.wizard-steps a[href="' + step + '"]').parent().prevAll().find('a').addClass('done'); // Mark all prev steps as done
		$('.wizard-steps a[href="' + step + '"]').parent().nextAll().find('a').removeClass('done'); // Mark all next steps as undone
		$(step).siblings('.wizard-content').hide(); // Hide all content divs
		$(step).fadeIn(); // Show the content div with the id equal to the id of clicked step
		return false;
	});

	// Content box accordions
	$('.accordion li div').hide();
	$('.accordion li:first-child div').show();
	$('.accordion .accordion-switch').click(
	function () {
		$(this).parent().siblings().find('div').slideUp();
		$(this).next().slideToggle();
		return false;
	});

	//Minimize Content Article
	$('article header h2').css({ 'cursor': 's-resize' }); // Minizmie is not available without javascript, so we don't change cursor style with CSS
	$('article header h2').click( // Toggle the Box Content
	function () {
		$(this).parent().find('nav').toggle();
		$(this).parent().parent().find('section, footer').toggle();
	});

	// Progress bar animation
	$('.progress-bar').each(function () {
		var progress = $(this).children().width();
		$(this).children().css({ 'width': 0 }).animate({ width: progress }, 3000);
	});

	//jQuery Full Calendar
	var date = new Date();
	var d = date.getDate();
	var m = date.getMonth();
	var y = date.getFullYear();

	$('.fullcalendar').fullCalendar({
		header: {
			left: 'prev,next today',
			center: 'title',
			right: 'month,basicWeek,basicDay'
		},
		editable: true,
		events: [
		{
			title: 'All Day Event',
			start: new Date(y, m, 1)
		},
		{
			title: 'Long Event',
			start: new Date(y, m, d - 5),
			end: new Date(y, m, d - 2)
		},
		{
			id: 999,
			title: 'Repeating Event',
			start: new Date(y, m, d - 3, 16, 0),
			allDay: false
		},
		{
			id: 999,
			title: 'Repeating Event',
			start: new Date(y, m, d + 4, 16, 0),
			allDay: false
		},
		{
			title: 'Meeting',
			start: new Date(y, m, d, 10, 30),
			allDay: false
		},
		{
			title: 'Lunch',
			start: new Date(y, m, d, 12, 0),
			end: new Date(y, m, d, 14, 0),
			allDay: false
		},
		{
			title: 'Birthday Party',
			start: new Date(y, m, d + 1, 19, 0),
			end: new Date(y, m, d + 1, 22, 30),
			allDay: false
		},
		{
			title: 'Click for Walking Pixels',
			start: new Date(y, m, 28),
			end: new Date(y, m, 29),
			url: 'http://www.walkingpixels.com/'
		}
	]
	});

	// jQuery Data Visualize
	$('table.data').each(function () {
		var chartWidth = $(this).parent().width() * 0.90; // Set chart width to 90% of its parent
		var chartType = ''; // Set chart type

		if ($(this).attr('data-chart')) { // If exists chart-chart attribute
			chartType = $(this).attr('data-chart'); // Get chart type from data-chart attribute
		} else {
			chartType = 'area'; // If data-chart attribute is not set, use 'area' type as default. Options: 'bar', 'area', 'pie', 'line'
		}

		if (chartType == 'line' || chartType == 'pie') {
			$(this).hide().visualize({
				type: chartType,
				width: chartWidth,
				height: '240px',
				lineDots: 'double',
				interaction: true,
				multiHover: 5,
				tooltip: true,
				tooltiphtml: function (data) {
					var html = '';
					for (var i = 0; i < data.point.length; i++) {
						html += '<p class="chart_tooltip"><strong>' + data.point[i].value + '</strong> ' + data.point[i].yLabels[0] + '</p>';
					}
					return html;
				}
			});
		} else {
			$(this).hide().visualize({
				type: chartType,
				width: chartWidth,
				height: '240px'
			});
		}
	});

});