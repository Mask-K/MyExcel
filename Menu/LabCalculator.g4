grammar LabCalculator;


/*
 * Parser Rules
 */

compileUnit : expression EOF;

expression :
  LPAREN expression RPAREN #ParenthesizedExpr
  | expression EXPONENT expression #ExponentialExpr
  | expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
  | expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
  | NUMBER #NumberExpr
  | IDENTIFIER #IdentifierExpr
  | MAX LPAREN exp1=expression COMA exp2=expression RPAREN #MaxExpr
  | MIN LPAREN exp1=expression COMA exp2=expression RPAREN #MinExpr
  | INC expression #IncExpr
  | DEC expression #DecExpr
  ; 

/*
 * Lexer Rules
 */

NUMBER : INT ('.' INT)?; 
IDENTIFIER : [a-zA-Z]+[1-9][0-9]+;

INT : ('0'..'9')+;

EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : '/';
SUBTRACT : '-';
ADD : '+';
LPAREN : '(';
RPAREN : ')';
MAX : 'max';
MIN : 'min';
COMA: ',';
INC : 'inc';
DEC : 'dec';

WS : [ \t\r\n] -> channel(HIDDEN);