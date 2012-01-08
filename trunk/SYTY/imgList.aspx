<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="imgList.aspx.cs" Inherits="imgList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="display">
                <div class="hd clearfix">
                	<h3 class="h3">田园展示</h3>
                     
                 </div>         
                    
                <div class="display_middle clearfix">
                    <div class="pic clearfix">
                    	<div id="JS_pic_list" class="pic_list">
                            <asp:Literal ID="litCenter" runat="server"></asp:Literal>
                        	 
                        </div>
                        
                        <!--display_content-->
                        <div class="display_content">
                            
                            <div id="JS_intro">
                                <asp:Literal ID="litLeft" runat="server"></asp:Literal>
                            </div>
                            
                        </div>
                    </div>
                </div>
                <!--display_middle end-->
                <div class="small_image_box clearfix">
                    <span class="trigger pic_prev">&nbsp;</span>
                    <span class="trigger pic_next">&nbsp;</span>
                    <div class="cert_image">
                        <ul>
                            <asp:Literal ID="litFoot" runat="server"></asp:Literal>
                       </ul>
                    </div>
            </div>
            </div>
</asp:Content>

