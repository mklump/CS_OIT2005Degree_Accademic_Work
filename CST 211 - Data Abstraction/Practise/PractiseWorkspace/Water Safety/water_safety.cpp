

#include <iostream>
using namespace std;

bool check_Splazz_content_in_water(const float& Splazz);

bool check_Frozz_content_in_water(const float& Frozz);

bool check_Dizz_content_in_water(const float& Dizz);

int main()
{
	float Splazz = 0, Frozz = 0, Dizz = 0;
	
	try {
	cout << "Please input the level of Splazz in the water:\n";
	cin >> Splazz;
	if(Splazz == 0) throw;
	cout << endl << 100 / Splazz << endl;
	cout << "Please input the level of Frozz in the water:\n";
	cin >> Frozz;
	if(Frozz == 0) throw;
	cout << endl << 100 / Frozz << endl;
	cout << "Please input the level of Dizz in the water:\n";
	cin >> Dizz;
	if(Dizz == 0) throw;
	cout << endl << 100 / Dizz << endl;
	}
	catch(...)
	{
		cout << "You screwed up. You caused a divide by zero error.\n";
	}
	if (!check_Splazz_content_in_water(Splazz) &&
		!check_Frozz_content_in_water(Frozz) &&
		!check_Dizz_content_in_water(Dizz))
		cout << "The water is safe.\n\n";

	return 0;
}

bool check_Splazz_content_in_water(const float& Splazz)
{
	if (Splazz > 0.02)
	{
		cout << "The water is not safe, the level of Splazz is "
			<< "\ngreater than .02 ppl.\n";
		return true;
	}
	else 
		return false;
}

bool check_Frozz_content_in_water(const float& Frozz)
{
	if (Frozz < 0.01)
	{
		cout << "\nThe water is not safe, the level of Frozz is "
			<< "\nless than 0.01 ppl.\n";
		return true;
	}
	else
		return false;
	if (Frozz > 0.06)
	{
		cout << "\nThe water is not safe, the level of Frozz is "
			<< "\ngreater than 0.06 ppl.\n";
		return true;
	}
	else
		return false;
}

bool check_Dizz_content_in_water(const float& Dizz)
{
	if (Dizz < 0.05)
	{
		cout << "\nThe water is not safe, the level of Dizz is "
			<< "\nless than .05 ppl.\n";
	return true;
	}
	else
		return false;
	if (Dizz > (2 * Dizz))
	{
		cout << "\nThe water is not safe, the level of Dizz is "
			<< "\ngreater than 2 times the current Frozz.\n";
	return true;
	}
	else
		return false;
}