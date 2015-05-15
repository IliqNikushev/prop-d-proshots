<?php

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
        $query1 = "SELECT Balance FROM visitors WHERE User_ID='$UserID'";
        $result1 = mysql_query($query1);
        while ($row1 = mysql_fetch_assoc($result1)) {
        $rows1[] = $row1;
        }
    
        foreach($rows1 as $row1) {
        $Balance = $row1["Balance"];
}
        }
        
if ($_POST['Balance_load'])
{
    
        $Amount = $Balance + $_POST["Amount"];
        
        $query2 = "UPDATE `visitors` SET `Balance`='$Amount' WHERE User_ID='$UserID'";
        $result2 = mysql_query($query2);

        echo json_encode();
        header("Location: Balance.php");
        exit();
}

?>