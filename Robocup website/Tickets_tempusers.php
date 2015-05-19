<?php
require('connect.php');
     $users =$_POST["users"];

foreach ($users as $x){
    
    $query_Check1 = "SELECT Email FROM tempusers WHERE Email='".$x["Email"]."' ";
$result_Check1 = mysql_query($query_Check1);
    
    if(mysql_num_rows($result_Check1)>0){
        $msg = "User with email: ".$x["Email"]." already exist.";
    }else{
$query3 = "INSERT INTO `tempusers` (Email,FirstName,LastName) VALUES ('".$x["Email"]."','".$x["FirstName"]."','".$x["LastName"]."')";
$result3 = mysql_query($query3);
echo mysql_error();
$Email = $x["Email"];
$query4 = "SELECT ID FROM tempusers WHERE Email='$Email' ";
$result4 = mysql_query($query4);
while ($row2 = mysql_fetch_assoc($result4)) {
     $rows2[] = $row2;
}
    
foreach($rows2 as $row2) {
$id = $row2["ID"];
}
$Link = "localhost/completeRegistration?id=".$id;
    $subject = "Your Robocup website registration"; 
    $message = "Hello, in order to complete your registration please follow this link $Link. 
     
    Username:
    Password:
     
    You can change them from your profile settings after you log into the website.
    Thanks! 
    Site admin 
     
    This is an automated response, please do not reply!"; 
     
    mail($x["Email"], $subject, $message, "From: Admin>\n 
        X-Mailer: PHP/" . phpversion()); 
    }
    }
    

    