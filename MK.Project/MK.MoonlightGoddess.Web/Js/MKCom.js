
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

//api异步ajax请求
function apiAsyncAjax(url, type, data, success) {
    $.ajax({
        url: url,
        type: type || "get",
        data: data || {},
        contentType: 'text/json',
        dataType: dataType || "json",
        success: success || function (r) {
            
        }
    })
}

//api同步ajax请求
function apiSyncAjax(url, type, data, success) {
    $.ajax({
        url: url,
        type: type || "get",
        data: data || {},
        contentType: 'text/json',
        dataType: dataType || "json",
        async: false,
        success: success || function (r) {

        }
    })
}

//无返回值的
function ajax(url, type, data, dataType, async, success) {
    $.ajax({
        url: url,
        type: type || "get",
        data: data || { },
        dataType: dataType || "json",
        async: async || true,
        success: success || function (r) {
            
        }
    })
}

//有返回值的
function ajaxResult(url, type, data, dataType, async) {
    var result;
    $.ajax({
        url: url,
        type: type || "get",
        data: data || {},
        dataType: dataType || "json",
        async: async || true,
        success: function (r) {
            result = r
        }
    })
    return result;
}

//同步Post
function ajaxSyncPost(url, data, success, dataType) {
    $.ajax({
        url: url,
        type: "post",
        data: data || {},
        dataType: dataType || "json",
        async: false,
        success: success || function (r) {

        }
    })
}

//同步Get
function ajaxSyncGet(url, data, success, dataType) {
    $.ajax({
        url: url,
        type: "get",
        data: data || {},
        dataType: dataType || "json",
        async: false,
        success: success || function (r) {

        }
    })
}


//设置cookie
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}

//获取cookie
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1);
        if (c.indexOf(name) != -1) return c.substring(name.length, c.length);
    }
    return "";
}

//清除cookie  
function clearCookie(name) {
    setCookie(name, "", -1);
} 
