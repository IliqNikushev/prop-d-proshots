<?php
require_once 'login.php';
require_once 'Input.php'; 

//getting username from the session
if(!isset($_SESSION['username']))
{
    $username = $_SESSION['username'];
}

//check if post exists
if (Input::exists('post', 'proceedPaypal')) {

    $visitor = $conn->query("SELECT * FROM users where Username = '$username'")->fetch();
    $visitorID = $visitor['ID'];

    $amount = Input::get('amount');
    $paypalID = Input::get('paypalID');
    $dateCreated = date("Y-m-d H:i:s");

    $query = "INSERT INTO `paypaldeposits` (visitor_id, amount, Date, paypal_document_id) VALUES ('$visitorID', '$amount', '$dateCreated', '$paypalID')";
    
    $count = $conn->query("SELECT Count(*) FROM paypaldeposits where id = '$visitorID'")->fetch();
      
    $raw = "";
    $raw += rand(1, 10) . rand(1, 10) . rand(1, 10) . rand(1, 10) . rand(1, 10) . rand(1, 10) . rand(1, 10) . $visitorID;
    $raw =+ $dateCreated . "\n";
    $raw += $count . "\n";
    $raw += rand(100, 1000) . $visitorID . " " . $amount . "\n";

    $query2 = "INSERT INTO `paypaldocuments` (Date, Raw) VALUES ('$dateCreated', '$raw')";
    mysql_query($query);
    mysql_query($query2); 

    //if its successfull redirect, or show a message.
    //header(Location: index.php);
}

?>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Sign In</title>
<link href="buying-page.css" rel="stylesheet" type="text/css">

</head>
<body>
<header>
     
</header>
<div class="main">

     <div class="container">
          <section class="hgroup">
               <h1>Log in your account</h1>
               <ul class="breadcrumb pull-right">
                    <li><a href="index.php">Home</a></li>
                    <li class="active">Log In</li>
               </ul>
          </section>

          <section>
               <div class="row">
               <h4 class="pull-left"><a href="register.php">&nbsp&nbsp&nbsp&nbspDon't have an account yet?</a></h4>
               <div class="col-sm-12">
                         <div class="signup">
                              <form action="" method="post">
                                   <fieldset>
                                        
                                        <div class="row"> 
                                             <div class="col-sm-6 col-sm-offset-3">
                                                  <img width="250" height="100" src="paypal.png" alt="">

                                                  <h3>Your Order Summary</h3>
                                                  <hr>
                                                  <form action="" method="post">
                                                  <table class="table table-bordered">
                                                   <thead>
                                                      <tr>
                                                         <th>Description</th>
                                                         <th>Ammount</th>
                                                      </tr>
                                                   </thead>
                                                   <tbody>
                                                      
                                                      <tr>
                                                         <td>Paypal Id</td>
                                                         <td><input id="paypalID" name="paypalID" placeholder="Paypal ID" class="form-control" required="" type="text" autocomplete="off"></td>
                                                      </tr>
                                                      <tr>
                                                         <td>Amount of money</td>
                                                         <td><input id="amount" name="amount" placeholder="Amount of money" class="form-control" required="" type="text" autocomplete="off"></td>
                                                      </tr>
                                                   </tbody>
                                                </table>
                                                <br>
                                                <div class="col-sm-8 col-sm-offset-2">
                                                  <h3>Paypal Account</h3>
                                                  
                                                
                                                  
                                                  <input id="username" name="username" placeholder="Username" class="form-control" required="" type="text" autocomplete="off">
                                                  <input id="password" name="password" placeholder="Password" class="form-control" required="" type="password" autocomplete="off">
                                                  <?php //echo $errorMessage; ?>
                                                  <a href="#">Forgot your password?</a>
                                                  <br>
                                                   <input class="btn btn-success btn-lg" name="proceedPaypal" type="submit" value="Pay now">

  
                                                </form>
                                                </div>
                                             </div>
                                        </div>
                                   </fieldset>
                              </form>
                              <br><br>
                            </div>
                         </div>
                    </div>
               </div>
          </section>
     </div>
     
</div>
<script src="http://code.jquery.com/jquery-latest.min.js"></script>
<script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>


</body>
</html>