<?php
        require('Login.php');
        require('Head.php');
        
        if (isset($_SESSION['username'])){
        $username = $_SESSION['username'];
        $query = "SELECT ID FROM `users` WHERE username='$username'";
        $result = mysql_query($query);
        while ($row = mysql_fetch_assoc($result)) {
     $rows[] = $row;
}
    
foreach($rows as $row) {
$UserID = $row["ID"];
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
    var title = "Booked items";
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
    <div id="Elements-Placement" >
        <?php
	if(isset($msg) & !empty($msg)){
		echo $msg;
	}
        ?>
			<div id="Heading">
				<h2>Booked items</h2>
			</div>
			
	<div id="BookedText" >
            <?php
                                         
                                    $query5 = "SELECT Brand,Model,rentedat,rentedtill FROM items i join rentableitemhistories r on i.ID=r.item_ID WHERE ID=5 ";
                                    $result5 = mysql_query($query5) or die(mysql_error());
                                    while ($row1 = mysql_fetch_assoc($result5)) {
     $rows1[] = $row1;
}


                                    
?>
		Booked items<br>
                <div style="overflow: auto;width: 100%;">
		<select  name="mySelect" size="15" id="ItemsList">
<?php

foreach($rows1 as $row1) {
echo "<option value='0'>";
echo $row1["Brand"]." ".$row1["Model"]." Rented at ".$row1["rentedat"]." Rented till ".$row1["rentedtill"];
echo "</option>";
}
?>
		</select>
	</div>
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
