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
Attempting to delete all the results for CRN <?php echo $_POST['CRN']; ?>. <br>See the details below.

<?php
    echo "<br>Deleting Eval Results for CRN " . $_POST['CRN'] ;
    $delete_status = mysql_query("DELETE FROM eval_results WHERE CRN=" . $_POST['CRN'] );
    if ($delete_status)
    {
      echo "<br>Deleting Eval Results succeeded.";
      printf("<br>Records deleted: %d\n", mysql_affected_rows() );
    }
    else
      echo "<br>Deleting Eval Results failed. CRN = "  . $_POST['CRN'];
      
    echo "<br>Deleting Demographic Results for CRN " . $_POST['CRN'] ;
    $delete_status=mysql_query("DELETE FROM demo_results where CRN = " . $_POST['CRN']);
    if ($delete_status)
    {
      echo "<br>Deleting Demographic Results succeeded.";
      printf("<br>Records deleted: %d\n", mysql_affected_rows() );
    }
    else
      echo "<br>Deleting Demographic Results failed. CRN = "  . $_POST['CRN'];
?>
<br><br>Click the back button below to go back to the Eval Management page.

<FORM action="openEval.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <INPUT name="action" value="Back" type="submit">
</FORM>

<?php
     return "";
  }
?>
