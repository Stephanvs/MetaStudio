$(function () {
	// Menu Dropdown
	$('#main-nav li ul').hide(); //Hide all sub menus
	$('#main-nav li.current a').parent().find('ul').slideToggle('slow'); // Slide down the current sub menu
	$('#main-nav li a').click(function () {
		$(this).parent().siblings().find('ul').slideUp('normal'); // Slide up all menus except the one clicked
		$(this).parent().find('ul').slideToggle('normal'); // Slide down the clicked sub menu
		return false;
	});

	// IE7 doesn't support :disabled
	$('.ie7').find(':disabled').addClass('disabled');

//	$('#main-nav li a.no-submenu, #main-nav li li a').click(function () {
//		window.location.href = (this.href); // Open link instead of a sub menu
//		return false;
//	});

	// jQuery Tipsy
	$('[rel=tooltip], #main-nav span, .loader').tipsy({ gravity: 's', fade: true }); // Tooltip Gravity Orientation: n | w | e | s
});



var vm = {
	data: ko.observableArray(['Content', 'Goes', 'Here', '!']),

	modelList: ko.observableArray([{
		modelId: ko.observable("30038808-E817-4554-AF82-9EF6733D3F8C"),
		modelName: ko.observable("Default")
	},
	{
		modelId: ko.observable("74E23EEC-106C-42B5-88F6-9E9F5165B8CB"),
		modelName: ko.observable("Sample Model 1")
	}]),

	menuSelectedModelId: ko.observable("30038808-E817-4554-AF82-9EF6733D3F8C"),

	menuChangeSelectedModel: function (data) {
		this.menuSelectedModelId(data.modelId());
	},

	metaModellingChangeSelectedModelId: function (data) {
		this.metaModellingSelectedModelId(data.modelId());
	},

	metaModellingSelectedModelId: ko.observable("30038808-E817-4554-AF82-9EF6733D3F8C"),

	debug: {
		version: ko.observable("0.0.0.1")
	}
};

ko.applyBindings(vm);