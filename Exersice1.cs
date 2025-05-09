#include <stdio.h>
#include <string.h>

int main() {
    char firstName[50];
    char lastName[50];
    char fullName[100];

    // First input
    printf("What is your first name? ");
    scanf("%s", firstName);
    printf("What is your last name? ");
    scanf("%s", lastName);
    
    // Format and display first output
    strcpy(fullName, lastName);
    strcat(fullName, ", ");
    strcat(fullName, firstName);
    strcat(fullName, " ");
    strcat(fullName, lastName);
    printf("Your name is %s.\n\n", fullName);

    // Second input
    printf("What is your first name? ");
    scanf("%s", firstName);
    printf("What is your last name? ");
    scanf("%s", lastName);
    
    // Format and display second output
    strcpy(fullName, lastName);
    strcat(fullName, ", ");
    strcat(fullName, firstName);
    strcat(fullName, " ");
    strcat(fullName, lastName);
    printf("Your name is %s.\n", fullName);

    return 0;
}