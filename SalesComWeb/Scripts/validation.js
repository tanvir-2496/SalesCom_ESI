﻿  function fnValidate()
  {
    var error="";
  
 
    var notValid = 0;
    
      // Validate Radio button
    var list = document.getElementById("ContentPlaceHolder1_RadioDisburseByEVSystem"); //Client ID of the radiolist
    var inputs = list.getElementsByTagName("input");
    var selected;
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].checked) {
            selected = inputs[i];
            break;
        }
    }
    if (selected) {
        // alert(selected.value);
    }
    else {
        alert("Please select a radio button.");
        // $("#RadioDisburseByEVSystem").css("border", "solid 1px #C5D3E4");
        notValid = 1;
    }
    
    //required field validator
    $("input.required,textarea.required").each(function(i){
             this.value = $.trim(this.value);
             notValid +=MarkError(this,this.value.length>0);
     });
     
     //integer field validator
     $("input.integer").each(function(i){
       this.value = $.trim(this.value);
        notValid+=MarkError(this,IsInteger(this.value));
     });
     
      //integer field validator
     $("input.word").each(function(i){
       this.value = $.trim(this.value);
        notValid+=MarkError(this,IsWord(this.value));
     });
     
      //integer field validator
     $("input.integerNR").each(function(i){
       this.value = $.trim(this.value);
        if(this.value.length<1) this.value = 0;
       notValid+=MarkError(this,IsInteger(this.value));
     });
     
     //decimal field validator
     $("input.double").each(function(i){
        this.value = $.trim(this.value);
        notValid+=MarkError(this,IsDouble(this.value));
     });
     
      //decimal field validator
     $("input.doubleNR").each(function(i){
        this.value = $.trim(this.value);
        if(this.value.length<1) this.value = 0;
        notValid+=MarkError(this,IsDouble(this.value));
     });
    
    //Date field validator dd-MM-yyyy
     $("input.date").each(function(i){
        this.value = $.trim(this.value);
        notValid+=MarkError(this,IsDate(this.value,false));
     });
     
     //Date field validator dd-MM-yyyy
     $("input.dateNR").each(function(i){
        this.value = $.trim(this.value);
        notValid+=MarkError(this,IsDate(this.value,true));
     });
     
     
     // drop down List Validation
     $("select.required").each(function(i){
        notValid+=MarkErrorForDDL(this,this.selectedIndex>0);
     });
     
     //email field validator
     $("input.email").each(function(i){
        this.value = $.trim(this.value);
        var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        notValid+=MarkError(this,emailPattern.test(this.value));
     });
    // password
     $("input.password").each(function(i){
        this.value = $.trim(this.value);
        if(this.value.length<8)
        notValid+=MarkError(this,false);
        
     });
    
     
     if(notValid>0)
     {
       $("span[id$=lblMsg]").html("<b>Provide valid information.</b>"+error).css("color","red");
        return false;
     }
     else
     {
       $("span[id$=lblMsg]").html("").css("color","Green");
       return true;
     }
    
 
  }
//grid view check
 function fnValidateRow(bItem)
  {
    var error="";
    
    var Row = bItem.parentNode.parentNode;
 
    var notValid = 0;
    
    
    //required field validator
    $(Row).find("input[class='required'],textarea[class='required']").each(function(i){
             this.value = $.trim(this.value);
             notValid +=MarkError(this,this.value.length>0);
     });
     
     //integer required field validator
     $(Row).find("input.integer").each(function(i){
       this.value = $.trim(this.value);
        notValid+=MarkError(this,IsInteger(this.value));
     });
     
      //integer field validator
     $(Row).find("input.integerNR").each(function(i){
       this.value = $.trim(this.value);
        if(this.value.length<1) this.value = 0;
       notValid+=MarkError(this,IsInteger(this.value));
     });
     
     //decimal field validator
     $(Row).find("input.double").each(function(i){
        this.value = $.trim(this.value);
        notValid+=MarkError(this,IsDouble(this.value));
     });
     
      //decimal field validator
     $(Row).find("input.doubleNR").each(function(i){
        this.value = $.trim(this.value);
        if(this.value.length<1) this.value = 0;
        notValid+=MarkError(this,IsDouble(this.value));
     });
    
    //Date field validator dd-MM-yyyy
     $(Row).find("input.date").each(function(i){
        this.value = $.trim(this.value);
        notValid+=MarkError(this,IsDate(this.value,false));
     });
    
     
    
     
     //Date field validator dd-MM-yyyy
     $(Row).find("input.dateNR").each(function(i){
        this.value = $.trim(this.value);
        notValid+=MarkError(this,IsDate(this.value,true));
     });
     
     
     // drop down List Validation
     $(Row).find("select.required").each(function(i){
        notValid+=MarkErrorForDDL(this,this.selectedIndex>0);
     });
     
     
     if(notValid>0)
     {
       $("span[id$=lblMsg]").html("<b>`qv K‡i wb¤¥³ Z_¨¸†jv cª`vb Kiæb</b><br>"+error).css("color","red");
        return false;
     }
     else
     {
       $("span[id$=lblMsg]").html("").css("color","black");
       return true;
     }
    
 
  }

