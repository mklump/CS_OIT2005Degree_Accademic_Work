/* CST 320 Fall 2002 Sample input program #3.
*   The goal of this program is to test the
*   compiler's ability to produce code for
*   if and else statements as well as producing
*   code for accessing parameters passed to a
*   function.
*
*   Depending on the command passed in as the
*   first parameter, this program executes
*   a different operation on the operands and
*   prints out the result.
*
*   Features tested.
*	Parameter accessing.
*	if-then-else statements.
*	Built-in functions.
*	expressions.
*/
void main(int cmd, int op_1, int op_2, int times)
{
    int result;



         if ( cmd == 1 )
        {
	result = op_1 + op_2;
	print(result);
        }
       else
       {
            if ( cmd == 2 )
           {
	result = op_1 * op_2;
	print(result);
           }
           else
           {
	result = op_1 - op_2;
	print(result);
           }

   }
}