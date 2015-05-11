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
    var title = "RobocupJunior";
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
				<h2>RoboCupJunior</h2>
			</div>
			
			<div id="RoboCupJuniorText">
			
			Junior<br><br>

			RoboCupJunior is targeted for primary and secondary school students. There is no fixed minimum age, but primary students are expected to be able to read (and hence write programs for their robots) on their own, without significant help from adult mentors. Students over age 19 are not allowed on RoboCupJunior teams. The division between the primary and secondary age categories is 14 years old.
			Teams with all student members age 14 and under are considered primary. Teams with any student member over age 14 must be secondary. Declaration day is the 1st of July. It is the mentor/teacher's as well as the National Representative's responsibility to follow the age regulation. Teams violating the regulation could be disqualified during or after RoboCupJunior competitions. <br><br>

			<a href="http://wiki.robocup.org/wiki/Junior" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>

			
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
