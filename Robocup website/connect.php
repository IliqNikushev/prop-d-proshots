<?php
$connection = mysql_connect('athena01.fhict.local', 'dbi317294', 'NBD7TnUwhT');
if (!$connection){
    die("Database Connection Failed" . mysql_error());
}
$select_db = mysql_select_db('dbi317294');
if (!$select_db){
    die("Database Selection Failed" . mysql_error());
}