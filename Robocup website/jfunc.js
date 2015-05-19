$('#name').keyup(function(){
    var name = $('#name').val();
    $.post("test_sql.php", { pay:name }, function(data) {
        $('#name_f').html(data);
    } );
});
