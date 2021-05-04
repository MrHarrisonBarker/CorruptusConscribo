mod TokenLibrary;

use std::fs::File;
use std::io::prelude::*;
use std::path::Path;
use regex::{Regex, Match, Matches};
use crate::TokenLibrary::{TokenExpression, AvailableTokens, Token};
use std::borrow::Borrow;
use std::ptr::null;

fn main() {
    println!("Hello, world!");
    let source = open_file("./TestPrograms/return_69.c");
    println!("raw source -> {}", source);
    lex(&source);
}

fn lex(source: &str)
{
    let token_library: Vec<TokenExpression> = TokenLibrary::new_token_library();
    let mut tokens_in_source: Vec<Token> = Vec::new();

    for tk in token_library {
        println!("starting next token");
        let matches: Matches = tk.Expression.find_iter(source);

        for matchedToken in matches {
            tokens_in_source.push(Token::new(tk.Type.clone()));
            println!("match, {},{} = {}", matchedToken.start(), matchedToken.end(), &source[matchedToken.start()..matchedToken.end()]);
        }
    }

    println!("all tokens found {}", tokens_in_source.len())
}

fn open_file(path: &str) -> String
{
    // Create a path to the desired file
    let path = Path::new(path);
    let display = path.display();

    // Open the path in read-only mode, returns `io::Result<File>`
    let mut file = match File::open(&path) {
        Err(why) => panic!("couldn't open {}: {}", display, why),
        Ok(file) => file,
    };

    // Read the file contents into a string, returns `io::Result<usize>`
    let mut s = String::new();
    match file.read_to_string(&mut s) {
        Err(why) => panic!("couldn't read {}: {}", display, why),
        Ok(_) => {
            print!("{} contains:\n{}", display, s);
            return s;
        }
    }
}
