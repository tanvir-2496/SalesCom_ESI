﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MessageBoxCore
/// </summary>
 public class MessageBoxCore
    {
        public static string MessageBoxButtonHtml = @"<input type='button' value='{0}' class='{1}' onclick='{2}' />";

        public static string MessageBoxHTML = @"<div id='wholePage' class=page>&nbsp;</div>
                                              <div id='messageBox' class='content'>
	                                          <div style='margin:4px;'>
		                                      <table  style='background-color:#FFFFFF; border:1px solid #999999; width: 100%;height:192px '>
			                                  <tr style='background-color:#F37821'>
				                              <td colspan='2' style='border-bottom:1px solid #CCCCCC;font-family:tahoma; font-size:11px; font-weight:bold; padding-left:5px; color:Black; text-align:center; height:30px;'>{0}</td>
			                                  </tr><tr><td><br /></td><td></td></tr><tr>
				                              <td style='width:150px; text-align:center;'>{1}</td>
				                              <td style='font-family:tahoma; font-size:14px;padding-left:5px;'>
                                              <span style='overflow:hidden; width: 99%;height:62px; border:none; font-size:14px; color:black'>{2}</span>
                                              </td></tr>
			                                  <tr>
				                              <td colspan='2' style='margin-top:5px;text-align:center;'>{3}</td>
			                                  </tr>
		                                      </table>
	                                          </div>
                                              </div>";

        public static string MessageBoxScript = @"var xmlHttpRequest;
                                               function Yes() {{
                                               var info = document.getElementById('result');
                                               info.innerHTML = """";
                                               var back = document.getElementById('wholePage');
                                               back.parentNode.removeChild(back);
                                               var message = document.getElementById('messageBox');
                                               message.parentNode.removeChild(message);{0}}}

                                               function Success(result) {{
                                                   var info = document.getElementById('result');
                                                   info.innerHTML = info.innerHTML +  result;
                                               }}

                                               function Failed(error) {{
                                                   var info = document.getElementById('result');
                                                   info.innerHTML = info.innerHTML + error;
                                               }}

                                               function No() {{
                                                   var info = document.getElementById('result');
                                                   info.innerHTML = """";
                                                   var back = document.getElementById('wholePage');
                                                   back.parentNode.removeChild(back);
                                                   var message = document.getElementById('messageBox');
                                                   message.parentNode.removeChild(message);{1}}}";
    }