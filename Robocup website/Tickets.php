<?php

        require('Head.php');
        require('Login.php');
        require('Tickets_SQL.php');
?>

<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script src="http://jqueryvalidation.org/files/dist/jquery.validate.min.js"></script>
<script src="http://jqueryvalidation.org/files/dist/additional-methods.min.js"></script>
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
        
	if(isset($_COOKIE['msg']) & !empty($_COOKIE['msg'])){ 
		echo $_COOKIE['msg'];
                $_COOKIE['msg'] = "";
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
			<b>First Name</b><br>
			<input id="Visitors_FirstName" type="text" pattern=".{1,25}" title="maximum 25 characters" name="FirstName" placeholder="First Name"><br>
			
			<b>Last Name</b><br>
			<input id="Visitors_LastName" type="text" pattern=".{1,25}" title="maximum 25 characters" name="LastName" placeholder="Last Name"><br>
			
                        <b>Email</b><br>
			<input id="Visitors_Email" type="email"   name="field"   placeholder="Email"><br><br>
                        
                        <div id="Message">
                        </div>
                        
                        <button type="button" onclick="Add(),Update_Tickets(),Update_Price()">Add visitor</button>
                        <button type="button" onclick="Remove(),Update_Tickets(),Update_Price()">Remove  visitor</button><br>
                
                
                         
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
		
                            
                             <input id="PaymentBtn" type="button" name="Ticket_payment" value="Continue to Payment" onclick="return  Send_post()"><br><br>
                
                            
			<hr/>
			<div id="Tickets_div">Tickets: <?php echo  $Tickets ?></div><br>
                        
			<div id="Price_div" >Price:  <?php  echo  $Price ?><br></div><br>

                        
                        <script>  
jQuery.validator.setDefaults({
  debug: true,
  success: "valid"
});
$( "#Visitors_Email" ).validate({
  rules: {
    field: {
      required: true,
      email: true
    }
  }
});

       var count = 0;                     
function Add() {
    if(0 == 0){

    count = count+1;
var table  = document.getElementById("table").getElementsByTagName('tbody')[0];
    if($('#Visitors_FirstName').val() !== "" && $('#Visitors_LastName').val() !== "" && $('#Visitors_Email').val() !== ""){
    var row = table.insertRow(table.rows.length);
    row.setAttribute('id',count);
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
}

function Remove() {
    
$('#'+count).remove();
count = count-1;
}
                            
                            var Has_Ticket = parseInt(<?php echo  json_encode($Tickets) ?>);

                            function Update_Tickets() {
                                        var People = parseInt($('#table tr').length);  
                                        var Tickets = (Has_Ticket + People)-1;
                                        jQuery('#Tickets_div').html('Tickets: ');
                                        $('#Tickets_div').append(Tickets);
                            }
                            
                               var Price = 0; 
                            
                            
                            function Update_Price() {
                                        var People = parseInt($('#table tr').length);  
                                        Price  = ((Has_Ticket + People) - 1) * 55;
                                        
                                        jQuery('#Price_div').html('Price: ');
                                        
                                        $('#Price_div').append(Price);
                                        
                                        
                            }
                            function Send_post() {
		
                 
                 
                 var MyRows = $('table#table').find('tbody').find('tr');
var users = [];
console.log(users);
for (var i = 0; i < MyRows.length; i++) {
var Fname = $(MyRows[i]).find('td:eq(0)').html();
var Lname = $(MyRows[i]).find('td:eq(1)').html();
var Email = $(MyRows[i]).find('td:eq(2)').html();
users.push({FirstName:Fname,LastName:Lname,Email:Email});
}


        $.post("Tickets_Pay.php", {users: users,Has_Ticket: Has_Ticket},function(data){window.location.pathname = "Prop/Tickets.php"});
   
    
    }
                        </script>
                        	
                       <div id="name_f"></div>

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
