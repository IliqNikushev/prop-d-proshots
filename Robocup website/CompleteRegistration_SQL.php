<?php
	require('connect.php');
     //$ID = 1;
if ($_POST['Complete_Registration'])
{
        $query = "SELECT Email,FirstName,LastName FROM tempusers WHERE ID='$ID' ";
        $result = mysql_query($query);
        


                                    
while ($row = mysql_fetch_assoc($result)) {
     $rows[] = $row;
}

foreach($rows as $row) {
 ",FirstName:'" . $row["FirstName"] . ",LastName:'" . $row["LastName"] . ",Email:'" . $row["Email"] . '\'},';
    
}

foreach($rows as $row) {

$FirstName = $row["FirstName"];
$LastName = $row["LastName"];
$Email = $row["Email"];
}
        
        $Username =  $_POST['Username'];
        $Password = $_POST['Password'];
        $Type = 1;
        
        $query1 = "INSERT INTO `users` (FirstName,LastName, Email, Username, Password , Type) VALUES ('$FirstName', '$LastName', '$Email', '$Username', '$Password', '$Type')";
        $result = mysql_query($query1);
        
                                    $query2 = "SELECT ID FROM `users` WHERE username='$Username'";
                                    $result = mysql_query($query2);
                                    while ($row = mysql_fetch_assoc($result)) {
     $rows[] = $row;
}
    


foreach($rows as $row) {

$UserID = $row["ID"];
$Balance = 0;
$Ticket = 1;
}
        
        $query3 = "INSERT INTO `visitors` (User_ID, Balance, Ticket) VALUES ('$UserID', '$Balance', '$Ticket')";
        $result = mysql_query($query3);
}

