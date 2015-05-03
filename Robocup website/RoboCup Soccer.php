<?php
        session_start();
	require('connect.php');
        error_reporting(E_ERROR | E_PARSE);
    
if ($_POST['Login'])
{
//3. If the form is submitted or not.
//3.1 If the form is submitted
if (isset($_POST['username']) and isset($_POST['password'])){
//3.1.1 Assigning posted values to variables.
$username = $_POST['username'];
$password = $_POST['password'];
//3.1.2 Checking the values are existing in the database or not
$query = "SELECT * FROM `user` WHERE username='$username' and password='$password'";
 
$result = mysql_query($query) or die(mysql_error());
$count = mysql_num_rows($result);
//3.1.2 If the posted values are equal to the database values, then session will be created for the user.
if ($count == 1){
$_SESSION['username'] = $username;
}else{
//3.1.3 If the login credentials doesn't match, he will be shown with an error message.
$msg = "Invalid Login Credentials.";
}
}
//3.1.4 if the user is logged in Greets the user with message
if (isset($_SESSION['username'])){
$username = $_SESSION['username'];

}
$date_of_expiry = time() + 60 * 60 * 24 ;
setcookie( "username", "$username", $date_of_expiry ); 
}

if ($_POST['Logout'])
{
session_destroy();
header("Location: index.php");
}
?>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Robocup Soccer</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/clean-blog.min.css" rel="stylesheet">
	<link href="css/page.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href='http://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script> 
$(document).ready(function(){

	$("#Login-Panel").hide();
	$("#Logout").hide();	 
	$("#Login-Button").click(function(){
		 $("#Login-Button").hide();
		 $("#Login-Panel").show();
                 
    });
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
			
		<ul class="nav navbar-nav navbar-left" id="Left-Navbar">

<?php
        if (isset($_SESSION['username'])){
?>
<script> 
$(document).ready(function(){

	$("#Login-Panel").hide();
        $("#Login-Button").hide();
        $("#Login-Panel-2").hide();
        $("#Logout").show();
        
        $("#Logout").click(function(){
	location.reload(true);
    });

});
</script> 
<?php
        }
?>

                                    
				<div id="Login-Panel">
                                <form action="" method="POST">
                                    
                                <input type="text" name="username" placeholder="Username">


                                <input type="password" name="password" placeholder="Password">

					
                                <input id="Login-Button-1" type="submit" name="Login" value="Login">
					
				</form>
					
					<br>
					  
				</div>
                                <div id="Login-Panel-2">
				<button class="link" id="Login-Button" >Login</button>
                                <a  href="Register.php" id="Register" >Register</a>
				<a  href="Forgotten.php" id="Forgotten-password" >Forgotten password</a>
                                </div>
                                <form id="Logout" action="" method="POST">
                                <div style="color: gray">
                                Hi , <a href="Profile.php" style="color: white"><?php 
                                if (isset($_COOKIE['username'])) {
                                    $username = $_COOKIE['username'];
                                    echo $_COOKIE['username'];
                                   }
                                   else{
                                    echo $username;   
                                   }
                                ?></a>&nbsp&nbsp&nbsp
                                <input type="submit" name="Logout" value="Logout">
                                </div>
                                </form>
                </ul>
				
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="index.php">Home</a>
                    </li>
					<li class="dropdown">
					<a href="#" class="dropdown-toggle" data-toggle="dropdown">Event<b class="caret"></b></a>
					<ul class="dropdown-menu " >
					<li><a href="Visitors.php" >Info</a></li>
                                        <li><a href="Location.php" >Location</a></li>
					<li><a href="Tickets.php" >Tickets</a></li>
					<li><a href="Reservation.php" >Camping spot</a></li>
					</ul>
					</li>
                    <li>
                        <a href="Schedule.php">Schedule</a>
                    </li>
					<li class="dropdown">
					<a href="#" class="dropdown-toggle" data-toggle="dropdown">Leagues<b class="caret"></b></a>
					<ul class="dropdown-menu " >
					<li><a href="RoboCup Soccer.php" >RoboCup Soccer</a></li>
					<li><a href="RoboCup Rescue.php" >RoboCup Rescue</a></li>
					<li><a href="RoboCupJunior.php" >RoboCupJunior </a></li>
					<li><a href="RoboCup@Home.php" >RoboCup@Home </a></li>
					<li><a href="RoboCup@Work.php" >RoboCup@Work </a></li>
					</ul>
					</li>
					<li class="dropdown">
					<a href="#" class="dropdown-toggle" data-toggle="dropdown">About<b class="caret"></b></a>
					<ul class="dropdown-menu" >
					<li><a href="Sponsors.php">Sponsors</a></li>
					<li><a href="Contact Information.php">Contact Information</a></li>
					</ul>
					</li>
                </ul>
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
	<div class="container" id="PicturesHeading">
	<div>Photos</div>
	</div>
	
	<div class="container" id="Pictures">
	 <a href="img/RoboCup-1.jpg"><img src="img/RoboCup-1.jpg"     alt="IMG"     title="IMG1" width="30%"/></a>
	 	 <a href="img/RoboCup-2.jpg"><img src="img/RoboCup-2.jpg"     alt="IMG"     title="IMG2" width="30%"/></a>
		 	 <a href="img/RoboCup-3.jpg"><img src="img/RoboCup-3.jpg"     alt="IMG"     title="IMG3" width="30%"/></a>
			 	 <a href="img/RoboCup-4.jpg"><img src="img/RoboCup-4.jpg"     alt="IMG"     title="IMG4" width="30%"/></a>
				 	<a href="img/RoboCup-5.jpg"><img src="img/RoboCup-5.jpg"     alt="IMG"     title="IMG5" width="30%"/></a>
						 <a href="img/RoboCup-6.jpg"><img src="img/RoboCup-6.jpg"     alt="IMG"     title="IMG6" width="30%"/></a>
	</div>
	
	<div class="container" id="TwitterHeading">
	<div>Twitter</div>
	</div>
	
	<div class="container" id="Twitter">
	
	</div>
	</div>
	
    <hr>

    <!-- Footer -->
    <footer style = "background-color:black; height: 100px;">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 col-md-10 col-md-offset-1">
                    <p class="copyright text-muted">Contact us on Robocup2015Netherland@gmail.com</p>
                </div>
            </div>
        </div>
    </footer>

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>


</body>

</html>
