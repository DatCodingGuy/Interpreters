-- Description --
Fishstacks is a Deadfish derivative based on a stack; the stack can only hold four elements and when a fifth element is pushed the bottom element is kicked out and printed out to the screen as a character. The name was originally meant to be Hpmestack but it was suggested that Deafstack or StackFish would be a better name as it is a derivative but eventually atriq came up with Fishstack.

-- Commands --
i = Increment value on top of the stack
d = Decremen value on top of the stack
s = Square the value on top of the stack
p = Push a new zero to the stack

-- Notes --
When a value is 255 and gets incrememnted it gets wrapped to 0 and values can't decrement below 0. There is also no pop function, the only way to get values out of the stack is to push more values on top of the stack which kicks out the bottom values and then prints them to the screen.

read more: https://esolangs.org/wiki/Fishstacks

-- How to use the interpreter --
1. The first thing you have to do is compile the C# project
2. After compiling the C# project, create a raw text file with the code you want to execute
3. Then open the interpreter's executable giving it the file as an argument, in Windows this can be done by dragging the file over the interpreter and dropping it running the interpreter with the file as an argument.

Example programs are provided in the 'Examples' folder
