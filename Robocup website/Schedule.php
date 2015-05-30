<?php
require('Login.php');
require('Head.php');
?>

<script>
    $(document).ready(function () {
        var title = "Schedule";
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
            <h2>Schedule</h2>
        </div>

        <div id="ScheduleText">
            The event starts at ... and it ends at ... .<br><br>
            - July 17: Major Team Setup<br><br>

            - July 18: Major and Junior Team Setup<br><br>

            - July 19-22: Competitions<br><br>

        </div>


    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
