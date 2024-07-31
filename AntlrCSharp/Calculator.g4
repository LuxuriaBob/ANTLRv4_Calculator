grammar Calculator;
 
@parser::members
{
    protected const int EOF = Eof;
}
 
@lexer::members
{
    protected const int EOF = Eof;
    protected const int HIDDEN = Hidden;
}
 
/*
 * Parser Rules
 */
 
prog: expr+ ;
 
expr : expr '!'                 # Factorial
     | 'log' '(' expr ')'       # Log
     | 'ln' '(' expr ')'        # Ln
     | 'exp' '(' expr ')'       # Exp
     | 'sin' '(' expr ')'       # Sin
     | 'cos' '(' expr ')'       # Cos
     | 'tan' '(' expr ')'       # Tan
     | '-' expr                 # Negate
     | expr '^' expr            # Power
     | expr op=('*'|'/') expr   # MulDiv
     | expr op=('+'|'-') expr   # AddSub
     | INT                      # Int
     | '(' expr ')'             # Parens
     ;
 
/*
 * Lexer Rules
 */
INT : [0-9]+;
MUL : '*';
DIV : '/';
ADD : '+';
SUB : '-';
POW : '^';
WS
    :   (' ' | '\r' | '\n') -> channel(HIDDEN)
    ;