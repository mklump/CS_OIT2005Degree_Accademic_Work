<?php 

  include("../global.dat");

  function main($user_type)
  {
    $error_str="";
    draw_screen();
    return $error_str;
  }


function draw_screen()
{
  echo "<table><tr><td></td><td><table><tr><td></td>";
  echo "<td width=127><center><b>Strongly<br>Disagree</td>";
  echo "<td width=127><center><b>Disagree</td>";
  echo "<td width=127><center><b>Neutral</td>";
  echo "<td width=127><center><b>Agree</td>";
  echo "<td width=127><center><b>Strongly<br>Agree</td>";
  echo "</table></td></tr>";


  $q=array(100);
  $sa=array(100);
  $a=array(100);
  $n=array(100);
  $d=array(100);
  $sd=array(100);
  $tot=array(100);
  $prct=array(100);
  $cntr=-1;
  $last_question=" ";

  $result=mysql_query("select q.questionText, r.response from eval_questions as q, eval_results as r where r.question_ID=q.question_ID and q.type='multi' and CRN=12345 order by q.questionText, r.response");
  while ($row=mysql_fetch_array($result))
  {
    if ($row[0]!=$last_question)
    {
      //calculate the percentage
      if ($tot[$cntr] > 0 )
      {
        $prct[$cntr]=($d[$cntr]+($n[$cntr]*2)+($a[$cntr]*3)+($sa[$cntr]*4))/(tot($cntr)*4);
      }
      $cntr++;
      $q[$cntr]=$row[0];
    }
    if ($row[1]=="Strongly Agree") {$sa[$cntr]++;}
    if ($row[1]=="Agree") {$a[$cntr]++;}
    if ($row[1]=="Neutral") {$n[$cntr]++;}
    if ($row[1]=="Disagree") {$d[$cntr]++;}
    if ($row[1]=="Strongly Disagree") {$sd[$cntr]++;}
    $tot[$cntr]++;
  }

// loop begins

  $cntr=0;
  while ($q[$cntr]!="")
  {
    //draw the question
    echo "<tr><td width=175>" . $q[$cntr];
    echo "</td><td><table><tr><td width=57></td><td colspan=5><table><tr>";

    //draw the bars
    echo "<td bgcolor=ffCC00><img src=gold.bmp height=15 width=347.5></td>";
    echo "<td bgcolor=0000ff><img src=blue.bmp height=15 width=6></td>";
    echo "<td bgcolor=ffCC00><img src=gold.bmp height=15 width=160.5></td>";

    //draw the total
    echo "<td></td></tr></table></td><td>Total</td></tr>";
    echo "<tr><td></td><td colspan=5><img src=scale.bmp></td>";
    echo "<td>" . $tot[$cntr] . "</td></tr>";
    echo "<tr><td colspan=7><center><table><tr>";

    //draw the aggregate
    echo "<td width=127><center>" . $sd[$cntr] . "</td>";
    echo "<td width=127><center>" . $d[$cntr] . "</td>";
    echo "<td width=127><center>" . $n[$cntr] . "</td>";
    echo "<td width=127><center>" . $a[$cntr] . "</td>";
    echo "<td width=127><center>" . $sa[$cntr] . "</td>";

    $cntr++;
  } // loop ends 
  echo "</tr></table></td></tr></table></td></tr></table>";
}

?>

