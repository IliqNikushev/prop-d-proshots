 <!DOCTYPE html>

<html>
<head>
    <script type="text/javascript" src="js/jquery.js"></script>
<title>Page Title</title>
</head>
<body>

    <input type="text" id="name" value=""/>
    <div id="name_f"></div>
    
<script >$('#name').change(function(){
    var name = $('#name').val();
    $.post("test_sql.php", { pay:name }, function(data) {
        $('#name_f').html(data);
    } );
});</script>
</body>
</html> 
