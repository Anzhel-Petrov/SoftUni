function stringSubstring(word, text) {
    let wordLowercase = word.toLowerCase() ;
    let tokens = text.toLowerCase().split(' ') ;
    
    tokens.includes(wordLowercase) ? console.log(wordLowercase) : console.log(`${wordLowercase} not found!`);
}

stringSubstring('javascript', 'JavaScript is the best programming language');
stringSubstring('python', 'JavaScript is the best programming language');