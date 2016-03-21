/* CST 407 Fall 2002 Input program 1.
*   This program demonstrates C code
*   using a single function (add) and using
*   built in functions accept and print.
*
*
*
*/
int add(int i, int j)
{
    int k;

   k = i + j;

   return k;
}

void main()
{
   int l;

   int in_1;

   int in_2;

   in_1 = accept();

   in_2 = accept();

   l = add(in_1, in_2);

   print(l);  
}