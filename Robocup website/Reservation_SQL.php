<?php
if ($_POST['Reservation'])
{   
    
    $Buyer = $_COOKIE['username'];
    $query = "SELECT ID FROM users WHERE users.Username='".$Buyer."'";
    $result = mysql_query($query);
    
    $location = $_POST["TentID"];
     while ($row1 = mysql_fetch_assoc($result)) {
     $rows1[] = $row1;
}
foreach($rows1 as $row1) {
$BuyerID = $row1["ID"];
}
    $Days = $_POST["Days"];
    
    $BookedOn = 
    
    $BookedTill;
    if($Days == 1){
      $BookedTill = "2015-05-15";  
    }elseif($Days == 2){
      $BookedTill = "2015-05-16";  
    }elseif($Days == 3){
      $BookedTill = "2015-05-17";  
    }
    
    $BookedOn = date("Y-m-d");
    $IsPayed = 1;
    $query1 = "INSERT INTO `tents` (location, BookedBy, BookedOn, IsPayed, BookedTill) VALUES ('$location','$BuyerID','$BookedOn','$IsPayed','$BookedTill')";
    $result1 = mysql_query($query1);


$Visitors =$_POST["Visitors"];
for($x = 1; $x <= $Visitors; $x++){
    $VEmail = $_POST["Email" . $x];
    $query2 = "SELECT ID FROM users WHERE users.Email='".$VEmail."' ";
    $result2 = mysql_query($query2);
    
    while ($row2 = mysql_fetch_assoc($result2)) {
     $rows2[] = $row2;
}

foreach($rows2 as $row2) {

$VisitorID = $row2["ID"];
}
    
    $query3 = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID) VALUES ('$location', '$VisitorID')";
    $result3 = mysql_query($query3);
}

    if($a = mysql_error())
      {
          $msg = mysql_error();
          
      }
      
}

