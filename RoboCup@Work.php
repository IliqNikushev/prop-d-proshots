<?php
require('Login.php');
require('Head.php');
?>

<script>
    $(document).ready(function () {
        var title = "Robocuo@Work";
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
            <h2>RoboCup@Work</h2>
        </div>

        <div id="RoboCupWorkText">

            RoboCup@Work is a new competition in RoboCup that targets the use of robots in work-related scenarios.<br><br>

            It aims to foster research and development that enables use of innovative mobile robots equipped with advanced manipulators for current and future industrial applications, where robots cooperate with human workers for complex tasks ranging from manufacturing, automation, and parts handling up to general logistics.<br><br>

            <a href="http://www.robocupatwork.org/" >@<font color="#0000FF">RoboCupAtWork</font></a><br><br>


        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
