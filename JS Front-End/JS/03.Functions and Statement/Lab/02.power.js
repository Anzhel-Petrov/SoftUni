function solve(value, exponent) {
    let result = 1;

    for (let i = 0; i < exponent; i++) {
        result *= value;
    }

    return result;
}

console.log(solve(2, 8));
console.log(solve(3, 4));