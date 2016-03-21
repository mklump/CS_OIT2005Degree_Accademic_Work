#include <iostream>
#include <string>
#include <fstream>
	using namespace std;
	
class Pair {
public:
	Pair(): m_x(0), m_y(0) {};
	Pair(const int & x, const int & y=0) : m_x(x), m_y(y) {};
	Pair(const Pair & p) : m_x(p.m_x), m_y(p.m_y) 
		{cout << "CCTOR: x " << m_x << " y " << m_y << endl; };
	friend Pair operator+(const Pair & p1, const Pair & p2);
private:
	int m_x, m_y;
};
class mom {
	public:
		mom(const string & n) : m_name(n), m_no_children(0) { };
		void print(const int & age) 
			{ cout << m_name << " " << age << " years" << endl;};
		void print(const string & greet) 
			{cout << greet << m_name << endl;}
	protected:
		int m_no_children;
		string m_name;
};

// grandma inherits from mom
class grandma   : public mom    {
	public: 
		// COMLETED constructor below
		grandma (const string & name) : mom(name), no_grand_children(0)
		 {};

		void print(const string & greet) 
			{cout << greet << "grandma " << m_name << endl;}
	protected:
		int no_grand_children;
};

class IntegerPointer {
	public:
		IntegerPointer() : m_ptr(NULL) {};
		IntegerPointer(const IntegerPointer & rhs);
		IntegerPointer operator= (const IntegerPointer &rhs);
	private:
		int * m_ptr;
};

struct Baseball {
	int hits, at_bats;
};

const int MAX_PLAYERS = 15;
const int MAX_GAMES = 60;

// Each customer in line is represented with the following structure:
struct Customer {
	int customer_no;	// Customer Number
	string name;	// Customer first name;
};

// Line is a node in a linked list of customers.  (Represents a line of customers.)
struct Line {
	Customer c;
	Line * next;
};

// Each Checkout counter is represented by:
struct Counter {
	int no_of_customers;  // number of customers in the line.
	Line * first;
};

void my_function(int n);
int best_counter (Counter store[], const int & number_counters);

void main(void)
{
	char pause;
	

	{
		cout << "\nCoding Problem 10" << endl;
		Pair p1(5,2);
		Pair p2(p1);
		Pair r;
		r = p1 + p2;

		cout << endl;
		
	}
	{
		cout << "\nCoding Problem 11" << endl;
		int j = 3;
		cout  << " j++ = " << j++ << " j " << j << endl;
		cout << "Real answer is UNKNOWN" << endl;

		cout << endl;
		
	}
	
	
	{
		cout << "\nCoding Problem 14" << endl;
		my_function(546);
		cout << endl;
		
	}
	cout << "Enter any key and return to continue" ;
	cin >> pause;

	{
		cout << "\nCoding Problem 17" << endl;
		
		grandma love("Bessie");
		love.print("hello");
		cout << endl;
		
	}
		{
		cout << "\nCoding Problem 18" << endl;
		cout << "NO OUPUT" << endl;
		cout << endl;
		
	}

	{
		cout << "\nCoding Problem 19" << endl;
		int j=32,k=5, r;
		
		r = j ^ k;
		cout << r << "#";
		r = j << 2;
		cout << r << "#" << endl;

		cout << endl;
		
	}
	{
		cout << "\nCoding Problem 18" << endl;
		cout << endl;
		
	}

	
	{
		cout << "\nCoding Problem 25" << endl;
		
		
		Baseball Sluggers[MAX_PLAYERS][MAX_GAMES];
		

		double player_hits, player_at_bats, player_average;

		for (int player = 0; player < MAX_PLAYERS;++player) {
			player_hits = player_at_bats = player_average = 0;
			for ( int game = 0; game < MAX_GAMES; ++game ) {
				player_hits += Sluggers[player][game].hits;
				player_at_bats += Sluggers[player][game].at_bats;
			}
			if (player_at_bats != 0)
				player_average = player_hits / player_at_bats;
			//cout << "Player " << player << " had  " << player_hits;
			//cout << " in "  << player_at_bats << " at bats " ;
			//cout << " for an average of " << player_average << endl;
		}
		cout << "OUTPUT DOESNT MATER" << endl;	
		cout << endl;	
	}
	{
		cout << "\nCoding Problem 26" << endl;
		char    name[40] = "My name is Ada";
		// using pointer arithmetic point the variable end at the last a in Ada
		char * end_of_name = name + strlen(name) - 1;                        

		cout << endl;
		
	}
	{
		cout << "\nCoding Problem 27" << endl;
		char	chara[20] = "Ziggy!", 	charR[40];

		string 	stringa = "Ziggy!",  stringR;


		cout << "STRING VERSION" << endl;
		stringR = stringa;
		for (int j=0;j< stringa.size();++j) {
		   if (ispunct(stringR.at(j)))
		      stringR.at(j) = 'a';
		}
		cout << stringR << endl;
		cout << "C-STRING VERSION" << endl;
		strcpy(charR,chara);
		for (int j=0;j< strlen(chara);++j) {
		   if (ispunct(charR[j]))
		      charR[j] = 'a';
		}
		cout << charR << endl;

		cout << endl;
		
	}
	{
		cout << "\nCoding Problem 28" << endl;
		ifstream inf("n.dat");

		char next;
		if (!inf.fail()) {		 
			while (!inf.eof()) {
				next = inf.get();
				next = toupper(next);
				cout.put(next);
			}
			inf.close();
		}

		cout << endl;
		
	}

	
	

	{
		cout << "\nCoding Problem 28" << endl;

		//  In our main program we have 10 counters as an array of Counter as below:
		Counter Freddies[10];
		cout << "The best is " << best_counter(Freddies,10) <<endl;
		cout << "OUTPUT DOESNT MATER" << endl;	
		cout << endl;	
	}


	
	
	
}
// Complete best_counter.  Recommends the best counter to a 
//   customer.  (The one with the least number of customers.)

int best_counter (Counter store[], const int & number_counters)  {
	int best = 0,  shortest_count = store[0].no_of_customers;

	for (int j=1;j<number_counters;++j) {

		// complete the following if statement to compare the j'th element 
		//   no_of_customers to the shortest_count variable;

		if  (store[j].no_of_customers < shortest_count)  {

			// complete the following assignment to move the 
			//   no_of_customers into the shortest count.

			shortest_count = store[j].no_of_customers;

			best = j;
		};
	};

	return(best);
}
void NewLine(Counter target, Counter source)  {


	// Move all but the first customer to the target line.
	if (source.first == NULL) {
		target.first = NULL;
		target.no_of_customers = 0;
	}
	else {
		target.first = source.first->next;
		Line * temp = target.first;
		int work_no = 0;
		while (temp != NULL) {
			work_no++;
			temp = temp->next;
		}
		target.no_of_customers = work_no;

		// This leaves the source counter with one customer.
		source.no_of_customers = 1;
		source.first->next = NULL;   
	}


}

Pair operator+(const Pair & p1, const  Pair & p2) {
	Pair temp;
	temp.m_x = p1.m_x + p2.m_x;
	temp.m_y = p1.m_y + p2.m_y;
	return (temp);
}
void my_function(int n) {
    if (n < 10)  
        cout << n << endl;
    else     {
        my_function(n/10);
        cout << (n%10) << endl;
    }
}



IntegerPointer::IntegerPointer(const IntegerPointer & rhs)
{
		m_ptr = rhs.m_ptr;
}

IntegerPointer IntegerPointer::operator=(const IntegerPointer &rhs)

{
    if (this != &rhs) { 
		// <snip> code to do the assignment;
    }
     return *this;
}
