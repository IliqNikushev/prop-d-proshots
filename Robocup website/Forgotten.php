<?php
require('Login.php');
require('Head.php');

if ($_POST['Send']) {
    $Email = $_POST['Email'];

    $query1 = mysql_query("SELECT Email FROM Users WHERE Email='$Email'");

    if (mysql_num_rows($query1) > 0) {
        $Email = mysql_real_escape_string($Email);
        $status = "OK";
    } else {
        $status = "NO";
    }

    if ($status == "OK") {
        $queryF = "SELECT * FROM `users` WHERE email='$Email'";
        $st = mysql_query($queryF);
        $recs = mysql_num_rows($st);
        $row = mysql_fetch_object($st);
        $em = $row->email_address; // email is stored to a variable
        if ($recs == 0) {
            $msg = "<p>Sorry your address is not there in our database.";
            exit;
        }

        function makeRandomPassword() {
            $salt = "abchefghjkmnpqrstuvwxyz0123456789";
            srand((double) microtime() * 1000000);
            $i = 0;
            while ($i <= 7) {
                $num = rand() % 33;
                $tmp = substr($salt, $num, 1);
                $pass = $pass . $tmp;
                $i++;
            }
            return $pass;
        }

        $random_password = makeRandomPassword();
        $db_password = ($random_password);

        $sql = mysql_query("UPDATE users SET password='$db_password'  
                WHERE email='$Email'");

        $subject = "Your New Password";
        $message = "Hello, you have chosen to reset your password. 
     
    New Password: $random_password 
     
    Thanks! 
    Site admin 
     
    This is an automated response, please do not reply!";


        require 'PHPMailer\PHPMailerAutoload.php';

        $mail = new PHPMailer;

        $mail->isSMTP();                                      // Set mailer to use SMTP
        $mail->Host = 'smtp1.fontys.nl';  // Specify main and backup SMTP servers
//        $mail->SMTPAuth = true;                               // Enable SMTP authentication
//        $mail->Username = '';                 // SMTP username
//        $mail->Password = '';                           // SMTP password
        $mail->SMTPSecure = 'tls';                            // Enable TLS encryption, `ssl` also accepted
        $mail->Port = 25;                                    // TCP port to connect to

        $mail->From = 'no-reply@fontys.nl';
        $mail->FromName = 'Proshots';
        $mail->addAddress($Email);     // Add a recipient
        $mail->isHTML(true);                                  // Set email format to HTML

        $mail->Subject = $subject;
        $mail->Body = $message;
        $mail->AltBody = $message;

        if (!$mail->send()) {
            $msg = 'Message could not be sent.';
        } else {
            $msg = "Your new password has been send! Please check your email!";
        }
    } else {
        $msg = "User not found!";
    }
}
?>

<script>
    $(document).ready(function () {
        var title = "Forgotten password";
        $('#title').append(title);
    });
</script> 

<body>

    <?php
    require('Navbar.php');
    ?>

    <!-- Main Content -->
    <div id="Elements-Placement">
        <?php
        if (isset($msg) & !empty($msg)) {
            echo $msg;
        }
        ?>

        <div id="ForgottenText">

            <form action="" method="POST">

                <b>Enter you email address to recive your password.</b><br><br><br>
                <input required pattern=".{6,25}" title="from 6 to 25 characters" type="email" name="Email" placeholder="Email"><br><br>

                <input type="submit" name="Send" value="Send email">
            </form>
        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
