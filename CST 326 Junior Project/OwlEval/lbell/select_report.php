<?php 
  
  include("../global.dat");

  function main($user_type)
  {
    if($user_type=="administrator" || $user_type=="faculty" || $user_type=="adfac" )
    {
      $error_str=draw_screen();
    }
    else
    {
      $error_str=$error_str . "<br>-- Insufficient privilege level for attempted action";
    }
    return $error_str;
  }

function draw_screen()
{
  $crns=0;
  $name=$_POST['fac_name'];
  $result=mysql_query("select CRN from access_control where user_name='" . $name . "'");
  while($row=mysql_fetch_array($result))
  {
    if (!$crns)
    {
      echo "<form method=post action=show_report.php>";
      echo "<select name=CRN>";
    }
    echo "<option>" . $row[0] . "</option>";
    $crns++;
  }
  if (!$crns) {return "<br>-- You have no results to view";}
  else
  {
    echo "</select>";
    echo "<input type=submit value=View>";
    echo "<input type=hidden name=fac_name value=" . $name . ">";
    echo "</form>";
  }
  return "";
}

?>
