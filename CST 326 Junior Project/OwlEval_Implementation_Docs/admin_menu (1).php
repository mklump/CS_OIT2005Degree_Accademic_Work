<?php 

  include("file:///C|/Documents%20and%20Settings/Nostro/Application%20Data/SSH/global.dat");

  function main($user_type)
  {
    if ($user_type=="admin" || $user_type=="faculty" || $user_type=="adfac" )
    {
      $error_str=draw_screen();
    }
    else
    {
      $error_str=$error_str . "<br>-- You do not have a valid session, please login.";
    }
    return $error_str;
  }


function draw_screen()
{
?>
<BODY VLINK="#OOOO66">
<BODY ALINK="#COCOCO">
<center>
<BR><BR><BR><BR>
<tr><td><h1>MENU</h1></td></tr>
<table>
<tr><td><center>

<FORM action="" method="post">
<input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
<P><INPUT name="action" value="      Change Password       " type="submit"></P>
</FORM>

<FORM action="http://www.culbertson.info/blues/lbell/openEval.php" method="post">
<input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
<P><INPUT name="action" value="   Evaluation Editor    " type="submit"></P>
</FORM>

<FORM action="" method="post">
<input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
<P><INPUT name="action" value="     ScanTron      " type="submit"></P>
</FORM>

</table>
<?php

return "";
}
?>