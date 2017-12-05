const tester = require('./pageTester');

tester = new tester(process.env.URL);

const pages = [
	"Balance.php",
	"Booked.php",
	"Bottom.php",
	"CompleteRegistration.php",
	"Contact Information.php",
	"Forgotten.php",
	"Head.php",
	"index.php",
	"Input.php",
	"Location.php",
	"Login.php",
	"Navbar.php",
	"Participants.php",
	"paypal.php",
	"Profile.php",
	"Register.php",
	"Reservation.php",
	"RoboCup Rescue.php",
	"RoboCup Soccer.php",
	"RoboCup@Home.php",
	"RoboCup@Work.php",
	"RoboCupJunior.php",
	"Schedule.php",
	"Sponsors.php",
	"Tickets.php",
	"Visitors.php"
];

tester.run(pages);