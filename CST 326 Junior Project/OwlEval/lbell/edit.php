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
Edit Evaluation  <br><br>

<B>The following can be edited:</B>
<LI>Student Keys
<LI>Instructor Name
<LI>CRN
<LI>Evaluation Start Time
<LI>Evaluation End Time
<LI>Number of students (either add or delete keys)

<br><br>To edit an evaluation for a course enter the CRN of the course you want to edit then click on the Retrieve information for CRN button.<br>

<FORM action="retrieve.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  CRN
<?php
  $result=mysql_query("select CRN from access_control");
  $existing = mysql_affected_rows();
  echo "<select name=\"CRN\">";
  
  $CRNarray3 = array();
  $i=0; //row count
  $arraylength =0;
  if ($existing > 0)  //skip if no CRNs exist
  {
     while($row=mysql_fetch_array($result))
     {
       if($i>0) // skip on first row
       {
          for($x = $arraylength; $x >= 0; $x--) //search array for CRNs
          {
             if($CRNarray3[$x]==$row[0])  // of it already exists in array exit
             {
                $exists = TRUE;
                break;
             }
             else     // otherwise add it to the array and flag it doesn't exist
             {
               $exists = FALSE;
               $CRNarray3[$arraylength++] = $row[0]; // add and increment
             }
          }
       }
       else $CRNarray3[$arraylength++] = $row[0]; // add first one and increment
       if(!$exists) echo "<option>" . $row[0] . "</option>";
       $i++;
     }
  }
  echo "</select>";
?>
  <br>
  <INPUT name="action" value="Retrieve information for CRN above" type="submit">
</FORM>

<FORM action="openEval.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <INPUT name="action" value="Back" type="submit">
</FORM>

<?php
     return "";
  }
?>
