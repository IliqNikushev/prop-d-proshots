
<?php
require('connect.php');
require('CompleteRegistration_SQL.php');
if (isset($msg) & !empty($msg)) {
    echo $msg;
}
?>
<div id="Heading">
    <h2>Complete Registration</h2>
</div>

<div>

    Please direct all general registration questions and inquiries via email to Help.RoboCup2015@gmail.com.<br>* required<br><br>

    <form id="Register-Form" action="" method="POST">

        <div style="display: inline-block; width:16%"><b>Username: </b></div>
        <input required pattern=".{3,25}" title="from 3 to 25 characters" type="text" name="Username" placeholder="Username"> *<br><br>

        <div style="display: inline-block; width:16%"><b>First Name: </b></div>
        <input required type="text" pattern=".{1,25}" title="maximum 25 characters" name="FirstName" placeholder="First Name"> *<br><br>

        <div  style="display: inline-block; width:16%"><b>Last Name: </b></div>
        <input required type="text" pattern=".{1,25}" title="maximum 25 characters" name="LastName" placeholder="Last Name"> *<br><br>

        <div style="display: inline-block; width:16%"><b>Password: </b></div>
        <input required pattern=".{4,25}" title="from 4 to 25 characters" type="password" name="Password" placeholder="Password"> *<br><br>

        <div style="display: inline-block; width:16%"><b>Confirm Password: </b></div>
        <input required onChange="checkPasswordMatch();" type="password" name="Cpassword" placeholder="Confirm Password"> *<br><br>



        <input class="btn register" type="submit" name="Complete_Registration" value="Complete Registration" /><br><br>

    </form>

</div>
