<?php 

  include("../global.dat");

  function main($user_type)
  {
    if ($user_type=="admin" || $user_type=="faculty" || $user_type=="adfac" || $user_type=="change_pword")
    {
      $error_str=draw_screen($user_type);
    }
    else
    {
      $error_str=$error_str . "<br>-- You do not have a valid session, please login.";
    }
    return $error_str;
  }


function draw_screen($user_type)
{
?>
<BODY VLINK="#OOOO66">
<BODY ALINK="#COCOCO">
<center>
<BR><BR><BR><BR>
<tr><td><h1>MENU</h1></td></tr>
<table>
<tr><td><center>


<?php
if ($user_type == "adfac" || $user_type=="admin" || $user_type=="change_pword" || $user_type=="faculty")
{
  echo "<FORM action=../mike/change_password.php method=post><input type=hidden name=fac_name value=" . $_POST['fac_name'] . "></input>";
  echo "<P><INPUT name=action value=\"      Change Password      \" type=submit></P></FORM>";
}

if ($user_type == "adfac" || $user_type=="admin")
{
  echo "<FORM action=http://matthew.klump-pdx.com/blues/lbell/openEval.php method=post>";
  echo "<input type=hidden name=fac_name value=" . $_POST['fac_name'] . "></input>";
  echo "<P><INPUT name=action value=\"      Create Evaluation       \" type=submit></P></FORM>";

  echo "<FORM action=http://matthew.klump-pdx.com/blues/glenn/account_admin.php method=post>";
  echo "<input type=hidden name=fac_name value=" . $_POST['fac_name'] . "></input>";
  echo "<P><INPUT name=action value=\"         User Accounts          \" type=submit></P></FORM>";
}

if ($user_type == "adfac" || $user_type=="admin" || $user_type=="faculty")
{

  echo "<FORM action=http://matthew.klump-pdx.com/blues/mklump/choose_aug.php method=post>";
  echo "<input type=hidden name=fac_name value=" . $_POST['fac_name'] . "></input>";
  echo "<P><INPUT name=action value=\"Add/Remove Questions\" type=submit></P></FORM>";

  echo "<FORM action=http://matthew.klump-pdx.com/blues/glenn/select_report.php method=post>";
  echo "<input type=hidden name=fac_name value=" . $_POST['fac_name'] . "></input>";
  echo "<P><INPUT name=action value=\"View Evaluation Results\" type=submit></P></FORM>";
}
?>

</table>
<?php



return "";
}
?>
