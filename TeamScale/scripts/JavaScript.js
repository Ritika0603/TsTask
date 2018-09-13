$(".downloadrecord").click(function () {
    window.open('downloadfile.aspx', '_blank');
});
$(".getdetails").click(function()
{
    var obj = {};
    obj.id = $("#udetails").val();
    $.ajax({
        cache: false,
        type: "POST",
        url: "index.aspx/getUserDetail",

        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(obj),
        success: function (r) {
            if (r.d != "false")
            {
                var obj = JSON.parse(r.d);
                var tabledata = "";
                for (var i = 0; i < obj.Table1[0].length; i++) {
                    tabledata = tabledata + "<td>" + obj.Table1[0][i] + "</td>"
                }
                var table = " <table  class=\"table table-bordered\"> <tr> <th>id</th> <th>age</th> <th>Work class</th> <th>Education</th> <th>Education Num</th> <th>Marital Status</th> <th>Occupation</th> <th>race</th> <th>sex</th> <th>capital gain</th> <th>capital loss</th> <th>hours week</th> <th>country</th> <th>over 50k</th> </tr><tr>" + tabledata + "</tr> </table>";
                $(".apidetails").show();
                $(".apisalary").hide();
                $('.tableDetails').html(table);
            }
            else
            {
                $(".apidetails").show();
                $(".apisalary").hide();
                $('.tableDetails').html("<span class=\"text-danger\">User not found</span>");
            }
           

        }
    })
})
$(".getsalary").click(function () {
    var obj = {};
    obj.id = $("#salary").val();
    $.ajax({
        cache: false,
        type: "POST",
        url: "index.aspx/getSalaryCateory",

        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(obj),
        success: function (r) {
            $(".apidetails").hide();
            $(".apisalary").show();
            if (r.d=="True")
            {
                $(".salDetails").html("<span class=\"text-success\">This user is having salary above 50K<span>")
            }
            else
            {
                $(".salDetails").html("<span class=\"text-danger\">This  user is having salary less then 50K<span>")
            }
            
           

        }
    })
})