<?php
        require('Login.php');
        require('Head.php');

if ($_POST['Send']){ 
$Email = $_POST['Email'];

$Email = mysql_real_escape_string($Email);
$status = "OK";

if($status=="OK"){  $queryF = "SELECT * FROM `users` WHERE email='$Email'";
$st=mysql_query($queryF);
$recs=mysql_num_rows($st);
$row=mysql_fetch_object($st);
$em=$row->email_address;// email is stored to a variable
 if ($recs == 0) {  
$msg = "<p>Sorry your address is not there in our database.";
exit;
}
function makeRandomPassword() { 
          $salt = "abchefghjkmnpqrstuvwxyz0123456789"; 
          srand((double)microtime()*1000000);  
          $i = 0; 
          while ($i <= 7) { 
                $num = rand() % 33; 
                $tmp = substr($salt, $num, 1); 
                $pass = $pass . $tmp; 
                $i++; 
          } 
          return $pass; 
    } 
    $random_password = makeRandomPassword(); 
    $db_password = ($random_password); 
     
    $sql = mysql_query("UPDATE users SET password='$db_password'  
                WHERE email='$Email'"); 
     
    $subject = "Your New Password"; 
    $message = "Hello, you have chosen to reset your password. 
     
    New Password: $random_password 
     
    Thanks! 
    Site admin 
     
    This is an automated response, please do not reply!"; 
     
    mail($Email, $subject, $message, "From: Admin>\n 
        X-Mailer: PHP/" . phpversion()); 
$msg = "Your new password has been send! Please check your email!";
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
    var title = "Forgotten password";
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
			
			<div id="ForgottenText">

                        <form action="" method="POST">
                            
			<b>Enter you email address to recive your password.</b><br><br><br>
			<input required pattern=".{6,25}" title="from 6 to 25 characters" type="email" name="Email" placeholder="Email"><br><br>
                        
			<input type="submit" name="Send" value="Send email">
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
