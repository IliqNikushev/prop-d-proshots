<?php
        
        require('Login.php');
        require('Head.php');
        
        if ($_POST['Register'])
{
    // If the values are posted, insert them into the database.
    if (isset($_POST['Username']) && isset($_POST['Password'])){
        $FirstName = $_POST['FirstName'];
        $LastName = $_POST['LastName'];
        $Email = $_POST['Email'];
        $Username = $_POST['Username'];
        $Password = $_POST['Password'];
        $Type = 1;
        $Ticket = 0;
        $query = "INSERT INTO `users` (FirstName,LastName, Email, Username, Password , Type, Ticket) VALUES ('$FirstName', '$LastName', '$Email', '$Username', '$Password', '$Type', '$Ticket')";
        
        
        $query1 = mysql_query("SELECT Username FROM Users WHERE Username='$Username'");
        $query2 = mysql_query("SELECT Email FROM Users WHERE Email='$Email'");
        
  if (mysql_num_rows($query1)>0 || mysql_num_rows($query2)>0)
  {
     $msg = "User Already Exist.";
  }else if ($_POST['Password']!= $_POST['Cpassword'])
    {
     $msg = "Passwords did not match! Try again.";
    }
  else {
      $msg = "User Created Successfully.";
      $result = mysql_query($query);
      if($a = mysql_error())
      {
          $msg = mysql_error();
          
      }
            
         }
    
    
    
    }
}
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
    var title = "Register";
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
				<h2>Registration</h2>
			</div>
			
			<div id="RegisterText">
			
			Please direct all general registration questions and inquiries via email to Help.RoboCup2015@gmail.com.<br><br>
			
			<form id="Register-Form" action="" method="POST">
			
			<div style="display: inline-block; width:16%"><b>Username: </b></div>
                        <input required pattern=".{3,25}" title="from 3 to 25 characters" type="text" name="Username" placeholder="Username"><br><br>
			
			<div style="display: inline-block; width:16%"><b>First Name: </b></div>
			<input type="text" pattern=".{1,25}" title="maximum 25 characters" name="FirstName" placeholder="First Name"><br><br>
			
			<div style="display: inline-block; width:16%"><b>Last Name: </b></div>
			<input type="text" pattern=".{1,25}" title="maximum 25 characters" name="LastName" placeholder="Last Name"><br><br>
			
			<div style="display: inline-block; width:16%"><b>Password: </b></div>
                        <input required pattern=".{4,25}" title="from 4 to 25 characters" type="password" name="Password" placeholder="Password"><br><br>
			
			<div style="display: inline-block; width:16%"><b>Confirm Password: </b></div>
                        <input required onChange="checkPasswordMatch();" type="password" name="Cpassword" placeholder="Confirm Password"><br><br>
                        
			<div style="display: inline-block; width:16%"><b>Email: </b></div>
			<input required pattern=".{6,25}" title="from 6 to 25 characters" type="email" name="Email" placeholder="Email"><br><br>
			
			
                        <input class="btn register" type="submit" name="Register" value="Register" /><br><br>
		
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
