<?php
require('connect.php');
 $username = $_COOKIE['username'];
        $query = "SELECT ID FROM `users` WHERE username='$username'";
        $result = mysql_query($query);
        while ($row = mysql_fetch_assoc($result)) {
     $rows[] = $row;
}
    
foreach($rows as $row) {
$UserID = $row["ID"];
}
        $query1 = "SELECT Ticket FROM visitors WHERE User_ID='$UserID'";
        $result1 = mysql_query($query1);
        
     while ($row1 = mysql_fetch_assoc($result1)) {
     $rows1[] = $row1;
}
    
foreach($rows1 as $row1) {
$Has_Ticket = $row1["Ticket"];
}
        $query5 = "SELECT Balance FROM visitors WHERE User_ID='$UserID'";
        $result5 = mysql_query($query5);
        while ($row2 = mysql_fetch_assoc($result5)) {
        $rows2[] = $row2;
        }
    
        foreach($rows2 as $row2) {
        $Balance = $row2["Balance"];
}    
$Pay = $_POST['Pay'];
if($Pay > $Balance){
    $msg = "You dont have enought money in your balance.";
}
 else {
  $Amount = $Balance - $Pay;  
        
        $query6 = "UPDATE `visitors` SET `Balance`='$Amount' WHERE User_ID='$UserID'";
        $result6 = mysql_query($query6);

        if($Has_Ticket == 0){
        $query2 = "UPDATE `visitors` SET `Ticket`='1' WHERE User_ID='$UserID'";
        $result2 = mysql_query($query2); 
        }
 else {
     
 }
 }
 

    

    

    