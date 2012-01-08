<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GK2010.Web.Admin._default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>工控商城管理后台</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="expires" content="0" />
<meta http-equiv="Pragma" content="no-cache" />
<meta http-equiv="x-ua-compatible" content="ie=7" />
<meta http-equiv="Cache-Control" content="no-cache" />
<base />
<script src="js/desktop/core.js" type="text/javascript"></script>
<script src="js/desktop/Cookie.js" type="text/javascript"></script>
<script src="js/desktop/list.js" type="text/javascript"></script>
<script src="js/desktop/drag.js" type="text/javascript"></script>
<script src="js/desktop/window.js" type="text/javascript"></script>
<script src="js/desktop/menu.js" type="text/javascript"></script>
<script src="js/desktop/pwmenu.js" type="text/javascript"></script>
<script src="js/desktop/panel.js" type="text/javascript"></script>
<script src="js/desktop/wpanel.js" type="text/javascript"></script>
<script src="js/desktop/startmenu.js" type="text/javascript"></script>
<script src="js/desktop/button.js" type="text/javascript"></script>
<script src="js/desktop/taskbutton.js" type="text/javascript"></script>
<script src="js/desktop/dialog.js" type="text/javascript"></script>
<script src="js/desktop/resize.js" type="text/javascript"></script>
<script src="js/desktop/adminnav.js" type="text/javascript"></script>
<link href="images/admin/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">function getObj(id) {return document.getElementById(id);}</script>
<script type="text/javascript">
	SETTING = {}; /*初始化设置对象*/
    USUALL = [<%=strUSUALL %>];
    ISMAXED = true;
    MAIN_BLOCK = [<%=strMAIN_BLOCK %>];
    SUBMENU_CONFIG = {<%=strSUBMENU_CONFIG %>};        
    var mainnavs =[<%=strMAIN_BLOCK  %>];        
    var menunavs = {<%=strSUBMENU_CONFIG %>};   
    CONTEXTMENU = {};
	SETTING.cascade = 0;
	~function(){/*加载图片*/
		var imgs=["admin_icon.png","admin_logo.png","admin_menubar.png","bianicion.gif","adv_nav_bg.png"];
		for (var i=0,len=imgs.length; i<len; i++)
		{
			new Image().src="images/admin/"+imgs[i];
		}
		if (top.location != self.location) {top.location=self.location;}
	}();
	function minAllWindows(){
		for (var i in PW.Window.all){
			PW.Window.all[i].min?PW.Window.all[i].min():0;
		}
	}

	function setCookie(name, value, expires, path, domain, secure) {
		if (!expires) {
			expires = new Date();
			expires.setTime(expires.getTime()+31536000000);
		}
		document.cookie = name + '=' + escape(value) +
			( (expires) ? ';expires=' + expires.toGMTString() : '') +
			'path=' + ( (path) ? path : '/') +
			( (domain)  ? ';domain=' + domain : '') +
			( (secure)  ? ';secure' : '');
	}
</script>
</head>
<body>
<div id="admin_header">
	<div class="admin_head" id="admin_head"><table width="100%" style="table-layout:fixed"><tr class="vt"><td width="145"><a href="/admin/" class="admin_logo fl" onClick="PW.Dialog({id:'home',url:'/admin/',name:'后台首页'});return false;"><img src="images/admin/admin_logo.png" alt="logo" /></a></td>
	<td style="vertical-align:bottom;" class="admin_nav_bg">
	<div class="admin_topbar cc">
	<div style="width:750px;" class="fr">
	<div class="fr">
	<a href="/" target="_blank" class="b">前台首页</a>&nbsp;&nbsp;<span class="blue">┊</span>&nbsp;&nbsp;<a href="/admin/" onClick="PW.Dialog({id:'home',url:'/admin/',name:'后台首页'});return false;" class="b">后台首页</a>
	<span class="ml20">用户名：<asp:Literal ID="txtUserName" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;级别：<asp:Literal ID="txtUserLevel" runat="server"></asp:Literal>&nbsp;&nbsp;&nbsp;<a href="/loginOut.aspx">[注销]</a></span></div>
	</div>
	</div>
	<div class="admin_nav_left" id="navleft"><a href="javascript:;" title="上一个"></a></div>
	<div class="admin_nav_right" id="navright"><a href="javascript:;" title="下一个"></a></div>
	<ul class="admin_nav cc">
		<span id="taskbar"></span>
	</ul>
	</td></tr></table></div>
    <table width="100%" style="table-layout:fixed;"><tr>
    <td id="admin_menubar_top">
    <div class="admin_menubar_top">
    <a href="javascript:;" id="startMenu">常用功能项</a>
	</div></td>
    <td class="breadCrumb">
    <div class="expand fr"><span id="fullscreen" onclick="adminNavClass.fullscreen();"><i class="admin_full">全屏</i></span><a id="admin_map" hidefocus="true" href="#" onClick="PW.Dialog({id:'shortcut',url:'#',name:'后台菜单地图'});return false;"title="后台菜单地图">后台地图</a><a id="refresh" href="javascript:;" onclick="adminNavClass.refresh();"  hidefocus="true">刷新</a>
    </div>
	<div id="breadCrumb"></div></td>
	</tr></table>
