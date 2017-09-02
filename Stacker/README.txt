-- Description --
Stacker is an esoteric programming language designed and created by me. It takes inspiration from multiple languages including Stack Up, Calcutape and Befunge.

-- Commands --
0-9 = Push a single digit on to the main stack
$ =	Pops the top value off the main stack and discards it
: =	Duplicates the top value of the main stack
_ =	Swaps the top two values of the main stack
i =	Increments the top value of the main stack by 1
d =	Decrements the top value of the main stack by 1
+ =	Pops the top two values off the main stack and pushes their sum
- =	Pops the top two values off the main stack and pushes their difference (1st - 2nd)
* =	Pops the top two values off the main stack and pushes their product
/ =	Pops the top two values off the main stack and pushes their quotient
^ =	Squares the top value of the main stack
> =	Pops the top value off the main stack and pushes it on to the extra stack
< =	Pops the top value off the extra stack and pushes it on to the main stack
} =	Pops the top value off the main stack (N) and then pops Nth amount of values off the main stack and pushes them on to the extra stack in the same order
{ =	Pops the top value off the main stack (N) and then pops Nth amount of values off the extra stack and pushes them on to the main stack in the same order
& =	Takes input from the user in the form of a 32bit integer and pushes it on to the main stack
, =	Takes input from the user in the form of an ASCII character and pushes its value on to the main stack
% =	Pops the top value off the main stack and prints it as an integer
. =	Pops the top value off the main stack and prints it as a character
[ =	If the flag is true then start the loop, otherwise jump to the matching ]
] =	If the flag is true then exit the loop, otherwise jump back to the matching [
( =	If the flag is true then continue executing the code, otherwise jump to the matching )
) =	Does nothing other than symbolize the end of an if statement
= =	Pops the top value off the main stack (N) and depending on N it does something different. If N is 0 then it pops the top two values off the main stack (N1 and N2) and if N1 equals N2 then the flag is set to true, otherwise the flag is set to false. If N is 1 then it pops the top two values off the stack (N1 and N2) and if N1 is greater than N2 then it sets the flag to true, otherwise the flag is false. If N is -1 then it pops two values off the main stack (N1 and N2) and if N1 is less than N2 then is sets the flag to true, otherwise the flag is set to false.
e =	Pops the top value off the main stack (N) and executes the value N as an opcode
! =	Terminates the program immediately
? =	Sets the program counter to 0 and continues executing commands from the start of the program
h =	Halts the program by entering an infinite loop
# =	If the flag is true then it skips the next command
| =	Reverses the direction of the PC
f =	Flips the flag (if the flag is true it will be set to false, if the flag is false it will be set to true)

-- Notes --
By default the input is not displayed to the console as it is being inputted. Please look at the examples on the wiki to find out how to work around that.

The order in which you push multiple values on to the main stack and extra stack remains the same. If the main stack is [0, 1, 2, 3] and you use the } command the top four values on the extra stack will be [0, 1, 2, 3]. If the four commands starting at position 3 are [4, 5, *, ^] and you use the " (giving it the arguments 3 and 4) command the first four values on the main stack will be [4, 5, 17, 19] (values that are pushed are the opcode values of the commands, not integer values of the character).

read more: https://esolangs.org/wiki/Stacker

-- How to use the interpreter --
1. The first thing you have to do is compile the C# project
2. After compiling the C# project, create a raw text file with the code you want to execute
3. Then open the interpreter's executable giving it the file as an argument, in Windows this can be done by dragging the file over the interpreter and dropping it running the interpreter with the file as an argument.

Example programs are provided in the 'Examples' folder
