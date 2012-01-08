<%@ Page Title="精英团队" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Team.aspx.cs" Inherits="Team" %>
<%@ Register src="Left.ascx" tagname="Left" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
<link rel="stylesheet" type="text/css" href="css/dialog.css" />
<script type="text/javascript" src="js/dialog.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <uc1:Left ID="Left1" runat="server" />
            <div class="team_display">
				<div class="hd clearfix">
					<h3 class="h3">
                        董事\设计总监</h3>
                        <div class="clearfix"></div>
					<div id="person-1" class="person-container" onclick="new Dialog({type:'id',value:'person-1a'},{title:'董事\\设计总监'}).show();">
                          <div id="ceo1" class="person"> 
                          </div>
                          <div id="person-1a" class="hidden">
                              <div class="detailshow p1a">
                                <h3>马秀娟</h3>
                                <p>董事、总经理、设计总监</p>
                                <p>风景园林硕士</p>
                                <p class="like">研究领域</p>
                                <p>景观生态学</p>
                                <p class="like">爱好</p>
                                <p>文学、旅游、居家</p>
                                <p class="like">擅长</p>
                                <p>以自然、生态艺术之手法处理景观空间</p>
                                <p class="like">主要作品</p>
                                <p> 丹东鸭绿江景观带</p>
                                <p>沈阳世纪情缘屋顶花园</p>
                                <p>哈尔滨远大都市绿洲</p>
                                <p>沈阳保利·国色添香</p>
                                <p>保利·风华溪岸</p>
                                <p>沈阳·水木清华</p>
                                <p>丹东·林江名城</p>
                              </div>
                          </div>
                    </div>
                     <div id="person-2" class="person-container" onclick="new Dialog({type:'id',value:'person-2a'},{title:'董事\\设计总监'}).show();">
                          <div id="ceo2" class="person"> 
                          </div>
                            <div id="person-2a" class="hidden">
                              <div class="detailshow p2a">
	                            <h3>贾启明</h3>
                                <p>董事、设计总监</p>
                                <p>风景园林硕士</p>
	                            <p class="like">研究领域</p>
	                            <p>风景园林</p>
	                            <p class="like">擅长</p>
	                            <p>居住区景观设计</p>
	                            <p class="like">主要作品</p>
	                            <p>宏发华诚世界</p>
	                            <p>米拉晶典</p>
	                            <p>格林春晓</p> 
                              </div>
                            </div>
                    </div>
                    <div id="person-3" class="person-container" onclick="new Dialog({type:'id',value:'person-3a'},{title:'董事\\设计总监'}).show();">
                          <div id="ceo3" class="person"> 
                          </div><!--/#dan-->
                            <div id="person-3a" class="hidden">
                              <div class="detailshow p3a">
	                            <h3>王鹤</h3>
                                <p>设计总监</p>
                                <p>景观建筑学硕士、城市规划学博士</p>
                                <p class="like">研究领域</p>
                                <p>景观规划</p>
	                            <p class="like">爱好</p>
	                            <p>旅游、健身、游泳</p>
	                            <p class="like">擅长</p>
	                            <p>方案、手绘表现</p>
	                            <p class="like">主要作品</p>
	                            <p>江南春城</p> 
                              </div>
                            </div>
                    </div>
				 </div>
				 <div class="hd clearfix">
					<h3 class="h3">
                        设计团队</h3>
					<div class="clearfix"></div>
                    <div id="team-1" class="team-container" onclick="new Dialog({type:'id',value:'t-1a'},{title:'设计团队'}).show();">
                          <div id="t1" class="team"> 
                          </div>
                        <div id="t-1a" class="hidden">
                            <div class="detailshow t1a">
                                <h3>第一工作室</h3>
                                 <p class="like">主要项目</p>
                                <p>万科金域国际</p>	 
                                <p>万科城8.0期</p> 
                                <p>国际软件园</p>
                                <p>大悦城商业街</p>
                                <p>第五大道</p>
                                <p class="like">介绍</p>
                                <p>在各专业设计师的有效配合下，共同营造欧式、英式、中式、以及现代风格的诸多项目，在这些不同风格的项目中我们寻求着景观设计的真谛，努力给人们提供更加优质的生活空间。同时我们团队与易道、日本LD等境外公司皆有合作，共同为国内知名地产商打造品牌项目。    
                                </p>
                               
                            </div>
                        </div>


                    </div>
                    <div id="team-2" class="team-container" onclick="new Dialog({type:'id',value:'t-2a'},{title:'设计团队'}).show();">
                          <div id="t2" class="team"> 
                          </div>
                             <div id="t-2a" class="hidden">
	                            <div class="detailshow t2a">
		                            <h3>第二工作室</h3>
		                             <p class="like">主要项目</p>
		                            <p>盘锦丽景湾</p>	 
		                            <p>锦州福山文华苑</p> 
		                            <p>沈阳盛世长安商业</p>
		                            <p>沈阳枫景尚城住区</p>
		                            <p>四平华宇蓝山尚城</p>
		                            <p>鞍山万科惠斯勒小镇</p>
		                            <p>大石桥迷镇山景区规划设计</p>
		                            <p>新民方巾牛村规划设计</p> 

		                            <p class="like">介绍</p>
		                            <p>主创设计团队成员经验丰富，在设计上追求精 益求精。为各式风格低密度别墅区景观设计、居住区景观设计、公园规划、屋顶花园设计等提供高质量的设计服务，结合城市规划、环艺设计与园林植物专业背景积极利用国内外本领域先进设计理念与本土地域文化结合，尤其对山地住区景观设计研究较多，注重从方案到施工的细节品质，同时在创建之始就与各大地产商和建筑设计院进行广泛的合作，得到业内外人士的一致认同。 
		                            </p>
	   
	                            </div>
                            </div>


                    </div>
                    <div id="team-3" class="team-container" onclick="new Dialog({type:'id',value:'t-3a'},{title:'设计团队'}).show();">
                          <div id="t3" class="team"> 
                          </div>
                             <div id="t-3a" class="hidden">
	                            <div class="detailshow t3a">
		                            <h3>第三工作室</h3>
		                             <p class="like">主要项目</p>
		                            <p>中海国际社区</p>	 
		                            <p>中海龙湾</p> 
		                            <p>中海寰宇天下</p>
		                            <p>中海城</p>
		                            <p>抚顺泊林铭郡</p>
		                            <p>抚顺文华天成</p>
		                            <p>沈阳格林生活坊</p>
		                            <p>沈阳水晶城</p> 
		                            <p>佳兆业营口龙湾</p>
		                            <p class="like">介绍</p>
		                            <p>秉承“自然、生态、和谐”塑造可持续发展景观，探索 生态设计的技术和方法，提高人对自然环境和历史文化 的敏感性和责任感，并寻求艺术化的语言方式，以满足 人的精神和心灵需求。
		                            </p>
	   
	                            </div>
                            </div>

                    </div>
                    <div id="team-4" class="team-container" onclick="new Dialog({type:'id',value:'t-4a'},{title:'设计团队'}).show();">
                          <div id="t4" class="team"> 
                          </div>
                            <div id="t-4a" class="hidden">
	                            <div class="detailshow t4a">
		                            <h3>第四工作室</h3>
		                             <p class="like">主要项目</p>
		                            <p>沈阳常青藤</p>	 
		                            <p>本溪高级中学</p> 
		                            <p>沈阳长白新城</p>
		                            <p>沈阳龙湖艳澜山</p>
		                            <p>沈阳阳光100</p>
		                            <p>大连尚品天城</p>
		                            <p>铁岭铭邦上品</p> 
		                            <p class="like">介绍</p>
		                            <p>见长于现代风格的景观设计，擅长把前沿景观思 想融于景观设计项目的实施中，并通过新材料、新工艺 的运用，使其景观作品有别于传统的景观设计，简约现 代的设计风格更使其产品风格鲜明、独道。  项目多涉及校园景观、广场景观赏夜景观等公共景 观设计以及现代风格的居住区项目。
		                            </p>
	   
	                            </div>
                            </div>
                    </div>
				 </div>
                      
			</div>
</asp:Content>
