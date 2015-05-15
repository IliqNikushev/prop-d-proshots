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
        $query1 = "SELECT Ticket FROM visitors WHERE User_ID='$UserID'";
        $result1 = mysql_query($query1);
        
        while ($row = mysql_fetch_assoc($result1)) {
     $rows[] = $row;
}
    
foreach($rows as $row) {
$Has_Ticket = $row["Ticket"];
}
        
        if ($Has_Ticket == 0){
        $Tickets = "1";
        $Price = 55;
        }elseif($Has_Ticket == 1){
        $Tickets = "0";
        $Price = 0;
        }
        }

if ($_POST['Payment'])
{   
    $users =$_POST["users"];


    foreach ($users as $x){
$query = "INSERT INTO `tempusers` (Email,FirstName,LastName) VALUES ('".$x["Email"]."','".$x["FirstName"]."','".$x["LastName"]."')";
echo $query;
$result = mysql_query($query);echo mysql_error();
    $Email = $x["Email"];
$query1 = "SELECT ID FROM tempusers WHERE Email='$Email' ";
$result = mysql_query($query1);
$id = $result;
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