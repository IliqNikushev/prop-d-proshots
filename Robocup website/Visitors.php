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
    var title = "Visitors Information";
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
				<h2>Visitors</h2>
			</div>
			
			<div id="VisitorsText">
			<b>Autonomous robots in action</b><br><br>
			Want to check the latest developments in service robots, rescue robots, soccer robots and music robots? With more than 2500 contestants from over 40 countries, RoboCup is the international robotics championship. During this mega-event in the Indoor Sports Center and Ice Sports Center in Eindhoven, you’ll be able to see all the latest robot technology in action!<br><br>
			
			<b>Make sure you’re there!</b><br><br>
			The doors open to visitors on Wednesday 26 June. That marks the start of four days of demonstrations and matches, ending on Sunday 30 June with the spectacular finals day. As well as the competition, both young and old can take part in workshops on the Robot Playground.<br><br>
			
			<b>Are you coming to this unique event too?</b><br><br>

			To keep in touch, follow RoboCup 2015 on Facebook and Twitter.<br><br>
			
			<img src="img/Pleo.jpg"	alt="IMG" title="IMGf" height="170" width="258" />
			<img src="img/Visitors.jpg"	alt="IMG" title="IMGf" height="170" width="258" />
			
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
