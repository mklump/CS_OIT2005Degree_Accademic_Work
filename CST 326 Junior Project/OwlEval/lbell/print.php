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

<STYLE type="text/css">
  BODY {
    margin-bottom:0;
    margin-left:0;
    margin-right:0
  }
</STYLE>

<SCRIPT LANGUAGE="JavaScript">

  <!-- Begin
  function printPage() {
  window.print();
  }
  //  End -->
</script>

<BODY OnLoad="printPage()">
  <!-- topmargin=0.25 leftmargin=0.25 rightmargin=0.5 bottommargin=0.5-->

  <B>Set font to medium text size. Click View, Text Size, Medium.<br>
  Set all your browser margins to 0.3". Click File then Page Setup...<br>
  Please wait for the printer dialog box to appear, set the printer properties, then click Print.</B>

<?php

     $select_status = mysql_query("SELECT e_key, valid_begin, valid_end FROM student_keys WHERE CRN = " . $_POST['CRN'] );
     $number = mysql_affected_rows();
     if ($number < 1)
        echo "<br>CRN does not exist.<br>Click on the back button.<br>";
     else
     {
       echo "<br>_____________________________________________________________________________________<br>";
       for ($i = 0; $i < $number; $i++)
       {
         $row=mysql_fetch_array($select_status);
         $time_start=strftime("%D at %r.", $row[1]);
         $time_end=strftime("%D at %r.", $row[2]);
         echo "<br>CRN: " . $_POST['CRN'] . ". Use key " . $row[0] . " to log in between " . $time_start . " and " . $time_end . "<br>";
         echo "Website URL is <a href=http://matthew.klump-pdx.com/blues/glenn/student_login.php>http://matthew.klump-pdx.com/blues/glenn/student_login.php</a><br>";
         echo "_____________________________________________________________________________________<br>";
         if($i == 9) echo "<br><H4></H4>_____________________________________________________________________________________<br>";
         if($i > 15 && ($i-9)%12 == 0) echo "<br><H4></H4>                                                                         _____________________________________________________________________________________<br>";
       }
     }
     draw_mainmenu_form();
?>

<FORM action="openEval.php" method="post">
  <input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
  <INPUT name="action" value="Back" type="submit">
</FORM>

<?php
     return "";
  }
?>

