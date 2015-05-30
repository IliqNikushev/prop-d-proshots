<?php

require('connect.php');
$ID = $_GET['id'];
if ($_POST['Complete_Registration']) {
    $query = "SELECT * FROM tempusers WHERE ID='$ID' ";
    $Tempusers_result = mysql_query($query);




    while ($row = mysql_fetch_assoc($Tempusers_result)) {
        $rows[] = $row;
    }

    foreach ($rows as $row) {
        $FirstName = $row["FirstName"];
        $LastName = $row["LastName"];
        $Email = $row["Email"];
    }

    $Username = $_POST['Username'];
    if ($_POST['FirstName'] != "") {
        $FirstName = $_POST['FirstName'];
    }
    if ($_POST['LastName'] != "") {
        $LastName = $_POST['LastName'];
    }
    $Password = $_POST['Password'];
    $Type = "visitor";
    $image_name = '';

    $query1 = "INSERT INTO `users` (FirstName,LastName, Email, Username, Password , Type, Picture) VALUES ('$FirstName', '$LastName', '$Email', '$Username', '$Password', '$Type','$image_name')";
    $Users_insert_result = mysql_query($query1);

    $query2 = "SELECT ID FROM `users` WHERE username='$Username'";
    $UsersID_result = mysql_query($query2);
    while ($row1 = mysql_fetch_assoc($UsersID_result)) {
        $rows1[] = $row1;
    }



    foreach ($rows1 as $row1) {

        $UserID = $row1["ID"];
    }

    $query3 = "DELETE FROM `tempusers` WHERE ID = '$ID' ";
    $Tempusers_delete_result = mysql_query($query3);

    $Balance = 0;
    $Ticket = 1;
    $query4 = "INSERT INTO `visitors` (User_ID, Balance, Ticket) VALUES ('$UserID', '$Balance', '$Ticket')";
    $Visitors_insert_result = mysql_query($query4);
    header("Location: https://athena.fhict.nl/webdir/i317294/Prop//index.php");
    exit();
}

