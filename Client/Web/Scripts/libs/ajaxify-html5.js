(function (window, undefined) {

	// Prepare our Variables
	var 
		History = window.History,
		$ = window.jQuery,
		document = window.document;

	// Check to see if History.js is enabled for our Browser
	if (!History.enabled) {
		return false;
	}

	// Wait for Document
	$(function () {
		// Prepare Variables
		var 
		/* Application Specific Variables */
		//contentSelector = '#content,article:first,.article:first,.post:first',
			contentSelector = '#content-placeholder',
			$content = $(contentSelector).filter(':first'),
			contentNode = $content.get(0),
			$menu = $('#menu,#nav,nav:first,.nav:first').filter(':first'),
			activeClass = 'current',
			activeSelector = '.current',
			menuChildrenSelector = '> li,> ul > li',
		/* Application Generic Variables */
			$body = $(document.body),
			rootUrl = History.getRootUrl(),
			scrollOptions = {
				duration: 800,
				easing: 'swing'
			};

		// Ensure Content
		if ($content.length === 0) {
			$content = $body;
		}

		// Internal Helper
		$.expr[':'].internal = function (obj, index, meta, stack) {
			// Prepare
			var 
				$this = $(obj),
				url = $this.attr('href') || '',
				isInternalLink;

			// Check link
			isInternalLink = url.substring(0, rootUrl.length) === rootUrl || (/[^\:]/).test(url);

			// Ignore or Keep
			return isInternalLink;
		};

		// HTML Helper
		var documentHtml = function (html) {
			// Prepare
			var result = String(html)
				.replace(/<\!DOCTYPE[^>]*>/i, '')
				.replace(/<('html'|'head'|'body'|'title'|'meta'|'script')/gi, '<section role="$1"')
				.replace(/<\/('html'|'head'|'body'|'title'|'meta'|'script')/gi, '</section')
			;

			// Return
			return result;
		};

		// Ajaxify Helper
		$.fn.ajaxify = function () {
			// Prepare
			var $this = $(this);

			// Ajaxify
			$this.find('a:internal').click(function (event) {
				// Prepare
				var 
					$this = $(this),
					url = $this.attr('href'),
					title = $this.attr('title') || null;

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
			// Prepare Variables
			var 
				State = History.getState(),
				url = State.url,
				relativeUrl = url.replace(rootUrl, '');

			// Set Loading
			$body.addClass('loading');

			// Start Fade Out
			// Animating to opacity to 0 still keeps the element's height intact
			// Which prevents that annoying pop bang issue when loading in new content
			$content.animate({ opacity: 0 }, 800);

			// Ajax Request the Traditional Page
			$.ajax({
				url: url,
				success: function (data, textStatus, jqXHR) {
					// Prepare
					var $data = $(documentHtml(data));
					var _content = $data.find('section[role=body]');
					var _scripts = $data.find('section[role=script]');

					// Fetch the content
					var contentHtml = _content.html();
					if (!contentHtml) {
						document.location.href = url;
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
					document.location.href = url;
					return false;
				}
			}); // end ajax

		}); // end onStateChange

	}); // end onDomLoad

})(window);           // end closure