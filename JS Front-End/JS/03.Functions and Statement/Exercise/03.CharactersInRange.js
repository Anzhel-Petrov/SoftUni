function charactersInRange(a, b) {
    let charA = a.charCodeAt(0);
    let charB = b.charCodeAt(0);

    let result = [];
    for (let i = Math.min(charA, charB) + 1; i < Math.max(charA, charB); i++) {
        result.push(String.fromCharCode(i));
    }

    console.log(result.join(' '));
}

// function charactersInRange(firstChar, secondChar) {
//     const smallerChar = firstChar < secondChar ? firstChar : secondChar;
//     const biggerChar = firstChar > secondChar ? firstChar : secondChar;

//     const smallerCharCode = smallerChar.charCodeAt(0);
//     const biggerCharCode = biggerChar.charCodeAt(0);

//     let result = [];
//     for(let i = smallerCharCode + 1; i < biggerCharCode; i++) {
//         result.push(String.fromCharCode(i));
//     }

//     return result.join(' ');
// }

charactersInRange('a', 'd');
charactersInRange('#', ':');
charactersInRange('C', '#');