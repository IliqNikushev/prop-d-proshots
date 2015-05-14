<?php
require('connect.php');
if ($_POST['Save_changes'])
{

        $User = $_COOKIE['username'];
        $FirstName = $_POST['FirstName'];
        $LastName = $_POST['LastName'];
        $Email = $_POST['Email'];
        $Password = $_POST['Password'];

        if($FirstName != ""){
        $query = "UPDATE `users` SET `FirstName`='$FirstName' WHERE users.Username='".$User."'";
        $result = mysql_query($query);
        }
        if($LastName != ""){
        $query = "UPDATE `users` SET `LastName`='$LastName' WHERE users.Username='".$User."'";
        $result = mysql_query($query);
        }
        if($Email != ""){
        $query = "UPDATE `users` SET `Email`='$Email' WHERE users.Username='".$User."'";
        $result = mysql_query($query);
        }
        if($Password != ""){
        $query = "UPDATE `users` SET `Password`='$Password' WHERE users.Username='".$User."'";
        $result = mysql_query($query);
        }
        echo json_encode();    
    
}

