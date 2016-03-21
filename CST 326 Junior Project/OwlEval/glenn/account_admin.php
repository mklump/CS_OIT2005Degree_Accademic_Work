<?php 

  include("../global.dat");

  function main($user_type)
  {
    $error_str="";

    if ($user_type=="admin" || $user_type="adfac")
    {
      draw_mainmenu_form();
      $error_str=Update_Page();
      $error_str=DrawPage($user_type, $error_str);	
    }
    return $error_str;
  }
  
  function DrawPage($user_type, $error_str)
  {
	echo "<BODY VLINK=\"#OOOO66\">\n";
	echo "<BODY ALINK=\"#COCOCO\">\n";

  	if( $user_type != "adfac" && $user_type != "admin" )
	{ 
          return $error_str = $error_str . "<br />-- Your are not authorized to administer user accounts.";
        }

?>
	<form method="post" action="./account_admin.php">
	<input type="hidden" name="fac_name" value="<?php echo $_POST['fac_name']; ?>" >
	<font size="+1">
	<img src="/small.JPG" width="30" height="6">
	<b>USER NAME: </b></font><input type="text" name="user_name_text" size="16">
	<font size="+1">
	<img src="/small.JPG" width="30" height="6">
	<b>ACCESS LEVEL: </b></font>
	<select name="access_level" size=1>
                <option></option>
		<option>faculty</option>
		<option>adfac</option>
		<option>admin</option>
	</select>
	<img src="/small.JPG" width="25" height="6">
	<input type="submit" name="add_user" value="ADD USER">
	</form>
	
	<form method="post" action="./account_admin.php">
	<table border>
		<tr>
		  <td><center><b>User Name</b></center></td>
		  <td><center><b>Privilege Level</b></center></td>
		  <td><center><b>Action</b></center></td>
		</tr>
<?php 
	$counter=0;
	$Result=mysql_query("SELECT user_name, privilege FROM users ORDER BY user_name");
	while($Row=mysql_fetch_array($Result))
	{
		echo "<input type=hidden name=user_name_" . $counter . " value=" . $Row[0] . ">";
		echo "<tr><td>" . $Row[0] . "</td><td>" . $Row[1] . "</td>";
		echo "<td> <input type=submit value=REMOVE name=remove_" . $counter . "></td></tr>";
		$counter++;
	}
?>

	</table>
	<input type="hidden" name="fac_name" value="<?php echo $_POST['fac_name']; ?>" >
	</form>
	

<?php
	return "";
  }
function Update_Page()
{
  $counter = 0;
  while($_POST['user_name_' . $counter])
  {
    if( $_POST['remove_' . $counter] )
    {
      $Result = mysql_query("DELETE FROM users WHERE user_name='" . $_POST['user_name_' . $counter] . "'");
    }
    $counter++;
  }

  if( $_POST['add_user'] && $_POST['access_level'])
  {
    if($_POST['user_name_text'])
    {$Result = mysql_query("INSERT INTO users (user_name, privilege, password) VALUES ('" . $_POST['user_name_text'] . "', '" . $_POST['access_level'] . "','" . $_POST['user_name_text'] . "')");}
  }
}
?>

