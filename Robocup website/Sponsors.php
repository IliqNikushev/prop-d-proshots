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
    var title = "Sponsors";
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
				<h2>Sponsors</h2>
			</div>
			
			
			<div class="container" id="Sponsors-Content">
			<div>

			<b>SPONSORING ROBOCUP 2015</b><br><br>

			<b>A unique opportunity for leaders in various sectors</b><br><br>

			The combination of fascinating robotics, vivacious competitions and presentations from innovative organizations that want to contribute to high tech solutions for a better society make RoboCup 2013 into an ideal stage and meeting place for:<br><br>
			
			- Hundreds of decision makers and influencers who want to accelerate the necessary technological innovation in, for instance, cure & care, food & agro, energy and transport;<br>

			- Developers, producers, adopters, users, prescribers, financers, insurance companies, labour mediators, educators and authorities.<br>

			- Thousands of technical students from 40 countries who take part or come to watch.<br>

			- Journalists, nationally and internationally, TV, radio, web, social media, journals, newspapers and blogs. Previous editions have reached millions of people worldwide.<br>

			- Thousands of spectators, including many young people and families.<br><br>
			
			<b>Sponsors RoboCup 2015</b><br>
			
			<div id="Leagues-text" class="content" style=" float: left;">
			<br><img src="img/RoboCup-Sponsor-1.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-4.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-7.jpg"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-10.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-13.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-16.jpg"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-19.jpg"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-22.jpg"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			</div>
			
			<div id="Leagues-text" class="content" style=" float: left;">
			<br><img src="img/RoboCup-Sponsor-2.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-5.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-8.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-11.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-14.jpg"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-17.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-20.gif"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-23.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			</div>
			
			<div id="Leagues-text" class="content" style=" float: left;">
			<br><img src="img/RoboCup-Sponsor-3.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-6.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-9.jpg"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-12.jpg"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-15.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-18.jpg"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-21.gif"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			<br><img src="img/RoboCup-Sponsor-24.png"	alt="IMG" title="IMG6" height="100" width="150"/></br><br>
			</div>

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
