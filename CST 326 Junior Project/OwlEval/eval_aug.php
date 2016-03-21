<?php 

  include("../global.dat");

  function main($user_type)
  {	
    $error_str="";
    if($user_type == "faculty" || $user_type == "adfac" )
    {
      if ($_POST['action']) {$error_str=save_changes($user_type);}
      if (!$error_str) {$error_str=DrawPage();}
    }
    else
    {
      $error_str=$error_str . "<br>-- You do not have a sufficient privilege to view this page.";
    }
    return $error_str;
  }
  
  function DrawPage()
  {
	?>
	<form method=post action="./account_admin.php"><input type=hidden name=fac_name value=" <?php $_POST['fac_name'] ?>" ><input type=submit value="Account Admin"></form>
	<?php
  
    $crn=$_POST['crn'];
    $name=$_POST['fac_name'];
	
	echo "<BODY VLINK=\"#OOOO66\">\n";
	echo "<BODY ALINK=\"#COCOCO\">\n";

    // this is the form for adding new questions
    echo "<center><form action=./eval_aug.php method=post><table border>\n";
    echo "<center><form action=./eval_aug.php method=post><table border>\n";
    echo "<tr><td colspan=2><center><h1>Augmentation for CRN $crn</h1></td></tr>\n";
    echo "<td colspan=2><center><b><input type=submit name=action value=\"Save All Changes\"></td></tr>\n";
    echo "<tr><Td><b><center>Question</td><td><center><b>Action</td></tr>\n";

    $cntr=0;
    $result=mysql_query("select question, question_ID from eval_questions where CRN=$crn and current=1 order by sequence");
    while ($row=mysql_fetch_array($result))
    {
      echo "<tr><Td><b><center><input type=text size=100 maxlength=75 name=mod_q_$cntr value=\"$row[0]\"></td>\n";
      echo "<td width=100><center><b><input type=submit name=rem_q_$cntr value=\"Remove\"></td></tr>\n";
      echo "<input type=hidden name=org_q_$cntr value=\"$row[0]\">\n";
      echo "<input type=hidden name=q_id_$cntr value=$row[1]>\n";
      echo "<input type=hidden name=action value=save>\n";
      $cntr=$cntr+1;
    }

    if ($cntr < 5)
    {
      echo "<tr><Td><b><center><input type=text size=100 name=new_q maxlength=75></td>\n";
      echo "<td width=100>Enter a new question</td></tr>\n";
    }
    else
    {
      echo "<tr><td colspan=2><center><b>Maximum number of questions reached</b><br>Delete questions before adding new ones.</td></tr>\n";
    }
	// The following lines of code (147 through 150) where added by Matthew Klump
	if( $cntr >= 1 && $error_str=="" )
	{
		echo "<tr><td colspan=\"2\"><center><h1><font color=\"green\">SAVE CHANGES SUCCESSFULL</font></h1></center></td></tr>\n";
		/*
		echo "<form action=\"http://www.culbertson.info/blues/mklump/changes_successfull.php\" method=\"post\">";
		echo "<input type=hidden name=fac_name value=\"" . $_POST['fac_name'] . "\"></input>";
		echo "</form>";
		*/
	}
	// End of code added by Matthew Klump
    echo "<input type=hidden name=fac_name value=$name>\n";
    echo "<input type=hidden name=crn value=$crn>\n";
    echo "</form>\n";

    return "";
  }

  function save_changes($user_type)
  {

    $crn=$_POST['crn'];
    $name=$_POST['fac_name'];

    $result=mysql_query("select * from access_control where CRN=$crn and user_name='$name'");
    $row=mysql_fetch_array($result);
    if(!$row && !$user_type="adfac")
    {
      $error_str=$error_str . "<br>-- You do not have sufficient rights to augment an evaluation for CRN $crn.";
    }

    $result=mysql_query("select count(*) from eval_questions where CRN=$crn");
    $row=mysql_fetch_array($result);
    $num_of_quesitons=$row[0];

    $time=time();
    $result=mysql_query("select valid_begin from student_keys where CRN=$crn");
    $row=mysql_fetch_array($result);
    if ($row and !$error_str)
    {
      if($row[0] <= $time)
      {

//removed for alpha testing
//        $error_str=$error_str . "<br>-- The evaluation is live, no further changes can be made.";
      }
    }
    else
    {
      if (!$error_str) {$error_str=$error_str . "<br>-- The evaluation for the CRN requested [$crn] has not been set up yet, contact an administrator.";}
    }

   
    if(!$error_str && $num_of_quesions < 5)
    {
      if ($_POST['new_q']) 
      {
        $result=mysql_query("select count(*) from eval_questions where CRN=$crn and current=1 order by sequence desc");
        $row=mysql_fetch_array($result);
        if ($row) 
        { 
          if ($row[0]=0)
          {
            $new_seq=0;
          }
          else
          {
            $result=mysql_query("select sequence from eval_questions where CRN=$crn and current=1 order by sequence desc");
            $row=mysql_fetch_array($result);
            $new_seq=$row[0]+1;
            $new_q=$_POST['new_q'];
          }
          $new_q=trim(str_replace("'","",$new_q));
          if ($new_q) {mysql_query("insert into eval_questions (question, sequence, type, current, CRN) values ('$new_q',$new_seq,'narra',1,$crn)");}
        }
      }

      $c=0;
      while ($_POST['org_q_' . $c])
      {
        $id=$_POST['q_id_' . $c];
        $mod=$_POST['mod_q_' . $c];
        if ($_POST['org_q_' . $c] != $_POST['mod_q_' . $c]) 
        {
         $mod=str_replace("'","",$mod);
          mysql_query("update eval_questions set question='$mod' where question_ID=$id");
        }
        $c=$c+1;
      }

      $c=0;
      while ($_POST['org_q_' . $c])
      {
        if ($_POST['rem_q_' . $c]) 
        {
          $id=$_POST['q_id_' . $c];
          mysql_query("delete from eval_questions where question_ID=$id");
        }
        $c=$c+1;
      }
    }
    return $error_str;
  }
?>