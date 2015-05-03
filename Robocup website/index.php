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

    <title>Robocup</title>

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
var numberOfImagesInLeagues = 0;
var numberOfImagesToDisplay = 0;
var offset = 0;
$(document).ready(function(){
  numberOfImagesInLeagues = $("#Index-Leagues-content").children().length;
  numberOfImagesToDisplay = Number(($("#Index-Leagues").width() / 250).toFixed(0));
  $("#Leagues-forward-arrow-1").css("margin-left", ($("#Leagues-back-arrow").width() + 24) +"px");
  $("#Leagues-back-arrow").hide();

    $("#Leagues-back-arrow").click(function(){
     if(offset == 0) return;
     if(offset == numberOfImagesInLeagues - numberOfImagesToDisplay)
      $("#Leagues-forward-arrow-1").show();

      $("#Index-Leagues-content").animate({left: '+=250px'});

      offset -= 1;
      if(offset == 0){
       $("#Leagues-back-arrow").hide();
       $("#Leagues-forward-arrow-1").css("margin-left", ($("#Leagues-back-arrow").width() + 24) +"px");
      }
    });

    $("#Leagues-forward-arrow-1").click(function(){
      if(offset == numberOfImagesInLeagues - numberOfImagesToDisplay) return;
     if(offset == 0)
     {
      $("#Leagues-back-arrow").show();
      $("#Leagues-forward-arrow-1").css("margin-left", "0px");
     }

      $("#Index-Leagues-content").animate({left: '-=250px'});

      offset += 1;
      if(offset == numberOfImagesInLeagues - numberOfImagesToDisplay)
       $("#Leagues-forward-arrow-1").hide();
    });
	
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
                                        <li><a href="Balance.php">Balance</a></li>
					<li><a href="Booked.php">Booked Items</a></li>
					<li><a href="Profile.php">Profile</a></li>
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
        <div class="row" id="Index-Info">
				<h2>
                <a href="tickets.html">You can buy tickets for Robocup 2015! Click here for the details.</a>
				</h2>
				<p>You can also <a href="reservation.html">reserve a camping spot</a> for Robocup 2015 from our website!</p>
				<p>RoboCup is a worldwide project.  The goal of the project is: Build a soccer playing robot that looks like a human and that can win from the human world champion in 2050! The knowledge about robotics which is obtained, is shared within the RoboCup teams so the technology improves very fast. By using soccer as a subject, many people will get interested in the RoboCup.</p>
				<p><img src="img/RoboCup-1.jpg"   alt="IMG"   title="IMG1" height="100%" width="100%"/></p>
        </div>
		
				<h2 id="Index-Leagues-Heading">Leagues 
				<button id="Leagues-back-arrow"><img src="img/Back.png"	alt="IMG" title="IMGf" width="25" height="25" /></button >
				<button id="Leagues-forward-arrow-1"><img src="img/Forward.png"	alt="IMG" title="IMGb" width="25" height="25" /></button >
				</h2>
		
		<div class="cantainer" id="Index-Leagues"> 

			<div id="Index-Leagues-content">
			
			<div id="Leagues-text"  >
			<img src="img/RoboCup-Soccer.jpg"	alt="IMG" title="IMG1" width="100%" height="150"/><br><br>
			<a href="Leagues.html" class="headline"><b>RoboCup Soccer</b></a><br><br>
			The main focus of the<br> RoboCup competitions is the<br> game of soccer, where the<br> research goals concern<br> cooperative multi-robot and<br> multi-agent systems in<br> dynamic adversarial<br> environments. All robots in<br> this league are fully<br>
			<br><a href="RoboCup Soccer.html"><img src="img/red-button.png"	alt="IMG" title="IMG2" height="50" width="90%" /></a>
			</div>
			
			<div id="Leagues-text"  >
			<img src="img/RoboCup-Rescue.jpg"	alt="IMG" title="IMG3" width="100%" height="150"/><br><br>
			<a href="Leagues.html" class="headline"><b>RoboCup Rescue</b></a><br><br>
			The RoboCupRescue Robot<br> League is an international<br> league of teams with one<br> objective: Develop and<br> demonstrate advanced<br> robotic capabilities for<br> emergency responders using<br> annual competitions to<br> evaluate,<br>
			<br><a href="RoboCup Rescue.html"><img src="img/red-button.png"	alt="IMG" title="IMG4" height="50" width="90%"/></a>
			</div>
			
			<div id="Leagues-text"  >
			<img src="img/RoboCup-Junior.jpg"	alt="IMG" title="IMG5" width="100%" height="150"/><br><br>
			<a href="Leagues.html" class="headline"><b>RoboCupJunior</b></a><br><br>
			RoboCupJunior is targeted<br> for primary and secondary<br> school students. There is no<br> fixed minimum age, but<br> primary students are<br> expected to be able to read<br> (and hence write programs<br> for their robots) on their<br> own, without <br>
			<br><a href="RoboCupJunior.html"><img src="img/red-button.png"	alt="IMG" title="IMG6" height="50" width="90%"/></a>
			</div>
			
			<div id="Leagues-text" >
			<img src="img/RoboCup@Home.jpg"	alt="IMG" title="IMG7" width="100%" height="150"/><br><br>
			<a href="Leagues.html" class="headline"><b>RoboCup@Home</b></a><br><br>
			The RoboCup@Home league<br> aims to develop service and<br> assistive robot technology<br> with high relevance for<br> future personal domestic<br> applications. It is the<br> largest international annual<br> competition for autonomous <br>
			<br><a href="RoboCup@Home.html"><img src="img/red-button.png"	alt="IMG" title="IMG8" height="50" width="90%"/></a>
			</div>
			
			<div id="Leagues-text" >
			<img src="img/RoboCup@Work.jpg"	alt="IMG" title="IMG9" width="100%" height="150"/><br><br>
			<a href="Leagues.html" class="headline"><b>RoboCup@Work</b></a><br><br>
			RoboCup@Work is a new<br> competition in RoboCup that<br> targets the use of robots in<br> work-related scenarios.<br>
			<br><a href="RoboCup@Work.html"><img src="img/red-button.png"	alt="IMG" title="IMG10" height="50" width="90%"/></a>
			</div>

			</div>
		
        </div>

				<h2 id="Index-Sponsors-Heading">
                Sponsors
				</h2>
		

			<div id="Index-Sponsors-Content" >

			<div>
			<br><a href="Sponsors.html"><img src="img/RoboCup-Federation.png"	alt="IMG" title="IMG1" width="100%"/></a></br>
			<br><a href="Sponsors.html"><img src="img/RoboCup-Sponsor-1.png"	alt="IMG" title="IMG2" width="100%"/></a></br>
			</div>
			
			<div>
			<br><a href="Sponsors.html"><img src="img/RoboCup-Sponsor-2.png"	alt="IMG" title="IMG3" width="100%"/></a></br>
			<br><a href="Sponsors.html"><img src="img/RoboCup-Sponsor-3.png"	alt="IMG" title="IMG4" width="100%"/></a></br>
			</div>
			
			<div>
			<br><a href="Sponsors.html"><img src="img/RoboCup-Sponsor-4.png"	alt="IMG" title="IMG5" width="100%"/></a></br>
			<br><a href="Sponsors.html"><img src="img/RoboCup-Sponsor-5.png"	alt="IMG" title="IMG6" width="100%"/></a></br>
			</div>
			
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
