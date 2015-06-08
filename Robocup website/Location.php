<?php
require('Login.php');
require('Head.php');
?>

<script>
    $(document).ready(function () {
        var title = "Location";
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
            <h2>Location</h2>
        </div>

        <div id="LocationText">
            <b>Venue</b><br><br>
            The RoboCup 2015 will take place at the molecaten park kuierpad in Wezuperbrug, the Netherlands. The Major competitions will take place in the park and the Junior competitions will be situated in the Ice Skating Center. Both locations are on 15 minutes walking distance from each other. The admission is free of charge.<br><br>

            <b>Address</b><br><br>
            Oranjekanaal Noordzijde 10<br>
            7853 TA Wezuperbrug.<br>
            The Netherlands<br><br>

            To keep in touch, follow RoboCup 2015 on Facebook and Twitter.<br><br>

            <a href="img/Park.png"><img src="img/Park.png"	alt="IMG" title="IMGf" height="15%" width="95%" id="LocationImg"/></a>
        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
