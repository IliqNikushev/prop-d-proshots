<?php

if ($_POST['Save_changes']) {

    $User = $_SESSION['username'];
    $FirstName = $_POST['FirstName'];
    $LastName = $_POST['LastName'];
    $Email = $_POST['Email'];
    $Password = $_POST['Password'];

    if ($FirstName != "") {
        $query = "UPDATE `users` SET `FirstName`='$FirstName' WHERE users.Username='" . $User . "'";
        $result = mysql_query($query);
    }
    if ($LastName != "") {
        $query = "UPDATE `users` SET `LastName`='$LastName' WHERE users.Username='" . $User . "'";
        $result = mysql_query($query);
    }
    if ($Email != "") {
        $query = "UPDATE `users` SET `Email`='$Email' WHERE users.Username='" . $User . "'";
        $result = mysql_query($query);
    }
    if ($Password != "") {
        $query = "UPDATE `users` SET `Password`='$Password' WHERE users.Username='" . $User . "'";
        $result = mysql_query($query);
    }



    $upload = true;
    $image_name = '';
    
    
    $UserID_query = "SELECT ID FROM `users` WHERE username='" . $User . "'";
                $UserID_result = mysql_query($UserID_query);
                while ($row1 = mysql_fetch_assoc($UserID_result)) {
                    $rows1[] = $row1;
                }
            }


            foreach ($rows1 as $row1) {

                $UserID = $row1["ID"];
            }

                    $Picture_query = "SELECT Picture FROM `visitors` WHERE User_ID='" . $UserID . "'";
                $Picture__result = mysql_query($Picture_query);
                while ($row = mysql_fetch_assoc($Picture__result)) {
                    $rows[] = $row;
                }
            


            foreach ($rows as $row) {

                $Picture = $row["Picture"];
            }
            unlink('user_images'.DIRECTORY_SEPARATOR.$Picture);

    if (isset($_FILES['image']) && $_FILES['image']['size'] != 0) {

        function check_file_name($file_name, $file_extension, $base_url) {
            $f_name = str_replace('=', '', base64_encode($file_name . time()));
            if (file_exists($base_url . $f_name . '.' . $file_extension)) {
                check_file_name($f_name, $file_extension, $base_url);
            } else {
                return $f_name . '.' . $file_extension;
            }
        }

        $allowedExts = array("jpg", "jpeg", "gif", "png", "image/pjpeg", "image/gif", "image/jpeg", "image/png");
        $image_ext = explode(".", $_FILES['image']['name']);
        if (count($image_ext) != 2) {
            $image_extt = $image_ext[count($image_ext) - 1];
        } else {
            $image_extt = $image_ext[1];
        }
        if (!in_array($_FILES["image"]["type"], $allowedExts)) {
            $image_message = 'file extension not allowed';
            $upload = false;
        } else {
            if ($_FILES['image']['error'] > 0) {
                $image_message = 'error in file upload';
                $upload = false;
            } else {
                $image_name = check_file_name($_FILES['image']['name'], $image_extt, 'user_images/');
                if (move_uploaded_file($_FILES["image"]["tmp_name"], 'user_images/' . $image_name)) {
                    $image_message = 'upload success';
                    $upload = true;
                    $upload_query = "UPDATE `visitors` SET `Picture`='$image_name' WHERE User_ID='$UserID'";
                    $$upload_queryresult = mysql_query($upload_query);
                } else {
                    $image_message = 'error in upload image';
                    $upload = false;
                }
            }
        }
    }