//check valid integer 1,15,18
 function IsInteger(val)
  {
      var re = new RegExp("^[0-9]+$");
      return val.match(re);
  }
  
  
   function IsWord(val)
  {
      var re = new RegExp("^[A-Za-z0-9_]+$");
      return val.match(re);
  }
  

//check valid date 25/12/1989
function IsDate(val,allowBalnk)
 {
      if(allowBalnk && val.length==0) return true;
      var dateaprts = val.split('-');
      var dt = new Date(dateaprts[2],dateaprts[1]-1,dateaprts[0]);
      return (dt.getDate()==dateaprts[0] && dt.getMonth()==dateaprts[1]-1 && dt.getFullYear()==dateaprts[2])
 }

//check valid decimal number  125,125.50 
 function IsDouble(val)
 {
      return !isNaN(val)&& (val.length>0) ;
 }



function MarkError(control,isValid)
{
    //$(control.offsetParent).find("BR,p").remove();
    if(isValid)
    {
       $(control).css("border","solid 1px #C5D3E4");
      
      
       return 0;
    }
    else
    {
    //    $(control.offsetParent).append("<br><p style='color:red'>Required</p>");
      //error +=$(this).attr('id').split('_txt')[1]+'<br>';
      $(control).css("border","solid 1px red");
      return 1;
    }

}



function MarkErrorForDDL (control,isValid)
{
    if(isValid)
    {
       $(control).css("color","black");
       return 0;
    }
    else
    {
      $(control).css("color","red");
      return 1;
    }

}










   function hideMsg()
   {
    document.getElementById("<%=lblMsg.ClientID%>").innerHTML ="";
   }
  function allowOnlyNumbers(evt)
{

    var keyCode="";
   if(window.event)
   { 
        keyCode = window.event.keyCode; 
        evt = window.event; 
    }
    else if (evt)keyCode = evt.which;    
    else return true; 
   if((keyCode==null) || (keyCode==0) || (keyCode==8) || (keyCode==9) || (keyCode==13) || (keyCode==27) )
   return true; 
   if((keyCode<48 ||keyCode>57))
    {     
        evt.returnValue= false;
        return false;
    }
} 
function CheckAnyValidDate(date)// dd-mm-yyyy 
{	
var dateValid = true;

	try 
	{
		var dateSeperator = "";
		//See what the character is that seperates the date parts...
		if (date.indexOf("-")>0) 
		{
			dateSeperator = "-";
		} 

		else 
		{
			//if it's not one of the ones listed above, then we don't have a valid date...
			dateValid = false;
		}
				
		var dateArray= new Array(5);		
		dateArray = date.split(dateSeperator);
		
		if (dateArray[0].length > 2){
			dateValid = false;
		}
		if (dateArray[1].length > 2){
			dateValid = false;
		}
		if (dateArray[2].length != 4){
			dateValid = false;
		}
		
		//If any of the parts aren't numbers, then we don't have a date
		if (isNaN(dateArray[0]) || isNaN(dateArray[1]) || isNaN(dateArray[2])) 
		{
			dateValid = false;
		}
		
		var iDate = parseInt(dateArray[0],10);
		var iMonth = parseInt(dateArray[1],10);		
		var iYear = parseInt(dateArray[2],10);
		
		//If the year is before 1900 it's not valid...
		if (iYear < 1900) 
		{
			dateValid = false;
		}
		//Make sure our month is in range...
		else if (iMonth < 0 || iMonth > 12) 
		{
			dateValid = false;
		}
		//Jan, Mar, May, July, Aug, Oct and Dec must have between 1 and 31 days...
		else if ( (iMonth == 1 || iMonth == 3 || iMonth == 5 || iMonth == 7 || iMonth == 8 || iMonth == 10 || iMonth == 12)
				   && (iDate < 0 || iDate > 31) ) {
			dateValid = false;
		}
		//April, June, Sept, and Nov must have between 1 and 30 days...
		else if ( (iMonth == 2 || iMonth == 6 || iMonth == 9 || iMonth == 11)
				   && (iDate < 0 || iDate > 30) ) {
			dateValid = false;
		}
		//Feb must have 28 days unless it's a leap year. If the year is evenly divisable by 4, then we're in a leap year
		//NOTE: that this will fail for the year 2100, since 2100 is not a leap century
		//			(even though we really don't have to worry about this yet)
		else if ( (iMonth == 2) && (iYear % 4 == 0) && (iDate < 0 || iDate > 29) ) {
			dateValid = false;
		}
		//Now we handle non-leap year Feb's...
		else if ( (iMonth == 2) && (iYear % 4 != 0) && (iDate < 0 || iDate > 28) ) {
			dateValid = false;
		} 		

	} 
	catch (e) 
	{
		dateValid = false;
	}
	return dateValid;
}

