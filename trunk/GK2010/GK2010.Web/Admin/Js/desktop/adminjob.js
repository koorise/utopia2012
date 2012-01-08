var adminjobclass = {
	/*��̨�û�����ϵͳ�� @2009-11-27 lh*/
	
	rewardid     : "reward",
	joblistid    : "joblist",
	prefix       : "job_",
	joballid     : "joball",
	current      : null,
	rewardTables : "rewardTables",
	jobtables    : "jobTables",
	sid          : "starttime",
	eid          : "endtime",
	
	/*IDѡ����*/
	$ : function(id){
		return document.getElementById(id);
	},
	/*��������*/
	bindReward : function(id){
		var lists = this.$(this.rewardid).getElementsByTagName("li");
		var _this = this;
		for(i=0;i<lists.length;i++){
			var input = lists[i].getElementsByTagName("input")[0];/*��ѡ��*/
			input.onclick = function(){
				if(this.checked){
					var current = _this.$(_this.rewardid+"_"+this.value);
					_this.hiddenReward();
					current.style.display = "";
				}
			}
		}
	},
	/*����������*/
	hiddenReward : function(){
		//var ids = ['reward_none','reward_credit','reward_tools','reward_medal','reward_usergroup','reward_invitecode'];
		var divs = this.$(this.rewardTables).getElementsByTagName("div");
		for(i=0;i<divs.length;i++){
			divs[i].style.display = "none";
		}
		return true;
	},
	/*��ʼ��������*/
	initReward : function(id){
		var obj = this.$(id);
		if(obj){
			obj.style.display = "";
		}
	},
	/*���������¼�*/
	bindJobList : function(){
		var lists = this.$(this.joblistid).getElementsByTagName("li");
		var _this = this;
		for(i=0;i<lists.length;i++){
			//lists[i].onmouseover = function(){
			lists[i].onclick = function(){
				var id = _this.prefix+this.getAttribute("id");
				var jobs = _this.$(id);
				_this.hiddenJobList();
				jobs.style.display = "";
				this.className = "current";
			}
		}
	},
	/*��ÿ���������������*/
	bindJob : function(){
		var uls = this.$(this.joballid).getElementsByTagName("ul");
		var _this = this;
		for(i=0;i<uls.length;i++){/*����ul�б�*/
			var lis = uls[i].getElementsByTagName("li");/*li�б�*/
			for(j=0;j<lis.length;j++){
				var input = lis[j].getElementsByTagName("input")[0];/*��ѡ��*/
				input.onclick = function(){
					if(this.checked){
						var id = _this.prefix+this.value;
						var jobs = _this.$(id);
						_this.hiddenJobTables();
						jobs.style.display = "";
					}
				}
			}
		}
	},
	/*������������*/
	hiddenJobTables : function(){
		var tables = this.$(this.jobtables).getElementsByTagName("table");
		for(i=0;i<tables.length;i++){
			tables[i].style.display = "none";
		}
		return true;
	},
	/*��������˵�*/
	hiddenJobList : function(){
		var uls = this.$(this.joballid).getElementsByTagName("ul");
		for(i=0;i<uls.length;i++){
			uls[i].style.display = "none";
		}
		var lis = this.$(this.joblistid).getElementsByTagName("li");
		for(i=0;i<lis.length;i++){
			lis[i].className = "";
		}
		return true;
	},
	/*��ʼ���˵�*/
	initJobList : function(id){
		this.$(this.prefix+id).style.display = "";
		this.$(id).className = "current";
	},
	/*��ʼ����������*/
	initJobTable : function(id){
		this.$(id).style.display = "";
	},
	/*��ʱ������*/
	bindCalendar : function (){
		var _this = this;
		this.$(this.sid).onclick = function(){
			ShowCalendar(_this.sid,1);
		}
		this.$(this.eid).onclick = function(){
			ShowCalendar(_this.eid,1);
		}		
	},
	/*��ʼ��*/
	init : function(reward,list,job){
		this.bindReward();
		this.bindJobList();
		this.bindJob();
		this.initReward(reward);/*��ʼ��ѡ��*/
		this.initJobList(list);/*��ʼ��*/
		this.initJobTable(job);/*��ʼ����������*/
		this.bindCalendar();
	},
	
	deleteJob : function(url,id){
		if(confirm("ɾ������󣬽�ɾ���������������������ݡ��Ƿ�ȷ��ɾ����")){
			var form = document.createElement("form");
			form.action = url;
			form.method = "post";
			var input_id = this.createInput("hidden","id",id);
			var input_action = this.createInput("hidden","action","delete");
			form.appendChild(input_id);
			form.appendChild(input_action);
			document.body.appendChild(form);
			setTimeout(function(){/*ie6*/
				form.submit();
				document.body.removeChild(form);
			},0);
		}
	},
	
	createInput : function(type,name,value){
		var hidden = document.createElement("input");
		hidden.type = type;
		hidden.name = name;
		hidden.value = value;
		return hidden;
	}
	
}

/*���õ����Զ��������¼�*/
function adminJobReady(reward,list,job){
	adminjobclass.init(reward,list,job);
}

function deleteJob(url,id){
	adminjobclass.deleteJob(url,id);
	return true;
}
























