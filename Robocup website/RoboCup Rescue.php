<?php
        require('Login.php');
        require('Head.php');
?>

<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script> 
$(document).ready(function(){

	$("#Login-Panel").hide();
	$("#Logout").hide();	 
	$("#Login-Button").click(function(){
		 $("#Login-Button").hide();
		 $("#Login-Panel").show();
                 
    });
    var title = "Robocup Rescue";
    $('#title').append(title);
});
</script> 

<body>

    <!-- Navigation -->
    <nav class=" navbar-inverse navbar-static-top" id="navbar">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
			
<?php
        require('Navbar.php');
?>
                
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>

    <!-- Page Header -->
    <!-- Set your background image for this header on the line below. -->
<header class="intro-header" style="background-image: url('img/home.jpg'); background-repeat: no-repeat; background-size: 100% 100%;" id="background-image" ></header>

    <!-- Main Content -->
	<div id="Elements-Placement">
        <?php
	if(isset($msg) & !empty($msg)){
		echo $msg;
	}
        ?>
			<div id="Heading">
				<h2>RoboCup Rescue</h2>
			</div>
			
			<div id="RoboCupRescueText">
			
			1.Robot League<br><br>

			The RoboCupRescue Robot League is an international league of teams with one objective: Develop and demonstrate advanced robotic capabilities for emergency responders using annual competitions to evaluate, and teaching camps to disseminate, best-in-class robotic solutions. <br><br>

			<a href="http://wiki.robocup.org/wiki/Robot_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>

			2.Rescue Simulation League<br><br>

			The league consist of three competitions:<br><br>

    		The agent competition<br><br>

			The infrastructure competition<br><br>

			The virtual robot competition <br><br>

			During rescue operations after a disaster, cooperation is a must (Jennings et al, 1997). In general the problem is not solvable by a single agent, and a heterogeneous team that dynamically combines individual capabilities in order to solve the task is needed (Murphy et al. 2000).
			This requirement is due to the structural diversity of disaster areas, variety of evidence the sensors can perceive and to the necessity of quickly and reliably examining large regions. <br><br>

			<a href="http://wiki.robocup.org/wiki/Rescue_Simulation_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>

			
			</div>

    </div>
	
        <div id="Elements-Placement-2">
    <?php
        require('Twitter.php');
    ?>
	</div>
	
    <hr>

    <?php
        require('Footer.php');
    ?>


</body>

</html>
