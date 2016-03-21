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
<?php
  $CRN = $_POST['CRN'];
  if($CRN == 0)
  {
      $string = "";
      $saveAs = "Evaluation Data for all CRNs";
      $Date = ", Date " . strftime("%D at %r.", time());
  }
  else
  {
      $string = " WHERE CRN=" . $CRN;
      $saveAs = "Evaluation Data for CRN " . $CRN ;
  }

?>
<SCRIPT LANGUAGE="JavaScript">

  <!-- Begin
  function savePage() {
  document.execCommand('SaveAs','1','<?php echo $saveAs; ?>');
  }
  //  End -->
</script>

<BODY OnLoad="savePage()">
Save Evaluation To File<br>
<button onclick="javascript: document.execCommand('SaveAs','1','<?php echo $saveAs; ?>');">Click to save this page</Button>
<?php
  echo $saveAs . $Date;
  echo "<br><table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Access Control---------------------</td></tr>";
  $file = "--------------------Access Control---------------------\n";
  echo "<tr><td><b><center>ID</td><td><b><center>CRN</td><td><b><center>Instructor</td></tr>";
  $file = $file . "----ID-----CRN-------Instructor---------------------\n";
  $result=mysql_query("select * from access_control" . $string );
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
     echo "<tr>";
     for ($c=0;$c<$fields;$c++)
     {
         echo "<td>" . $row[$c] . "</td>";
         $file = $file . $row[$c];
     }
     echo "</tr>";
     $file = $file . "\n";
  }

  echo "</table><table border>";
  $file = $file . "\n";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Eval Questions---------------------</td></tr>";
  $file = $file . "--------------------Eval Questions---------------------\n";
  echo "<tr><td><b><center>ID</td><td><b><center>Question</td><td><b><center>Sequence</td><td><b><center>Type</td><td><b><center>CRN</td></tr>";
  $file = $file . "--ID----------------Question---Sequence----Type-----CRN---\n";
  if($CRN > 9999) $result=mysql_query("select question_ID, question, sequence, type, CRN from eval_questions WHERE CRN=" . $_POST['CRN'] . " OR CRN=0");
  else if($CRN == 0) $result=mysql_query("select question_ID, question, sequence, type, CRN from eval_questions");
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
     echo "<tr>";
     echo "<td>" . $row[0] . "</td>";
     $file = $file . $row[0] . "\t";
     echo "<td>" . $row[1] . "</td>";
     $file = $file . $row[1] . "\t";
     echo "<td>" . $row[2] . "</td>";
     $file = $file . $row[2] . "\t";
     echo "<td>" . $row[3] . "</td>";
     $file = $file . $row[3] . "\t";
     echo "<td>" . $row[4] . "</td>";
     $file = $file . $row[4] . "\t";
     echo "</tr>";
     $file = $file . "\n";
  }

  echo "</table><table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Eval Results---------------------</td></tr>";
  $file = $file . "--------------------Eval Results---------------------\n";
  echo "<tr><td><b><center>ID</td><td><b><center>CRN</td><td><b><center>Question ID</td><td><b><center>Answer</td><td><b><center>Time</td></tr>";
  $file = $file . "--ID---CRN-----------Question ID---Answer----Time--------\n";
  $result=mysql_query("select ID, CRN, question_ID, response, time_stamp from eval_results" . $string );
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
    $time_str=strftime("%D at %r.", $row[4]);
     echo "<tr>";
     echo "<td>" . $row[0] . "</td>";
     $file = $file . $row[0] . "\t";
     echo "<td>" . $row[1] . "</td>";
     $file = $file . $row[1] . "\t";
     echo "<td>" . $row[2] . "</td>";
     $file = $file . $row[2] . "\t";
     echo "<td>" . $row[3] . "</td>";
     $file = $file . $row[3] . "\t";
     echo "<td><center>" . $row[4] . "<br>(" . $time_str . ")</td>";
     $file = $file . $row[4] . $time_str . "\t";
     echo "</tr>";
     $file = $file . "\n";
  }

  echo "</table><table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Demographic Results---------------------</td></tr>";
  $file = $file . "--------------------Demographic Results---------------------\n";
  echo "<tr><td><b><center>ID</td><td><b><center>CRN</td><td><b><center>Standing</td><td><b><center>Exp Grade</td><td><b><center>Elec/Req</td><td><b><center>Req/Not Req</td><td><b><center>Time</td></tr>";
  $file = $file . "--ID---CRN-----------Standing---Exp Grade----Elec/Req----Req/Not Req------Time----\n";
  $result=mysql_query("select ID, CRN, course_standing, expect_grade, course_required, time_stamp, course_inmajor from demo_results" . $string );
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
    $time_str=strftime("%D at %r.", $row[5]);
     echo "<tr>";
     echo "<td>" . $row[0] . "</td>";
     $file = $file . $row[0] . "\t";
     echo "<td>" . $row[1] . "</td>";
     $file = $file . $row[1] . "\t";
     echo "<td>" . $row[2] . "</td>";
     $file = $file . $row[2] . "\t";
     echo "<td>" . $row[3] . "</td>";
     $file = $file . $row[3] . "\t";
     echo "<td>" . $row[4] . "</td>";
     $file = $file . $row[4] . "\t";
     echo "<td>" . $row[6] . "</td>";
     $file = $file . $row[6] . "\t";
     echo "<td><center>" . $row[5] . "<br>(" . $time_str . ")</td>";
     $file = $file . $row[5] . $time_str . "\t";
     echo "</tr>";
     $file = $file . "\n";
  }

  echo "</table><table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Student Keys---------------------</td></tr>";
  $file = $file . "--------------------Student Keys---------------------\n";
  echo "<tr><td><b><center>Key</td><td><b><center>CRN</td><td><b><center>Creator</td><td><b><center>Create Time</td><td><b><center>Open Time</td><td><b><center>Close Time</td></tr>";
  $file = $file . "--Key---CRN-----------Creator---Create Time----Open Time----Close Time---------\n";
  $result=mysql_query("select e_key, CRN, creator, create_time, valid_begin, valid_end from student_keys" . $string );
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
    $time_str3=strftime("%D at %r.", $row[3]);
    $time_str4=strftime("%D at %r.", $row[4]);
    $time_str5=strftime("%D at %r.", $row[5]);
     echo "<tr>";
     echo "<td>" . $row[0] . "</td>";
     $file = $file . $row[0] . "\t";
     echo "<td>" . $row[1] . "</td>";
     $file = $file . $row[1] . "\t";
     echo "<td>" . $row[2] . "</td>";
     $file = $file . $row[2] . "\t";
     echo "<td><center>" . $time_str3 . "</td>";
     $file = $file . $time_str3 . "\t";
     echo "<td><center>" . $time_str4 . "</td>";
     $file = $file . $time_str4 . "\t";
     echo "<td><center>" . $time_str5 . "</td>";
     $file = $file . $time_str5 . "\t";
     echo "</tr>";
     $file = $file . "\n";
  }
     echo "<script>document.write(" . $file . ")</script>";

     $output_file = "/home/blues/html/lbell/" . $saveAs . ".txt";
     $file_handle = fopen($output_file , "wb" );
     if($file_handle) echo "File " . $output_file . " was created.<br>";
     else echo "File " . $output_file . " was not created.<br>";
     $bytes_written = fwrite( $file_handle, $file );
     if($bytes_written) echo "Wrote " . $bytes_written . " bytes to disk.<br>";
     else echo "Nothing was written to disk.<br>";
     $file_status = fclose( $file_handle );
     if($file_status) echo "File " . $output_file . " was closed.<br>";
     else echo "File " . $output_file . " was not closed.<br>";
     return "";

  }
?>
