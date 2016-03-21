<body OnLoad="document.changepass.current_password.focus();">
<?PHP

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
<form name=changepass method=post action="validate_password_changes.php">	
<input type=hidden name=fac_name value=<?PHP print($_POST['fac_name']) ?>>
<table>
<tr><td height=100 valign=bottom><h1>Change Password</h1></td></tr>
<tr><td><center>Current Password</td></tr>
<tr><td><center><input type=password size=20 name=current_password></td></tr>
<tr><td><center>New Password</td></tr>
<tr><td><center><input type=password size=20 name=new_password></td></tr>
<tr><td><center>Retype New Password</td></tr>
<tr><td><center><input type=password size=20 name=retype_new_password></td></tr>
<tr><td><center><input type=submit value="Submit Changes"</td></tr>
</table>
</form>
<?php
draw_mainmenu_form();
return"";

}
?>
