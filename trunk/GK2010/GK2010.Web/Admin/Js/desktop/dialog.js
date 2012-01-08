/**
 * �Ի����� ���ڴ���������ڣ������л������� ʹ�ã�PW.Dialog(JSONArgu); JSONArgu Ϊһ��object�������ݡ��磺
 * {id:'',url:'',name:''}
 *
 * @param string
 *            id ����id��
 * @param string
 *            url ��������Ӧ��url��ַ
 * @param string
 *            name ���ڵı���.
 */
~function() {
	/**
	 * ��ȡ����������body�ľ�������
	 *
	 * @param nodeElement
	 *            d ����
	 * @return Array:[x,y]
	 */
	var _getPos = function(d) {
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
	};

	/**
	 * ����ѡ����
	 */
	PW.lrSelector = function() {
		var winButtons = $("taskbar").getElementsByTagName("LI");
		var totalNum = winButtons.length;
		for ( var i = 0; i < totalNum; i++) {
			if (winButtons[i].className == "current") {
				current = i;
			}
		}
		// ��ѡ��
		var leftKey = current - 1;
		var left = leftKey >= 0 ? winButtons[leftKey] : 0;
		var navleft = $("navleft");
		if (left) {
			navleft.className = "admin_nav_left";
			navleft.onclick = function() {
				left ? left.self.onclick() : 0;
			}
		} else {
			navleft.className = "admin_nav_left_old";
			navleft.onclick = function() {
			}/* ע���¼� */
		}
		// ��ѡ��
		var rightKey = current + 1;
		var right = rightKey > 0 ? winButtons[rightKey] : 0;
		var navright = $("navright");
		if (right) {
			navright.className = "admin_nav_right";
			navright.onclick = function() {
				right ? right.self.onclick() : 0;
			}
		} else {
			navright.className = "admin_nav_right_old";
			navright.onclick = function() {
			}/* ע���¼� */
		}
		if(!totalNum ){/*���û�д��ڲ˵�*/
			navleft.style.display = "none";
			navright.style.display = "none";
		}else{
			navleft.style.display = "";
			navright.style.display = "";
		}
		return false;
	}

	/* ���ҷ�ҳ�� */
	PW.lrPager = function() {
		// var showNum = 8;/*���ҳ���ȵ���*/
		var showNum = Math
				.ceil((document.documentElement.clientWidth - 170) / 116);
		var current;
		var winButtons = $("taskbar").getElementsByTagName("LI");
		var totalNum = winButtons.length;
		/* ��ȡ��ǰ�˵���λ�� */
		for ( var i = 0; i < totalNum; i++) {
			if (winButtons[i].className == "current") {
				current = i;
			}
		}
		var page = Math.ceil((current + 1) / showNum);
		var start = (page - 1) * showNum;
		var end = start + showNum - 1;
		for ( var j = 0; j < totalNum; j++) {
			if (j >= start && j <= end) {
				winButtons[j].style.display = "";
				continue;
			}
			winButtons[j].style.display = "none";
		}
		return false;
	}

	PW.checkClose = function(){
		var elements = $("taskbar").getElementsByTagName("li");
		if(elements.length == 0){
			PW.openHome();
		}
	}

	/*��������*/
	PW.menuNav = function(obj){
		$("breadCrumb").innerHTML = "";
		var defaulMenu = "��̨��ҳ";
		var index = [defaulMenu,"�������","����phpwind","��̨�˵���ͼ"];
		var obj = $("button_"+obj.id);
		var name = obj.firstChild.firstChild.innerHTML;/*��ȡ��ǰ�Ĳ˵�����*/
		//��̨��ҳ��������
		if(index.toString().indexOf(name) != "-1"){
			menus = [name];
		}else{
			var menus = adminNavClass.get(name,mainnavs,menunavs);
			if(menus == null){//Ĭ��
				menus = [defaulMenu];
			}
			if(menus[0] == "ģʽ����"){
				menus.splice(0,1);
			}
		}
		//$("breadCrumb").innerHTML = "��ǰλ�� &raquo; "+menus.join(" &raquo; ");

		var menubox = document.createElement("div");
		menubox.innerHTML = "��ǰλ��: ";
		var j = 1;
		var length = menus.length;
		for(i=0;i<length;i++){
			var span       = document.createElement("span");
			var divide     = (j == length) ? "" : " &raquo; ";
			//var classname  = (j == length && j >2 ) ? "admenu_down" : "";
			var classname  = ( length == 1 ) ? "" : "admenu_down";
			span.className = classname;
			span.innerHTML = menus[i];
			span.setAttribute("menu",menus[i]);
			span.setAttribute("depth",i);
			/*�������˵�*/
			//if( i > 0 ){
				span.onclick = function(evt){
					adminNavClass.remove();
					var name = this.getAttribute("menu");
					var depth = this.getAttribute("depth");
					adminNavClass.node(name,mainnavs,menunavs,this,depth);
					//adminNavClass.stop(evt);
					return false;
				}
				span.onmouseout = function(){
				}
			//}
			var span1 = document.createElement("span");
			span1.innerHTML = divide;
			menubox.appendChild(span);
			menubox.appendChild(span1);
			j++;
		}
		$("breadCrumb").appendChild(menubox);
	}
	/*�����Ӳ˵�ҳ��*/
	PW.ChildDialog = function(obj){
		adminNavClass.remove();
		var name = obj.getAttribute("name");
		var id = obj.getAttribute("aid");
		var menu = adminNavClass.level(id, name, mainnavs,menunavs);
		if(menu){
			setTimeout(function(){
				PW.Dialog(menu);
			},0);
		}
		/*�رյ����˵�*/
		for ( var i in PW.Menu.all) {
			PW.Menu.all[i] ? PW.Menu.all[i].remove ? PW.Menu.all[i].remove() : 0 : 0;
		}
		return false;
	}

	PW.Dialog = function(items) {
		window.MOUSE_OVERED = false;
		if (!$("iframe_" + items.id)) {
			var ifr = document.createElement("iframe");
			ifr.scrolling = "auto";
			ifr.width = "100%";
			ifr.height = $('desktopContainer').offsetHeight + "px";
			ifr.frameBorder = "no";
			ifr.style.border = "0";
			ifr.src = items.url;
			ifr.id = "iframe_" + items.id;
			$('desktopContainer').appendChild(ifr);
			//ifr.contentWindow.onkeydown=enterkeycode;
		} else {
			$("iframe_" + items.id).src = items.url;
		}
		var ifr = $("iframe_" + items.id);
		var mousedownFn = function(ev, win) {

			for ( var i in PW.Menu.all) {
				PW.Menu.all[i] ? PW.Menu.all[i].remove ? PW.Menu.all[i]
						.remove() : 0 : 0;
			}
			try {
				PW.setCurrent();
				startPanelShow.remove();
			} catch (e) {
			}
			// !IE?event.cancelBubble=true:0;
		};
		var allIframes = [ ifr ];
		for ( var i = 0, len = allIframes.length; i < len; i++) {
			cwin = allIframes[i].contentWindow;
			if (cwin.document) {
				cwin.document.onmousedown = function(ev) {
					mousedownFn(ev || event, cwin)
				};
			}
			var onloadFn = function() {

				try {
					setTimeout(function() {
						cwin.focus();
					}, 1000);
				} catch (e) {
				}
				return function() {
					cwin.document.onmousedown = function(ev) {
						mousedownFn(ev || event, cwin)
					};
				};
			};
			onloadFn = onloadFn.call(cwin);
			allIframes[i].detachEvent("onload", onloadFn);
			allIframes[i].attachEvent("onload", onloadFn);

		}
		if (PW.Window.all[items.id]) {

			var b = PW.Window.all[items.id];
			mousedownFn();
		} else {
			var b = new PW.TaskButton();

		}

		PW.Window.all[items.id] = b;
		b.id = items.id;

		/**
		 * ���������İ�ť��ɾ��ʱ�����˷�������ɾ����Ӧ��iframe����
		 */

		b.onremove = function() {
			$removeNode(ifr);
			PW.lrSelector();
			PW.checkClose();
		};
		b.text = items.name;
		// b.width = 94;/*��Ҫ�ʵ�����*/
		/**
		 * ��������������İ�ť�󣬴����˷�����
		 */
		b.onclick = function() {
			ACTIVEDBUTTON ? ACTIVEDBUTTON.blur() : 0;
			ifr.style.display = "";
			b.focus();
		};

		/**
		 * ���۽�����ťʱ�������÷���
		 */
		b.onfocus = function() {
			ifr.style.display = "";
			PW.lrSelector();/* ����ѡ���� */
			PW.lrPager();/*���ҷ�ҳ*/
			PW.setCurrent();/*��ǰ*/
			PW.menuNav(b);/*����*/
			adminNavClass.initTips();
			$('taskbar').scrollTop = IE ? b.element.offsetTop
					: _getPos(b.element)[1] - _getPos($('taskbar'))[1];

		};
		/**
		 * ����ťʧȥ����ʱ�������˷�����
		 */
		b.onblur = function() {
			ifr.style.display = "none";
		};
		b.render($('taskbar'));
		this.button = b;
		b.element.self = b;
		/**
		 * �ڰ�ť��ɾ��ǰ�������÷�������һЩ�л��ڽ���ť�Ĺ���
		 */
		b.onbeforeremove = function() {
			if (ACTIVEDBUTTON != this) {/* ������ǵ�ǰ��ť���л� */
				return;
			}
			var e = b.element.previousSibling || b.element.nextSibling;
			e ? e.self.onclick() : 0;
		};

		$('taskbar').scrollTop = $('taskbar').scrollHeight;
		items.onclick ? items.onclick(items) : 0;
		b.focus();
		/**
		 * Ϊ�˼����ϵĴ��룬��������װΪ���󷵻ء�
		 */
		return {
			loadIframe : function() {
				ifr.src = items.url;
				return {
					ifr : ifr
				}
			},
			ifr : ifr
		};
	};
}();