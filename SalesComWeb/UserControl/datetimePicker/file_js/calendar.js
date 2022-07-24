
if (!window.Zapatec || (Zapatec && !Zapatec.include)) {
	alert("You need to include zapatec.js file!");
} else {
	Zapatec.calendarPath = Zapatec.getPath("Zapatec.CalendarWidget");

	// Include required scripts
	Zapatec.Transport.include(Zapatec.calendarPath + 'calendar-core.js', "Zapatec.Calendar");
	Zapatec.Transport.include(Zapatec.calendarPath + 'calendar-date-core.js');
	Zapatec.Transport.include(Zapatec.calendarPath + 'calendar-setup.js');
}

window.calendar = null;		/**< global object that remembers the calendar */

// initialize the preferences object;
// embed it in a try/catch so we don't have any surprises
try {
	Zapatec.Calendar.loadPrefs();
} catch(e) {};

Zapatec.Utils.addEvent(window, 'load', Zapatec.Utils.checkActivation);