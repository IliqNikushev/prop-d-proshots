<?php
	require('Login.php');
?><!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.

-->
<?php
	session_start() ;

	$username = $user = $first = $last = $email = $address = '' ;
	
	//===> Login <===\\
	if(isset($_POST['user'])){
		$user = $_POST['user'] ;
		$pass = $_POST['pass'] ;
		if($user == ''){
			$message = 'enter user for login' ;
		}else if(!preg_match('/^[A-Za-z0-9_]+$/' ,$user)){
			$message = 'enter valid user for login' ;
		}else if($pass == ''){
			$message = 'enter password' ;
		}else{
			$query = "SELECT * FROM `users` WHERE `username` = '{$user}' LIMIT 1" ;
			$result = mysql_query($query) ;
			
			if(!$result){
				$message = mysql_error() ;
			}else if(mysql_num_rows($result) == 0){
				$message = 'user not found';
			}else{
				$data = mysql_fetch_array($result) ;
				
				if($data['password'] != $pass){
					$message = 'password not correct' ;
				}else{
					$message = 'login ok' ;
					$_SESSION['username'] = $data['username'] ;
					$_SESSION['first_name'] = $data['first_name'] ;
					$_SESSION['last_name'] = $data['last_name'] ;
					$_SESSION['email'] = $data['email'] ;
					$_SESSION['address'] = $data['address'] ;
					$_SESSION['time'] = time() ; //===> for check activity time ex: now time - session time > 3600 thene session destroy
					header("Location: index.php") ;
					exit() ;
				}
			
			}
		
		}
	
	}
	
	//===> Create Account <===\\
	if(isset($_POST['username'])){
		$username 	= $_POST['username'] ;
		$password 	= $_POST['password'] ;
		$first		= $_POST['first'] ;
		$last 		= $_POST['last'] ;
		$email 		= $_POST['email'] ;
		$address 	= $_POST['address'] ;
		$toggel 	= 'create' ; //==> for toggel in login and create account form
		$upload		= true ;
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
		if($username == ''){
			$message = 'enter user name' ;
		}else if(!preg_match('/^[A-Za-z0-9_]+$/' ,$username)){
			$message = 'enter correct user name' ;
		}else if($password == ''){
			$message = 'enter password' ;
		}else if(strlen($password) < 6){
			$message = 'enter password lenght min 6' ;
		}else if($first == ''){
			$message = 'enter first name' ;
		}else if($last == ''){
			$message = 'enter last name' ;
		}else if($email == ''){
			$message = 'enter email' ;
		}else if(!filter_var($email, FILTER_VALIDATE_EMAIL)){
			$message  = 'enter valid email' ;
		}else if(!$upload){
			$message = 'error in upload <br />'. $image_message ;
		}else{
			$address = addslashes(nl2br($address)) ;
			$query = "INSERT INTO `users` (`username` ,`password` ,`first_name` ,`last_name` ,`email` ,`address` ,`image`) 
									VALUES ('{$username}' ,'{$password}' ,'{$first}' ,'{$last}' ,'{$email}' ,'{$address}' ,'{$image_name}')" ;
									
			$result = mysql_query($query) ;
			if(!$result){
				if(mysql_errno() == 1062){
					$message = 'user name already exist' ;
				}else{
					$message = mysql_error() ;
				}
			}else{
				$message = 'username created' ;
			}
		}
	}


