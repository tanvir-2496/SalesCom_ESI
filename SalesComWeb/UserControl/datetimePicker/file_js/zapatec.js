if (typeof Zapatec == 'undefined') {
  /**
   * Namespace definition.
   * @constructor
   */
  Zapatec = function() {};
}
Zapatec.zapatecPath = function() {
  // Get all script elements
  var arrScripts = document.getElementsByTagName('script');
  // Find the script in the list
  for (var iScript = arrScripts.length - 1; iScript >= 0; iScript--) {
    var strSrc = arrScripts[iScript].getAttribute('src');
    if (!strSrc) {
      continue;
    }
    var arrTokens = strSrc.split('/');
    // Remove last token
    var strLastToken;
    if (Array.prototype.pop) {
      strLastToken = arrTokens.pop();
    } else {
      // IE 5
      strLastToken = arrTokens[arrTokens.length - 1];
      arrTokens.length -= 1;
    }
    if (strLastToken == 'zapatec.js') {
      return arrTokens.length ? arrTokens.join('/') + '/' : '';
    }
  }
  // Not found
  return '';
} ();

Zapatec.include = function(strSrc, strId) {
  // Check flag
  if (Zapatec.doNotInclude) {
    return;
  }
  // Include file
  document.write('<script type="text/javascript" src="' +
   strSrc + (typeof strId == 'string' ? '" id="' + strId : '') + '"></script>');
};

// Include required scripts
Zapatec.include(Zapatec.zapatecPath + 'utils.js', 'Zapatec.Utils');
Zapatec.include(Zapatec.zapatecPath + 'zpeventdriven.js', 'Zapatec.EventDriven');
Zapatec.include(Zapatec.zapatecPath + 'transport.js', 'Zapatec.Transport');
Zapatec.include(Zapatec.zapatecPath + 'zpwidget.js', 'Zapatec.Widget');