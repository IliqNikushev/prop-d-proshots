<html>

<head>

<title>ThaiCreate.Com PHP & Rename File</title>

</head>

<body>

<?php

$flgDelete = unlink('user_images'.DIRECTORY_SEPARATOR."bW9ydGFsLWtvbWJhdC5qcGcxNDMyNzQ0NjYz.jpg");

if($flgDelete)

{

echo "File Deleted";

}

else

{

echo "File can not delete";

}

?>

</body>

</html>