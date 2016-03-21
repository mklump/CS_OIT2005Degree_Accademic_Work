<?php 

  include("../global.dat");

  function main($user_type)
  {
    $error_str="";
    if ($user_type=="administrator" || $user_type=="faculty" || $user_type=="adfac")
    {
      $error_str=check_view();
      if($error_str=="")
      {
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
  $ex_a=0;
  $ex_b=0;
  $ex_c=0;
  $ex_d=0;
  $ex_o=0;

  $elec_nr=0;
  $elec_r=0;

  $inmaj_nr=0;
  $inmaj_r=0;
  $inmaj_e=0;

  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_standing='Freshman'");
  if ($row=mysql_fetch_array($result)) {$fresh=$row[0];}
  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_standing='Sophomore'");
  if ($row=mysql_fetch_array($result)) {$soph=$row[0];}
  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_standing='Junior'");
  if ($row=mysql_fetch_array($result)) {$jr=$row[0];}
  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_standing='Senior'");
  if ($row=mysql_fetch_array($result)) {$senior=$row[0];}

  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='A'");
  if ($row=mysql_fetch_array($result)) {$ex_a=$row[0];}
  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='B'");
  if ($row=mysql_fetch_array($result)) {$ex_b=$row[0];}
  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='C'");
  if ($row=mysql_fetch_array($result)) {$ex_c=$row[0];}
  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='D'");
  if ($row=mysql_fetch_array($result)) {$ex_d=$row[0];}
  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and expect_grade='Other'");
  if ($row=mysql_fetch_array($result)) {$ex_o=$row[0];}

  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_required='Required'");
  if ($row=mysql_fetch_array($result)) {$elec_r=$row[0];}
  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_required='Not Required'");
  if ($row=mysql_fetch_array($result)) {$elec_nr=$row[0];}

  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_inmajor='My Major'");
  if ($row=mysql_fetch_array($result)) {$inmaj_r=$row[0];}
  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_inmajor='Required for my major'");
  if ($row=mysql_fetch_array($result)) {$inmaj_nr=$row[0];}
  $result=mysql_query("select count(*) from demo_results as a where CRN=" . $crn . " and course_inmajor='Elective'");
  if ($row=mysql_fetch_array($result)) {$inmaj_e=$row[0];}


echo "<table><Tr><td colspan=8 valign=bottom><h2>Demographics</h2></td></tr><tr>";
echo "<td colspan=2><b>Standing</td><td colspan=2><b>Grade Expected</td><td colspan=2><b>Course Required</td><td colspan=2><b>Course Is In</td></tr><tr>";

echo "<td valign=top width=100>Freshmen<br>Sophomores<br>Juniors<br>Seniors</td>";
echo "<td valign=top width=50>" . $fresh . "<br>" . $soph . "<br>" . $jr . "<br>" . $senior . "</td>"; 

echo "<td valign=top width=100>A<br>B<br>C<br>D<br>Other</td>";
echo "<td valign=top width=50>" . $ex_a . "<br>" . $ex_b . "<br>" . $ex_c . "<br>" . $ex_d . "<br>" . $ex_o . "</td>"; 

echo "<td valign=top width=100>Yes<br>No</td>";
echo "<td valign=top width=50>" . $elec_r . "<br>" . $elec_nr . "</td>"; 

echo "<td valign=top width=100>Major, Not Required<br>Major, required<br>Elective</td>";
echo "<td valign=top width=50>" . $inmaj_r . "<br>" . $inmaj_nr . "<br>" . $inmaj_e . "<br>"; 
echo "</tr></table>";

  echo "<table border><tr><td width=150><b><center>Question</td><td><table><tr><td></td>";
  echo "<td width=125><center><b>Strongly<br>Disagree<br>Poor</td>";
  echo "<td width=125><center><b>Disagree<br>Acceptable</td>";
  echo "<td width=125><center><b>Neutral<br>Satisfactory</td>";
  echo "<td width=125><center><b>Agree<br>Good</td>";
  echo "<td width=125><center><b>Strongly<br>Agree<br>Excellent</td>";
  echo "</table></td></tr><tr><td>";


  $q[100];
  $sa[100];
  $a[100];
  $n[100];
  $d[100];
  $sd[100];
  $tot[100];
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
  }

  $result=mysql_query("select q.question, r.response from eval_questions as q, eval_results as r where r.question_ID=q.question_ID and q.type='multi' and r.CRN=" . $crn . " order by q.sequence, r.response");

  while ($row=mysql_fetch_array($result))
  {
    if ($row[0]!=$last_question)
    {
      //calculate the percentage
      if($cntr>=0)
      {
        if($tot[$cntr] > 0 ){$pct[$cntr]=($d[$cntr]+($n[$cntr]*2)+($a[$cntr]*3)+($sa[$cntr]*4))/($tot[$cntr]*4);}
      }
      $cntr++;
      $last_question=$row[0];
      $q[$cntr]=$row[0];

    }


    if ($row[1]=="Strongly Agree") {$sa[$cntr]++;}
    if ($row[1]=="Agree") {$a[$cntr]+=1;}
    if ($row[1]=="Neutral") {$n[$cntr]++;}
    if ($row[1]=="Disagree") {$d[$cntr]++;}
    if ($row[1]=="Strongly Disagree") {$sd[$cntr]++;}
    $tot[$cntr]+=1;

  }
  if($tot[$cntr] > 0 ){$pct[$cntr]=($d[$cntr]+($n[$cntr]*2)+($a[$cntr]*3)+($sa[$cntr]*4))/($tot[$cntr]*4);}

  // loop begins

  $cntr=0;
  while ($q[$cntr]!="")
  {
    $pre=528*$pct[$cntr]-3;
    $post=528*(1-$pct[$cntr])-3;

    //draw the question
    echo "<tr><td width=175>" . $q[$cntr] . "</td><td>";

    //draw a spacer
    echo "<img src=gold.bmp height=15 width=57>";
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

    //draw the total and the scale
    echo "</td></tr>";


    $cntr++;
  } // loop ends 
  echo "</table>";

  echo "<h1>Comments</h1>";

  $last_question="";
  $result=mysql_query("select q.question, r.response from eval_questions as q, eval_results as r where r.question_ID=q.question_ID and q.type='narra' and r.CRN=" . $crn . " order by q.sequence");
  while ($row=mysql_fetch_array($result))
  {
    if ($last_question!=$row[0])
    {
      echo "<h2>" . $row[0] . "</h2>";
      $last_question=$row[0];
      echo "-------------------------------------------------------------------<br>";
    }
    echo $row[1] . "<br>";
    echo "-------------------------------------------------------------------<br>";
  }
}

?>

