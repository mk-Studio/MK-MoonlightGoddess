
//id：指定下拉框的id属性，也可以为class
//name：sqlname名称
//调用示列：InitCombobox("#id","GetUserType")
function InitCombobox(id, name, form) {
    $.ajax({
        url: "/api/SeletcOptions/GetSelectOptions?name=" + name,
        type: "get",
        async: false,
        dataType: "json",
        contentType: "text/json",
        success: function (r) {
            for (var i = 0; i < r.length; i++) {
                if (i === 0) {
                    jQuery("<option value='All'>全部</option>").appendTo(id);
                }
                jQuery("<option value='" + r[i].Value + "'>" + r[i].Text + "</option>").appendTo(id);
            }
            form.render('select');
        }
    })
}

function InitNewCombobox(id, name, form, hasAll) {
    $.ajax({
        url: "/api/SeletcOptions/GetSelectOptions?name=" + name,
        type: "get",
        async: false,
        dataType: "json",
        contentType: "text/json",
        success: function (r) {
            for (var i = 0; i < r.length; i++) {
                if (i === 0 && hasAll) {
                    jQuery("<option value='All'>全部</option>").appendTo(id);
                }
                jQuery("<option value='" + r[i].Value + "'>" + r[i].Text + "</option>").appendTo(id);
            }
            form.render('select');
        }
    })
}

//验证是否存在，存在返回true，不存在返回false
var ajaxVerify = (data, notexistsCallback, callback) => {
    $.ajax({
        type: "post",
        url: "/api/VerifyDbData/VerifyExists",
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (r) {
            if (r.Msg === "EXISTS") {
                notexistsCallback(r);
            } else {
                callback(r);
            }
        }
    })
}
