function solve(text) {
    let pattern = /^#([A-Za-z]+)$/;

    let tokens = text.split(' ');

    for (let token of tokens) {
        //console.log(token.match(pattern));
        const match = token.match(pattern);
        if (match)
        {
            console.log(match[1]);
        }
    }
}

// function solve(string) {
//     let regex = /#([A-Za-z]+)/g; 
//     let matches = [...string.matchAll(regex)]; 
//     let result = matches.map(match => match[1]);
 
//     if (result.length > 0) {
//         console.log(result.join('\n'));
//     }
// }

// function solve (text) {
//     let specialWords = text.split(' ');
 
//     for(let i=0; i < specialWords.length; i++){
//         let currentword = specialWords[i];
//         if (currentword.startsWith('#') && /[#][a-z]+/.test(currentword)){
//             console.log(currentword.replace('#','').trim());
//         }
//     }
 
// }

// function solve(text) {
//     let helpArray = [];
 
//     let regex = /#[a-zA-z]+/g;
 
//     let match = text.match(regex);
 
//     for (let i = 0; i < match.length; i++) {
//         match[i] = match[i].replace('#', '')
//     }
 
//     console.log(match.join('\n'));
// }

// function solve (text) {
//     let specialWords = text.split(' ');
 
//     for(let i=0; i < specialWords.length; i++){
//         let currentword = specialWords[i];
//         if (currentword.startsWith('#') && /[#][a-z]+/.test(currentword)){
//             console.log(currentword.replace('#','').trim());
//         }
//     }
 
// }

// function solve(text) {
//     let helpArray = [];
 
//     let regex = /#[a-zA-z]+/g;
 
//     let match = text.match(regex);
 
//     for (let i = 0; i < match.length; i++) {
//         match[i] = match[i].replace('#', '')
//     }
 
//     console.log(match.join('\n'));
// }

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');
solve('The symbol # is known #variously in English-speaking #regions as the #number sign');