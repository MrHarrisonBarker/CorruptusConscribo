# CorruptusConscribo
## A C compiler
Corruptus Conscribo is a **VERY** basic C compiler written in C# for intel x64 running on macOS.

Thanks to [Write-a-Compiler](https://norasandler.com/2017/11/29/Write-a-Compiler.html)

Function calls use `RDI`, `RSI`, `RDX`, `RCX`, `R8`, `R9` registers in order for passing parameters with a 16bit offset as per the macOS specification.

```C
int twice(int x){
    return 2 * x;
}

int main() {
    return twice(3);
}
```
```assembly
.globl _twice
_twice:
push  %rbp            # push stack
movq  %rsp,%rbp       # move call stack

push  %rdi            # pushing parameter int x onto stack
movq  $2, %rax
push  %rax            # pushing left of operator into stack
movq  -8(%rbp), %rax  # moving x onto rax, 1

pop   %rcx            # popping left of operator onto rcx
imulq %rcx,%rax

movq  %rbp,%rsp       # clear stack
pop   %rbp            # pop previous stack
ret

.globl _main
_main:
push  %rbp            # push stack
movq  %rsp,%rbp       # move call stack

subq  $16, %rsp       #offsetting
movq  $3, %rax
movq  %rax, %rdi      # moving argument 3
call  _twice
addq  $8, %rsp        # removing arguments from stack

movq  %rbp,%rsp       # clear stack
pop   %rbp            # pop previous stack
ret
```
## Supported
### Types
-    Integers
### Unary Operators
-    Bitwise complement ~
-    Negation -
-    Logical negation !
### Binary Operators
-    Addition +
-    Subtraction -
-    Division /
-    Multiplication *
-    Logical And &&
-    Logical Or ||
-    Modulo %
-    Equal ==
-    Not Equal !=
-    Less Than <
-    Less Than Or Equal <=
-    Greater Than >
-    Greater Than Or Equal >=
-    Bitwise AND &, OR |, XOR ^, Left <<, Right >>
### Assignments
-    Assign =
-    Addition +=
-    Subtraction -=
-    Division /=
-    Multiplication *=
-    Modulo %=
-    Increment ++
-    Decrement --
-    AND &=
-    OR |=
-    XOR ^=
### Statements
-    Variable declare, initialisation and assignment
-    Ternary conditional (a ? b : c)
-    If conditional with else support
-    For loop
-    While loop
-    Do while loop
-    Forward function declare
-    Function call
-    Break
-    Continue
-    Global variable forward declare
-    Return

## Tests

Tests have been written using the _CompilerTest_ & _FailureTest_ class which compile C files from the **TestPrograms** directory, runs them and then checks for the correct exit code. 