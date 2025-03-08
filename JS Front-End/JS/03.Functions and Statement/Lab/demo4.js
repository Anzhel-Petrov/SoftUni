let myArr = [1, 2, 3, 4, 5, 6, 7, 8];

//let oddNumbers = myArr.filter(x => x % 2);
let oddNumbers = myArr.filter(oddValues);

console.log(oddNumbers);

function oddValues(number) {
    return Boolean(number % 2);
}