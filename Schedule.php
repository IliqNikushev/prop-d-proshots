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
            The event starts at 26th of June  and it ends at 28th of June 2015 .<br><br>
            
            - June 26: Major and Junior Team Setup and Visitors preparations <br><br>

            - June 27: Competitions<br><br>

            - June 28: Final competitions and preparations for leaving the event<br><br>

        </div>


    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
