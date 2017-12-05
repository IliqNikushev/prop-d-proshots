<?php

$connection = mysqli_connect('dbi321166.cq5dlpggp7y3.eu-central-1.rds.amazonaws.com:3306', 'dbi321166', 'parola12');
if (!$connection) {
    die("Database Connection Failed" . mysql_error());
}
$select_db = mysql_select_db('dbi321166');
if (!$select_db) {
    die("Database Selection Failed" . mysql_error());
}