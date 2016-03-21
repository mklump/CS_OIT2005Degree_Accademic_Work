<?php 
  
  include("../global.dat");

  function main($user_type)
  {
    if($user_type=="administrator" || $user_type=="faculty" || $user_type=="adfac" )
    {
      draw_mainmenu_form();
      echo "<center>";
      $error_str=draw_screen($user_type);
      echo "</center>";
    }
    else
    {
      $error_str=$error_str . "<br>-- Insufficient privilege level for attempted action";
    }
    return $error_str;
  }

function draw_screen($user_type)
{
  $crns=0;
  $name=$_POST['fac_name'];

  if($user_type=="faculty")
  {$result=mysql_query("select distinct CRN from access_control where user_name='$name' order by CRN");}
  else
  {$result=mysql_query("select distinct CRN from access_control order by CRN");}

  while($row=mysql_fetch_array($result))
  {
    if (!$crns)
    {
      echo "<br><br>Select the CRN for the course results you wish to view :";
      echo "<form method=post action=show_report.php>";
      echo "<select name=CRN size=12>";
    }
    echo "<option>" . $row[0] . "</option>";
    $crns++;
  }
  if (!$crns) {return "<br>-- You have no results to view";}
  else
  {
    echo "</select><br><Br>";
    echo "<input type=submit value=View>";
    echo "<input type=hidden name=fac_name value=" . $name . ">";
    echo "</form>";
  }
  return "";
}

?>
