<?php
require('connect.php');

$users = $_POST["users"];
$username = $_SESSION['username'];
$query = "SELECT ID FROM `users` WHERE username='$username'";
$result = mysql_query($query);
while ($row = mysql_fetch_assoc($result)) {
    $rows[] = $row;
}

foreach ($rows as $row) {
    $UserID = $row["ID"];
}
$Ticket_query = "SELECT Ticket FROM visitors WHERE User_ID='$UserID'";
$Ticket_result = mysql_query($Ticket_query);

while ($row1 = mysql_fetch_assoc($Ticket_result)) {
    $rows1[] = $row1;
}

foreach ($rows1 as $row1) {
    $Has_Ticket = $row1["Ticket"];
}
$Balance_query = "SELECT Balance FROM visitors WHERE User_ID='$UserID'";
$Balance_result = mysql_query($Balance_query);
while ($row2 = mysql_fetch_assoc($Balance_result)) {
    $rows2[] = $row2;
}

foreach ($rows2 as $row2) {
    $Balance = $row2["Balance"];
    $Balance = (int) $Balance;
}

if ($_POST["Has_Ticket"] == 1) {
    $Pay = 55;
} else {
    $Pay = 0;
}
foreach ($users as $x) {
    $Pay = $Pay + 55;
}

if ($Pay > $Balance) {
    $msg = "You dont have enought money in your balance.";
    setcookie("msg", "$msg", time() + 15);
    exit();
}
 else {
foreach ($users as $x) {
    $query_Check1 = "SELECT Email FROM tempusers WHERE Email='" . $x["Email"] . "' ";
    $result_Check1 = mysql_query($query_Check1);
    $query_Check2 = "SELECT Email FROM users WHERE Email='" . $x["Email"] . "' ";
    $result_Check2 = mysql_query($query_Check2);

    if (mysql_num_rows($result_Check1) > 0 || mysql_num_rows($result_Check2) > 0) {
        $msg = "User with email: " . $x["Email"] . " already exist.";
        setcookie("msg", "$msg", time() + 15);
        exit();
    } 
    else {
        $tempusers_insert_query = "INSERT INTO `tempusers` (Email,FirstName,LastName) VALUES ('" . $x["Email"] . "','" . $x["FirstName"] . "','" . $x["LastName"] . "')";
        $tempusers_insert_result = mysql_query($tempusers_insert_query);
        $Email = $x["Email"];
        $tempusersID_query = "SELECT ID FROM tempusers WHERE Email='$Email' ";
        $tempusersID_result = mysql_query($tempusersID_query);
        while ($row2 = mysql_fetch_assoc($tempusersID_result)) {
            $rows2[] = $row2;
        }

        foreach ($rows2 as $row2) {
            $id = $row2["ID"];
        }
        $Link = "https://athena.fhict.nl/webdir/i317294/Prop/CompleteRegistration.php?id=" . $id;
        $subject = "Your Robocup website registration";
        $message = "Hello, in order to complete your registration please follow this link $Link. 
    

    Username:
    Password:
     
    You can change them from your profile settings after you log into the website.
    Thanks! 
    Site admin 
     
    This is an automated response, please do not reply!";

        require 'PHPMailer\PHPMailerAutoload.php';

        $mail = new PHPMailer;

//        $mail->SMTPDebug = 3;                               // Enable verbose debug output

        $mail->isSMTP();                                      // Set mailer to use SMTP
        $mail->Host = 'smtp1.fontys.nl';  // Specify main and backup SMTP servers
//        $mail->SMTPAuth = true;                               // Enable SMTP authentication
//        $mail->Username = '';                 // SMTP username
//        $mail->Password = '';                           // SMTP password
        $mail->SMTPSecure = 'tls';                            // Enable TLS encryption, `ssl` also accepted
        $mail->Port = 25;                                    // TCP port to connect to

        $mail->From = 'no-reply@fontys.nl';
        $mail->FromName = 'ProShots';
        $mail->addAddress($Email);     // Add a recipient
//        $mail->addReplyTo('info@example.com', 'Information');
//        $mail->addCC('cc@example.com');
//        $mail->addBCC('bcc@example.com');

//        $mail->addAttachment('/var/tmp/file.tar.gz');         // Add attachments
//        $mail->addAttachment('/tmp/image.jpg', 'new.jpg');    // Optional name
        $mail->isHTML(true);                                  // Set email format to HTML

        $mail->Subject = $subject;
        $mail->Body = $message;
        $mail->AltBody = $message;

        if (!$mail->send()) {
            echo 'Message could not be sent.';
        } else {
            echo 'Message has been sent';
        }
    }
}
$UPDATE_visitors_Ticket_query = "UPDATE `visitors` SET `Ticket`='1' WHERE User_ID='$UserID'";
$UPDATE_visitors_Ticket_result = mysql_query($UPDATE_visitors_Ticket_query);

$Amount = $Balance - $Pay;

$UPDATE_visitors_Balance_query = "UPDATE `visitors` SET `Balance`='$Amount' WHERE User_ID='$UserID'";
$UPDATE_visitors_Balance_result = mysql_query($UPDATE_visitors_Balance_query);
$msg = "You payment was successful.";
setcookie("msg", "$msg", time() + 15);
exit();
}
