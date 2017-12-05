<?php
require('Login.php');
require('Head.php');
?>

<script>
    $(document).ready(function () {
        var title = "Robocup Rescue";
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
            <h2>RoboCup Rescue</h2>
        </div>

        <div id="RoboCupRescueText">

            1.Robot League<br><br>

            The RoboCupRescue Robot League is an international league of teams with one objective: Develop and demonstrate advanced robotic capabilities for emergency responders using annual competitions to evaluate, and teaching camps to disseminate, best-in-class robotic solutions. <br><br>

            <a href="http://wiki.robocup.org/wiki/Robot_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>

            2.Rescue Simulation League<br><br>

            The league consist of three competitions:<br><br>

            The agent competition<br><br>

            The infrastructure competition<br><br>

            The virtual robot competition <br><br>

            During rescue operations after a disaster, cooperation is a must (Jennings et al, 1997). In general the problem is not solvable by a single agent, and a heterogeneous team that dynamically combines individual capabilities in order to solve the task is needed (Murphy et al. 2000).
            This requirement is due to the structural diversity of disaster areas, variety of evidence the sensors can perceive and to the necessity of quickly and reliably examining large regions. <br><br>

            <a href="http://wiki.robocup.org/wiki/Rescue_Simulation_League" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>


        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
