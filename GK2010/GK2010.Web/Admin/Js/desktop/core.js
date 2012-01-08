IE = document.all;
PW={};
/*
 * ɾ��dom�ڵ㣬���ͷ��ڴ�
 *@param nodeElement htmlElement �ڵ����
 */
$removeNode=function(htmlElement)
{
	var a=document.createElement("DIV");
	a.appendChild(htmlElement);
	a.innerHTML="";
	a=null;
};
/*
 *����ID��ȡ�ڵ����
 *@param String id �ڵ�id
 */
$ = function(id) 
{
    return document.getElementById(id);
};

~function()
{
	/*
	 *��readyBound���뵽�հ�����������ʹ��ȫ�ֱ���
	 */
	var readyBound=false;
	/*
	 *ҳ�����������ʱִ�У���onloadҪ��ִ�С�
	 */
	window.onReady = function(fallBackFunction)
	{
		if (window.readyBound) return;
		readyBound = true;
		var ready = 0;
		// Mozilla, Opera and webkit nightlies currently support this event
		if (document.addEventListener)
		{
			// Use the handy event callback
			document.addEventListener("DOMContentLoaded",
			function()
			{
				document.removeEventListener("DOMContentLoaded", arguments.callee, false);
				if (ready) return;
				ready = 1;
				fallBackFunction?fallBackFunction():0;
			},
			false);

			// If IE event model is used
		} else if (document.attachEvent)
		{
			// ensure firing before onload,
			// maybe late but safe also for iframes
			document.attachEvent("onreadystatechange",
			function()
			{
				if (document.readyState === "complete")
				{
					document.detachEvent("onreadystatechange", arguments.callee);
					if (ready) return;
					ready = 1;
					fallBackFunction?fallBackFunction():0;
				}
			});

			// If IE and not an iframe
			// continually check to see if the document is ready
			if (document.documentElement.doScroll && window == window.top)(function()
			{
				if (ready) return;
				try
				{
					// If IE is used, use the trick by Diego Perini
					// http://javascript.nwbox.com/IEContentLoaded/
					document.documentElement.doScroll("left");
				} catch(error)
				{
					setTimeout(arguments.callee, 0);
					return;
				}
				ready = 1;
				fallBackFunction?fallBackFunction():0;

			})();
		}
	};
}();
/**
 *���������Ĵ�������������(this)ָ���׸�����
 * @param Object b ��ǰ��������󣬽�b�滻�����ڵ�this����
 * @example ʹ�þ�����killError=function(){return true};
 * window.onerror= killError.delegate();
 */
Function.prototype.delegate = function(b)
{
    var _ = this;
    return function()
    {
        try{return _.call(b)}catch(e){}
    }
};
/**
 *��̳�
 *@param  JSON overrides ���Ժͷ���������
 */
Function.prototype.extend = function(overrides)
{
    var F = function(config)
    {
        if (typeof(config) == "object")
        {
            for (var i in config)
            {
               try{ this[i] = config[i];}catch(e){}
            }
        }
    };
    F.prototype = new this;
    if (overrides)
    {
        for (var i in overrides)
        {
			/**
			 *safri ������ڱ���ʱ�ᱨһ���쳣
			 */
            try{F.prototype[i] = overrides[i];}catch(e){}
        }
    }
    return F;

};

/*
 *������࣬��������������ĸ��࣬���߸����࣬�κ�����඼�̳��Դ��࣬���������бȽ�ͳһ��������
 *@param JSON config �������
 */
var baseClass=function(config)	 
{
	if (typeof(config) == "object")
	{
		for (var i in config)
		{
			try{this[i] = config[i];}catch(e){}
		}
	}
};