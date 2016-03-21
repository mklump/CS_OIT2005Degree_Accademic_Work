<?php

  include("../global.dat");

  function main($user_type)
  {
    if($user_type == "adfac" || $user_type == "admin")
        $error_str=DrawPage();
    else
        $error_str = $error_str . "<br>You don't have access to this page";
    return $error_str;
  }

  function DrawPage()
  {
?>
<!--Navigation Button Bar-->
<TABLE>
  <TR><!--one row-->
    <TD><?php draw_mainmenu_form(); ?>
    <TD>
      <FORM action="openEval.php" method="post">
        <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
        <INPUT name="action" value="Eval Management" type="submit">
      </FORM>
    <TD>
      <FORM action="edit.php" method="post">
        <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
        <INPUT name="action" value="Edit Eval" type="submit">
      </FORM>
    <TD>
      <FORM action="manual.php" method="post">
        <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
        <INPUT name="action" value="Insert Key" type="submit">
      </FORM>
    <TD>
      <FORM action="adminMap.php" method="post">
        <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
        <INPUT name="action" value="Admin Site Map" type="submit">
      </FORM>
</TABLE>

Create Keys  <br>

Enter the following information then click the Create Keys button to create student keys for a course evaluation. <br>
The Instructors below are the only ones available in the users table of the database.<br>
New Instructors are available after adding their login name and passwords to the system.<br>
You may need to refresh this page after changes are done.<br>
<FORM action="create.php" method="post">
<input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <TABLE>
    <TR><TH align=right>Instructor Name<TD>
<?php
  $number=0;
  $result=mysql_query("select user_name from users where privilege = \"adfac\" || privilege = \"faculty\"");
  while($row=mysql_fetch_array($result))
  {
    if (!$number)
    {
      echo "<select name=\"name\">";
    }
    echo "<option>" . $row[0] . "</option>";
    $number++;
  }
  if (!$number) {return "<br>-- no users in the database";}
  else
  {
    echo "</select>";
  }
?>
    <TR><TH align=right>CRN<TD><INPUT maxlength=5 size=5 name="CRN" type="text">
    <TR><TH align=right>Number of students in the course<TD><INPUT maxlength=2 size=2 name="number" type="text">
    <TR><TH align=right>When do you want the evaluation to start?(mm/dd/yyyy hh:mm)<TD><INPUT name="start" type="text">
      <a href=http://www.gnu.org/software/tar/manual/html_chapter/tar_7.html>Valid date and time formats</a>
    <TR><TH align=right>When do you want the evaluation to end?(mm/dd/yyyy hh:mm)<TD><INPUT name="end" type="text">
      <a href=http://us2.php.net/manual/en/function.strtotime.php>More valid date and time formats</a>
    <TR><TH align=right>Click this button.<TD><INPUT name="action" value="Create Keys" type="submit">
  </TABLE>
</FORM>

<?php
     return "";
  }
?>

