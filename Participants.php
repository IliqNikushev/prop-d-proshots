<?php
require('Login.php');
require('Head.php');
?>

<script>
    $(document).ready(function () {
        var title = "Participants";
        $('#title').append(title);
    });
</script> 

<body>

    <?php
    require('Navbar.php');
    ?>


    <!-- Page Header -->
    <!-- Set your background image for this header on the line below. -->
    <header class="intro-header" style="background-image: url('img/home.jpg'); background-repeat: no-repeat; background-size: 100% 100%;" id="background-image" ></header>

    <!-- Main Content -->
    <div id="Elements-Placement">
        <?php
        if (isset($msg) & !empty($msg)) {
            echo $msg;
        }
        ?>
        <div id="Heading">
            <h2>Participants</h2>
        </div>

        <div id="ParticipantsText">
            <h2>RoboCup 2015,molecaten park kuierpad</h2><br><br>
            <b>PLEASE READ THIS INFORMATION CAREFULLY!</b><br><br>
            <b>Please direct all general registration questions and inquiries via email to Help.RoboCup2015@gmail.com.</b><br><br> 
            <b>If you encounter any problems with regard to accessing the online registration system, please contact service.robocup2015@gmail.com.</b><br><br> 
            <b>If you have registered and need an invitation letter for your participation, please contact inviteletter.robocup2015@gmail.com.</b><br><br> 


            Please follow our Facebook and Twitter stream for the latest updates.<br><br>

        </div>


    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
