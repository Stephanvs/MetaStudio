(function (window, undefined) {

	// Define variables
	var History = window.History;
	var $ = window.jQuery;
	var document = window.document;

	// Check to see if History.js is enabled for our Browser
	if (!History.enabled) {
		return false;
	}

	// Wait for jQuery Document
	$(function () {
		// Define variables
		var $content = $('section[role=main]');
		var contentNode = $content.get(0);

		var $menu = $('#menu,#nav,nav:first,.nav:first').filter(':first');
		var activeClass = 'current';
		var activeSelector = '.current';
		var menuChildrenSelector = '> li,> ul > li';
		var $body = $(document.body);
		var rootUrl = History.getRootUrl();
		var scrollOptions = {
			duration: 800,
			easing: 'swing'
		};

		// Ensure Content
		if ($content.length === 0) {
			$content = $body;
		}

		// Internal Helper
		$.expr[':'].internal = function (obj, index, meta, stack) {
			var $this = $(obj);
			var url = $this.attr('href') || '';
			var isInternalLink;

			// Check link
			isInternalLink = url.substring(0, rootUrl.length) === rootUrl || (/[^\:]/).test(url);

			// Ignore or Keep
			return isInternalLink;
		};

		// Ajaxify Helper
		$.fn.ajaxify = function () {
			var $this = $(this);

			$this.find('a:internal').click(function (event) {
				var $this = $(this);
				var url = $this.attr('href');
				var title = $this.attr('title') || null;

				// Continue as normal for cmd clicks etc
				if (event.which == 2 || event.metaKey) { return true; }

				// Ajaxify this link
				History.pushState(null, title, url);
				event.preventDefault();
				return false;
			});

			// Chain
			return $this;
		};

		// Ajaxify our Internal Links
		$body.ajaxify();

		// Hook into State Changes
		$(window).bind('statechange', function () {
			var State = History.getState();
			var url = State.url;
			var relativeUrl = url.replace(rootUrl, '');

			// Set async loading indicator
			$body.addClass('loading');

			// Start fade out
			$content.animate({ opacity: 0 }, 800);

			// Ajax request the original page
			$.ajax({
				url: url,
				success: function (data, textStatus, jqXhr) {
					// Fetch data
					var $data = $(data);
					var _content = $data.find('section[role=body]');
					var _scripts = $data.find('section[role=script]');

					// Fetch content
					var contentHtml = _content.html();
					if (!contentHtml) {
						// todo: no content came back, do something smart here
						return false;
					}

					// Update the menu
					var $menuChildren = $menu.find(menuChildrenSelector);
					$menuChildren.filter(activeSelector).removeClass(activeClass);
					$menuChildren = $menuChildren.has('a[href^="' + relativeUrl + '"],a[href^="/' + relativeUrl + '"],a[href^="' + url + '"]');
					if ($menuChildren.length === 1) { $menuChildren.addClass(activeClass); }

					// Update the content
					$content.stop(true, true);
					$content.html(contentHtml).ajaxify().css('opacity', 500).show(); /* you could fade in here if you'd like */

					// Add the scripts
					_scripts.each(function () {
						var $script = $(this), scriptText = $script.html(), scriptNode = document.createElement('script');
						scriptNode.appendChild(document.createTextNode(scriptText));
						contentNode.appendChild(scriptNode);
						//_content.append($script);
					});

					// Complete the change
					if ($body.ScrollTo || false) { $body.ScrollTo(scrollOptions); } /* http://balupton.com/projects/jquery-scrollto */
					$body.removeClass('loading');

					// Inform Google Analytics of the change
					if (typeof window.pageTracker !== 'undefined') {
						window.pageTracker._trackPageview(relativeUrl);
					}
				},
				error: function (jqXHR, textStatus, errorThrown) {
					// Todo: some intelligent error handling
					//document.location.href = url;
					return false;
				}
			});
		});
	});
})(window);