use regex::Regex;

pub fn new_token_library() -> Vec<TokenExpression>
{
    return vec![
        TokenExpression::new(AvailableTokens::OpenBrace, "([{])"),
        TokenExpression::new(AvailableTokens::CloseBrace, "([}])"),
        TokenExpression::new(AvailableTokens::OpenParenthesis, "([(])"),
        TokenExpression::new(AvailableTokens::CloseParenthesis, "([)])"),
        TokenExpression::new(AvailableTokens::Semicolon, "([;])"),
        TokenExpression::new(AvailableTokens::Int, "(int)"),
        TokenExpression::new(AvailableTokens::Return, "(return)"),
        TokenExpression::new(AvailableTokens::Identifier, r"([a-zA-Z]\w*)"),
        TokenExpression::new(AvailableTokens::IntegerLiteral, r"([0-9]+)"),
    ];
}

pub struct TokenExpression {
    pub Type: AvailableTokens,
    pub Expression: Regex,
}

impl TokenExpression {
    pub fn new(tk: AvailableTokens, exp: &str) -> TokenExpression {
        TokenExpression {
            Type: tk,
            Expression: Regex::new(exp).unwrap(),
        }
    }
}

pub struct Token {
    pub Type: AvailableTokens,
    // Value: Option<bool>
}

impl Token {
    pub fn new(tk: AvailableTokens) -> Token {
        Token {
            Type: tk
        }
    }
}

// impl<T> Token<T> {
//     pub fn new(val: T,tk: AvailableTokens) -> Token<T> {
//         Token {
//             Type: tk,
//             Value: val
//         }
//     }
// }

#[derive(Clone)]
pub enum AvailableTokens {
    OpenBrace,
    CloseBrace,
    OpenParenthesis,
    CloseParenthesis,
    Semicolon,
    Int,
    Return,
    Identifier,
    IntegerLiteral
}

// impl AvailableTokens {
//     pub fn new<F>(constructor: F) -> Self where F: Fn(String) -> Self {
//         (constructor)(none)
//     }
// }