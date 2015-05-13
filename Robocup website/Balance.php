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
    var title = "Balance";
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
				<h2>Balance</h2>
			</div>
			
			<div id="BalanceText">
			Your current balance is:<br><br>
			You can recharge your balance using your paypal account.<br><br>
			Please select the amount of balance you want to load:<br><br>
			<select name="Load amount">
			<option value="5 EUR">5 EUR</option>
			<option value="10 EUR">10 EUR</option>
			<option value="20 EUR">20 EUR</option>
			<option value="30 EUR">30 EUR</option>
			<option value="40 EUR">40 EUR</option>
			<option value="50 EUR">50 EUR</option>
			</select><br><br>
			<input type="submit" name="Payment" value="Continue to Payment"><br><br>
			
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
