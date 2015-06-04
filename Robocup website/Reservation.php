<?php
require('Head.php');
require('Login.php');
require('Reservation_SQL.php');
?>


<script>
    $(document).ready(function () {

        $("#Reservation_Email_1").hide();
        $("#Reservation_Email_2").hide();
        $("#Reservation_Email_3").hide();
        $("#Reservation_Email_4").hide();
        $("#Reservation_Email_5").hide();

        var title = "Camping Spot Reservation";
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
        if (isset($_COOKIE['msg']) & !empty($_COOKIE['msg'])) {
            echo $_COOKIE['msg'];
            $_COOKIE['msg'] = "";
            setcookie("msg", "", time() - 15);
        }
        ?>
        <div id="Heading">
            <h2>Camping spot reservation</h2>
        </div>

        <div id="ReservationText">

            To reserve a camping spot for the weekend you need to be registered.<br>
            You can add additional visitors for the camping spot but they need to be registered //and also have a ticket//.<br>
            The price for  reserving a camping spot is 30 euro plus 20 euro for every additional visitor per day.<br><br>
            <form id="Reservation-Form" action="" method="POST">
                <?php
                $Available_tents_query = "SELECT * FROM `landmarks` WHERE Type='tent' And landmarks.ID not in (SELECT location FROM tents WHERE location > 0)";
                $Available_tents_result = mysql_query($Available_tents_query) or die(mysql_error());
                while ($row = mysql_fetch_assoc($Available_tents_result)) {
                    $rows[] = $row;
                }
                ?>
                Select camping spot:
                <select name="TentID" id="Camping_spot">
                    <option value="" selected></option>
                    <?php
                    foreach ($rows as $row) {
                        echo "<option value='";
                        echo $row["ID"];
                        echo "'>";
                        echo "Tent" . " " . $row["ID"];
                        echo "</option>";
                    }
                    ?>


                </select> <br><br>
                Number of days :
                <select name="Days" id="Number_of_days">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3" selected>3</option>
                </select><br><br>


                Additional visitors:
                <select name="Visitors" id="Additional_visitors">
                    <option value="0">0</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                </select><br><br>


                <div id="Reservation_Email_1">
                    <b>Email</b><br>
                    <input pattern=".{1,25}" title="Maximum 25 characters" type="email" name="Email1" placeholder="Email"><br><br>
                </div>

                <div id="Reservation_Email_2">
                    <b>Email</b><br>
                    <input pattern=".{1,25}" title="Maximum 25 characters" type="email" name="Email2" placeholder="Email"><br><br>
                </div>



                <div id="Reservation_Email_3">
                    <b>Email</b><br>
                    <input pattern=".{1,25}" title="Maximum 25 characters" type="email" name="Email3" placeholder="Email"><br><br>
                </div>


                <div id="Reservation_Email_4">
                    <b>Email</b><br>
                    <input pattern=".{1,25}" title="Maximum 25 characters" type="email" name="Email4" placeholder="Email"><br><br>
                </div>


                <div id="Reservation_Email_5">
                    <b>Email</b><br>
                    <input pattern=".{1,25}" title="Maximum 25 characters" type="email" name="Email5" placeholder="Email"><br><br>
                </div>


                <input type="submit" name="Reservation" value="Continue to Payment"><br><br>

                <script>

                    $("#Camping_spot").change(function () {
                        Update_Price();
                        $.post("Reservation.php", {TentID: TentID});
                    });

                    $("#Number_of_days").change(function () {
                        Update_Price();
                        $.post("Reservation.php", {Days: Days});
                    });
                    var Value = $("#Additional_visitors option:selected").val();
                    $("#Additional_visitors").change(function () {
                        Value = $("#Additional_visitors option:selected").val();

                        if (Value == 0) {
                            $("#Reservation_Email_1").hide();
                            $("#Reservation_Email_2").hide();
                            $("#Reservation_Email_3").hide();
                            $("#Reservation_Email_4").hide();
                            $("#Reservation_Email_5").hide();
                        }

                        if (Value == 1) {
                            $("#Reservation_Email_1").show();
                            $("#Reservation_Email_2").hide();
                            $("#Reservation_Email_3").hide();
                            $("#Reservation_Email_4").hide();
                            $("#Reservation_Email_5").hide();
                        }

                        if (Value == 2) {
                            $("#Reservation_Email_1").show();
                            $("#Reservation_Email_2").show();
                            $("#Reservation_Email_3").hide();
                            $("#Reservation_Email_4").hide();
                            $("#Reservation_Email_5").hide();
                        }

                        if (Value == 3) {
                            $("#Reservation_Email_1").show();
                            $("#Reservation_Email_2").show();
                            $("#Reservation_Email_3").show();
                            $("#Reservation_Email_4").hide();
                            $("#Reservation_Email_5").hide();
                        }

                        if (Value == 4) {
                            $("#Reservation_Email_1").show();
                            $("#Reservation_Email_2").show();
                            $("#Reservation_Email_3").show();
                            $("#Reservation_Email_4").show();
                            $("#Reservation_Email_5").hide();
                        }

                        if (Value == 5) {
                            $("#Reservation_Email_1").show();
                            $("#Reservation_Email_2").show();
                            $("#Reservation_Email_3").show();
                            $("#Reservation_Email_4").show();
                            $("#Reservation_Email_5").show();
                        }
                        Update_Price()
                        $.post("Reservation.php", {Visitors: Visitors});
                    });
                    
                    function Update_Price() {
                        var Price = 0;
                        var Camping_price = 30;
                        var Visitors_price = 20;

                        if ($('#Camping_spot').val() != 0) {
                            Price = Camping_price * $('#Number_of_days').val() + $('#Additional_visitors').val() * 20 + " euro";
                            jQuery('#Price_div').html('Price: ');
                            $('#Price_div').append(Price);
                        }
                        else {
                            jQuery('#Price_div').html('Price: ');
                            $('#Price_div').append("");
                        }

                    }
//                    function Send_post() {
//
//                        $.post("Reservation_SQL.php", {Visitors: Value, Price: Price}, function (data) {
//                        window.location.pathname = "webdir/i317294/Prop/Reservation.php"
//                    });
//                    }
                </script>

            </form>



            <div id="Price_div">Price:  <?php echo $Price ?><br></div><br>

        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
