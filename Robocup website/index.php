<?php
        require('Login.php');
        require('Head.php');
?>

<!DOCTYPE html>
<html lang="en">

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
    var title = "Robocup";
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
        <div class="row" id="Index-Info">
				<h2>
                                    <a href="Register.php">You can buy tickets and reserve a camping spot for Robocup 2015! After registering.</a>
				</h2>
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
