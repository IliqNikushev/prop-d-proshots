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

            Competitions: <br>	competitions.robocup2015@gmail.com<br><br>
            Hospitality: <br>	hospitality.robocup2015@gmail.com<br><br>
            Accomodations:<br> 	accomodations.robocup2015@gmail.com<br><br>
            Website / RoboCupTV:<br>  	website.robocup2015@gmail.com<br><br>
            Social Media &nbsp: <br>	socialmedia.robocup2015@gmail.com<br><br>

        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
