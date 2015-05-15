		<ul class="nav navbar-nav navbar-left" id="Left-Navbar">

<?php
        if (isset($_SESSION['username'])){
?>
<script> 
$(document).ready(function(){

	$("#Login-Panel").hide();
        $("#Login-Panel-2").hide();
        $("#Login-Button").hide();
        $("#Logout").show();

    });
</script> 
<?php
        }
?>

                                    
				<div id="Login-Panel">
                                <form action="" method="POST">
                                    
                                <input type="text" name="username" placeholder="Username">


                                <input type="password" name="password" placeholder="Password">

					
                                <input id="Login-Button-1" type="submit" name="Login" value="Login">
					
				</form>
					
					<br>
					  
				</div>
                                <div id="Login-Panel-2">
				<button class="link" id="Login-Button" >Login</button>
                                <a  href="Register.php" id="Register" >Register</a>
				<a  href="Forgotten.php" id="Forgotten-password" >Forgotten password</a>
                                </div>
                                <form id="Logout" action="" method="POST">
                                <div style="color: gray">
                                <li class="dropdown">Welcome,&nbsp
				<a href="#" class="dropdown-toggle" data-toggle="dropdown" style="color: lightblue"><?php 
                                if (isset($_COOKIE['username'])) { 
                                    $username_cookie = $_COOKIE['username'];
                                if ($username_cookie == $username) { 
                                    echo $username_cookie;
                                   }
                                   else{
                                    echo $username;   
                                   }
                                   if ($username == NULL) { 
                                    echo $username_cookie;
                                   }
                                   }
                                   else{
                                    echo $username;   
                                   }
                                ?><b class="caret"></b></a>
					<ul class="dropdown-menu " style="text-align: center">
                                            <li><a href="Profile.php" >Settings</a></li>
                                            <li><a href="Balance.php" >Balance</a></li>
                                            <li><a href="Tickets.php" >Tickets</a></li>
                                            <li><a href="Reservation.php" >Camping spot</a></li>
                                            <li><a href="Booked.php" >Booked Items</a></li>
                                            <li><input type="submit" name="Logout" value="Logout"></li>
					</ul>
                                    &nbsp&nbsp<input type="submit" name="Logout" value="Logout">
					</li> 
                                </div>
                                </form>
                </ul>
				
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="index.php">Home</a>
                    </li>
					<li class="dropdown">
					<a href="#" class="dropdown-toggle" data-toggle="dropdown">Event<b class="caret"></b></a>
					<ul class="dropdown-menu " >
					<li><a href="Visitors.php" >Info</a></li>
                                        <li><a href="Location.php" >Location</a></li>
					</ul>
					</li>
                    <li>
                        <a href="Schedule.php">Schedule</a>
                    </li>
					<li class="dropdown">
					<a href="#" class="dropdown-toggle" data-toggle="dropdown">Leagues<b class="caret"></b></a>
					<ul class="dropdown-menu " >
					<li><a href="RoboCup Soccer.php" >RoboCup Soccer</a></li>
					<li><a href="RoboCup Rescue.php" >RoboCup Rescue</a></li>
					<li><a href="RoboCupJunior.php" >RoboCupJunior </a></li>
					<li><a href="RoboCup@Home.php" >RoboCup@Home </a></li>
					<li><a href="RoboCup@Work.php" >RoboCup@Work </a></li>
					</ul>
					</li>
					<li class="dropdown">
					<a href="#" class="dropdown-toggle" data-toggle="dropdown">About<b class="caret"></b></a>
					<ul class="dropdown-menu" >
					<li><a href="Sponsors.php">Sponsors</a></li>
					<li><a href="Contact Information.php">Contact Information</a></li>
					</ul>
					</li>
                </ul>