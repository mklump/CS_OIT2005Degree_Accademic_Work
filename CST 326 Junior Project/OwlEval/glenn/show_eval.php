<?php 
  
  include("../global.dat");

  function main($user_type)
  {
    if ($user_type=="student")
    {
      $error_str=draw_screen();
    }
    else
    {
      $error_str=$error_str . "<br>-- Please enter a valid key.";
    }
    return $error_str;
  }

function draw_screen()
{
  $crn=key_to_CRN();
  $key=$_POST['key'];
  $error_str="";

  if($crn)
  {
    $time=time();
    $time_str=strftime("%D at %r.", $crn[1]);

$opened=strftime("%D at %r.", $crn[1]);
$closes=strftime("%D at %r.", $crn[2]);
$created=strftime("%D at %r.", $crn[3]);
echo "<br><center>Evaluation created $created, opens $opened, closes $closes</center><br>";

    if ($time < $crn[1]) { $error_str=$error_str . "<br>-- The evaluation for your key will be accessible as of " . $time_str;}
    if ($time > $crn[2]) { $error_str=$error_str . "<br>-- The evaluation for your key is expired.";}
  }



  if (!$crn || $error_str) 
  {
    if (!$error_str) {$error_str="<br>-- No evaluation could be found for the key you entered. Please check the key and try again.";}
  }
  else
  { 
    $result=mysql_query("select question, type, question_ID from eval_questions where (CRN=0 or CRN=$crn[0]) and current=1 order by CRN, type, sequence");
    if (!$result) 
    {
      $error_str="<br>-- No evaluation could be found for the key you entered. Please notify an instructor.";
    }
    else
    { 
      echo "<center><form method=post action=save_eval.php><table border>\n";

        echo "<tr><td colspan=10 bgcolor=ffffff><b><font size=5>Demographics</b></td></tr>\n";

        echo "<tr><td colspan=10 bgcolor=9999ff><b>Your Course Standing is</b></td></tr>\n";
        echo "<tr><td><table><tr>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_0 value=\"Freshman\"><br>Freshman</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_0 value=\"Sophomore\"><br>Sophomore</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_0 value=\"Junior\"><br>Junior</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_0 value=\"Senior\"><br>Senior</td>\n";
        echo "<td width=125 valign=top><center><br></td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_0 value=\"NR\" checked><br>NR</td>\n";
        echo "</tr></table></td></tr>";

        echo "<tr><td colspan=10 bgcolor=9999ff><b>The grade you expect is</b></td></tr>\n";
        echo "<tr><td><table><tr>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_1 value=\"A\"><br>A</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_1 value=\"B\"><br>B</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_1 value=\"C\"><br>C</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_1 value=\"D\"><br>D</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_1 value=\"Other\"><br>Other</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_1 value=\"NR\" checked><br>NR</td>\n";
        echo "</tr></table></td></tr>";

        echo "<tr><td colspan=10 bgcolor=9999ff><b>This course is</b></td></tr>\n";
        echo "<tr><td><table><tr>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_2 value=\"Required\"><br>Required</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_2 value=\"Not Required\"><br>Not Required</td>\n";
        echo "<td width=125 valign=top><center><br></td>\n";
        echo "<td width=125 valign=top><center><br></td>\n";
        echo "<td width=125 valign=top><center><br></td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_2 value=\"NR\" checked><br>NR</td>\n";
        echo "</tr></table></td></tr>";

        echo "<tr><td colspan=10 bgcolor=9999ff><b>This course is in</b></td></tr>\n";
        echo "<tr><td><table><tr>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_3 value=\"My major\"><br>My Major</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_3 value=\"Required for my major\"><br>Required for my major</td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_3 value=\"Elective\"><br>Elective</td>\n";
        echo "<td width=125 valign=top><center><br></td>\n";
        echo "<td width=125 valign=top><center><br></td>\n";
        echo "<td width=125 valign=top><center><input type=radio name=demo_3 value=\"NR\" checked><br>NR</td>\n";
        echo "</tr></table></td></tr>";

        echo "<tr><td colspan=10 bgcolor=ffffff><b><font size=5>Course Evaluation</b></td></tr>\n";

      $cntr=0;
      while ($row=mysql_fetch_array($result))
      {
        if($row[1]=="multi")
        {
          echo "<tr><td colspan=10 bgcolor=9999ff><b>$row[0]</b></td></tr>\n";
          echo "<tr><td><input type=hidden name=question_id_$cntr value=$row[2]></input><table><tr>\n";
          echo "<td width=125 valign=top><center><input type=radio name=question_$cntr value=\"Strongly Disagree\"><br>Strongly Disagree</td>\n";
          echo "<td width=125 valign=top><center><input type=radio name=question_$cntr value=\"Disagree\"><br>Disagree</td>\n";
          echo "<td width=125 valign=top><center><input type=radio name=question_$cntr value=\"Neutral\"><br>Neutral</td>\n";
          echo "<td width=125 valign=top><center><input type=radio name=question_$cntr value=\"Agree\"><br>Agree</td>\n";
          echo "<td width=125 valign=top><center><input type=radio name=question_$cntr value=\"Strongly Agree\"><br>Strongly Agree</td>\n";
          echo "<td width=125 valign=top><center><input type=radio name=question_$cntr value=\"NR\" checked><br>NR</td>\n";
          echo "</tr></table></td></tr>";
        }
        if($row[1]=="narra")
        {
          echo "<tr><td colspan=10 bgcolor=9999ff><b>$row[0]</b></td></tr>\n";
          echo "<tr><input type=hidden name=question_id_$cntr value=$row[2]></input>\n";
          echo "<td colspan=10><center><textarea name=question_$cntr rows=5 cols=95></textarea></td>\n";
          echo "</tr>";
        }
        $cntr=$cntr+1;
      }
      echo "</table>\n";
      echo "<input type=hidden name=eval_count value=$cntr></input>\n";
      echo "<input type=hidden name=key value=$key></input>\n";
      echo "<input type=submit name=save value=\"Save Evaluation\"></input>\n";
      echo "</form>\n";
    }
  }
  return $error_str;
}
?>