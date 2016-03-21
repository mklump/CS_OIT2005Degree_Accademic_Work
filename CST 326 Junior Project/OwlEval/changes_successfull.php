<?php 

  include("../global.dat");
  
  function main($user_type)
  {

    $error_str="";
	
	//Removed after debugging completed
	$user_type="adfac";
	
    if($user_type == "faculty" || $user_type == "adfac" )
    {
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
	<BODY VLINK="#OOOO66">
	<BODY ALINK="#COCOCO">
	<center>
	<BR><BR><BR><BR>
	<tr><td><h1>SAVE CHANGES SUCCESSFULL</h1></td></tr>
	<table>
	<tr><td><center>
	
	<FORM action="http://www.culbertson.info/blues/glenn/eval_aug.php" method="post">
	<input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
	<P><INPUT name="action" value="Return to Add/Remove Questions" type="submit"></P>
	</FORM>
	
	<FORM action="http://www.culbertson.info/blues/gwr/admin_menu.php" method="post">
	<input type=hidden name=fac_name value="<?php echo $_POST['fac_name']; ?>"></input>
	<P><INPUT name="action" value="              Return to Main Menu            " type="submit"></P>
	</FORM>
	
	</table>
	<?php
  	return $error_str="";
  }
    
  ?>