function CheckValidCurrentDate(date, currentyear, currentmonth, currentday)// check valid current date: dd-mm-yyyy
{

var dateValid = true;

	try 
	{
		var dateSeperator = "";
		//See what the character is that seperates the date parts...
		if (date.indexOf("-")>0) 
		{
			dateSeperator = "-";
		} 
		else 
		{
			//if it's not one of the ones listed above, then we don't have a valid date...
			dateValid = false;
		}
				
		var dateArray= new Array(5);		
		dateArray = date.split(dateSeperator);
		
		if (dateArray[0].length > 2){
			dateValid = false;
		}
		if (dateArray[1].length > 2){
			dateValid = false;
		}
		if (dateArray[2].length != 4){
			dateValid = false;
		}
		
		//If any of the parts aren't numbers, then we don't have a date
		if (isNaN(dateArray[0]) || isNaN(dateArray[1]) || isNaN(dateArray[2])) 
		{
			dateValid = false;
		}
		
		var iDate = parseInt(dateArray[0],10);
		var iMonth = parseInt(dateArray[1],10);		
		var iYear = parseInt(dateArray[2],10);
		
		//If the year is before 1900 or later than the current date, it's not valid...
		if (iYear < 1900 || iYear > currentyear) 
		{
			dateValid = false;
		}
		//Make sure our month is in range...
		else if (iMonth < 0 || iMonth > 12) 
		{
			dateValid = false;
		}
		//Jan, Mar, May, July, Aug, Oct and Dec must have between 1 and 31 days...
		else if ( (iMonth == 1 || iMonth == 3 || iMonth == 5 || iMonth == 7 || iMonth == 8 || iMonth == 10 || iMonth == 12)
				   && (iDate < 0 || iDate > 31) ) {
			dateValid = false;
		}
		//April, June, Sept, and Nov must have between 1 and 30 days...
		else if ( (iMonth == 2 || iMonth == 6 || iMonth == 9 || iMonth == 11)
				   && (iDate < 0 || iDate > 30) ) {
			dateValid = false;
		}
		//Feb must have 28 days unless it's a leap year. If the year is evenly divisable by 4, then we're in a leap year
		//NOTE: that this will fail for the year 2100, since 2100 is not a leap century
		//			(even though we really don't have to worry about this yet)
		else if ( (iMonth == 2) && (iYear % 4 == 0) && (iDate < 0 || iDate > 29) ) {
			dateValid = false;
		}
		//Now we handle non-leap year Feb's...
		else if ( (iMonth == 2) && (iYear % 4 != 0) && (iDate < 0 || iDate > 28) ) {
			dateValid = false;
		}
		else 
		{
			//Now see if we can create a Date object with our date parts. If so, then we have a valid date...
//			var validDate:Date = new Date(iYear, iMonth, iDate);
//check for current date
			if ((iYear == currentyear && iMonth > currentmonth)||(iYear == currentyear && iMonth == currentmonth && iDate > currentday))
			{
				dateValid = false;
			}
		}
	} 
	catch (e) 
	{
		dateValid = false;
	}
	return dateValid;
}

function FuturedateValidatecheck(date, currentyear, currentmonth, currentday) ////checking for future date only
{	

var dateValid = true;

	try 
	{
		var dateSeperator = "-";
		
		var dateArray= new Array(5);		
		dateArray = date.split(dateSeperator);
		
		var iDate = parseInt(dateArray[0],10);
		var iMonth = parseInt(dateArray[1],10);		
		var iYear = parseInt(dateArray[2],10);			
		
//			//checking for future date.
			if (iYear > currentyear||(iYear == currentyear && iMonth > currentmonth)||(iYear == currentyear && iMonth == currentmonth && iDate > currentday))
			{
				dateValid = false;
			}
		}
	 
	catch (e) 
	{
		dateValid = false;
	}
	return dateValid;
}
