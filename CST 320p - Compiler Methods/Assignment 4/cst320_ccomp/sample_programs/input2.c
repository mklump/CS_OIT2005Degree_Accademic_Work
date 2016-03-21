/* 
*  CST 407 Fall 2002. Sample input program #2.
*  This program accepts upto 4 integers from the
*  user and adds them up and prints out the sum.
*
*  This program demonstrates calling built-in
*  functions and using while loops(one level).
*
*/

void main()
{
    int my_array[4];

    int idx;
    int sum;

    idx = 0;
    sum = 0;

    while ( idx < 4 ) 
    {
        my_array[idx] = accept();

        sum = sum + my_array[idx];        

        idx = idx + 1;
    }

    print(sum);
}    