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
    
    $("#Reservation-Email-1").hide();
		 $("#Reservation-Email-2").hide();
		 $("#Reservation-Email-3").hide();
		 $("#Reservation-Email-4").hide();
		 $("#Reservation-Email-5").hide();
		 
		 $( "#Additional-visitors" ).change(function() {
		 var Values = $( "#Additional-visitors option:selected" ).val();
  		 if(Values == 0) {
		 $("#Reservation-Email-1").hide();
		 $("#Reservation-Email-2").hide();
		 $("#Reservation-Email-3").hide();
		 $("#Reservation-Email-4").hide();
		 $("#Reservation-Email-5").hide();
		 }
		 
		   		 if(Values == 1) {
		 $("#Reservation-Email-1").show();
		 $("#Reservation-Email-2").hide();
		 $("#Reservation-Email-3").hide();
		 $("#Reservation-Email-4").hide();
		 $("#Reservation-Email-5").hide();
		 }
		 
		   		 if(Values == 2) {
		 $("#Reservation-Email-1").show();
		 $("#Reservation-Email-2").show();
		 $("#Reservation-Email-3").hide();
		 $("#Reservation-Email-4").hide();
		 $("#Reservation-Email-5").hide();
		 }
		 
		   		 if(Values == 3) {
		 $("#Reservation-Email-1").show();
		 $("#Reservation-Email-2").show();
		 $("#Reservation-Email-3").show();
		 $("#Reservation-Email-4").hide();
		 $("#Reservation-Email-5").hide();
		 }
		 
		   		 if(Values == 4) {
		 $("#Reservation-Email-1").show();
		 $("#Reservation-Email-2").show();
		 $("#Reservation-Email-3").show();
		 $("#Reservation-Email-4").show();
		 $("#Reservation-Email-5").hide();
		 }
		 
		  if(Values == 5) {
		 $("#Reservation-Email-1").show();
		 $("#Reservation-Email-2").show();
		 $("#Reservation-Email-3").show();
		 $("#Reservation-Email-4").show();
		 $("#Reservation-Email-5").show();
		 }
                 });
    var title = "Camping Spot Reservation";
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
				<h2>Camping spot reservation</h2>
			</div>
			
			<div id="ReservationText">
			
			To reserve a camping spot for the weekend you need to be registered.<br>
			You can add additional visitors for the camping spot but they also need to be registered.<br>
			The price for  reserving a camping spot is 30 euro plus 20 euro for every additional visitor.<br><br>
			
			Select camping spot:<br> 
			<select name="Camping spot">
			<option value="Camping spot">no camping spot</option>
			</select><br><br>

			Additional visitors:
			<select name="Additional visitors" id="Additional-visitors">
			<option value="0">0</option>
			<option value="1">1</option>
			<option value="2">2</option>
			<option value="3">3</option>
			<option value="4">4</option>
			<option value="5">5</option>
			</select><br><br>
                        
			<form id="Reservation-Form" action="" method="POST">
                            
			<div id="Reservation-Email-1">
			<b>Email</b><br>
			<input pattern=".{,25}" title="Maximum 25 characters" type="email" name="Email" placeholder="Email"><br><br>
			</div>
			
			<div id="Reservation-Email-2">
			<b>Email</b><br>
			<input pattern=".{,25}" title="Maximum 25 characters" type="email" name="Email" placeholder="Email"><br><br>
			</div>
						
			
			
			<div id="Reservation-Email-3">
			<b>Email</b><br>
			<input pattern=".{,25}" title="Maximum 25 characters" type="email" name="Email" placeholder="Email"><br><br>
			</div>
						
			
			<div id="Reservation-Email-4">
			<b>Email</b><br>
			<input pattern=".{,25}" title="Maximum 25 characters" type="email" name="Email" placeholder="Email"><br><br>
			</div>
						
			
			<div id="Reservation-Email-5">
			<b>Email</b><br>
			<input pattern=".{,25}" title="Maximum 25 characters" type="email" name="Email" placeholder="Email"><br><br>
			</div>
			
			
			Price:<br><br>
			
			<input type="submit" name="Payment" value="Continue to Payment"><br><br>
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
