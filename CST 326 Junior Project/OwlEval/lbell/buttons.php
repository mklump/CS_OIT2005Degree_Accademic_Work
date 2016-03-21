
<!--Navigation Button Bar-->
<TABLE>
  <TR><!--one row-->
    <TD>
      <FORM action="..\gwr\admin_menu.php" method="post">
        <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
        <INPUT name="action" value="Main Menu" type="submit">
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

