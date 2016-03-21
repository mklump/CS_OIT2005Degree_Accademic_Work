<?php 

  include("../global.dat");

  function main($user_type)
  {
    $error_str="";

    if ($user_type=="adfac" || $user_type=="faculty")
    {
      $error_str=show_screen();
    }
    else
    {
      $error_str=$error_str . "<br>-- You do not have sufficient access privilege to use this page.";
    }
    return $error_str;
  }

function show_screen()
{
  $error_str="";

  $name=$_POST['fac_name'];

  echo "<BODY VLINK=\"#OOOO66\">\n";
  echo "<BODY ALINK=\"#COCOCO\">\n";
  echo "<center><h1>Please choose the CRN to augment</h1>\n";
  echo "<form method=post action=eval_aug.php>\n";
  echo "<input type=hidden name=fac_name value=$name>\n";
  echo "<select name=crn>\n";

  //change to limit by access_control
  $result=mysql_query("select distinct CRN from student_keys order by CRN");

  while ($row=mysql_fetch_array($result))
  {
    echo "<option>" . $row[0] . "</option>\n";
  }
  echo "</select>\n";
  echo "<input type=submit value=Augment>\n";
  echo "</form>\n";
  return $error_str;
}
?>