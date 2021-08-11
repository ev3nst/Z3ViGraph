jsonDisplay = {
	outputPretty: function (el) {
		var textjson = $(el).text();
		var pretty = JSON.stringify(JSON.parse(textjson), null, 2);
		// syntaxhighlight the pretty print version
		shpretty = jsonDisplay.syntaxHighlight(pretty);
		//output to a div
		// This could be a one liner with jQuery
		// - but not making assumptions about jQuery or other library being available.
		newDiv = document.createElement('pre');
		newDiv.innerHTML = shpretty;
		$(el).html(newDiv);
		// document.getElementById(jsonDisplay.outputDivID).appendChild(newDiv);
	},

	syntaxHighlight: function (json) {
		if (typeof json != 'string') {
			json = JSON.stringify(json, undefined, 2);
		}

		json = json
			.replace(/&/g, '&amp;')
			.replace(/</g, '&lt;')
			.replace(/>/g, '&gt;');
		return json.replace(
			/("(\\u[a-zA-Z0-9]{4}|\\[^u]|[^\\"])*"(\s*:)?|\b(true|false|null)\b|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?)/g,
			function (match) {
				var cls = 'number';
				if (/^"/.test(match)) {
					if (/:$/.test(match)) {
						cls = 'key';
					} else {
						cls = 'string';
					}
				} else if (/true|false/.test(match)) {
					cls = 'boolean';
				} else if (/null/.test(match)) {
					cls = 'null';
				}
				return '<span class="' + cls + '">' + match + '</span>';
			}
		);
	},
};
$(document).ready(function () {
	$('div.language-json').each(function (i, el) {
		jsonDisplay.outputPretty(el);
	});
});
