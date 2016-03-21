<?php
include("../global.dat");
  function main($user_type)
  {
//mysql_query("insert into access_control (user_name, CRN) values ('gdiviney',12345)");
    if($user_type=="student")
    {
      $error_str=save_eval();
      maintain_keys();
    }
    else
    {
       $error_str=$error_str . "<br>-- Insufficient privilege level for attempted action";
    }
    return $error_str;
}

function maintain_keys()
{
  $time=time();
  mysql_query("delete from student_keys where valid_end < " . $time );
  return "";
}

function save_eval()
{
  $error_str="";
  $crn=key_to_crn();
  $key=$_POST['key'];
  if($crn)
  {
    $time=time();
    $time_str=strftime("%D at %r.", $crn[1]);
    if ($time < $crn[1]) 
    { 
      $error_str=$error_str . "<br>-- The evaluation for your key will be accessible on " . $time_str;
    }    
    if ($time > $crn[2])
    {
      $error_str=$error_str . "<br>-- The evaluation for your key is expired.";
    }
  }
  if (!$crn)  
  {
    $error_str=$error_str . "<br>-- Your key is no longer valid."; 
  }
  if(!$error_str)
  {
    $standing=$_POST['demo_0'];
    $expect_grade=$_POST['demo_1'];
    $course_req=$_POST['demo_2'];
    $course_maj=$_POST['demo_3'];
    mysql_query("insert into demo_results (CRN, course_standing, expect_grade, course_inmajor, course_required, time_stamp) values ($crn[0], '$standing','$expect_grade','$course_maj','$course_req',$time)");

    for ($cntr=0;$cntr<$_POST['eval_count'];$cntr++)
    {
      $id=$_POST['question_id_' . $cntr];
      $res=$_POST['question_' . $cntr];
      $res=str_replace("'","",$res);
      if ($res)
      {
        mysql_query("insert into eval_results (CRN, question_ID, response, time_stamp) values ($crn[0],'$id','$res',$time)"); 
      }
    }
    if ($key!="apple") 
    {
      mysql_query("delete from student_keys where e_key='$key'");
    }
    echo "<center><table><tr><td height=350 halign=centerr><center><font size=6 color=0000dd>Thank You for submitting your feedback!</font><br>You may now close the browser window.</td></tr></table>";
  }
  return $error_str;
}
?>