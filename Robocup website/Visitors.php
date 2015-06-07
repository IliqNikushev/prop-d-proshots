<?php
        require('Login.php');
        require('Head.php');
?>

<script> 
$(document).ready(function(){
    var title = "Visitors Information";
    $('#title').append(title);
});
</script> 

<body>

    <?php
    require('Navbar.php');
    ?>

    <!-- Main Content -->

	<div id="Elements-Placement">
        <?php
	if(isset($msg) & !empty($msg)){
		echo $msg;
	}
        ?>
			<div id="Heading">
				<h2>Visitors</h2>
			</div>
			
			<div id="VisitorsText">
			<b>Autonomous robots in action</b><br><br>
			Want to check the latest developments in service robots, rescue robots, soccer robots and music robots? With more than 2500 contestants from over 40 countries, RoboCup is the international robotics championship. During this mega-event in the Indoor Sports Center and Ice Sports Center in Eindhoven, you’ll be able to see all the latest robot technology in action!<br><br>
			
			<b>Make sure you’re there!</b><br><br>
			The doors open to visitors on Friday 26 June. That marks the start of three days of demonstrations and matches, ending on Sunday 28 June with the spectacular finals day. As well as the competition, both young and old can take part in workshops on the Robot Playground.<br><br>
			
			<b>Are you coming to this unique event too?</b><br><br>

			To keep in touch, follow RoboCup 2015 on Facebook and Twitter.<br><br>
			<div>
			<img src="img/Pleo.jpg"	alt="IMG" title="IMGf" height="15%" width="45%" />
			<img src="img/Visitors.jpg"	alt="IMG" title="IMGf" height="15%" width="45%" />
			</div><br>
			</div>


	</div>
	
    <?php
    require('Bottom.php');
    ?>

</body>

</html>
