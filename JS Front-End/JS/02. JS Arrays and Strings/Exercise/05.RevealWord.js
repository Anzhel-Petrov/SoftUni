// function RevelaWord(words, sentence)
// {
//     let wordsArray = words.split(', ');
//     let wordsSentence = sentence.split(' ');
//     for (let i = 0; i < wordsArray.length; i++) {
//         let found = wordsSentence.find(function(element) {
//             return element.includes('*');
//             });
//         let foo = wordsSentence.indexOf(found);
//         if(wordsArray[i].length == found.length)
//         {
//             wordsSentence[foo] = wordsArray[i];
//         }
//     }

//     console.log(wordsSentence.join(' '));
// }

// function solve(wordsString, sentence){
//     let wordArr = wordsString.split(', ');
 
//     let sentenceArr = sentence.split(' ');
 
//     for (let i = 0; i < sentenceArr.length; i++) {
 
//         for (let j = 0; j < wordArr.length; j++) {
//             if(sentenceArr[i] == wordArr[j].replace(wordArr[j],'*').repeat(wordArr[j].length)){
 
//                     sentenceArr[i] = wordArr[j];
//             }
//         }  
//     }
//     console.log(sentenceArr.join(' '));
// }

// function revealWords (words, text) {
//     wordsArr = words.split(', ');
//     splittedText = text.split(' ');
//     let currentText = text;
//     for (let word of splittedText) {
//         for (let w of wordsArr) {
//             if (word.length == w.length && word.includes('*')) {
//                 currentText = currentText.replace(word, w)
//             }
//         }
//     }
 
//     console.log(currentText);
// }

// function solve (word,text) {
 
//     let words = word.split(', ');
 
//     for(let i=0; i< words.length; i++){
//         text = text.replace('*'.repeat(words[i].length),words[i]);
//     }
 
//     console.log(text);
 
// }

// function solve (words, string) {
//     wordsArr = words.split(', ');
 
//     for (let word of wordsArr) {
//         let wordLen = word.length;
//         let secret = '\\*'.repeat(wordLen);
//         let regex = new RegExp(`(?<=\\s|^)${secret}(?=\\s|$)`, 'g');
//         while (regex.test(string)) {
//             string = string.replace(regex, word);
//         }
//     }
 
//     console.log(string);
// }

// function solve(template, text) {
//     let words = template.split(', ')
 
//     for (let word of words) {
//         text = text.replace('*'.repeat(word.length), word)
//     }
 
//     console.log(text)
// }
 
// function solve(template, string) {
//     let arr = string.split(' ');
 
//     for (let word of arr) {
//         if (word.startsWith('*')) {
//             for (let temp of template.split(', ')) {
//                 if (word.length == temp.length) {
//                     arr.splice(arr.indexOf(word), 1, temp)
//                 }
//             }
//         }
//     }
//     console.log(arr.join(' '))
// }
 
// function solve(words, sentence) {
//     let wordsArr = words.split(', ');
//     for (let word of wordsArr) {
//         sentence = sentence.replace('*'.repeat(word.length), word);
//     }
//     return sentence;
// }

function solve(wordsAsString, text)
{
    let words = wordsAsString.split(', ');
    let tokens = text.split(' ');


    for (let word of words) {
        let stars = '*'.repeat(word.length);
        for (let i = 0; i < tokens.length; i++)
            if (tokens[i] == stars)
            {
                tokens[i] = word;
            }
        }


    console.log(tokens.join(' '));
}

solve('great', 'softuni is ***** place for learning new programming languages');
solve('great, learning', 'softuni is ***** place for ******** new programming languages');