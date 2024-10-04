<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Popup.aspx.cs" Inherits="Popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
body {font-family: Arial, Helvetica, sans-serif;}

/* The Popup (background) */
.Popup {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  padding-top: 100px; /* Location of the box */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  
 background-color: rgb(0,0,0); /* Fallback color */
 background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
}

/* Popup Content */
.Popup-content {
  position: relative;
  background-image: url("web/images/bag.jpg");
  background-color: #fefefe;
  margin: auto;
  padding: 0;
  border: 1px solid #888;
  width: 40%;
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
  -webkit-animation-name: animatetop;
  -webkit-animation-duration: 0.4s;
  animation-name: animatetop;
  animation-duration: 0.4s
}

.Popupbutton {
  font-family: helvetica;
  color: #FFFFFF !important;
  font-size: 14px;
  padding: 8px 16px;
  background: #dd0268;
   border-style: solid;
   border-width: 0px;
}
.Popupbutton:hover {
  color: #FFA600 !important;
  background: #000000;
}

.csstxt-input {
     padding: 8px 16px;
     font-size: 14px;
     border-width: 1px;
     border-color: #CCCCCC;
     background-color: #FFFFFF;
     color: #000000;
     border-style: solid;
     border-radius: 0px;
     width:250px;
     
}
 .csstxt-input:focus {
     outline:none;
}

@media only screen and (max-width: 600px) 
{
    .Popup-content {
   width: 80%;}
   
   .csstxt-input {   
     width:110px;     
}

.Popup-header 
{
  right:10px;
  padding: 6px 8px;
  font-size:12px;
}   
    }
    
    @media only screen and (max-width: 800px) 
{
    .Popup-content {
   width: 80%;}
   
   .csstxt-input {   
     width:110px;     
}

.Popup-header 
{
  right:10px;
  padding: 6px 8px;
  font-size:12px;
}   
    }
    
     @media only screen and (max-width: 1336px) 
{
    .Popup-content {
   width: 80%;}
 
    }

/* Add Animation */
@-webkit-keyframes animatetop {
  from {top:-300px; opacity:0} 
  to {top:0; opacity:1}
}

@keyframes animatetop {
  from {top:-300px; opacity:0}
  to {top:0; opacity:1}
}

/* The Close Button */
.close {
  color: white;
  float: right;
  font-size: 28px;
  font-weight: bold;
}

.close:hover,
.close:focus {
  color: #000;
  text-decoration: none;
  cursor: pointer;
}

.Popup-header 
{
    text-shadow: 1px 1px #000;
    right:20px;
    font-family: 'Open Sans', sans-serif;
  padding: 12px 16px;
  background-color: transparent;
  color: white;
}

.Popup-sideRight 
{
    font-family: 'Open Sans', sans-serif;
    line-height: 1.2;
    text-align: justify;
    letter-spacing: 1px; 
    text-shadow: 1px 1px #000;
  padding: 2px 16px;
  background-color: transparent;
  color: white;
}

.Popup-body {padding: 2px 16px;}

.Popup-footer {
  padding: 2px 16px;
  background-color: #5cb85c;
  color: white;
}
</style>

</head>
<body>
  <form id="form1" runat="server">
    <h2>Animated Popup with Header and Footer</h2>

<!-- Trigger/Open The Popup -->
<button id="myBtn">Open Popup</button>

<!-- The Popup -->
<div id="myPopup" class="Popup">

  <!-- Popup content -->
  <div class="Popup-content">
    <div class="Popup-header">
      <span class="close">&times;</span>
      <h2>LET'S REDEEM RM 2 VOUCHER</h2>
    </div>
    <table><tr><td> <div class="Popup-body">
      <p> 
          <input id="Text1" type="text" placeholder='Enter Name Here' class="csstxt-input" />  </p>
      <p> <input id="Text2" type="text" placeholder='Enter Email Here' class="csstxt-input" /></p>
      <p><input id="Button1" type="button" value="Submit" class="Popupbutton" /></p>
    </div></td><td valign="top" ><div class="Popup-sideRight">We offering additional 10% discount today to new customer So sign up and receive discount code and RM2 Voucher right away in your box </div> 
 </td></tr></table>

  </div>

</div>
<script>
    // Get the Popup
    var Popup = document.getElementById("myPopup");

    // Get the button that opens the Popup
    var btn = document.getElementById("myBtn");

    // Get the <span> element that closes the Popup
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks the button, open the Popup 
    btn.onclick = function () {
        Popup.style.display = "block";
    }

    function pgload() {
        Popup.style.display = "block";
    }
    // When the user clicks on <span> (x), close the Popup
    span.onclick = function () {
        Popup.style.display = "none";
    }

    // When the user clicks anywhere outside of the Popup, close it
    window.onclick = function (event) {
        if (event.target == Popup) {
            Popup.style.display = "none";
        }
    }
</script>
  
    </form>
</body>
</html>
