const testerClass = require('./pageTester');

const tester = new testerClass(process.env.URL);

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