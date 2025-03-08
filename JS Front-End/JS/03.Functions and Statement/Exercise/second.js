function solve(num1, num2, num3) {
    function sum(x, y) {
        return x + y;
    }

    function subtract(x, y) {
        return x - y;
    }

    let sumResult = sum(num1, num2);

    return subtract(sumResult, num3);
}


function addAndSubtract(numOne, numTwo, numThree) {
    function sum(numOne, numTwo) {
        return numOne + numTwo;
    }

    let subtraction = sum(numOne, numTwo) - numThree;

    console.log(subtraction);
}

function solve(num1, num2, num3) {

    const add = (num1, num2) => {
        return num1 + num2;
    }

    const substract = (num1, num2, num3) => {
        const sum = add(num1, num2);
        return sum - num3;
    }

    const result = substract(num1, num2, num3);
    console.log(result);
}

//solve (23,6,10);
//solve (1,17,30);
//solve (42,58,100);

function addSub(n1, n2, n3) {
    let sum = (a, b) => a + b;
    let sub = (a, b) => a - b;
    console.log(sub(sum(n1, n2), n3));
}