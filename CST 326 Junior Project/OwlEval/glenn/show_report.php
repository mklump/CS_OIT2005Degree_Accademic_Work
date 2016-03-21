<?php 

  include("../global.dat");

  function main($user_type)
  {
    $error_str="";
    if ($user_type=="administrator" || $user_type=="faculty" || $user_type=="adfac")
    {
      if ($user_type=="faculty") {$error_str=check_view();}
      if($error_str=="")
      {
        draw_mainmenu_form();
        draw_screen();
      }
    }
    else
    {  
      $error_str=$error_str . "<br>-- You do not have sufficient privilege to access this page.";
    }
    return $error_str;

  }

function check_view()
{
  $error_str="";

  $name=$_POST['fac_name'];
  $crn=$_POST['CRN'];
  $result=mysql_query("select CRN from access_control where user_name='" . $name . "' and CRN=" . $crn );
  if (!$row=mysql_fetch_array($result)) 
  {  $error_str=$error_str . "<br>-- You do not have the credentials to access these results.";}
  return $error_str;
}

function draw_screen()
{

  $crn=$_POST['CRN'];


  $fresh=0;
  $soph=0;
  $jr=0;
  $senior=0;
  $s_nores=0;

  $ex_a=0;
  $ex_b=0;
  $ex_c=0;
  $ex_d=0;
  $ex_o=0;
  $ex_nores=0;

  $elec_nr=0;
  $elec_r=0;
  $elec_nores=0;

  $inmaj_nr=0;
  $inmaj_r=0;
  $inmaj_e=0;
  $inmaj_nores=0;
  $q[100];
  $sa[100];
  $a[100];
  $n[100];
  $d[100];
  $sd[100];
  $tot[100];
  $nr[100];
  $pct[100];
  $cntr=-1;
  $last_question="";

  for($c=0;$c<100;$c++)
  {
    $q[$c]="";
    $sa[$c]=0;
    $a[$c]=0;
    $n[$c]=0;
    $d[$c]=0;
    $sd[$c]=0;
    $tot[$c]=0;
    $pct[$c]=0;
    $nr[$c]=0;
  }

  $cntr_2=0;
  while ($cntr_2<1)
  {
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_standing='Freshman'");
    if ($row=mysql_fetch_array($result)) {$fresh+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_standing='Sophomore'");
    if ($row=mysql_fetch_array($result)) {$soph+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_standing='Junior'");
    if ($row=mysql_fetch_array($result)) {$jr+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_standing='Senior'");
    if ($row=mysql_fetch_array($result)) {$senior+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_standing='NR'");
    if ($row=mysql_fetch_array($result)) {$s_nores+=$row[0];}

    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='A'");
    if ($row=mysql_fetch_array($result)) {$ex_a+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='B'");
    if ($row=mysql_fetch_array($result)) {$ex_b+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='C'");
    if ($row=mysql_fetch_array($result)) {$ex_c+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='D'");
    if ($row=mysql_fetch_array($result)) {$ex_d+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='Other'");
    if ($row=mysql_fetch_array($result)) {$ex_o+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='NR'");
    if ($row=mysql_fetch_array($result)) {$ex_nores+=$row[0];}

    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_required='Required'");
    if ($row=mysql_fetch_array($result)) {$elec_r+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_required='Not Required'");
    if ($row=mysql_fetch_array($result)) {$elec_nr+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_required='NR'");
    if ($row=mysql_fetch_array($result)) {$elec_nores+=$row[0];}

    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_inmajor='My Major'");
    if ($row=mysql_fetch_array($result)) {$inmaj_r+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_inmajor='Required for my major'");
    if ($row=mysql_fetch_array($result)) {$inmaj_nr+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_inmajor='Elective'");
    if ($row=mysql_fetch_array($result)) {$inmaj_e+=$row[0];}
    $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_inmajor='NR'");
    if ($row=mysql_fetch_array($result)) {$inmaj_nores+=$row[0];}

    $result=mysql_query("select q.question, r.response from eval_questions as q, eval_results as r where r.question_ID=q.question_ID and q.type='multi' and r.CRN=" . $crn . " order by q.sequence, r.response");

    while ($row=mysql_fetch_array($result))
    {
      if ($row[0]!=$last_question)
      {
        //calculate the percentage
        if($cntr>=0)
        {
          if($tot[$cntr] > 0 )
          {$pct[$cntr]=($d[$cntr]+($n[$cntr]*2)+($a[$cntr]*3)+($sa[$cntr]*4))/($tot[$cntr]*4);}
        }
        $cntr++;
        $last_question=$row[0];
        $q[$cntr]=$row[0];

      }

      if ($row[1]=="Strongly Agree") {$sa[$cntr]++;}
      if ($row[1]=="Agree") {$a[$cntr]++;}
      if ($row[1]=="Neutral") {$n[$cntr]++;}
      if ($row[1]=="Disagree") {$d[$cntr]++;}
      if ($row[1]=="Strongly Disagree") {$sd[$cntr]++;}
      if ($row[1]=="NR") {$nr[$cntr]++;}
      if ($row[1]!="NR") {$tot[$cntr]++;}

    }
    if($tot[$cntr] > 0 )
          {$pct[$cntr]=($d[$cntr]+($n[$cntr]*2)+($a[$cntr]*3)+($sa[$cntr]*4))/($tot[$cntr]*4);}
    $cntr_2++;
  }

  // Display loop begins
  echo "<h1>Results for CRN# " . $crn . "</h1>";
  echo "<table border><tr><Td colspan=8 bgcolor=ffffff><font size=5>Demographics</td></tr><tr><td colspan=2><table>";
  echo "<tr><td colspan=2 width=208><b>Standing</td><td colspan=2 width=208><b>Grade Expected</td><td colspan=2 width=208><b>Course Required</td><td colspan=2 width=208><b>Course Is In</td></tr>";

  echo "<tr><td>Freshmen</td><td width=65>" . $fresh . "</td><td>A</td><td width=65>" . $ex_a . "</td><td>Yes</td><td width=65>" . $elec_r . "</td><td>Maj., Not Req.</td><td width=65>" . $inmaj_r . "</td></tr>";
  echo "<tr><td>Sophomores</td><td>" . $soph . "</td><td>B</td><td>" . $ex_b . "</td><td>No</td><td>" . $elec_nr . "</td><td>Maj., Required</td><td>" . $inmaj_nr . "</td></tr>";
  echo "<tr><td>Juniors</td><td>" . $jr . "</td><td>C</td><td>" . $ex_c . "</td><td></td><td></td><td>Elective</td><td>" . $inmaj_e . "</td></tr>";
  echo "<tr><td>Seniors</td><td>" . $senior . "</td><td>D</td><td>" . $ex_d . "</td><td></td><td></td><td></td><td></td></tr>";
  echo "<tr><td></td><td></td><td>Other</td><td>" . $ex_o . "</td><td></td><td></td><td></td><td></td></tr>";
  echo "<tr><td>No Response</td><td>" . $s_nores . "</td><td>No Response</td><td>" . $ex_nores . "</td><td>No Response</td><td>" . $elec_nores . "</td><td>No Response</td><td>" . $inmaj_nores . "</td></tr>";
  echo "</table></td></tr>";

  echo "<tr><td colspan=2 bgcolor=ffffff><font size=5>Responses</td></tr>";
  echo "<tr><td width=150><b><center>Question</td><td>";

  echo "<table><tr><td></td>";
  echo "<td width=125><center><b>Strongly<br>Disagree</td>";
  echo "<td width=125><center><b>Disagree</td>";
  echo "<td width=125><center><b>Neutral</td>";
  echo "<td width=125><center><b>Agree</td>";
  echo "<td width=125><center><b>Strongly<br>Agree</td>";
  echo "</table>";

  echo "</td></tr>";

  $cntr=0;
  while ($q[$cntr]!="")
  {
    $pre=528*$pct[$cntr]-3;
    $post=528*(1-$pct[$cntr])-3;

    //draw the question
    echo "<tr><td width=175>" . $q[$cntr] . "</td><td>";

    //draw a spacer
    echo "<img src=gold.bmp height=15 width=55>";
    //draw the bars
    echo "<img src=gold.bmp height=15 width=" . $pre . ">";
    echo "<img src=blue.bmp height=15 width=6>";
    echo "<img src=gold.bmp height=15 width=" . $post . "><br>";

    //draw a spacer
    echo "<img src=gold.bmp height=15 width=57>";

    //draw the scale
    echo "<img src=scale.bmp><img src=gold.bmp width=5><B>Total:  </b>" . $tot[$cntr] . "<br>";

    //draw a spacer and the aggregate
    echo "<img src=gold.bmp height=15 width=54>" . $sd[$cntr];
    echo "<img src=gold.bmp height=15 width=123>" . $d[$cntr];
    echo "<img src=gold.bmp height=15 width=123>" . $n[$cntr];
    echo "<img src=gold.bmp height=15 width=124>" . $a[$cntr];
    echo "<img src=gold.bmp height=15 width=124>" . $sa[$cntr];
    echo "<img src=gold.bmp width=7><B>NR :  </b>" . $nr[$cntr];

    //draw the total and the scale
    echo "</td></tr>";


    $cntr++;
  } 

  //draw the comments
  echo "</table><table border><tr><td width=842 bgcolor=ffffff><font size=5>Comments</td></tr>";

  $last_question="";
  $result=mysql_query("select q.question, r.response from eval_questions as q, eval_results as r where r.question_ID=q.question_ID and q.type='narra' and r.CRN=" . $crn . " order by q.sequence");
  while ($row=mysql_fetch_array($result))
  {
    if ($last_question!=$row[0])
    {
      if ($last_question!="") { echo "</td></tr></table>";}
      echo "<tr><td><table><tr><td><font size=4>" . $row[0] . "</td></tr>";
      $last_question=$row[0];
    }
    echo "<tr><td>" . $row[1] . "</td></tr>";
  }
  echo "</table></td></tr></table>";
}

?>

