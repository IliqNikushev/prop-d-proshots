<?php
        require('Login.php');
        require('Head.php');
        require('Reservation_SQL.php');
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
		 
		 $( "#Additional_visitors" ).change(function() {
		 var Values = $( "#Additional_visitors option:selected" ).val();
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
			You can add additional visitors for the camping spot but they need to be registered //and also have a ticket//.<br>
			The price for  reserving a camping spot is 30 euro plus 20 euro for every additional visitor per day.<br><br>

<?php
                                         
                                    $query4 = "SELECT ID FROM `landmarks` WHERE Type='1'";
                                    $result4 = mysql_query($query4) or die(mysql_error());
                                    while ($row = mysql_fetch_assoc($result4)) {
     $rows[] = $row;
}


                                    
?>
<form id="Reservation-Form" action="" method="POST">
			Select camping spot:
                        <select name="TentID" id="Camping_spot">
                        <option value="" selected></option>
<?php

foreach($rows as $row) {
echo "<option value='";
echo $row["ID"];
echo "'>";
echo "Tent" . " " . $row["ID"];
echo "</option>";
}
?>

                            
                        </select> <br><br>
                        Number of days :
                        <select name="Days" id="Number_of_days">
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3" selected>3</option>
			</select><br><br>
                        

			Additional visitors:
			<select name="Visitors" id="Additional_visitors">
			<option value="0">0</option>
			<option value="1">1</option>
			<option value="2">2</option>
			<option value="3">3</option>
			<option value="4">4</option>
			<option value="5">5</option>
			</select><br><br>
                        
                            
			<div id="Reservation-Email-1">
			<b>Email</b><br>
			<input pattern=".{1,25}" title="Maximum 25 characters" type="email" name="Email1" placeholder="Email"><br><br>
			</div>
			
			<div id="Reservation-Email-2">
			<b>Email</b><br>
			<input pattern=".{1,25}" title="Maximum 25 characters" type="email" name="Email2" placeholder="Email"><br><br>
			</div>
						
			
			
			<div id="Reservation-Email-3">
			<b>Email</b><br>
			<input pattern=".{1,25}" title="Maximum 25 characters" type="email" name="Email3" placeholder="Email"><br><br>
			</div>
						
			
			<div id="Reservation-Email-4">
			<b>Email</b><br>
			<input pattern=".{1,25}" title="Maximum 25 characters" type="email" name="Email4" placeholder="Email"><br><br>
			</div>
						
			
			<div id="Reservation-Email-5">
			<b>Email</b><br>
			<input pattern=".{1,25}" title="Maximum 25 characters" type="email" name="Email5" placeholder="Email"><br><br>
			</div>
			
			
			<input type="submit" name="Reservation" value="Continue to Payment"><br><br>
                        
                            <script>
                            
                            $( "#Camping_spot" ).change(function() {
                            Update_Price();
                            $.post("Reservation_SQL.php", {TentID: TentID});
                            });
                            
                            $( "#Number_of_days" ).change(function() {
                            Update_Price();
                            $.post("Reservation_SQL.php", {Days: Days});
                            });
                            
                            $( "#Additional_visitors" ).change(function() {
                            Update_Price()
                            $.post("Reservation_SQL.php", {Visitors: Visitors});
                            });
                            
                            function Update_Price() {
                                var Camping_price = 30;
                                var Visitors_price = 20;
                                var Price = 0;
                                if($('#Camping_spot').val() != 0){
                                    Price = Camping_price * $('#Number_of_days').val() + $('#Additional_visitors').val() * 20 + " euro";
                                    jQuery('#Price_div').html('Price: ');
                                    $('#Price_div').append(Price);
                                }
                                else{
                                    jQuery('#Price_div').html('Price: ');
                                    $('#Price_div').append("");
                                }
                                        
                            }
                            </script>
                        
			</form>
                        

                        
			<div id="Price_div">Price:  <?php  echo  $Price ?><br></div><br>
                        
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
