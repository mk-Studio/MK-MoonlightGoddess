
//id：指定下拉框的id属性，也可以为class
//name：sqlname名称
//调用示列：InitCombobox("#id","GetUserType")
function InitCombobox(id, name, form, isSelects) {
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
            if (isSelects) {
                form.render('select');
            }
            else {
                form.render();
            }
        }
    });
}

function InitNewCombobox(id, name, form, hasAll,isSelects) {
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
            if (isSelects) {
                form.render('select');
            }
            else {
                form.render();
            }
        }
    });
}

function InitDataCombobox(id, name, data, form, hasAll, isSelects) {
    $.ajax({
        url: "/api/SeletcOptions/GetSelectOptions?name=" + name,
        data: data,
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
            if (isSelects) {
                form.render('select');
            }
            else {
                form.render();
            }
        }
    });
}

function OnCombobox(id, name, form, eObj) {
    $.ajax({
        url: "/api/SeletcOptions/GetSelectOptions?name=" + name,
        type: "get",
        async: false,
        dataType: "json",
        contentType: "text/json",
        success: function (r) {
            if (eObj) {
                for (var ei = 0; ei < eObj.length; ei++) {
                    jQuery("<option value='" + eObj[ei].Value + "'>" + eObj[ei].Text + "</option>").appendTo(id);
                }
            }
            for (var i = 0; i < r.length; i++) {
                jQuery("<option value='" + r[i].Value + "'>" + r[i].Text + "</option>").appendTo(id);
            }
            form.render();
        }
    });
}

function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r !== null) return unescape(r[2]); return null;
}
function getUrlParam(url, name) {
    var pattern = new RegExp("[?&]" + name + "\=([^&]+)", "g");
    var matcher = pattern.exec(url);
    var items = null;
    if (null !== matcher) {
        try {
            items = decodeURIComponent(decodeURIComponent(matcher[1]));
        } catch (e) {
            try {
                items = decodeURIComponent(matcher[1]);
            } catch (e) {
                items = matcher[1];
            }
        }
    }
    return items;
}  

//验证是否存在，存在返回true，不存在返回false
function ajaxVerify(data, notexistsCallback, callback) {
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
        }, complete: function () {
            layer.closeAll("loading");
        }
        
    });
};

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

//不会自动消失的弹出型提示框
function layalert(message, title) {
    layer.alert(message, { skin: 'layui-layer-molv', title: title || '系统提示' })
}
function laywarn(message, title) {
    layer.alert(message, { icon: 0, skin: 'layui-layer-molv', title: title || '温馨提示' })
}
function layok(message, title) {
    layer.alert(message, { icon: 1, skin: 'layui-layer-molv', title: title || '温馨提示' })
}
function layerror(message, title) {
    layer.alert(message, { icon: 2, skin: 'layui-layer-molv', title: title || '温馨提示' })
}
function laycfm(message, title) {
    layer.alert(message, { icon: 3, skin: 'layui-layer-molv', title: title || '温馨提示' })
}
function laylock(message, title) {
    layer.alert(message, { icon: 4, skin: 'layui-layer-molv', title: title || '温馨提示' })
}

//会自动消失提示框
function laymsg(message, time) {
    layer.msg(message, { time: time || 2970 })
}
function laymsgalert(message,callback,btnArray) {
    layer.msg(message, {
        time: 0 //不自动关闭
        , btn: btnArray || ['确定', '不了']
        , yes: function (index) {
            if (callback) {
                callback();
            }
            layer.close(index)
        }
    });
}
function laymsgwr(message, title, time) {
    layer.msg(message, { icon: 0, skin: 'layui-layer-molv', title: title || '温馨提示', time: time || 2970 })
}
function laymsgok(message, title, time) {
    layer.msg(message, { icon: 1, skin: 'layui-layer-molv', title: title || '温馨提示', time: time || 2970 })
}
function laymsgerr(message, title, time) {
    layer.msg(message, { icon: 2, skin: 'layui-layer-molv', title: title || '温馨提示', time: time || 2970 })
}
function laymsgcfm(message, title, time) {
    layer.msg(message, { icon: 3, skin: 'layui-layer-molv', title: title || '温馨提示', time: time || 2970 })
}
function laymsglock(message, title, time) {
    layer.msg(message, { icon: 4, skin: 'layui-layer-molv', title: title || '温馨提示', time: time || 2970 })
}


//吸附提示框方向
function direc(s) {
    var r = 0;
    switch (s) {
        case "top": case "t": case "w": r = 1; break;
        case "bottom": case "b": case "s": r = 3; break;
        case "left": case "l": case "a": r = 4; break;
        case "right": case "r": case "d": r = 2; break;
    }
    return r;
}
//吸附型提示框
function laytip(message, el, direction,time ) {
    layer.tips(message, el, {
        tips: [direc(direction || "d"), '#393D49'],
        time: time || 2970
    });
}
function laytipx(message, el,  direction, time) {
    layer.tips(message, el, {
        tips: [direc(direction || "d"), '#01AAED'],
        time: time || 2970
    });
}
function laytipok(message, el,  direction, time) {
    layer.tips(message, el, {
        tips: [direc(direction || "d"), '#5FB878'],
        time: time || 2970
    });
}
function laytipwran(message, el,  direction, time) {
    layer.tips(message, el, {
        tips: [direc(direction || "d"), '#FFB800'],
        time: time || 2970
    });
}
function laytiperr(message, el, direction, time) {
    layer.tips(message, el, {
        tips: [direc(direction || "d"), '#E53935'],
        time: time || 2970
    });
}


//确认提示框
function layConfirm(message,okCallback, title, btnArray,cancelCallback) {
    layer.confirm(message, {
        icon: 3
        , skin: 'layui-layer-molv'
        , title: title || '提示'
        , btn: btnArray || ['确定', '取消']
    },
        function (index) {
            if (okCallback) okCallback();
            layer.close(index);
        },
        function () {
            if (cancelCallback) {
                cancelCallback()
            }
            layer.closeAll("loading");
        }
    );
}
function layConfirmlock(message, okCallback, title, btnArray) {
    layer.confirm(message, {
        icon: 4
        , skin: 'layui-layer-molv'
        , title: title || '提示'
        , btn: btnArray || ['确定', '取消']
    },
        function (index) {
            if (okCallback) okCallback();
            layer.close(index);
        },
        function () {
            layer.closeAll("loading");
        }
    );
}

function copy(obj) {
    var newobj = {};
    for (var attr in obj) {
        newobj[attr] = obj[attr];
    }
    return newobj;
}

function deepCopy(obj) {
    if (typeof obj !== 'object') {
        return obj;
    }
    var newobj = {};
    for (var attr in obj) {
        newobj[attr] = deepCopy(obj[attr]);
    }
    return newobj;
}

function delEmptyArray(arr) {
    var result = [];
    for (var i = 0; i < arr.length; i++) {
        if (arr[i]) {
            result.push(arr[i]);
        }
    }
    return result;
}
/*
     i = 0;
    var icons = document.querySelectorAll('.icon-gouwuche1');
    setInterval(function () {
    if (i<icons.length){
    icons.item(i).click();
    i=i+1;
    }
    else{clearInterval(1)}
    },10);
 */