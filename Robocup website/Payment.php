<?php
    $FirstName = array ('a'=>$_POST["FirstName"]);
    $LastName = array ('a'=>$_POST["LastName"]);
    $Email = array ('a'=>$_POST["Email"]);
    
    echo json_encode($FirstName);
    echo json_encode($LastName);
    echo json_encode($Email);
    
?>