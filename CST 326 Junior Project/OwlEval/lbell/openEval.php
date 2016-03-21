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
Evaluation Management Page <br><br>

Please choose one of the options above or below by clicking on a button.<br>
The CRNs below are the only ones available in the access control table of the database.<br>
New CRNs are available after creating keys for the CRN by clicking the Create Keys button above.<br>
You may need to refresh this page after changes are done.<br>
<br>
<TABLE frame="border">
  <TR><TH align=center>
    <FORM action="erase.php" method="post">
      <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
        <TABLE>
          <TR><TH align=center colspan="2">Delete Keys
          <TR><TH align=center colspan="2">Select a CRN below
          <TR>
            <TH align=center>CRN
          <TD>
<?php
  $result=mysql_query("select CRN from student_keys");
  $existing = mysql_affected_rows();
  $CRNarray = array();
  echo "<select name=\"CRN\">";
  $i=0; //row count
  $arraylength =0;
  if ($existing > 0) //skip if no CRNs exist
  {
     while($row=mysql_fetch_array($result))
     {
       if($i>0) // skip on first row
       {
          for($x = $arraylength; $x >= 0; $x--) //search array for CRNs
          {
             if($CRNarray2[$x]==$row[0])  // of it already exists in array exit
             {
                $exists = TRUE;
                break;
             }
             else     // otherwise add it to the array and flag it doesn't exist
             {
               $exists = FALSE;
               $CRNarray2[$arraylength++] = $row[0]; // add and increment
             }
          }
       }
       else $CRNarray2[$arraylength++] = $row[0]; // add first one and increment
       if(!$exists)
       {
           echo "<option>" . $row[0] . "</option>";
           $options = $options . "<option>" . $row[0] . "</option>";
       }
       $i++;
     }
  }
  echo "</select>";
?>
        </TABLE>
            <center><INPUT name="action" value="Delete keys for CRN" type="submit">
    </FORM>
    <TD>
    <FORM action="print.php" method="post">
      <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
      <TABLE>
          <TR><TH align=center colspan="2">Print Keys
          <TR><TH align=center colspan="2">Select a CRN below
        <TR><TH align=center>CRN
          <TD>
<?php
  echo "<select name=\"CRN\">" . $options. "</select>";
?>
      </TABLE>
        <center><INPUT name="action" value="Print keys for CRN" type="submit">
    </FORM>
    <TD>
    <FORM action="saveToFile.php" method="post">
      <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
      <TABLE>
          <TR><TH align=center colspan="2">View Eval
          <TR><TH align=center colspan="2">Select a CRN below
          <TR><TH align=center colspan="2">Select 0 for all CRNs
          <TR><TH align=right>CRN<TD>
<?php
  $result=mysql_query("select CRN from access_control");
  $existing = mysql_affected_rows();
  echo "<select name=\"CRN\">";
  echo "<option>0</option>";
  $CRNarray2 = array();
  $i=0; //row count
  $arraylength =0;
  $exists = FALSE;
  if ($existing > 0) //skip if no CRNs exist
  {
     while($row=mysql_fetch_array($result))
     {
       if($i>0) // skip on first row
       {
          for($x = $arraylength; $x >= 0; $x--) //search array for CRNs
          {
             if($CRNarray2[$x-1]==$row[0])  // of it already exists in array exit
             {
                $exists = TRUE;
                break;
             }
             else     // otherwise add it to the array and flag it doesn't exist
             {
               $exists = FALSE;
               $CRNarray2[$arraylength++] = $row[0]; // add and increment
             }
          }
       }
       else $CRNarray2[$arraylength++] = $row[0]; // add first one and increment
       if(!$exists) echo "<option>" . $row[0] . "</option>";
       $i++;
     }
  }
  echo "</select>";
?>
      </TABLE>
      <center><INPUT name="action" value="View Eval" type="submit">
    </FORM>
</TABLE>
<?php
     if( $_POST['fac_name'] == "lbell")
     {
?>
      <form name=submitkey method=post action="show_eval.php">
         <TABLE>
          <TR><TH align=center colspan="2">Enter a student Eval
          <TR><TH align=center colspan="2">Select a key below
          <TR><TH align=right>Key<TD>
<?php
  $result=mysql_query("select e_key from student_keys");
  $existing = mysql_affected_rows();
  echo "<select type=text name=key>";
  if ($existing  > 0)
  {
     while($row=mysql_fetch_array($result))
     {
       echo "<option>" . $row[0] . "</option>";
     }
  }
  echo "</select>";
?>
         </TABLE>
         <INPUT name="action" value="View Eval" type="submit">
      </FORM>
      <FORM action="select_report.php" method="post">
         <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
            View Eval
         <INPUT name="action" value="View Evaluation Results" type="submit">
      </FORM>
            <FORM action="Document.txt" method="post">
         <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
            View Eval
         <INPUT name="action" value="Document.txt" type="submit">
      </FORM>
<?php
     }
     return "";
  }
?>
