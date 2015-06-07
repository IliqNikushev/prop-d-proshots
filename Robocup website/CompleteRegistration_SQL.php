<?php
if ($_POST['Complete_Registration']) {
    $ID = $_GET['id'];
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

    $query1 = "INSERT INTO `users` (FirstName,LastName, Email, Username, Password , Type) VALUES ('$FirstName', '$LastName', '$Email', '$Username', '$Password', '$Type')";
    $Users_insert_result = mysql_query($query1);

    $query2 = "SELECT ID FROM `users` WHERE username='$Username'";
    $UsersID_result = mysql_query($query2);
    while ($row1 = mysql_fetch_assoc($UsersID_result)) {
        $rows1[] = $row1;
    }



    foreach ($rows1 as $row1) {

        $UserID = $row1["ID"];
    }

        $Balance = 0;
    $Ticket = 1;
    $dateCreated = date("Y-m-d H:i:s");
    $image_name = 'Default.jpg';
    $query4 = "INSERT INTO `visitors` (User_ID, Balance, Ticket, picture, dateCreated) VALUES ('$UserID', '$Balance', '$Ticket', '$image_name', '$dateCreated')";
    $Visitors_insert_result = mysql_query($query4);
    
    $query3 = "DELETE FROM `tempusers` WHERE ID = '$ID' ";
    $Tempusers_delete_result = mysql_query($query3);

    header("Location: https://athena.fhict.nl/webdir/i317294/Prop//index.php");
    exit();
}

