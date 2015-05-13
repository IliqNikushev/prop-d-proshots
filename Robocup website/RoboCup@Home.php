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
    var title = "Robocuo@Home";
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
				<h2>RoboCup@Home</h2>
			</div>
			
			<div id="RoboCupHomeText">
			
			RoboCup@Work is a new competition in RoboCup that targets the use of robots in work-related scenarios.

			The RoboCup@Home league aims to develop service and assistive robot technology with high relevance for future personal domestic applications. It is the largest international annual competition for autonomous service robots and is part of the RoboCup initiative. A set of benchmark tests is used to evaluate the robots’ abilities and performance in a realistic non-standardized home environment setting.
			Focus lies on the following domains but is not limited to: Human-Robot-Interaction and Cooperation, Navigation and Mapping in dynamic environments, Computer Vision and Object Recognition under natural light conditions, Object Manipulation, Adaptive Behaviors, Behavior Integration, Ambient Intelligence, Standardization and System Integration. It is colocated with the RoboCup symposium. <br><br>

			<a href="http://wiki.robocup.org/wiki/@Home_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>

			
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
