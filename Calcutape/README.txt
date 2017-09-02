-- Description --
Calcutape is a programming language designed to calculate mathmatical expressions on tape, designed by Darkrifts from the esolang wiki (esolang.org).

-- Commands --
The language is stack-based and only has 1-character commands:
0-9 = Push a single digit to the stack
+ = Pops the top two digits on the stack and pushes their sum
- = Pops the top two digits on the stack and pushes the difference (1st - 2nd)
* = Pops the top two digits on the stack and pushes their product
/ = Pops the top two digits on the stack and pushes their quotient (1st / 2nd)

% = Pops the top digit on the stack and outputs it as a number
@ = Pops the top digit on the stack and outputs it as a character

| = Swaps the position of the top two digits on the stack
_ = Duplicates the top number on the stack
& = Pops the top digit on the stack (N) and pushes a copy of the Nth number to the top of the stack
$ = Pops the top number of the stack and discards it
^ = Pops the top number of the stack (N) and waits for N milliseconds
= = Clears the screen
? = Terminates the program
# = Checks the top number of the stack (doesn't pop it) and if the number is 0 then it reverses the direction of interpretation, if the number is greater than 0 then it skips N commands and if the number is less than 0 it does nothing and continues with the program.

V = Reads a single character from the keyboard and pushes it to the top of the stack
( = Opens comment section, all code within the comment section is not executed
) = Closes comment section

read more: https://esolangs.org/wiki/Calcutape

-- How to use the interpreter --
1. The first thing you have to do is compile the C# project
2. After compiling the C# project, create a raw text file with the code you want to execute
3. Then open the interpreter's executable giving it the file as an argument, in Windows this can be done by dragging the file over the interpreter and dropping it running the interpreter with the file as an argument.

Example programs are provided in the 'Examples' folder
