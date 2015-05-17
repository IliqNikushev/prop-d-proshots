<?php
if ($_POST['Reservation'])
{   
    
    $Buyer = $_COOKIE['username'];
    $query = "SELECT ID FROM users WHERE users.Username='".$Buyer."'";
    $result = mysql_query($query);
    
    $location = $_POST["TentID"];
    
    $query10 = "SELECT location FROM tents WHERE location='".$location."'";
    $result10 = mysql_query($query10);
    if(mysql_num_rows($result10)>0){
        $msg = "Tent is already reserved.";
    }
 else {
     while ($row1 = mysql_fetch_assoc($result)) {
     $rows1[] = $row1;
}
foreach($rows1 as $row1) {
$BuyerID = $row1["ID"];
}

$query11 = "SELECT BookedBy FROM tents WHERE BookedBy='".$BuyerID."'";
$result11 = mysql_query($query11);

if(mysql_num_rows($result11)>0){
    $msg = "You had already booked a camping spot.";
}
 else {
    
    $Days = $_POST["Days"];
    
    
    $BookedTill;
    if($Days == 1){
      $BookedTill = "2015-07-15";  
    }elseif($Days == 2){
      $BookedTill = "2015-07-16";  
    }elseif($Days == 3){
      $BookedTill = "2015-07-17";  
    }
    
    $BookedOn = date("Y-m-d");
    $IsPayed = 1;
    $query1 = "INSERT INTO `tents` (location, BookedBy, BookedOn, IsPayed, BookedTill) VALUES ('$location','$BuyerID','$BookedOn','$IsPayed','$BookedTill')";
    $result1 = mysql_query($query1);
    $query2 = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID) VALUES ('$location', '$BuyerID')";
    $result2 = mysql_query($query2);


$Visitors =$_POST["Visitors"];
for($x = 1; $x <= $Visitors; $x++){
    $VEmail = $_POST["Email" . $x];
    $query3 = "SELECT ID FROM users WHERE users.Email='".$VEmail."' ";
    $result3 = mysql_query($query3);
    
    while ($row3 = mysql_fetch_assoc($result3)) {
     $rows3[] = $row3;
}

foreach($rows3 as $row3) {

$VisitorID = $row3["ID"];
}
    
$query12 = "SELECT Visitor_ID FROM tentpeople WHERE Visitor_ID='".$VisitorID."' ";
$result12 = mysql_query($query12);
 if(mysql_num_rows($result12)>0){
     
    $msg = "The user with email: " . $VEmail . " " . "cannot reserve a camping spot";
     
    $query2 = "DELETE FROM `tentpeople` WHERE Tent_ID='$location'";
    $result2 = mysql_query($query2);
    $query1 = "DELETE FROM `tents` WHERE  BookedBy='$BuyerID'";
    $result1 = mysql_query($query1);
 }   
 else {
    $query4 = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID) VALUES ('$location', '$VisitorID')";
    $result4 = mysql_query($query4);}
}

    if($a = mysql_error())
      {
          $msg = mysql_error();
          
      }
      }
      }
      echo json_encode($query10);
}

