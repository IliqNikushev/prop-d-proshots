<?php

if ($_POST['Reservation']) {
    $Days = $_POST["Days"];
    $Visitors = $_POST["Visitors"];
    $Pay = 0;
    $Camping_price = 30;
    $Visitors_price = 20;

    $DaysINT = (int) $Days;
    $VisitorsINT = (int) $Visitors;

    $Pay = $Camping_price * $DaysINT + ($VisitorsINT * 20);

    $username = $_SESSION['username'];
    $query0 = "SELECT ID FROM `users` WHERE username='$username'";
    $result0 = mysql_query($query0);
    while ($row0 = mysql_fetch_assoc($result0)) {
        $rows0[] = $row0;
    }

    foreach ($rows0 as $row0) {
        $UserID = $row0["ID"];
    }
    $query5 = "SELECT Balance FROM visitors WHERE User_ID='$UserID'";
    $result5 = mysql_query($query5);
    while ($row2 = mysql_fetch_assoc($result5)) {
        $rows2[] = $row2;
    }

    foreach ($rows2 as $row2) {
        $Balance = $row2["Balance"];
        $Balance = (int) $Balance;
    }

    $Buyer = $_SESSION['username'];
    $query = "SELECT ID FROM users WHERE users.Username='" . $Buyer . "'";
    $result = mysql_query($query);
    $location = $_POST["TentID"];

    if ($location == "") {
        $msg = "Plase select tent.";
        setcookie("msg", "$msg", time() + 15);
        header("Location: https://athena.fhict.nl/webdir/i317294/Prop/Reservation.php");
    } else {
        if ($Pay > $Balance) {
            $msg = "You dont have enought money in your balance.";
            setcookie("msg", "$msg", time() + 15);
            header("Location: https://athena.fhict.nl/webdir/i317294/Prop/Reservation.php");
        } else {
            $query10 = "SELECT location FROM tents WHERE location='" . $location . "'";
            $result10 = mysql_query($query10);
            if (mysql_num_rows($result10) > 0) {
                $msg = "Tent is already reserved.";
                setcookie("msg", "$msg", time() + 15);
                header("Location: https://athena.fhict.nl/webdir/i317294/Prop/Reservation.php");
            } else {
                while ($row1 = mysql_fetch_assoc($result)) {
                    $rows1[] = $row1;
                }
                foreach ($rows1 as $row1) {
                    $BuyerID = $row1["ID"];
                }

                $query11 = "SELECT BookedBy FROM tents WHERE BookedBy='" . $BuyerID . "'";
                $result11 = mysql_query($query11);

                if (mysql_num_rows($result11) > 0) {
                    $msg = "You had already booked a camping spot.";
                    setcookie("msg", "$msg", time() + 15);
                    header("Location: https://athena.fhict.nl/webdir/i317294/Prop/Reservation.php");
                } else {

                    $Days = $_POST["Days"];


                    $BookedTill;
                    if ($Days == 1) {
                        $BookedTill = "2015-07-15 00:00:00";
                    } elseif ($Days == 2) {
                        $BookedTill = "2015-07-16 00:00:00";
                    } elseif ($Days == 3) {
                        $BookedTill = "2015-07-17 00:00:00";
                    }

                    $BookedOn = date("Y-m-d H:i:s");
                    $IsPayed = 1;

                    IF ($Visitors == 0) {
                        $query1 = "INSERT INTO `tents` (location, BookedBy, BookedOn, IsPayed, BookedTill) VALUES ('$location','$BuyerID','$BookedOn','$IsPayed','$BookedTill')";
                        $result1 = mysql_query($query1);
                        $query2 = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID) VALUES ('$location', '$BuyerID')";
                        $result2 = mysql_query($query2);
                        $Amount = $Balance - $Pay;
                        $query5 = "UPDATE `visitors` SET `Balance`='$Amount' WHERE User_ID='$UserID'";
                        $result5 = mysql_query($query5);
                        $msg = "Tent reserved.";
                        setcookie("msg", "$msg", time() + 15);
                        header("Location: https://athena.fhict.nl/webdir/i317294/Prop/Reservation.php");
                    } else {

                        for ($x = 1; $x <= $Visitors; $x++) {
                            $VEmail = $_POST["Email" . $x];
                            $query3 = "SELECT ID FROM users WHERE users.Email='" . $VEmail . "' ";
                            $result3 = mysql_query($query3);

                            while ($row3 = mysql_fetch_assoc($result3)) {
                                $rows3[] = $row3;
                            }

                            foreach ($rows3 as $row3) {

                                $VisitorID = $row3["ID"];
                            }

                            $query22 = "SELECT Visitor_ID FROM tentpeople WHERE Visitor_ID='" . $VisitorID . "' ";
                            $result22 = mysql_query($query22);
                            if (mysql_num_rows($result22) > 0) {

                                $msg = "The user with email: " . $VEmail . " " . "cannot reserve a camping spot";
                                setcookie("msg", "$msg", time() + 15);
                                $Proceed = 0;
                                header("Location: https://athena.fhict.nl/webdir/i317294/Prop/Reservation.php");
                            } else {
                                if ($x == 1) {
                                    $Visitor1 = $VisitorID;
                                }
                                if ($x == 2) {
                                    $Visitor2 = $VisitorID;
                                }
                                if ($x == 3) {
                                    $Visitor3 = $VisitorID;
                                }
                                if ($x == 4) {
                                    $Visitor4 = $VisitorID;
                                }
                                if ($x == 5) {
                                    $Visitor5 = $VisitorID;
                                }

                                $Proceed = 1;
                            }
                        }
                        IF ($Proceed == 1) {
                            $query1 = "INSERT INTO `tents` (location, BookedBy, BookedOn, IsPayed, BookedTill) VALUES ('$location','$BuyerID','$BookedOn','$IsPayed','$BookedTill')";
                            $result1 = mysql_query($query1);
                            $query2 = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID) VALUES ('$location', '$BuyerID')";
                            $result2 = mysql_query($query2);
                            for ($x = 1; $x <= $Visitors; $x++) {
                                if ($x == 1) {
                                    $Visitor1_query = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID) VALUES ('$location', '$Visitor1')";
                                    $Visitor1_result = mysql_query($Visitor1_query);
                                }
                                if ($x == 2) {
                                    $Visitor2_query = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID) VALUES ('$location', '$Visitor2')";
                                    $Visitor2_result = mysql_query($Visitor2_query);
                                }
                                if ($x == 3) {
                                    $Visitor3_query = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID) VALUES ('$location', '$Visitor3')";
                                    $Visitor3_result = mysql_query($Visitor3_query);
                                }
                                if ($x == 4) {
                                    $Visitor4_query = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID) VALUES ('$location', '$Visitor4')";
                                    $Visitor4_result = mysql_query($Visitor4_query);
                                }
                                if ($x == 5) {
                                    $Visitor5_query = "INSERT INTO `tentpeople` (Tent_ID , Visitor_ID) VALUES ('$location', '$Visitor5')";
                                    $Visitor5_result = mysql_query($Visitor5_query);
                                }
                            }
                            $Amount = $Balance - $Pay;
                            $query6 = "UPDATE `visitors` SET `Balance`='$Amount' WHERE User_ID='$UserID'";
                            $result6 = mysql_query($query6);
                            $msg = "Tent reserved.";
                            setcookie("msg", "$msg", time() + 15);
                            header("Location: https://athena.fhict.nl/webdir/i317294/Prop/Reservation.php");
                        }
                    }
                }
            }
        }
        header("Location: https://athena.fhict.nl/webdir/i317294/Prop/Reservation.php");
    }
}
