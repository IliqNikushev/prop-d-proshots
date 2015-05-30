<?php
require('Login.php');
require('Head.php');
require('Balance_SQL.php');
?>

<script>
    $(document).ready(function () {
        var title = "Balance";
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
            <h2>Balance</h2>
        </div>

        <form id="BalanceText" action="" method="POST">
            Your current balance is: <?php echo json_decode($Balance) ?> euro<br><br>
            You can recharge your balance using your paypal account.<br><br>
            Please select the amount of balance you want to load:<br><br>
            <select name="Amount" id="Load_amount">
                <option value="5">5 EUR</option>
                <option value="10">10 EUR</option>
                <option value="20">20 EUR</option>
                <option value="30">30 EUR</option>
                <option value="40">40 EUR</option>
                <option value="50">50 EUR</option>
                <option value="55">55 EUR</option>
                <option value="100">100 EUR</option>
                <option value="110">110 EUR</option>
                <option value="150">150 EUR</option>
                <option value="170">170 EUR</option>
                <option value="250">250 EUR</option>
                <option value="300">300 EUR</option>
                <option value="350">350 EUR</option>
            </select><br><br>
            <input type="submit" name="Balance_load" value="Continue to Payment"><br><br>


        </form>


    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
