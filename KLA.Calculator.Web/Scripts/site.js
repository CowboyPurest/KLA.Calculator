$(document)
    .ready(function() {
            $(".calculator")
                .on("click",
                    function(e) {
                        var btnValue = $(this).attr("value");
                        var prevValue = $("div.result").html();
                        //if it is then it should not be added. Also if it is not a number the it will be an operator
                        if (prevValue !== 0 || prevValue === NaN) btnValue = prevValue + btnValue;
                        $("div.result").html(btnValue);
                    });
         $("#clearCalc")
                .on("click",
                    function(e) {
                        $("div.result").html("");
                    });

            $("#calculate")
                .on("click",
                    function(e) {
                        var value = $("div.result").html();
                        $.ajax({
                            type: "POST",
                            async: false,
                            cache: false,
                            url: "/Calculator/Calculate",
                            data: "{" + "expression :" + JSON.stringify(value) + "}",
                            contentType: 'application/json; charset=utf-8',
                            success: function(result) {
                                $("div.result").html(result);
                            },
                            error: function(xhr) {
                                //debugger;  
                                console.log(xhr.responseText);
                                alert(xhr.responseText);
                            }

                        });
                    });
        }
    );