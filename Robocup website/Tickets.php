<?php
require('Head.php');
require('Login.php');
require('Tickets_SQL.php');
?>

<script src="http://jqueryvalidation.org/files/dist/jquery.validate.min.js"></script>
<script src="http://jqueryvalidation.org/files/dist/additional-methods.min.js"></script>
<script>
    $(document).ready(function () {
        var title = "Tickets";
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
        }
        ?>
        <div id="Heading">
            <h2>Buy tickets</h2>
        </div>

        <div id="TicketsText">

            You can buy ticket for yourself and for you friends.<br>
            The price of one ticket is 55 euro.<br>
            After entering information for the additional visitors they will recive a message with information about their registration.<br><br>
            <form id="Visitors_form">
                Visitors:<br><br>
                <b>First Name</b><br>
                <input id="Visitors_FirstName" type="text" pattern=".{1,25}" title="maximum 25 characters" name="FirstName" placeholder="First Name"><br>

                <b>Last Name</b><br>
                <input id="Visitors_LastName" type="text" pattern=".{1,25}" title="maximum 25 characters" name="LastName" placeholder="Last Name"><br>

                <b>Email</b><br>
                <input id="Visitors_Email" type="email"   name="field"   placeholder="Email"><br><br>

                <div id="Message">
                </div>

                <button type="button" onclick="Add(), Update_Tickets(), Update_Price()">Add visitor</button>
                <button type="button" onclick="Remove(), Update_Tickets(), Update_Price()">Remove  visitor</button><br>
            </form>


            <table id="table" border="1" style="width:100%">
                <thead>
                    <tr>
                        <th>Firstname</th>
                        <th>Lastname</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>


            <input id="PaymentBtn" type="button" name="Ticket_payment" value="Continue to Payment" onclick="Send_post()"><br><br>


            <hr/>
            <div id="Tickets_div">Tickets: <?php echo $Tickets ?></div><br>

            <div id="Price_div" >Price:  <?php echo $Price ?><br></div><br>


            <script>

                

                var count = 0;
                function Add() {
                    
                    var MyRows = $('table#table').find('tbody').find('tr');
                    var DontAdd = 0;
                    for (var i = 0; i < MyRows.length; i++) {
                        var Email = $(MyRows[i]).find('td:eq(2)').html();
                        if(Email == $('#Visitors_Email').val()){
                            DontAdd = 1;
                        }
                        else{
                            DontAdd = 0;
                        }
                    }
                    if(DontAdd == 0){
                        count = count + 1;
                        var table = document.getElementById("table").getElementsByTagName('tbody')[0];
                        if ($('#Visitors_FirstName').val() !== "" && $('#Visitors_LastName').val() !== "" && $('#Visitors_Email').val() !== "") {
                            var row = table.insertRow(table.rows.length);
                            row.setAttribute('id', count);
                            var cell1 = row.insertCell(0);
                            var cell2 = row.insertCell(1);
                            var cell3 = row.insertCell(2);
                            cell1.innerHTML = $('#Visitors_FirstName').val();
                            cell2.innerHTML = $('#Visitors_LastName').val();
                            cell3.innerHTML = $('#Visitors_Email').val();

                            var TicketsTextHeight = $('#TicketsText').height();
                            $('#TicketsText').height(TicketsTextHeight + 30);

                        }
                        else {
                            $('#Message').text("All fields must be filled!");
                        }
                    }
                    else {
                            $('#Message').text("Can't add the same Email!");
                        }
                }

                function Remove() {

                    $('#' + count).remove();
                    count = count - 1;
                }

                var Has_Ticket = parseInt(<?php echo json_encode($Tickets) ?>);

                function Update_Tickets() {
                    var People = parseInt($('#table tr').length);
                    var Tickets = (Has_Ticket + People) - 1;
                    jQuery('#Tickets_div').html('Tickets: ');
                    $('#Tickets_div').append(Tickets);
                }

                var Price = 0;


                function Update_Price() {
                    var People = parseInt($('#table tr').length);
                    Price = ((Has_Ticket + People) - 1) * 55;

                    jQuery('#Price_div').html('Price: ');

                    $('#Price_div').append(Price);


                }
                function Send_post() {



                    var MyRows = $('table#table').find('tbody').find('tr');
                    var users = [];
                    for (var i = 0; i < MyRows.length; i++) {
                        var Fname = $(MyRows[i]).find('td:eq(0)').html();
                        var Lname = $(MyRows[i]).find('td:eq(1)').html();
                        var Email = $(MyRows[i]).find('td:eq(2)').html();
                        users.push({FirstName: Fname, LastName: Lname, Email: Email});
                    }


                    $.post("Tickets_Pay.php", {Has_Ticket: Has_Ticket, users: users}, function (data) {
                        window.location.pathname = "webdir/i317294/Prop/Tickets.php"
                    });


                }
            </script>

            <div id="name_f"></div>

        </div>

    </div>

    <?php
    require('Bottom.php');
    ?>

</body>

</html>
