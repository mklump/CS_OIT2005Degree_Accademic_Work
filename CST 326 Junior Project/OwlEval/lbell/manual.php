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
      <FORM action="new.php" method="post">
        <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
        <INPUT name="action" value="Create Keys" type="submit">
      </FORM>
    <TD>
      <FORM action="edit.php" method="post">
        <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
        <INPUT name="action" value="Edit Eval" type="submit">
      </FORM>
    <TD>
      <FORM action="adminMap.php" method="post">
        <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
        <INPUT name="action" value="Admin Site Map" type="submit">
      </FORM>
</TABLE>
Insert one key at a time.<br>
Warning: The key can be up to any ten characters.<br>

<FORM action="insert.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <TABLE>
    <TR>
      <TH align=right>Instructor Name
      <TD>
<?php
  $numberInstructors=0;
  $result=mysql_query("select user_name from users where privilege = \"adfac\" || privilege = \"faculty\"");
  while($row=mysql_fetch_array($result))
  {
    if (!$numberInstructors)
    {
      echo "<select name=\"name\">";
    }
    $selected = "";
    if( $row[0] == $instructor_name[0]) $selected = " selected";
    echo "<option" . $selected . ">" . $row[0] . "</option>";
    $numberInstructors++;
  }
  if (!$numberInstructors) {return "<br>-- no Instructors in the database";}
  else
  {
    echo "</select>";
  }
?>
    <TR>
      <TH align=right>CRN
      <TD>
        <INPUT name="CRN" type="text">
    <TR>
      <TH align=right>key
      <TD>
        <INPUT name="Key" type="text">
    <TR>
      <TH align=right>When do you want the evaluation to start?(mm/dd/yyyy hh:mm)
      <TD>
        <INPUT name="start" type="text">
        <a href=http://www.gnu.org/software/tar/manual/html_chapter/tar_7.html>Valid date and time formats</a>
    <TR>
      <TH align=right>When do you want the evaluation to end?(mm/dd/yyyy hh:mm)
      <TD>
        <INPUT name="end" type="text">
        <a href=http://us2.php.net/manual/en/function.strtotime.php>More valid date and time formats</a>
  </TABLE>
  <INPUT name="action" value="Insert Key" type="submit">
</FORM>

<FORM action="openEval.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <INPUT name="action" value="Back" type="submit">
</FORM>

<?php
     return "";
  }
?>

