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
Create Keys Part 2<br><br>

This is where the student login keys are created for a course evaluation. <br>
The following information was attempted to be entered into the database. <br>

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
        $keys = array();
        $seed = time() + date();
        for ($i = 1; $i <= $number; $i++)
        $keys[$i] =  round( ($seed * gmp_strval(gmp_random(1))) / ($_POST['CRN'] * 1000000));
        $result=mysql_query("select CRN from access_control");
        $existingCRNs = mysql_affected_rows();
        if ($existingCRNs  > 0)
        {
           while($row=mysql_fetch_array($result))
           {
               if( $row[0] == $_POST['CRN'] ) $exists = TRUE;
           }
        }
        if (!$exists)
        {
           $insert_status1 = mysql_query("INSERT INTO access_control(CRN,user_name) VALUES (" . $_POST['CRN'] . ",'" . $_POST['name'] . "')" );
           if ($insert_status1)
              echo "<br>Insertion of " . $_POST['name'] . " " . $keys[$i] . " succeeded.";
           else
              echo "<br>Insertion of access_control failed.";
        }
        else echo "<br>CRN already exists.";
        for ($i = 1; $i <= $number; $i++)
        {
           $insert_status = mysql_query("INSERT INTO student_keys VALUES (" . $keys[$i] . "," . $_POST['CRN'] . ",'" . $_POST['fac_name'] . "'," . $timeNow . "," . $timeStart . "," . $timeEnd . ")" );
           if ($insert_status)
              echo "<br>Insertion of key " . $keys[$i] . " succeeded.";
           else
              echo "<br>Insertion failed.";
        }
     // If statement continues below
?>
<br>
<FORM action="erase.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <input type=hidden name=name value="<?php echo $_POST['name']; ?>"></input>
  <input type=hidden name="CRN" value="<?php echo $_POST['CRN']; ?>"></input>
  <INPUT name="action" value="Delete keys" type="submit">
</FORM>

<FORM action="print.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <input type=hidden name="CRN" value="<?php echo $_POST['CRN']; ?>"></input>
  <INPUT name="action" value="Print keys" type="submit">
</FORM>

<?php
     // If statement continued from above
     }
     else
        echo "<br>Click the back button below to correct the errors.<br>";
?>

<FORM action="new.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <INPUT name="action" value="Back" type="submit">
</FORM>

<?php
     return "";
  }
?>
