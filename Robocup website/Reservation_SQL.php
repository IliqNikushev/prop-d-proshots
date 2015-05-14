<?php
require('connect.php');
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

    $query1 = "INSERT INTO `tents` (location, BookedBy) VALUES ('$location','$BuyerID')";
    $result1 = mysql_query($query1);

$Days = $_POST["Days"];


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
    
    $query3 = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID, CheckedInTime) VALUES ('$location', '$VisitorID', NULL)";
    $result3 = mysql_query($query3);
}

    if($a = mysql_error())
      {
          $msg = mysql_error();
          
      }

}

