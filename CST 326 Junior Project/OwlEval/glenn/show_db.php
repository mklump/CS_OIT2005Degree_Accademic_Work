<?php 
  
  include("../global.dat");

  function main($user_type)
  {
    show_db();
  }

function show_db()
{
  echo "<table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Access Control---------------------</td></tr>";
  $result=mysql_query("select * from access_control");
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
     echo "<tr>";
     for ($c=0;$c<$fields;$c++) { echo "<td>" . $row[$c] . "</td>"; }
     echo "</tr>";
  }

  echo "</table><table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Access Log---------------------</td></tr>";
  echo "<tr><td><b><center>ID</td><td><b><center>User Name</td><td><b><center>IP</td><td><b><center>Last Access Time</td></tr>";
  $result=mysql_query("select ID, user_name, IP_address, time_stamp from access_log");
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
    $time_str=strftime("%D at %r.", $row[3]);
     echo "<tr>";
     echo "<td>" . $row[0] . "</td>";
     echo "<td>" . $row[1] . "</td>";
     echo "<td>" . $row[2] . "</td>";
     echo "<td><center>" . $row[3] . "<br>(" . $time_str . ")</td>";
     echo "</tr>"; 
  }

  echo "</table><table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Eval Questions---------------------</td></tr>";
  echo "<tr><td><b><center>ID</td><td><b><center>Question</td><td><b><center>Sequence</td><td><b><center>Type</td><td><b><center>Active</td><td><b><center>CRN</td></tr>";
  $result=mysql_query("select question_ID, question, sequence, type, current, CRN from eval_questions");
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
     echo "<tr>";
     echo "<td>" . $row[0] . "</td>";
     echo "<td>" . $row[1] . "</td>";
     echo "<td>" . $row[2] . "</td>";
     echo "<td>" . $row[3] . "</td>";
     echo "<td>" . $row[4] . "</td>";
     echo "<td>" . $row[5] . "</td>";
     echo "</tr>"; 
  }

  echo "</table><table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Eval Results---------------------</td></tr>";
  echo "<tr><td><b><center>ID</td><td><b><center>CRN</td><td><b><center>Question ID</td><td><b><center>Answer</td><td><b><center>Time</td></tr>";
  $result=mysql_query("select ID, CRN, question_ID, response, time_stamp from eval_results");
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
    $time_str=strftime("%D at %r.", $row[4]);
     echo "<tr>";
     echo "<td>" . $row[0] . "</td>";
     echo "<td>" . $row[1] . "</td>";
     echo "<td>" . $row[2] . "</td>";

     if(strlen($row[3]) > 20) 
     {
       echo "<td>" . substr($row[3],0,20) . "<br>[truncated]</td>";
     }
     else
     {
       echo "<td>" . $row[3] . "</td>";
     }
     echo "<td><center>" . $row[4] . "<br>(" . $time_str . ")</td>";
     echo "</tr>"; 
  }

  echo "</table><table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Demographic Results---------------------</td></tr>";
  echo "<tr><td><b><center>ID</td><td><b><center>CRN</td><td><b><center>Standing</td><td><b><center>Exp Grade</td><td><b><center>Elec/Req</td><td><b><center>Req/Not Req</td><td><b><center>Time</td></tr>";
  $result=mysql_query("select ID, CRN, course_standing, expect_grade, course_required, time_stamp, course_inmajor from demo_results");
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
    $time_str=strftime("%D at %r.", $row[5]);
     echo "<tr>";
     echo "<td>" . $row[0] . "</td>";
     echo "<td>" . $row[1] . "</td>";
     echo "<td>" . $row[2] . "</td>";
     echo "<td>" . $row[3] . "</td>";
     echo "<td>" . $row[4] . "</td>";
     echo "<td>" . $row[6] . "</td>";
     echo "<td><center>" . $row[5] . "<br>(" . $time_str . ")</td>";
     echo "</tr>"; 
  }

  echo "</table><table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------Student Keys---------------------</td></tr>";
  echo "<tr><td><b><center>Key</td><td><b><center>CRN</td><td><b><center>Creator</td><td><b><center>Create Time</td><td><b><center>Open Time</td><td><b><center>Close Time</td></tr>";
  $result=mysql_query("select e_key, CRN, creator, create_time, valid_begin, valid_end from student_keys");
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
    $time_str3=strftime("%D at %r.", $row[3]);
    $time_str4=strftime("%D at %r.", $row[4]);
    $time_str5=strftime("%D at %r.", $row[5]);
     echo "<tr>";
     echo "<td>" . $row[0] . "</td>";
     echo "<td>" . $row[1] . "</td>";
     echo "<td>" . $row[2] . "</td>";
     echo "<td><center>" . $row[3] . "<br>(" . $time_str3 . ")</td>";
     echo "<td><center>" . $row[4] . "<br>(" . $time_str4 . ")</td>";
     echo "<td><center>" . $row[5] . "<br>(" . $time_str5 . ")</td>";
     echo "</tr>"; 
  }

  echo "</table><table border>";
  echo "<tr><td colspan=15 bgcolor=ffffff><center><b>--------------------users---------------------</td></tr>";
  $result=mysql_query("select user_name, privilege from users");
  $fields=mysql_num_fields($result);
  while ($row=mysql_fetch_array($result))
  {
     echo "<tr>";
     for ($c=0;$c<$fields;$c++) { echo "<td>" . $row[$c] . "</td>"; }
     echo "</tr>";
  }


  echo "</table>";
}

?>
