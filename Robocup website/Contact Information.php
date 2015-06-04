<?php
require('Login.php');
require('Head.php');
?>

<script>
    $(document).ready(function () {
        var title = "Contact information";
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
        <div id="Heading">
            <h2>Contact Information</h2>
        </div>

        <div id="ContactUsText">
            <b>Questions?</b><br><br>

            Please contact us at info.robocup2015@gmail.com for general questions about RoboCup 2015, or make use of the contact form below.<br><br>

            Do you have any specific question? Please contact one of the e-mailadresses listed below.<br><br>

            Competitions &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;	competitions.robocup2015@gmail.com<br>
            Hospitality &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;	hospitality.robocup2015@gmail.com<br>
            Accomodations &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 	accomodations.robocup2015@gmail.com<br>
            Website / RoboCupTV &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 	website.robocup2015@gmail.com<br>
            Social Media &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;	socialmedia.robocup2015@gmail.com<br>

        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