</div>
<div id="admin_menubar">
		<ul class="menubar_ul cc" id="x-shortcuts">
		<!-- 左侧菜单区 开始 -->
		
		<script type="text/javascript">
		    var db_adminfile = '/admin/default.aspx'; /*后台文件名*/
		    var times = 0;
		    var mode = { items: [] }; /*模式类*/
		    for (var i = 0, len = MAIN_BLOCK.length; i < len; i++) { /*获取模式部分菜单*/
		        MAIN_BLOCK[i].id == "mode" ? (mode = MAIN_BLOCK[i]) & MAIN_BLOCK.splice(i, 1) : 0;
		    }
		    SUB_BLOCK = mode.id ? SUBMENU_CONFIG[mode.id].items : {};
		    SUB_BLOCK_ITEM = {};
		    for (var i = 0, len = SUB_BLOCK.length; i < len; i++) {
		        SUB_BLOCK_ITEM[SUB_BLOCK[i].id] = SUB_BLOCK[i];
		    }
		    (function() {
		        var module = '<li class="{enname}" id="shortcut-{id}" text="{name}" value="{url}"><a href="javascript:;" hidefocus="true" aid={id} name={name} onclick="PW.ChildDialog(this);" >{name}</a></li>'; /*左侧菜单模板*/
		        var moduleDown = '<li down="1"  class="{enname}" id="shortcut-{id}" text="{name}" value="{url}"><a class="none" href="javascript:;" hidefocus="true">{name}</a></li>'; /*模式部分html代码*/
		        document.write(desk.list.simple(MAIN_BLOCK, module, '')); /*生成左侧菜单*/
		    })();
		    var lastObj;
		    window.onReady(function() {

		        try {
		            document.execCommand('BackgroundImageCache', false, true);
		        }
		        catch (e) {
		        }
		        var lastMenu;
		        var lastClick;
		        var leftMenu = $('x-shortcuts').getElementsByTagName("LI"); /*获取左侧菜单元素 原来是 * */
		        var mouseover = function(evt) {
		            var ev = evt || event;
		            var el = ev.srcElement ? ev.srcElement : ev.target;
		            if (el && el.tagName == "A") {/*firefox*/
		                el = el.parentNode;
		            }

		            if (lastObj == el) return;
		            lastObj = el;
		            if (el && el.tagName == "LI") {
		                var c = new PW.PWMenu; /*pw.menu*/
		                for (var i in PW.Menu.all) {
		                    try {
		                        if (PW.Menu.all[i] && PW.Menu.all[i].id == el.id + "menu") {
		                            c = PW.Menu.all[i];
		                        } else {
		                            PW.Menu.all[i] ? PW.Menu.all[i].remove ? PW.Menu.all[i].remove() : 0 : 0;
		                        }
		                    } catch (e) { }
		                }

		                lastClick ? lastClick.clicked = 0 : 0;
		                el.clicked = 1;
		                lastClick = el;
		                lastMenu = c;

		                c.width = 207;
		                c.ROOT = document.body;
		                c.id = el.id + "menu";
		                try {
		                    el.getAttribute("down") ? c.items = SUB_BLOCK_ITEM[el.id.replace("shortcut-", "")].items : c.items = SUBMENU_CONFIG[el.id.replace("shortcut-", "")].items;
		                } catch (e) {
		                    return; /*抑制错误,开发时需要调试*/
		                    //return alert(e.message||e)
		                }
		                c.body = $('x-desktop');
		                c.left = this.offsetWidth - c.body.offsetLeft + c.ROOT.scrollLeft - 146; /*左边宽度*/
		                c.top = ev.clientY - ev.offsetY + c.ROOT.scrollTop - 71; /*顶部高度 100=60(头高度)+40(箭头高度)*/
		                c.render();
		                PW.setCurrent(el);
		                startPanelShow ? startPanelShow.remove() : 0; /*删除常用功能*/
		                ev.returnValue = false;
		                return false;
		            }
		        };
		        /* 左侧菜单绑定事件 */
		        for (var i = 0, len = leftMenu.length; i < len; i++) {
		            leftMenu[i].onmousedown = function() {
		                mouseover(event);
		                event.cancelBubble = true;
		                event.returnValue = false;
		                return false;
		            };

		            leftMenu[i].onclick = function() {

		            }
		        }
		        $('x-shortcuts').onmouseover = mouseover;
		        killMenu = function() {
		            for (var i in PW.Menu.all) {
		                PW.Menu.all[i].remove ? PW.Menu.all[i].remove() : 0;
		            }
		        };
		        /*常用功能*/
		        STartMenu = new PW.StartMenu({
		            items: USUALL
		        });
		        STartMenu.direct = "down";
		        STartMenu.render();

		        PW.openHome();
		        Cookie.get('tipOpened') ? 0 : ($("searchTip") || document.body).style.display = '';
		        window.onerror = function() { return true; };
		    });
		    /*默认页*/
		    PW.openHome = function() {
		    PW.Dialog({ id: "home", name: '后台首页', url: db_adminfile });
		    }

		    /*设置当前*/
		    PW.setCurrent = function(current) {
		        var elements = $("x-shortcuts").getElementsByTagName("li");
		        for (var i = 0; i < elements.length; i++) {
		            elements[i].className = elements[i].className.replace("current", "");
		        }
		        current ? current.className = current.className + " current" : 0;
		    }

		</script>
		<!--左侧菜单结束-->
		</ul>
</div>
<div id="admin_contont">
<!--内容开始-->
	<div id="x-desktop" style="height:100%;width:100%;">
		<div id="desktopContainer" style="height:100%;float:left;width:100%;"></div>
	</div>
<!--内容结束-->
</div>
</body>
</html>
