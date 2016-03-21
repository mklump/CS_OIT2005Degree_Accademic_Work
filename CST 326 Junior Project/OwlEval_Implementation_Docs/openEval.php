<?php

  include("file:///C|/Documents%20and%20Settings/Nostro/Application%20Data/SSH/global.dat");

  function main($user_type)
  {
    $error_str=DrawPage();
    return $error_str;
  }

  function DrawPage()
  {
?>
         Evaluation  <br><br>

Please choose one of the options below by clicking on a button.<br>

<FORM action="file:///C|/Documents%20and%20Settings/Nostro/Application%20Data/SSH/temp/new.php" method="post">
<input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
    <P>
       <INPUT name="action" value="Start a new evaluation" type="submit">
    </P>
</FORM>

<FORM action="file:///C|/Documents%20and%20Settings/Nostro/Application%20Data/SSH/temp/edit.php" method="post">
<input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
    <P>
       <INPUT name="action" value="Edit an evaluation" type="submit">
    </P>
</FORM>

     <?php
     return "";
  }
?>
