/**
 * ��̨��������
 * 2009-11-8 lh
 * @use
 * var menus = adminNavClass.get('Sphinxȫ������',mains,menus);
 */
var adminNavClass = {
	/*�������� ȫ��*/
	navArray : [],
	navMain  : [],
	/*�ָ��ʶ��*/
	sing : "|",

	/*���������װ����*/
	strip : function(obj,prefix){
		for(i in obj){
			this.navArray.push(prefix+this.sing+obj[i].id+this.sing+obj[i].name);
			if(obj[i].items){
				this.strip(obj[i].items,prefix+this.sing+obj[i].id);
			}
		}
		return this.navArray;
	},

	/*�������˵����Ӳ˵�*/
	stripMain : function(mainobj,menuobj){
		for(i in mainobj){
			var id = mainobj[i].id;
			var name = mainobj[i].name;
			this.navArray.push(id+this.sing+name);
			var obj = menuobj[id] ? menuobj[id]['items'] : 0;/*�˵������������*/
			obj ? this.strip(obj,id) : 0;
		}
		return this.navArray;
	},

	/*��װ���˵�*/
	buildMain : function(mainobj){
		for(i in mainobj){
			var id = mainobj[i].id;
			var name = mainobj[i].name;
			this.navMain[id] = name;
		}
	},

	/*��ʼ���˵�����*/
	init : function(mainobj,menuobj){
		this.stripMain(mainobj,menuobj);
		this.buildMain(mainobj);
	},

	/*��ȡ�˵�����*/
	get : function(name,mainobj,menuobj){
		if(typeof(mainobj) != "object" || typeof(menuobj) != "object" || name == ""){
			//return alert(this.language('data_error'));
			return null;
		}
		this.init(mainobj,menuobj);/*��ʼ��*/
		if(this.navArray.length <= 0){
			//return alert(this.language('data_error'));
			return null;
		}
		var result = null;/*�Ƿ���ڶ����ͬ�Ĳ˵�*/
		for(var i=0;i<this.navArray.length;i++){
			if(this.navArray[i].indexOf(name) != "-1"){
				result = this.navArray[i];
			}
		}
		if(result === null){
			//return alert(this.language('data_not_exist'));
			return null;
		}
		/*�ָ�*/
		var keys = result.split(this.sing);
		var length = keys.length;/*�˵����length-1��*/
		var menus = [];
		var topmenu = keys[0] ? keys[0] : '';
		if(topmenu){
			this.navMain[topmenu] ? menus.push(this.navMain[topmenu]) : '';/*���˵�����*/
		}
		for(var i=0;i<length;i++){
			var menu = this.getNav(keys[i],i+2);
			menu ? menus.push(menu) : 0;
		}
		return menus;
	},

	node : function(name,mainobj,menuobj,obj,depth){
		if(typeof(mainobj) != "object" || typeof(menuobj) != "object" || name == ""){
			//return alert(this.language('data_error'));
			return null;
		}
		this.init(mainobj,menuobj);/*��ʼ��*/
		if(this.navArray.length <= 0){
			//return alert(this.language('data_error'));
			return null;
		}
		var result = null;/*�Ƿ���ڶ����ͬ�Ĳ˵�*/
		for(var i=0;i<this.navArray.length;i++){
			if(this.navArray[i].indexOf(name) != "-1"){
				result = this.navArray[i];
			}
		}
		if(result === null){
			//return alert(this.language('data_not_exist'));
			return null;
		}
		/*�ָ�*/
		var keys = result.split(this.sing);
		//var depth = (depth > 0 && keys[0] == 'mode') ? 3 : depth;//ģʽ����֧���ļ�
		if(depth == 0){
			this.menu(MAIN_BLOCK,obj,name);//MAIN_BLOCK ��Ŀ¼
		}else if(depth == 1){
			this.menu(menuobj[keys[0]]['items'],obj,name);
		}else if(depth == 2){
			var nodes = menuobj[keys[0]]['items'];
			for(var i=0;i<nodes.length;i++){
				if(nodes[i].id == keys[1]){
					this.menu(nodes[i]['items'],obj,name);
				}
			}
		}else if(depth == 3){
			var nodes = menuobj[keys[0]]['items'];
			for(var i=0;i<nodes.length;i++){//��ȡ����
				if(nodes[i].id == keys[1]){
					nodes = nodes[i]['items'];
					break;
				}
			}
			for(var i=0;i<nodes.length;i++){//��ȡ�ļ�
				if(nodes[i].id == keys[2]){
					this.menu(nodes[i]['items'],obj,name);
				}
			}
		}else{
			return;
		}

	},

	menu : function(nodes,obj,name){
		var div1 = document.createElement("div");
		div1.id = "topmenu3";
		div1.className = "admenu";
		var div2 = document.createElement("div");
		div2.className = "admenu_bg";

		var div3 = document.createElement("h2");
		div3.innerHTML = name;
		div3.className = "treename";

		var ul = document.createElement("ul");
		for(var i=0;i<nodes.length;i++){
			var li = this.create(nodes[i].id,nodes[i].name,nodes[i].url);
			ul.appendChild(li);
		}
		div2.appendChild(div3);
		div2.appendChild(ul);
		div1.appendChild(div2);
		/*��λ*/
		var p = this.getpos(obj);
		div1.style.left = p[0]-12+"px";
		div1.style.top  = p[1]+obj.offsetHeight-21+"px";
		div1.style.position = "absolute";
		div1.style.zIndex = "9999";
		div1.style.width = "110px";
		var _this = this;
		div1.onmouseover = function(evt){
			_this.stop(evt);
		}
		div1.onmousemove = function(evt){
			_this.stop(evt);
		}
		document.body.onmouseover = function(){
			_this.remove();
		}
		var divframe = this.buildIframe("topmenu3fr", div1);
		document.body.appendChild(div1);
		divframe.style.height=div1.clientHeight+'px';
	},

	buildIframe : function(id,element){
		var divframe = document.createElement("iframe");
		divframe.id = id;
		divframe.frameborder = "0";
		divframe.style.left = element.style.left;
		divframe.style.top  = element.style.top;
		divframe.style.position = "absolute";
		divframe.style.zIndex = "9999";
		divframe.style.width = "150px";
		divframe.style.border = "0";
		divframe.style.filter = "alpha(opacity=0)";
		divframe.scrolling = "no";
		divframe.src="about:blank";

		document.body.appendChild(divframe);
		return divframe;
	},

    getpos : function(d) {
        var e = [ 0, 0 ];
        var el = d;
        while (el) {
            if (el == document.body)
                break;
            e[0] = e[0] + el.offsetLeft;
            e[1] = e[1] + el.offsetTop;
            el = el.offsetParent;
        }
        return e;
    },

    stop : function(evt){
    	if(evt){
    		evt.stopPropagation();
    	}else{
    		event.cancelBubble = true;
    	}
    },

	create : function(id,name,url){
		var li = document.createElement("li");
		var a  = document.createElement("a");
		a.innerHTML = name;
		a.href = "javascript:;";
		a.setAttribute("aid",id);//���Ǽ�����
		a.setAttribute("name",name);
		var _this = this;
		if(url){
			a.onclick = function(){
				_this.remove();
				setTimeout(function(){
					PW.Dialog({id:id,name:name,url:url});
				},0);
			}
			li.appendChild(a);
		}else{
			a.onclick = function(){
				_this.remove();
				var name = this.getAttribute("name");
				var id = this.getAttribute("aid");
				var menu = _this.level(id, name, mainnavs,menunavs);//ע��mainnavs��menunavsȫ�ֱ���
				if(menu){
					PW.Dialog(menu);
				}
			}
			li.appendChild(a);
		}
		return li;
	},




	level : function(id ,name,mainobj,menuobj){
		if(typeof(mainobj) != "object" || typeof(menuobj) != "object" || name == ""){
			return null;
		}
		return this.find(id,name,mainobj,menuobj);
	},

	/*Ŀǰ���������˵����Ӳ˵����Ϊ���� */
	find : function(id ,name,mainobj,menuobj){
		var depth = 0;
		for(k in mainobj){
			var tmp_id = mainobj[k].id;
			var tmp_name = mainobj[k].name;
			if(tmp_id == id && tmp_name == name){
				depth = 1;
			}
			if(depth == 1){
				var menu = menuobj[tmp_id]['items'][0];
				if( menu.url != undefined){
					return menu;
				}
				//�����ֲ˵�
				var nodes = menuobj[tmp_id]['items'];
				for(var i=0;i<nodes.length;i++){
					var menu = nodes[i]['items'][0];
					if(menu.url != undefined){
						return menu;
					}
				}
			}else{
				//�����˵�����
				var nodes = menuobj[tmp_id]['items'];
				for(var i=0;i<nodes.length;i++){
					if(nodes[i].id == id && nodes[i].name == name ){
						var menu = nodes[i]['items'][0];
						if(menu.url != undefined){
							return menu;
						}
					}
				}
			}
		}

	},

	$ : function(id){
		return document.getElementById(id);
	},

	remove : function(){
		var obj = this.$("topmenu3");
		var ifr = this.$("topmenu3fr");
		if(obj){
			ifr.parentNode.removeChild(ifr);
			obj.parentNode.removeChild(obj);
		}
	},

	/*��ȡ����*/
	getNav : function(id,depth){
		for(var i=0;i<this.navArray.length;i++){
			if(this.navArray[i].indexOf(this.sing+id+this.sing) != "-1" && this.navArray[i].split(this.sing).length == depth){
				return this.navArray[i].split(this.sing)[depth-1];
			}
		}
	},


	sid  : "link_screen",
	seid : "link_screen_empty",
	/*ȫ��*/
	fullscreen : function(){
		var screen = this.$(this.sid);
		var empty  = this.$(this.seid);
		var fullscreen = this.$("fullscreen");
		if(screen){
			screen.parentNode.removeChild(screen);
			this.loadCss("images/admin/fullscreenempty.css",this.seid);
			fullscreen.innerHTML = "<i class=\"admin_full\">ȫ��</i>";
		}else{
			if(empty){empty.parentNode.removeChild(empty);}
			this.loadCss("images/admin/fullscreen.css",this.sid);
			fullscreen.innerHTML = "<i class=\"admin_fullclose\">�˳�ȫ��</i>";
		}
	},
	/*����css�ļ�*/
	loadCss : function(file,id){
		var css = document.createElement("link");
		css.rel = "stylesheet";
		css.type = "text/css";
		css.href = file;
		css.id = id;
		var head = document.getElementsByTagName("head")[0];
		head.appendChild(css);
	},
	/*ˢ��ҳ��*/
	refresh : function(){
		var iframe = this.getframe();
		iframe.contentWindow.location.reload(true);
	},

	pid      : "pagesetting",
	showDesc : "showtips",
	showTips : "showfunc",
	/*ҳ������*/
	page : function(obj){
		var page = this.$(this.pid);
		if(page){
			page.parentNode.removeChild(page);
		}
		var div1 = document.createElement("div");
		div1.id = this.pid;
		div1.className = "admenu";
		var div2 = document.createElement("div");
		div2.className = "admenu_bg";
		var i = document.createElement("i");
		i.innerHTML = "ҳ������";
		i.className = "toppage_down";



		var ul = document.createElement("ul");

		var stvs = this.buildPage("t1"," ��ʾ��ʾ��Ϣ",this.showTips);

		var sfvs = this.buildPage("t2"," ��ʾ��������",this.showDesc);

		ul.appendChild(stvs);
		ul.appendChild(sfvs);
		div2.appendChild(i);
		div2.appendChild(ul);
		div1.appendChild(div2);
		/*��λ*/
		var p = this.getpos(obj);
		div1.className = "toppage_menu admenu";
		div1.style.left = p[0]-obj.offsetWidth+6+"px";
		div1.style.top  = p[1]+obj.offsetHeight-2+"px";

		var _this = this;
		div1.onmouseover = function(evt){
			_this.stop(evt);
		}
		div1.onmousemove = function(evt){
			_this.stop(evt);
		}
		document.body.onmouseover = function(){
			_this.pageRemove();
		}
		var divframe = this.buildIframe("pageifr", div1);
		divframe.onmousemove = function(evt){
			_this.stop(evt);
		}
		document.body.appendChild(div1);
		this.setChecked(this.showTips);
		this.setChecked(this.showDesc);

		divframe.style.height=div1.clientHeight+10+'px';
	},
	/*ҳ������ѡ��ֵ*/
	setChecked : function(ckey){
		var sfv = (Cookie.get(ckey)) ? 0 : 1;
		if(sfv){
			this.$(ckey+"input").checked = true;
		}else{
			this.$(ckey+"input").checked = false;
		}
	},
	/*��װҳ����������*/
	buildPage : function(name,descript,ckey){
		var li = document.createElement("li");
		var input = document.createElement("input");
		input.id = ckey+"input";
		input.type="checkbox";
		input.name=name;
		var value = (Cookie.get(ckey)) ? 0 : 1;
		input.value=value;
		var _this = this;

		var span = document.createElement("span");
		span.innerHTML = descript;
		li.appendChild(input);
		li.appendChild(span);
		li.onclick = function(e){
			e = e||window.event;
			var target = e.srcElement||e.target;
			var v = (input.checked) ? 0 : 1;
			if(target.tagName!='INPUT')
			{
				var x = !!v;
				input.checked=x;
				v = v?0:1;
			}
			if(v){
				setCookie(ckey,v);
			}else{
				Cookie.del(ckey);
			}
			_this.initTips();
		}
		return li;
	},
	/*�Ƴ�ҳ������*/
	pageRemove : function(){
		var page = this.$(this.pid);
		var ifr = this.$("pageifr");
		if(page){
			ifr.parentNode.removeChild(ifr);
			page.parentNode.removeChild(page);
		}
	},
	/*��ʼ����Ϣ*/
	initTips : function(){
		var tips = Cookie.get(this.showTips) ? 0 : 1;
		this._showTips(tips);
		var desc = Cookie.get(this.showDesc) ? 0 : 1;
		this._showDesc(desc);
	},
	/*������ʾ��Ϣ*/
	_showTips : function(isopen){
		var iframe = this._getChild();
		var infos = this.$C("admin_info",iframe);
		var v = (isopen) ? "block" : "none";
		if(infos){
			for(var i=0;i<infos.length;i++){
				infos[i].style.display = v;
			}
		}
	},
	/*���ƹ�������*/
	_showDesc : function(isopen){
		var iframe = this._getChild();
		var descs = this.$C("help_a",iframe);
		var v = (isopen) ? "block" : "none";
		if(descs){
			for(var i=0;i<descs.length;i++){
				descs[i].style.display = v;
			}
		}
	},
	/*��ȡiframe��Ԫ��*/
	_getChild : function(){
		var iframe = this.getframe();
		return iframe.contentWindow.document;
	},
	/*��ȡ��ǰiframe*/
	getframe : function(){
		var frames = this.$("desktopContainer").getElementsByTagName("iframe");
		for(var i=0;i<frames.length;i++){
			if(frames[i].style.display == ""){
				return frames[i];
			}
		}
	},

	$C : function (className, parentElement){
		if (typeof(parentElement)=='object') {
			var elems = parentElement.getElementsByTagName("*");
		} else {
			var elems = (document.getElementById(parentElement)||document.body).getElementsByTagName("*");
		}
		var result=[];
		for (i=0; j=elems[i]; i++) {
		   if ((j.className).indexOf(className)!=-1) {
				result.push(j);
		   }
		}
		return result;
	},

	manage : function(){},

	/*����*/
	language : function(key){
		var m = [];
		m['data_error'] = "���ݸ�ʽ����ȷ";
		m['data_not_exist'] = "���ҵĲ˵�������";
		return m[key];
	}
}