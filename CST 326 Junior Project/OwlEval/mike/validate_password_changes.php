<?PHP

include("../global.dat");

function main($user_type) {
  $error_str="";

  if ($user_type="faculty"||$user_type=="admin"||$user_type=="adfac") 
    {
      $error_str=draw_screen();
    }	
  else 
    {
      $error_str=$error_str."<br>-- Only Administrators and Faculty are allowed to change their passwords.";
    } 
  return $error_str;
}    


function draw_screen() {

  $user_name=$_POST['fac_name'];
  $current_password=$_POST['current_password'];
  $new_password=$_POST['new_password'];
  $retype_new_password=$_POST['retype_new_password'];
  $error="";

  if ($current_password == "") {
    $error ="<br>-- You must enter your current password in order to change your password.";
    return $error;
}
  
  elseif ($new_password == "") {
    $error ="<br>-- You must enter a new password in order to change your password.";
    return $error;
  }
  
  elseif ($retype_new_password == "") {
    $error ="<br>-- You must retype your new password in order change your password.";
    return $error;
  }
  
  elseif ($new_password != $retype_new_password) {
    $error ="<br>-- Your new passwords don't match. Please go back and retype them.";
    return $error;
  }
  
  $DB_password_results=mysql_query("select password from users where user_name='$user_name'");
  if($DB_password_results) {
    $DB_password_array=mysql_fetch_row($DB_password_results);
    $DB_password=$DB_password_array[0];
  }
  else {
    $error=mysql_error();
    $error.="<br>-- There was an error gathering data from the Database. Your password has not been changed.";
    return $error;
  }
  if ($DB_password != $current_password) {
    $error ="<br>-- Your current password was entered incorrectly. Please go back and correct the error.";
    return $error;
  }
  if (($DB_password == $current_password) && ($new_password == $retype_new_password)) {
    if (mysql_query("update users set password='$new_password' where user_name='$user_name'")) {
      print("<center><h1>Your Password has been updated.</h1></center>");
      draw_mainmenu_form();
    }
    else {
      $error=mysql_error();
      $error .="<br>-- There was an error updating the database. Your password has not been changed.";
      return $error;
    }
  }
}

?>
