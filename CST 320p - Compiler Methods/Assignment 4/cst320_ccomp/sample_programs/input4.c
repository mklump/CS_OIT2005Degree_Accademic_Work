/* CST320 fall 2002 sample input program #4.
*   This program tests the compiler's ability
*   to produce code for functions, 
*   accessing a function's parameters,
*   producing code for if-else statements,
*   and others.
*
*/
int min( int a, int b )
{

   int m;

   if ( a > b )
 	m = b;
  else
	m = a;

   return m;
}

int max( int a, int b)
{
    int m;

   if ( a < b )
        m = b;
   else
        m = a;

   return m;
}

int main(int a, int b, int c, int d)
{
    int array[4];
    int cur_min;
    int cur_max;

    array[0] = a;
    array[1] = b;

    array[2] = c;
    array[3] = d;

    cur_min = min(array[0], array[1]);
    cur_min = min(cur_min, array[2]);
    cur_min = min(cur_min, array[3]);

    cur_max = max(array[0], array[1]);
    cur_max = max(cur_max, array[2]);
    cur_max = max(cur_max, array[3]);

    print(cur_min);

    print(cur_max);
}