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

Update Evaluation  <br><br>

The information was updated for the following: <br>

<TABLE>
  <TR>
    <TH align=right>Instructor Name
    <TD><?php echo $_POST['name']; ?>
  <TR>
    <TH align=right>CRN
    <TD><?php echo $_POST['CRN']; ?>
  <TR>
    <TH align=right>Number of students in the course
    <TD><?php echo $_POST['number']; ?>
  <TR>
    <TH align=right>When do you want the evaluation to start?(mm/dd/yyyy hh:mm)
    <TD><?php echo $_POST['start']; ?>
  <TR>
    <TH align=right>When do you want the evaluation to end?(mm/dd/yyyy hh:mm)
    <TD><?php echo $_POST['end']; ?>
</TABLE>

<?php
     $number = $_POST['number'];
     $valid = TRUE;
     if ($number < 1 )
     {
        echo "<br>number of students were too low<br>";
        $valid = FALSE;
     }
     if ($_POST['CRN'] <= 9999 )
     {
         echo "<br>CRN has too few digits<br>";
         $valid = FALSE;
     }
     if ($_POST['CRN'] > 99999 )
     {
         echo "<br>CRN has too many digits<br>";
         $valid = FALSE;
     }
     if ( $_POST['name'] == NULL )
     {
         echo "<br>Instructor name is NULL<br>";
         $valid = FALSE;
     }
     $timeEnd = strtotime($_POST['end']);
     $timeStart = strtotime($_POST['start']);
     $timeNow = time();
     if ( $timeEnd <= $timeStart )
     {
         echo "<br>The end time must be after the start time.<br>";
         $valid = FALSE;
     }
     if ( $timeStart < $timeNow )
     {
         echo "<br>The start time must be after the time now.<br>";
         $valid = FALSE;
     }
     if ($timeEnd == -1)
     {
         echo "<br>The end time is not valid.<br>";
         $valid = FALSE;
     }
     if ($timeStart == -1)
     {
         echo "<br>The start time is not valid.<br>";
         $valid = FALSE;
     }
     if ( $valid == TRUE )
     {
        $UPDATE_status = mysql_query("UPDATE access_control SET CRN=" . $_POST['CRN'] . ", user_name='" . $_POST['name'] . "' WHERE CRN=" . $_POST['old_CRN'] );
        $existing = mysql_affected_rows();
        if ($existing)
           echo "<br>UPDATE of " . $_POST['name'] . " succeeded.";
        else
        {
           echo "<br>UPDATE of  " . $_POST['name'] . " in access_control failed.";
           $insert_status1 = mysql_query("INSERT INTO access_control(CRN,user_name) VALUES (" . $_POST['CRN'] . ",'" . $_POST['name'] . "')" );
           if ($insert_status1)
              echo "<br>Insertion of " . $_POST['name'] . " succeeded.";
           else
              echo "<br>Insertion of " . $_POST['name'] . " failed.";
        }
        for ($i = 0; $i < $_POST['old_number']; $i++)
        {
            if($i < $number)
            {
                $UPDATE_status2 = mysql_query("UPDATE student_keys SET e_key=" . $_POST['key'.$i] . ", CRN=" . $_POST['CRN'] . ", creator='" . $_POST['fac_name'] . "', create_time=" . $timeNow . ", valid_begin=" . $timeStart . ", valid_end=" . $timeEnd . " WHERE e_key=" . $_POST['old_key'.$i] );
                if ($UPDATE_status2)
                   echo "<br>UPDATE of key " . $_POST['key'.$i] . " succeeded.";
                else
                    echo "<br>UPDATE of key " . $_POST['key'.$i] . " failed.";
            }
            else
            {
                $UPDATE_status3 = mysql_query("DELETE FROM student_keys WHERE e_key=" . $_POST['old_key'.$i] );
                $deleted = mysql_affected_rows();
                if ($deleted)
                   echo "<br>Key " . $_POST['old_key'.$i] . " was deleted.";
                else
                    echo "<br>Key " . $_POST['old_key'.$i] . " was NOT deleted.";
            }
        }
        $select_status = mysql_query("SELECT * FROM student_keys WHERE CRN = " . $_POST['CRN']);
        $existing = mysql_affected_rows();
        if($existing < $number)
        {
            $numberToAdd = $number - $existing;
?>
            <FORM action="create.php" method="post">
              <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
              <input type=hidden name=name value="<?php echo $_POST['name']; ?>"></input>
              <input type=hidden name=CRN value="<?php echo $_POST['CRN']; ?>"></input>
              <input type=hidden name=number value="<?php echo $numberToAdd; ?>"></input>
              <input type=hidden name=start value="<?php echo $_POST['start']; ?>"></input>
              <input type=hidden name=end value="<?php echo $_POST['end']; ?>"></input>
              <INPUT name="action" value="Click here to add <?php echo $numberToAdd; ?> more keys for CRN <?php echo $_POST['CRN']; ?> ." type="submit"></P>
            </FORM>
<?php
        }
?>

<br>

<FORM action="print.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <input type=hidden name="CRN" value="<?php echo $_POST['CRN']; ?>"></input>
  <INPUT name="action" value="Print keys" type="submit">
</FORM>

<?php
     }
     else
       echo "<br>Click the back button below to correct the errors.<br>";
?>

<FORM action="edit.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <INPUT name="action" value="Back" type="submit">
</FORM>

<?php
     return "";
  }
?>
