.globl _main
_main:
movq    $10, %rax
push	%rax
movq    $1, %rax
pop	%rcx
movq	$1,%cl
shlq	%cl,%rax
ret