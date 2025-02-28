function listOfNames(array)
{
    array.sort((a, b) => a.localeCompare(b));
    let counter = 1;
    array.forEach(element => {
        console.log(`${counter++}.${element}`)
    });
}

// function solve(arr) {
//     arr.sort((a, b) => a.localeCompare(b));
 
//     for (let [i, value] of arr.entries()) {
//         console.log(`${i + 1}.${value}`)
//     }
// }

// function solve(arr) {
//     let result = arr.sort((a, b) => a.localeCompare(b))
//                    .map((name, index) => `${index + 1}.${name}`);
 
//     console.log(result.join("\n"));
// }

// function listOfNames(arr) {
//     arr.sort((a, b) => a.localeCompare(b));
//     let helpArray = [];
//     for (let i = 0; i < arr.length; i++) {
//         helpArray.push(`${i + 1}.${arr[i]}`);
//     }
 
//     return helpArray.join('\n')
// }

// function solve (myArr) {
//     let count = 0;
//     myArr.sort((a, b) => a.localeCompare(b));;
//     for (let i=0; i < myArr.length; i++){ 
//         count++;
//         //console.log(count + '.' + sorted[i])
//         console.log(`${count}.${myArr[i]}`)
//     }
// } 

listOfNames(["John", "Bob", "Christina", "Ema"]);
listOfNames(["John", "Bob", "Christina", "Ema", "bob"]);