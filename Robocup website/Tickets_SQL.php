<?php
        if (isset($_SESSION['username'])){
        $username = $_SESSION['username'];
        $query = "SELECT ID FROM `users` WHERE username='$username'";
        $UsersID_result = mysql_query($query);
        while ($row = mysql_fetch_assoc($UsersID_result)) {
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
        
        if ($Has_Ticket == 0){
        $Tickets = "1";
        $Price = 55;
        }elseif($Has_Ticket == 1){
        $Tickets = "0";
        $Price = "0";
        }
        }
?>


    

    


    