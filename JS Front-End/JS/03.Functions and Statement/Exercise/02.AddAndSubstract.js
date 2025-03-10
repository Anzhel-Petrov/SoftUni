// function addAndSubstract(a, b, c) {

//     function subtract(a, b) {
//         return a - b;
//     }

//     function sum(a, b) {
//         return a + b;
//     }

//     console.log(subtract(sum(a, b), c));
// }

function addAndSubstract(firstNumber, secondNumber, thirdNumber) {
    const sum = (a, b) => a + b;
    const subtract = (a, b) => a - b;

    return subtract(sum(firstNumber, secondNumber), thirdNumber);
}

// function solve(num1, num2, num3) {
//     function sum(x, y) {
//         return x + y;
//     }

//     function subtract(x, y) {
//         return x - y;
//     }

//     let sumResult = sum(num1, num2);

//     return subtract(sumResult, num3);
// }


// function addAndSubtract(numOne, numTwo, numThree) {
//     function sum(numOne, numTwo) {
//         return numOne + numTwo;
//     }

//     let subtraction = sum(numOne, numTwo) - numThree;

//     console.log(subtraction);
// }

// function solve(num1, num2, num3) {

//     const add = (num1, num2) => {
//         return num1 + num2;
//     }

//     const substract = (num1, num2, num3) => {
//         const sum = add(num1, num2);
//         return sum - num3;
//     }

//     const result = substract(num1, num2, num3);
//     console.log(result);
// }

// function addSub(n1, n2, n3) {
//     let sum = (a, b) => a + b;
//     let sub = (a, b) => a - b;
//     console.log(sub(sum(n1, n2), n3));
// }

addAndSubstract(23, 6, 10);
addAndSubstract(1, 17, 30);
addAndSubstract(42, 58, 100);