?><html>
    <head>
        <title>Login</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
         <meta http-equiv="X-UA-Compatible" content="IE=edge">
         <meta name="viewport" content="width=device-width, initial-scale=1">
          <meta name="description" content="">
    <meta name="author" content="">
   
    <!-- Michael Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/agency.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="http://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">
    <link href='http://fonts.googleapis.com/css?family=Kaushan+Script' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700' rel='stylesheet' type='text/css'>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

    
    </head>
    <body id="page-top" class="index">

    <!-- Navigation -->
    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header page-scroll">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand page-scroll" href="index.php#page-top">Moore!</a></div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li class="hidden">
                        <a href="#page-top"></a>
                    </li>
                    <li>
                        <a class="page-scroll" href="index.php#services">Services</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="index.php#portfolio">Profiles</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="index.php#about">About</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="index.php#team">Team</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="index.php#contact">Contact</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>

    <!-- Header -->
    <header>
        <div class="container">
            <div class="intro-text"></div>
                
        </div>
    </header>

    <!-- Services Section --><!-- Portfolio Grid Section -->
    <section id="portfolio" class="bg-light-gray">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2 class="section-heading">Login</h2>
                    <h3 class="section-subheading text-muted">Join us to access moore!</h3>
                </div>
            </div>
            <div  class="center-block" align="center" >
              <div  align="center">
            <div><link class="cssdeck" rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/2.3.1/css/bootstrap.min.css">
<link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/2.3.1/css/bootstrap-responsive.min.css" class="cssdeck">

<div class="" id="loginModal">
	<!--<div class="modal-header">
		<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
		
	</div> -->
	<div class="modal-body">
		<div class="well">
<?php
			if(isset($message) && $message != ''){
?>
			<div class="alert alert-danger alert-dismissible" id="message" role="alert">
				<button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
				<?php echo $message ; ?>
			</div>
<?php
			}
?>
			<ul class="nav nav-tabs">
				<li class="<?php echo (!isset($toggel)? 'active' : ''); ?>"><a href="#login" data-toggle="tab">Login</a></li>
				<li class="<?php echo (isset($toggel)? 'active' : ''); ?>"><a href="#create" data-toggle="tab">Create Account</a></li>
			</ul>
			<div id="myTabContent" class="tab-content">
				<div class="tab-pane <?php echo (!isset($toggel)? 'active in' : 'fade'); ?>" id="login">
					<form class="form-horizontal" action='#portfolio' method="POST">
						<fieldset>
							<div id="legend">
								<legend class="">Login</legend>
							</div>    
							<div class="control-group">
								<!-- Username -->
								<label class="control-label" for="user">Username</label>
								<div class="controls">
									<input type="text" id="user" name="user" placeholder="Username" class="input-xlarge">
								</div>
							</div>
							
							<div class="control-group">
								<!-- Password-->
								<label class="control-label" for="pass">Password</label>
								<div class="controls">
									<input type="password" id="pass" name="pass" placeholder="" class="input-xlarge">
								</div>
							</div>
							
							
							<div class="control-group">
								<!-- Button -->
								<div class="controls">
									<button class="btn btn-success">Login</button>
								</div>
							</div>
						</fieldset>
					</form>                
				</div>
				<div class="tab-pane <?php echo (isset($toggel)? 'active in' : 'fade'); ?>" id="create">
					<form id="tab" action="#portfolio" method="post" enctype="multipart/form-data">
						<label for="username">Username</label>
						<input type="text" name="username" id="username" value="<?php echo ($username != '' ? $username : '') ; ?>" class="input-xlarge" />
						
						<label for="password">Password</label>
						<input type="password" name="password" id="password" value="" class="input-xlarge" />
						
						<label for="first">First Name</label>
						<input type="text" name="first" id="first" value="<?php echo ($first != '' ? $first : '') ; ?>" class="input-xlarge" />
						
						<label for="last">Last Name</label>
						<input type="text" name="last" id="last" value="<?php echo ($last != '' ? $last : '') ; ?>" class="input-xlarge" />
						
						<label for="email">Email</label>
						<input type="email" name="email" id="email" value="<?php echo ($email != '' ? $email : '') ; ?>" class="input-xlarge" />
						
						<label for="address">Address</label>
						<textarea name="address" id="address" rows="3" class="input-xlarge"><?php echo ($address != '' ? stripslashes($address) : '') ; ?></textarea>
						
						<label for="image">Image</label>
						<input type="file" name="image" id="image" class="input-xlarge" />
						<br />
						<div>
							<button class="btn btn-primary" type="submit">Create Account</button>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>

<script class="cssdeck" src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script class="cssdeck" src="//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/2.3.1/js/bootstrap.min.js"></script></div>

    
    

</body>

</html>

    
