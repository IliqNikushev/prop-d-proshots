<?php
require('Login.php');
require('Head.php');

if (isset($_SESSION['username'])) {
    $username = $_SESSION['username'];
    $query = "SELECT ID FROM `users` WHERE username='$username'";
    $result = mysql_query($query);
    while ($row = mysql_fetch_assoc($result)) {
        $rows[] = $row;
    }

    foreach ($rows as $row) {
        $UserID = $row["ID"];
    }
}
?>

<script>
    $(document).ready(function () {
        var title = "Booked items";
        $('#title').append(title);
    });
</script> 

<body>

    <?php
    require('Navbar.php');
    ?>

    <!-- Main Content -->
    <div id="Elements-Placement" >
<?php
if (isset($msg) & !empty($msg)) {
    echo $msg;
}
?>
        <div id="Heading">
            <h2>Booked items</h2>
        </div>

        <div id="BookedText" >
<?php
$query5 = "SELECT Brand,Model,rentedat,rentedtill FROM items i join rentableitemhistories r on i.ID=r.item_ID WHERE ID=5 ";
$result5 = mysql_query($query5) or die(mysql_error());
while ($row1 = mysql_fetch_assoc($result5)) {
    $rows1[] = $row1;
}
?>
            Booked items<br>
            <div>
                <select  name="mySelect" size="15" id="ItemsList">
            <?php
            foreach ($rows1 as $row1) {
                echo "<option value='0'>";
                echo $row1["Brand"] . " " . $row1["Model"] . " Rented at " . $row1["rentedat"] . " Rented till " . $row1["rentedtill"];
                echo "</option>";
            }
            ?>
                </select>
            </div>
        </div>  
    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
