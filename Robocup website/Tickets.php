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
    var title = "Tickets";
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
				<h2>Buy tickets</h2>
			</div>
			
			<div id="TicketsText">
			
			You can buy ticket for yourself and for you friends.<br>
			The price of one ticket is 55 euro.<br>
			After entering information for the additional visitors they will recive a message with information about their registration.<br><br>
			
			 Visitors:<br><br>
                         <form>
			<b>First Name</b><br>
			<input id="Visitors_FirstName" type="text" pattern=".{1,25}" title="maximum 25 characters" name="FirstName" placeholder="First Name"><br>
			
			<b>Last Name</b><br>
			<input id="Visitors_LastName" type="text" pattern=".{1,25}" title="maximum 25 characters" name="LastName" placeholder="Last Name"><br>
			
			<b>Email</b><br>
			<input id="Visitors_Email" required pattern=".{6,25}" title="from 6 to 25 characters" type="email" name="Email" placeholder="Email"><br><br>
                        
                        <div id="Message">
                        </div>
                        
                        <button type="button" onclick="Add(),Update_Tickets(),Update_Price()">Add visitor</button>
                        <button type="button" onclick="Remove()">Remove  visitor</button><br>
			</form>
<script>        
function Add() {
    var table  = document.getElementById("table").getElementsByTagName('tbody')[0];
    if($('#Visitors_FirstName').val() !== "" && $('#Visitors_LastName').val() !== "" && $('#Visitors_Email').val() !== ""){
    var row = table.insertRow(table.rows.length);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    cell1.innerHTML = $('#Visitors_FirstName').val();
    cell2.innerHTML = $('#Visitors_LastName').val();
    cell3.innerHTML = $('#Visitors_Email').val();
    
    var TicketsTextHeight = $('#TicketsText').height();
    $('#TicketsText').height(TicketsTextHeight + 30);
    }
    else{
        $('#Message').text("All fields must be filled!");
    }
}
function Remove() {
var MyRows = $('table#table').find('tbody').find('tr');
for (var i = 0; i < MyRows.length; i++) {
var FName = $(MyRows[i]).find('td:eq(0)').html();
var Lname = $(MyRows[i]).find('td:eq(1)').html();
var Email = $(MyRows[i]).find('td:eq(2)').html();
$.post("Payment.php", {FirstName: FName,LastName: Lname,Email: Email}, function(x){console.log(x)})}

}
</script>

                
                <form id="Tickets-Form" action="" method="POST">
		<table id="table" border="1" style="width:100%">
                    <thead>
                      <tr>
                        <th>Firstname</th>
                        <th>Lastname</th>
                        <th>Email</th>
                      </tr>
                      </thead>
                      <tbody>
                          </tbody>
		</table>
		

		<input type="submit" name="Payment" value="Continue to Payment"><br><br>
                </form>
<?php
if (isset($_SESSION['username'])){
$query = "SELECT Ticket FROM users WHERE username='$username_cookie'";
$result = mysql_query($query);
$value  = mysql_result($result, 0);
if ($value == 0){
$Tickets = "1";
$Price = 55;
}else{
$Tickets = "0";
$Price = 0;
}
}
?>
                

	 					
			<hr/>
			<div id="Tickets_div">Tickets: <?php echo  $Tickets ?></div> 
                        <script>
                            var Tickets = <?php echo  json_encode($Tickets) ?>;
                            function Update_Tickets() {
                                        
                                        var TicketsF = ((Tickets).length + $('#table tr').length)-1;
                                        jQuery('#Tickets_div').html('Tickets: ');
                                        $('#Tickets_div').append(TicketsF);
                            }
                             
                            
                        </script><br>
                        
			<div id="Price_div">Price:  <?php  echo  $Price ?> euro<br><br></div>
                        <script>
                            function Update_Price() {
                                        
                                        var Price = (((Tickets).length + $('#table tr').length) - 1) * 55 + " euro";
                                        jQuery('#Price_div').html('Price: ');
                                        $('#Price_div').append(Price);
                                        
                            }
                                        
                        </script>
                        
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
