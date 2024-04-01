// 210101110_Assignment1B.cpp : Defines the entry point for the console application.

// header file necessary to run c++ is visual studio
#include "stdafx.h"

// c++ necessary header files
#include <iostream>
#include <vector>

// header file to help the user to view the console with ease
#include "conio.h"

// for std functions
using namespace std;

// this is a function that checks if the value entered by the user is an integer or not
long long int number_input()
{
    long long int number; // declaration of the number taken as input

    while (true) // while loop to keep entering the number till it is valid
    {
        if (cin >> number) // input the number
        {
            // Check if there are any remaining characters in the input buffer
            if (cin.peek() == '\n')
            {
                break; // Exit the loop if a valid number is entered
            }
            else
				// number is invalid. Clear memory block.
            {
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(), '\n');

				// Displaying the message on the screen.
                cout << "Invalid input. Please enter a valid number." << endl;
            }
        }
        else
        {
            // Clear the input buffer to handle the error
            cin.clear();

            // Ignore any remaining characters in the input buffer, up to the newline
            cin.ignore(numeric_limits<streamsize>::max(), '\n');

            cout << "Invalid input. Please enter a valid number." << endl;
        }
    }

	// After all the necessary checks, the number is a valid integer. Now returning the number.
    return number;
}

// this is a function to check the range of the number of elements in the array, which is taken as input from the user.
// we keep the range of n from 1 to 10 for better visualisation in the software.
int checkRangeForN(long long int n)
{
	if(n>=1 && n<=10) //  correct range
		return 1; // returning 1 for valid range number
	
	// number n falls out of the restricted range. Display the message on screen and return 0.
	cout<<"Please enter a value of n between 1 and 10, for easier visualisation in the software."<<endl;
	return 0;
}


// this is a function to check the range of the elements of the array, which are taken as input from the user.
// we keep the range of n from -1000 to 1000 for better visualisation in the software.
int checkRangeForArrayElements(long long int num)
{
	if(num >=-1000 && num<=1000) //  correct range
		return 1; // returning 1 for valid range number

	// number n falls out of the restricted range. Display the message on screen and return 0.
	cout<<"Please enter a value of this element between -1000 and 1000, for easier visualisation in the software."<<endl;
	return 0;
}



int _tmain(int argc, _TCHAR *argv[])
{
    long long int n; //  number of elements in the array
	cout<<"Number of elements in the array ? "; //  asking the user for input
	n = number_input();

	while(!(checkRangeForN(n))) // keep asking for the input till the value of n meets the required range
	{
		n = number_input();
	}

	vector<long long int>arr(n); // the array containing the elements to be sorted.

	for(int i=0;i<n;i++)
	{
		cout<<"\nElement number " <<i+1<<"?"<<endl; //  asking the user for input

		arr[i] = number_input(); // taking each element as input


		while(!(checkRangeForArrayElements(arr[i]))) // keep asking for the input till the value of arr[i] meets the required range
		{
		arr[i] = number_input();
		}
	}

	// The following loop iterates through each element of the array starting from the second element (index 1).
for (int i = 1; i < n; i++) {
    // Store the current element in a variable called key.
    int key = arr[i];
    // Initialize a variable j to the index one less than the current index.
    int j = i - 1;

    // Continue iterating backward while j is greater than or equal to 0
    // and the element at index j is greater than the key.
    while (j >= 0 && arr[j] > key) {
        // Shift the elements to the right to make space for the key.
        arr[j + 1] = arr[j];
        // Move to the previous index.
        j = j - 1;
    }

    // Place the key in its correct position in the sorted sequence.
    arr[j + 1] = key;

    // Print the current state of the array after each pass.
    cout << "Pass number " << i << " : ";
    for (int k = 0; k < n; k++)
        cout << arr[k] << " ";
    cout << endl;
}

	// now we get the sorted array.
	cout<<"\nNow the array is completely sorted"<<endl;
	cout<<"Program terminates."<<endl;

	// to fix the console screen for ease of the user.
	getch();
    return 0;
}