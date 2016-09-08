$(document).ready(function() {
        $('.calculator')
            .on('click', function(e) {
                var btnValue = $(this).attr('value');
                $('div.result').html(btnValue);
            });
    }   
);
