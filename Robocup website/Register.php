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
        $CPassword = $_POST['CPassword'];
        $Type = 'visitor';
        $upload	= true ;
	$image_name = '' ;
                
                
                if(isset($_FILES['image']) && $_FILES['image']['size'] != 0){
			function check_file_name($file_name ,$file_extension ,$base_url){
				$f_name = str_replace('=' ,'' ,base64_encode($file_name.time())) ;
				if(file_exists($base_url.$f_name.'.'.$file_extension)){
					check_file_name($f_name ,$file_extension ,$base_url) ;
				}else{
					return $f_name.'.'.$file_extension ;
				}
			}
			
			$allowedExts = array("jpg", "jpeg", "gif", "png" ,"image/pjpeg" ,"image/gif" ,"image/jpeg" ,"image/png");
			$image_ext = explode("." ,$_FILES['image']['name']) ;
			if(count($image_ext) != 2){
				$image_extt = $image_ext[count($image_ext)-1] ;
			}else{
				$image_extt = $image_ext[1] ;
			}
			if (!in_array($_FILES["image"]["type"] ,$allowedExts)){
				$image_message = 'file extension not allowed' ;
				$upload = false ;
			}else{
				if($_FILES['image']['error'] > 0){
					$image_message = 'error in file upload' ;
					$upload = false ;
				}else{
					$image_name = check_file_name($_FILES['image']['name'] ,$image_extt ,'user_images/') ;
					if(move_uploaded_file($_FILES["image"]["tmp_name"],'user_images/'.$image_name)){
						$image_message = 'upload success' ;
						$upload = true ;
					}else{
						$image_message = 'error in upload image' ;
						$upload = false ;
					}
				}
			}
	
		}
                if(!$upload){
			$msg = 'error in upload <br />'. $image_message ;
		}
                
                
    if($Password == $CPassword){
        
    
        $query = "INSERT INTO `users` (FirstName,LastName, Email, Username, Password , Type ,`Picture`) VALUES ('$FirstName', '$LastName', '$Email', '$Username', '$Password', '$Type' ,'{$image_name}')";
        
        
        $query1 = mysql_query("SELECT Username FROM Users WHERE Username='$Username'");
        $query2 = mysql_query("SELECT Email FROM Users WHERE Email='$Email'");
        
     if (mysql_num_rows($query1)>0 && mysql_num_rows($query2)>0)
  {
     $msg = "Username and Email already exist.";
  }
  
  elseif (mysql_num_rows($query1)>0)
  {
     $msg = "Username already exist.";
  }
   elseif (mysql_num_rows($query2)>0)
  {
     $msg = "Email already exist.";
  }
  else {
      $msg = "User Created Successfully.";
      $result = mysql_query($query);
      

                                    $query3 = "SELECT ID FROM `users` WHERE username='$Username'";
                                    $result1 = mysql_query($query3);
                                    while ($row = mysql_fetch_assoc($result1)) {
     $rows[] = $row;
}
    
}


foreach($rows as $row) {

$UserID = $row["ID"];
$Balance = 0;
$Ticket = 0;
}
$query4 = "INSERT INTO `visitors` (User_ID, Balance, Ticket) VALUES ('$UserID', '$Balance', '$Ticket')";
$result2 = mysql_query($query4);
      
            
         }
 else {
          $msg = "password doesn't match! Try again.";   
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
			
			Please direct all general registration questions and inquiries via email to Help.RoboCup2015@gmail.com.<br>* required<br><br>
			
			<form id="Register-Form" action="" method="POST">
			
			<div style="display: inline-block; width:16%"><b>Username: </b></div>
                        <input required pattern=".{3,25}" title="from 3 to 25 characters" type="text" name="Username" placeholder="Username"> *<br><br>
			
			<div style="display: inline-block; width:16%"><b>First Name: </b></div>
			<input type="text" pattern=".{1,25}" title="maximum 25 characters" name="FirstName" placeholder="First Name"><br><br>
			
			<div style="display: inline-block; width:16%"><b>Last Name: </b></div>
			<input type="text" pattern=".{1,25}" title="maximum 25 characters" name="LastName" placeholder="Last Name"><br><br>
			
			<div style="display: inline-block; width:16%"><b>Password: </b></div>
                        <input required pattern=".{4,25}" title="from 4 to 25 characters" type="password" name="Password" placeholder="Password"> *<br><br>
			
			<div style="display: inline-block; width:16%"><b>Confirm Password: </b></div>
                        <input required type="password" name="CPassword" placeholder="Confirm Password"> *<br><br>
                        
			<div style="display: inline-block; width:16%"><b>Email: </b></div>
			<input required pattern=".{6,25}" title="from 6 to 25 characters" type="email" name="Email" placeholder="Email"> *<br><br>
			
                        <div style="display: inline-block; width:16%" for="image:">Image</div>
			<input type="file" name="image" id="image" class="input-xlarge" /><br><br>
			
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
