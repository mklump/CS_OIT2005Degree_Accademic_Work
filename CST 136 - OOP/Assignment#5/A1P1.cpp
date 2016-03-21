// Name: Dom Virgilio & modified by Matthew Klump
// Class: CST 136
// Assignment #1, Part I

// A1P1.cpp
//

#include <iostream.h>
#include <string.h>
#include <stdio.h>

#define MAX_PHRASE_SIZE 256
#define MAX_NUMBER_OF_WORDS 128 // one-letter-word, space, one-letter-word, space, etc.

bool phrase_loop();
void print_by_letter(char *word[], int n);
void print_by_length(char *word[], int n);
bool letter_loop(char *word[], int n);

int main(int argc, char* argv[])
{
	while (phrase_loop());
	return 0;
}

bool phrase_loop()
{
	int n = 0;
	char phrase[MAX_PHRASE_SIZE];
	char *word[MAX_NUMBER_OF_WORDS];
	char seps[]   = " ,\t\n";

	cout << "Input Phrase or 0 to Quit: ";
	length_error;
	cin.getline(phrase, MAX_PHRASE_SIZE);
	word[n] = strtok(phrase, seps);

	if (word[n] != NULL) {
		if (strcmp(word[n], "0") == 0) return false;

		while(word[n] != NULL){
			n = n + 1;
			word[n] = strtok(NULL, seps);
		}

		cout << "Number of words: " << n << endl;

		print_by_letter(word, n);
		print_by_length(word, n);
	}

	while (letter_loop(word, n));

	return true;
}

bool letter_loop(char *word[], int n)
{
	char *matchedWord[MAX_NUMBER_OF_WORDS];
	cout << "Enter [a-z] or 0 to Quit: ";

	char input[MAX_PHRASE_SIZE];
	cin.getline(input, MAX_PHRASE_SIZE);

	if (strcmp(input, "0") == 0) return false;

	int count = 0;
	char letter = input[0];
    for(int i=0; i < n; i = i+1) {
		if (strchr(word[i], letter) != NULL) {
			matchedWord[count] = word[i];
			count = count + 1;
		}
	}

	cout << "Number of words with " << letter << " : " << count << endl;

	cout << "List of words with " << letter << " : ";
	for (i=0; i<count; i=i+1) {
		cout << matchedWord[i];
		if (i < (count-1)) {
			cout << ", ";
		}
	}

	cout << endl;

	return true;
}

void print_by_letter(char *w[], int n)
{
	char *word[MAX_NUMBER_OF_WORDS];
    for(int i=0; i < n; i = i+1) {
       word[i] = w[i];
	}
	
	for (i=0; i<n-1; i=i+1) {
		for (int j=i+1; j < n; j=j+1) {
			if (strcmp(word[j], word[i]) < 0) {
				char *tmp = word[i];
				word[i] = word[j];
				word[j] = tmp;
			}
		}
	}

	cout << "Alphabetical Order: ";
	for (i=0; i<n; i=i+1) {
		cout << word[i];
		if (i < (n-1)) {
			cout << ", ";
		}
	}

	cout << endl;
}

void print_by_length(char *w[], int n)
{
	int position[MAX_NUMBER_OF_WORDS];
	char *word[MAX_NUMBER_OF_WORDS];
    for(int i=0; i < n; i = i+1) {
		position[i] = i;
		word[i] = w[i];
	}

	for (i=0; i<n-1; i=i+1) {
		for (int j=i+1; j < n; j=j+1) {
			if (strlen(word[j]) < strlen(word[i])) {
				char *tmp = word[i];
				word[i] = word[j];
				word[j] = tmp;

				int tmpPosition = position[i];
				position[i] = position[j];
				position[j] = tmpPosition;
			}
		}
	}

	for (i=0; i<n-1; i=i+1) {
		bool bSwap = false;
		int index = i;
		for (int j=i+1; j < n; j=j+1) {
			if (strlen(word[j]) == strlen(word[i])) {
				if ((position[j] < position[i])) {
					if (position[j] < position[index]) {
						bSwap = true;
						index = j;
					}
				}
			}
		}

		if (bSwap) {
			char *tmp = word[i];
			word[i] = word[index];
			word[index] = tmp;

			int tmpPosition = position[i];
			position[i] = position[index];
			position[index] = tmpPosition;
		}
	}

	cout << "Length Order: ";
	for (i=0; i<n; i=i+1) {
		cout << word[i];
		if (i < (n-1)) {
			cout << ", ";
		}
	}

	cout << endl;
}