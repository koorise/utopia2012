<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlSlide.ascx.cs" Inherits="GK2010.Web.Controls.ControlSlide" %>
<script type="text/javascript">
    linkarr<%=Category %> = new Array();
    picarr<%=Category %> = new Array();
    textarr<%=Category %> = new Array();
    var swf_width<%=Category %>=<%=Width %>;
    var swf_height<%=Category %>=<%=Height %>;
    var files<%=Category %> = "";
    var links<%=Category %> = "";
    var texts<%=Category %> = "";
    
    //这里设置调用标记
    <%=strList %>
    
    for(i=1;i<picarr<%=Category %>.length;i++){
      if(files<%=Category %>=="") files<%=Category %> = picarr<%=Category %>[i];
      else files<%=Category %> += "|"+picarr<%=Category %>[i];
    }
    
    for(i=1;i<linkarr<%=Category %>.length;i++){
      if(links<%=Category %>=="") links<%=Category %> = linkarr<%=Category %>[i];
      else links<%=Category %> += "|"+linkarr<%=Category %>[i];
    }
    
    for(i=1;i<textarr<%=Category %>.length;i++){
      if(texts<%=Category %>=="") texts = textarr<%=Category %>[i];
      else texts<%=Category %> += "|"+textarr<%=Category %>[i];
    }
    
    document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ swf_width<%=Category %> +'" height="'+ swf_height<%=Category %> +'">');
    document.write('<param name="movie" value="/flash/slide.swf"><param name="quality" value="high">');
    document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
    document.write('<param name="FlashVars" value="TitleBgPosition=1&bcastr_file='+files<%=Category %>+'&bcastr_link='+links<%=Category %>+'&bcastr_title='+texts<%=Category %>+'">');
    document.write('<embed src="/flash/slide.swf" wmode="opaque" FlashVars="TitleBgPosition=1&bcastr_file='+files<%=Category %>+'&bcastr_link='+links<%=Category %>+'&bcastr_title='+texts<%=Category %>+'& menu="false" quality="high" width="'+ swf_width<%=Category %> +'" height="'+ swf_height<%=Category %> +'" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />'); 
    document.write('</object>');    
</script>