let myArr = [10, 20, 30, 40, 50, 60, 70];

console.log(myArr);

let [a, b, ...rest] = myArr;

console.log(a);
console.log(b);
console.log(rest);