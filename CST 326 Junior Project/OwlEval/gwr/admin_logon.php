<?php     

  include("../global.dat");    
  
  function main($user_type)   
  {     
    $error_str=draw_screen();
    return $error_str;   
  }   

function draw_screen() 
{ 
?>

<form action="admin_menu.php" method=post>
<center><h1>Faculty/Administration logon</h1>
<table>
 <tr><td width="30%">&nbsp;<td width="10%"><b>USER NAME</b><td>
<INPUT TYPE="text" SIZE="20" NAME="fac_name"></td></tr>
 <tr><td>&nbsp;<td width="10%"><b>PASSWORD</b><td>
<INPUT TYPE="password" SIZE="20" NAME="fac_pass"></p></td></tr>
<tr align="right"><td width="700"><INPUT TYPE="submit" value=Login></td></tr>
</table></center>
</form>

<center>
<h2>This page is for Faculty/Administration logon ONLY. </h2>

<h2>If you are a student<br> enter <a href="http://matthew.klump-pdx.com/blues/glenn/student_login.php">HERE</a></h2>
</center>

<?php  

  return ""; 
} 
?>
