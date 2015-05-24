<?php
        require('Login.php');
        require('Head.php');
        require('Profile_SQL.php');
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
    var title = "Profile";
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
				<h2>Profile settings</h2>
			</div>
			
			<div id="ProfileText">
			
			You can change your details by entering new in the fields.<br><br><br>
                        
			<form id="Profile-Form" action="" method="POST">
                            
			<div style="display: inline-block; width:16%"><b>First Name: </b></div>
			<input type="text" pattern=".{1,25}" title="maximum 25 characters" name="FirstName" placeholder="First Name"><br><br>
			
			<div style="display: inline-block; width:16%"><b>Last Name: </b></div>
			<input type="text" pattern=".{1,25}" title="maximum 25 characters" name="LastName" placeholder="Last Name"><br><br>
			
			<div style="display: inline-block; width:16%"><b>Password: </b></div>
                        <input  pattern=".{4,25}" title="from 4 to 25 characters" type="password" name="Password" placeholder="Password"><br><br>
			
			<div style="display: inline-block; width:16%"><b>Confirm Password: </b></div>
                        <input type="password" name="Cpassword" placeholder="Confirm Password"><br><br>
                        
			<div style="display: inline-block; width:16%"><b>Email: </b></div>
			<input  pattern=".{6,25}" title="from 6 to 25 characters" type="email" name="Email" placeholder="Email"><br><br>
			
			
			<input type="submit" name="Save_changes" value="Save changes"><br><br>
			
                        </form>
                        
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
