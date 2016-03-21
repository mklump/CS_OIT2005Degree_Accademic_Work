/* CST320 Fall 2002 sample input program #5.
*   A very simple ( really simple ) program
*   that prints the sum of 5 + a value read
*   from the user.
*
*    Just call a function with no parameters and
*    use the return value.
*
*/
int return_plus_5()
{
   int k;

   k = accept();

   k = k + 5;

   return k;
}

int main()
{
    
   int l;

   l = return_plus_5();

   print(l);
}