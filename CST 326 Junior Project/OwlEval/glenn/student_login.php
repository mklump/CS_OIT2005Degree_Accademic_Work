<body OnLoad="document.submitkey.key.focus();">
<?php 
  
  include("../global.dat");

  function main($user_type, $conn)
  {
    $error_str=draw_screen();
    return $error_str;
  }

function draw_screen()
{
?>
<center>
<form name=submitkey method=post action="show_eval.php">
<table>
<tr><td height=100 valign=bottom><h1>Student Login</h1></td></tr>
<tr><td><center>Please enter your key</td></tr>
<tr><td><center><input type=text size=20 name=key></td></tr>
<tr><td><center><input type=submit value="Begin Evaluation"></td></tr>
</table>
</form>
<?php

  return "";
}
?>
