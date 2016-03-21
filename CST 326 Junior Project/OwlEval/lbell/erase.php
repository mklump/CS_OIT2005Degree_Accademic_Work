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
Attempting to delete all the keys for CRN <?php echo $_POST['CRN']; ?>. <br>See the details below.

<?php
    if ($_POST['CRN'] == 12345) echo "<br>Cannot delete keys for CRN " . $_POST['CRN'] ;
    else
    {
       echo "<br>Deleting keys for CRN " . $_POST['CRN'] ;
       $delete_status = mysql_query("DELETE FROM student_keys WHERE CRN=" . $_POST['CRN'] );
       printf("<br>Records deleted: %d\n", mysql_affected_rows() );
       if ($delete_status)
         echo "<br>Delete succeeded.";
       else
         echo "<br>Delete failed.";
    }
?>
<br><br>Click the Delete Results button below to delete all the students responces for this CRN.<br>
Warning: This should only be done if all the evaluation data is to be deleted.
<FORM action="deleteResults.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <input type=hidden name=CRN value="<?php echo $_POST['CRN']; ?>"></input>
  <INPUT name="action" value="Delete Results" type="submit">
</FORM>

Click the back button below to go back to the Eval Management page.

<FORM action="openEval.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <INPUT name="action" value="Back" type="submit">
</FORM>

Click the manual button below to insert student keys into the database.

<FORM action="manual.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <INPUT name="action" value="manual" type="submit">
</FORM>

<?php
     return "";
  }
?>
