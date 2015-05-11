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
    var title = "Robocup Soccer";
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
				<h2>RoboCup Soccer</h2>
			</div>
			
			<div id="RoboCupSoccerText">
			
			There are five leagues in RoboCup Soccer. You could find more information at RoboCup wiki.<br><br>

			1.Small Size League<br><br>

			Small Size robot soccer is one of the RoboCup league divisions. Small Size robot soccer, or F180 as it is otherwise known, focuses on the problem of intelligent multi-agent cooperation and control in a highly dynamic environment with a hybrid centralized/distributed system.<br><br>

			<a href="http://wiki.robocup.org/wiki/Small_Size_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>

			2.Middle Size League<br><br>

			<a href="http://wiki.robocup.org/wiki/Middle_Size_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>

			3.Humanoid League<br><br>

			In the Humanoid League, autonomous robots with a human-like body plan and human-like senses play soccer against each other. Unlike humanoid robots outside the Humanoid League the task of perception and world modeling is not simplified by using non-human like range sensors.
			In addition to soccer competitions technical challenges take place. Dynamic walking, running, and kicking the ball while maintaining balance, visual perception of the ball, other players, and the field, self-localization, and team play are among the many research issues investigated in the Humanoid League. Several of the best autonomous humanoid robots in the world compete in the RoboCup Humanoid League.<br><br>

			<a href="http://wiki.robocup.org/wiki/Humanoid_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>

			4.Standard Platform League<br><br>

			The RoboCup Standard Platform League is a RoboCup robot soccer league, in which all teams compete with identical robots. The robots operate fully autonomously, i.e. there is no external control, neither by humans nor by computers. The current standard platform used is the humanoid NAO by Aldebaran Robotics.<br><br>

			<a href="http://wiki.robocup.org/wiki/Standard_Platform_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>

			5.Soccer Simulation League<br><br>

			Without the necessity to maintain any robot hardware, the RoboCup Simulation League's focus comprises artificial intelligence and team strategy.<br><br>

			<a href="http://wiki.robocup.org/wiki/Soccer_Simulation_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>
			
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
