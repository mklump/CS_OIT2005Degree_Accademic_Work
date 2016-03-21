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
Insertion of the key <?php echo $_POST['key']; ?> was attempted.<br>
See status below.<br>

<?php
     $valid = TRUE;
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
     $select_status = mysql_query("SELECT e_key FROM student_keys");
     $number = mysql_affected_rows();
     $counter = 0;
     while ($valid && $counter <= $number)
     {
        $key=mysql_fetch_array($select_status);
        if($key == $_POST['Key'])
        {
           $valid = FALSE;
           echo "<br>The key already exists.<br>Click on the back button.<br>";
        }
        $counter++;
     }
     if ( $valid == TRUE )
     {
        $select_status = mysql_query("SELECT CRN, user_name FROM access_control");
        $number = mysql_affected_rows();
        $counter = 0;
        while ($valid && $counter <= $number)
        {
           $access=mysql_fetch_array($select_status);
           if($access[0] == $_POST['CRN'] || $access[1] == $_POST['name'])
              $valid = FALSE;
           $counter++;
        }
        if ( $valid == TRUE )
        {
           $insert_status1 = mysql_query("INSERT INTO access_control(CRN,user_name) VALUES (" . $_POST['CRN'] . ",'" . $_POST['name'] . "')" );
           if ($insert_status1)
              echo "<br>Insertion of " . $_POST['name'] . " succeeded.";
           else
              echo "<br>Insertion of " . $_POST['name'] . " failed.";
        }
        $insert_status = mysql_query("INSERT INTO student_keys VALUES (" . $_POST['Key'] . "," . $_POST['CRN'] . ",'" . $_POST['fac_name'] . "'," . $timeNow . "," . $timeStart . "," . $timeEnd . ")" );
        if ($insert_status)
           echo "<br>Insertion of key " . $_POST['Key'] . " succeeded.";
        else
            echo "<br>Insertion of key " . $_POST['Key'] . " failed.";
     }
     else
        echo "<br>Click the back button below to correct the errors.<br>";
?>
<FORM action="manual.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <INPUT name="action" value="Back" type="submit">
</FORM>
<?php
     return "";
  }
?>

