
function InitCombobox(name)
{
    $.ajax({
        url: "/api/SeletcOptions/GetSelectOptions?name=" + name,
        type: "get",
        async: false,
        dataType: "json",
        contentType: "text/json",
        success: function (r) {
            for (var i = 0; i < r.length; i++) {
                if (i === 0) {
                    jQuery("<option value='All'>全部</option>").appendTo("#wuliaoType");
                }
                jQuery("<option value='" + r[i].Value + "'>" + r[i].Text + "</option>").appendTo("#wuliaoType");
            }
            form.render('select');
        }
    })
}