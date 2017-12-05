<?php
require('Login.php');
require('Head.php');
require('Profile_SQL.php');
?>

<script>
    $(document).ready(function () {
        var title = "Profile";
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
            <h2>Profile settings</h2>
        </div>

        <div id="ProfileText">

            You can change your details by entering new in the fields.<br><br><br>

            <form id="Profile-Form" action="" method="POST" enctype="multipart/form-data">

                <div style="display: inline-block; width:16%"><b>First Name: </b></div>
                <input type="text" pattern=".{1,25}" title="maximum 25 characters" name="FirstName" placeholder="First Name"><br><br>

                <div style="display: inline-block; width:16%"><b>Last Name: </b></div>
                <input type="text" pattern=".{1,25}" title="maximum 25 characters" name="LastName" placeholder="Last Name"><br><br>

                <div style="display: inline-block; width:16%"><b>Password: </b></div>
                <input  pattern=".{4,25}" title="from 4 to 25 characters" type="password" name="Password" placeholder="Password"><br><br>

                <div style="display: inline-block; width:16%"><b>Confirm Password: </b></div>
                <input type="password" name="Cpassword" placeholder="Confirm Password"><br><br>

                <div style="display: inline-block; width:16%"><b>Email: </b></div>
                <input  pattern=".{6,25}" title="from 6 to 25 characters" type="email" name="Email" placeholder="Email"><br><br>
                
                <div style="display: inline-block; width:16%" for="image:">Image: </div><br>
                <input style="display: inline-block; width:45%" type="file" name="image" id="image" class="input-xlarge" /><br><br>

                <input type="submit" name="Save_changes" value="Save changes"><br><br>

            </form>

        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>

