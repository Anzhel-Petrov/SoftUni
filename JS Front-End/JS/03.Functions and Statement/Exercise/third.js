function solve(char1, char2) {
    const first_char_code = Math.min(char1.charCodeAt(), char2.charCodeAt());
    const second_char_code = Math.max(char1.charCodeAt(), char2.charCodeAt());

    console.log(Array.from({ length: second_char_code - first_char_code - 1 }, (_, i) => String.fromCharCode(first_char_code + i + 1)).join(" "));
}

function asciiFinder(startChar, endChar) {
    let decStart = startChar.charCodeAt(0);
    let decEnd = endChar.charCodeAt(0);
    let asArr = [decStart, decEnd];
    let sortedArr = asArr.sort(function (a, b) { return a - b });
    let asciiArr = [];
    let asciiToChar = [];

    for (let i = sortedArr[0] + 1; i < sortedArr[1]; i++) {
        asciiArr.push(i);
    }

    for (char of asciiArr) {
        asciiToChar.push(String.fromCharCode(char));
    }

    console.log(asciiToChar.join(' '));

}

function solve(char1, char2) {
    let charCode1 = char1.charCodeAt(0);
    let charCode2 = char2.charCodeAt(0);
    let result = [];

    if (charCode1 > charCode2) {
        [charCode1, charCode2] = [charCode2, charCode1];
    }

    for (let i = charCode1 + 1; i < charCode2; i++) {
        result.push(String.fromCharCode(i));
    }

    return result.join(' ');
}

console.log(solve('C', '#'))

function charsInRange(stringOne, stringTwo) {
    let asciiNumForStringOne = stringOne.charCodeAt(0);
    let asciiNumForStringTwo = stringTwo.charCodeAt(0);

    let result = [];

    if (asciiNumForStringOne < asciiNumForStringTwo) {
        for (let i = asciiNumForStringOne + 1; i < asciiNumForStringTwo; i++) {
            result.push(String.fromCharCode(i));
        }
    } else {
        for (let i = asciiNumForStringOne - 1; i > asciiNumForStringTwo; i--) {
            result.push(String.fromCharCode(i));
        }
        result.reverse();
    }

    console.log(result.join(' '))
}

function solve(str1, str2) {

    let first = str1.charCodeAt(0);
    let second = str2.charCodeAt(0);
    let myArr = [];
    if (first > second) {
        for (let i = second + 1; i < first; i++) {
            myArr.push(String.fromCharCode(i));
        }
    } else {
        for (let i = first + 1; i < second; i++) {
            myArr.push(String.fromCharCode(i));
        }
    }

    console.log(myArr.join(' '))

}

//solve ('a','d');
//solve ('#',':');
//solve ('C','#');