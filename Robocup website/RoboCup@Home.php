<?php
require('Login.php');
require('Head.php');
?>

<script>
    $(document).ready(function () {
        var title = "Robocuo@Home";
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
            <h2>RoboCup@Home</h2>
        </div>

        <div id="RoboCupHomeText">

            RoboCup@Work is a new competition in RoboCup that targets the use of robots in work-related scenarios.

            The RoboCup@Home league aims to develop service and assistive robot technology with high relevance for future personal domestic applications. It is the largest international annual competition for autonomous service robots and is part of the RoboCup initiative. A set of benchmark tests is used to evaluate the robots’ abilities and performance in a realistic non-standardized home environment setting.
            Focus lies on the following domains but is not limited to: Human-Robot-Interaction and Cooperation, Navigation and Mapping in dynamic environments, Computer Vision and Object Recognition under natural light conditions, Object Manipulation, Adaptive Behaviors, Behavior Integration, Ambient Intelligence, Standardization and System Integration. It is colocated with the RoboCup symposium. <br><br>

            <a href="http://wiki.robocup.org/wiki/@Home_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>


        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
