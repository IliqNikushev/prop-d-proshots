<?php

        session_start();
	require('connect.php');
        error_reporting(E_ERROR | E_PARSE);

if ($_POST['Login'])
{
//3. If the form is submitted or not.
//3.1 If the form is submitted
if (isset($_POST['username']) and isset($_POST['password'])){
//3.1.1 Assigning posted values to variables.
$username = $_POST['username'];
$password = $_POST['password'];
//3.1.2 Checking the values are existing in the database or not
$query = "SELECT * FROM `users` WHERE username='$username' and password='$password'";
$result = mysql_query($query) or die(mysql_error());
$count = mysql_num_rows($result);
//3.1.2 If the posted values are equal to the database values, then session will be created for the user.
if ($count == 1){
$_SESSION['username'] = $username;
}else{
//3.1.3 If the login credentials doesn't match, he will be shown with an error message.
$msg = "Invalid Login Credentials.";
}
}
//3.1.4 if the user is logged in Greets the user with message
if (isset($_SESSION['username'])){
$username = $_SESSION['username'];

}
$date_of_expiry = time() + 60 * 60 * 24 ;
setcookie( "username", "$username", $date_of_expiry ); 
}

if ($_POST['Logout'])
{
session_destroy();
header('Location: '.$_SERVER['PHP_SELF']);
die;
}
