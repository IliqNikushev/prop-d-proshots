session_start();
<?php
ob_start();
require('connect.php');

$users =$_POST["users"];
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
        $Balance = (int)$Balance;
}    

if($_POST["Has_Ticket"] == 1)
{
    $Pay = 55;
}
else{
    $Pay = 0;
}
foreach ($users as $x){
$Pay = $Pay + 55;
}

if($Pay > $Balance){
    $msg = "You dont have enought money in your balance.";
    setcookie( "msg", "$msg", time() + 15 );
     exit();
}
foreach ($users as $x){
    $query_Check1 = "SELECT Email FROM tempusers WHERE Email='".$x["Email"]."' ";
$result_Check1 = mysql_query($query_Check1);
        $query_Check2 = "SELECT Email FROM users WHERE Email='".$x["Email"]."' ";
$result_Check2 = mysql_query($query_Check2);
    
    if(mysql_num_rows($result_Check1)>0 || mysql_num_rows($result_Check2)>0){
           $msg = "User with email: ".$x["Email"]." already exist.";
            setcookie( "msg", "$msg", time() + 15 );
     exit();
        }
 else {
$query3 = "INSERT INTO `tempusers` (Email,FirstName,LastName) VALUES ('".$x["Email"]."','".$x["FirstName"]."','".$x["LastName"]."')";
$result3 = mysql_query($query3);
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
//        X-Mailer: PHP/" . phpversion()); 
    }
    
    }
         $query2 = "UPDATE `visitors` SET `Ticket`='1' WHERE User_ID='$UserID'";
        $result2 = mysql_query($query2); 
  
      $Amount = $Balance - $Pay; 
    
    $query6 = "UPDATE `visitors` SET `Balance`='$Amount' WHERE User_ID='$UserID'";
        $result6 = mysql_query($query6);
$msg = "You payment was successful.";
setcookie( "msg", "$msg", time() + 15 );
     exit();

        