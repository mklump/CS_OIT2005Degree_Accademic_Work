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
<B>This page retrieves all information about a CRN from the data base.<br>
Edit any of the following information then click the Update button. Click the Back button to cancel editing.</B>

<FORM action="update.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <TABLE>
    <!--The table continues to the bottom of the page-->
<?php
  $instructor=mysql_query("select user_name from access_control where CRN = " . $_POST['CRN']);
  $numberCRNs = mysql_affected_rows();
  if ($numberCRNs < 0)
  {
     echo "<br>CRN does not exist in Access Control table.<br>Unknown instructor. <br>Attempting to get data from Student Keys table.<br>";
  }
  else
  {
     $instructor_name=mysql_fetch_array($instructor);
  }
  $select_status = mysql_query("SELECT e_key, valid_begin, valid_end FROM student_keys WHERE CRN = " . $_POST['CRN'] );
  $numberStudents = mysql_affected_rows();
  if ($numberStudents < 1)
  {
     echo "<br>CRN does not exist.<br>Click on the back button.<br>";
  }
  else
  {
     $keys = array();
     for ($i = 0; $i < $numberStudents; $i++)
     {
        $record=mysql_fetch_array($select_status);
        $time_start=strftime("%D %r", $record[1]);
        $time_end=strftime("%D %r", $record[2]);
        if($i%3 == 0 ) echo '<TR>';
        echo '<TH align=right>Key # ' . ($i+1) . '<TD><INPUT name=key' . $i . ' type=text value=' . $record[0] . '>';
        echo '<input type=hidden name=old_key' . $i . ' value=' . $record[0] . '></input>';
        $keys[$i]=$record[0];
     }
  }
  $result=mysql_query("select ID from access_control");
  $ID=mysql_fetch_array($result);
  echo '<input type=hidden name=ID value=' . $ID[0] . '></input>';
?>
    <!--The table continued from the top of the page-->
    <input type=hidden name=old_number value="<?php echo $numberStudents; ?>"></input>
    <input type=hidden name=keys value="<?php echo $keys; ?>"></input>
    <TR>
      <TH colspan="3" align=right>Instructor Name
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
      <TH colspan="3" align=right>CRN
      <TD>
        <INPUT name="CRN" type="text" maxlength=5 size=5 value = "<?php echo $_POST['CRN']?>" >
        <input type=hidden name=old_CRN value="<?php echo $_POST['CRN']; ?>"></input>
    <TR>
      <TH colspan="3" align=right>Number of students in the course
      <TD>
        <INPUT name="number" type="text" maxlength=2 size=2 value = "<?php echo $numberStudents;?>" >
    <TR>
      <TH colspan="3" align=right>When do you want the evaluation to start?(mm/dd/yyyy hh:mm)
      <TD>
        <INPUT name="start" type="text" value = "<?php echo $time_start;?>" >
      <TD colspan="3">
        <a href=http://www.gnu.org/software/tar/manual/html_chapter/tar_7.html>Valid date and time formats</a>
    <TR>
      <TH colspan="3" align=right>When do you want the evaluation to end?(mm/dd/yyyy hh:mm)
      <TD>
        <INPUT name="end" type="text" value = "<?php echo $time_end;?>" >
      <TD colspan="3">
        <a href=http://us2.php.net/manual/en/function.strtotime.php>More valid date and time formats</a>
    <TR>
      <TH colspan="3" align=right>Click this button to change the information.
      <TD>
        <INPUT name="action" value="Update information" type="submit">
  </TABLE>
</FORM>

Click this button to cancel.

<FORM action="edit.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <INPUT name="action" value="Back" type="submit">
</FORM>

<?php
     return "";
  }
?>
