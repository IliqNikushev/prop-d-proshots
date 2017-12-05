<?php
require('Login.php');
require('Head.php');
?>

<script>
    $(document).ready(function () {
        var title = "RobocupJunior";
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
            <h2>RoboCupJunior</h2>
        </div>

        <div id="RoboCupJuniorText">

            Junior<br><br>

            RoboCupJunior is targeted for primary and secondary school students. There is no fixed minimum age, but primary students are expected to be able to read (and hence write programs for their robots) on their own, without significant help from adult mentors. Students over age 19 are not allowed on RoboCupJunior teams. The division between the primary and secondary age categories is 14 years old.
            Teams with all student members age 14 and under are considered primary. Teams with any student member over age 14 must be secondary. Declaration day is the 1st of July. It is the mentor/teacher's as well as the National Representative's responsibility to follow the age regulation. Teams violating the regulation could be disqualified during or after RoboCupJunior competitions. <br><br>

            <a href="http://wiki.robocup.org/wiki/Junior" >@<font color="#0000FF">RoboCupWiki</font></a><br><br>


        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
