// function sortNumbers(array) {
//     array.sort((a, b) => a - b);
//     let result = [];
//     for(let i = 0; i < array.length; i++)
//     {
//         result.push(array.shift());
//         result.push(array.pop());
//     }

//     result.push(array.shift());
//     result.push(array.pop());

//     return(result);
// }

// function solve(numbers) {
//     const small = numbers.sort((a, b) => a - b).slice(0, numbers.length / 2)
//     const big = numbers.slice(numbers.length / 2).reverse()
//     let result = [];
//     for (let i = 0; i < small.length; i++) {
//       result.push(small[i], big[i])
//     }
//     if (numbers.length % 2 !== 0) {
//         result.push(numbers[Math.floor(numbers.length / 2)]);
//     }
//     console.log(result);
//   }

function solve (myArr) {
    let sorted = [];
    myArr.sort((a, b) => a - b);
    let start = 0;
    let end = myArr.length - 1; 
    for (let i=0; i< myArr.length ; i++){
        if (i % 2 ==0 && start <= end) {
            sorted.push(myArr[start]);
            start++;
        } else {
            sorted.push(myArr[end]);
            end--;
        }
    }

    console.log(sorted);
    // /for(let i=0;i< sorted.length ; i++){
    //     console.log(sorted[i]);
    // }/

}

  console.log(solve([1, 2, 3, 4, 5]));

// function sortNumbers(array) {
//     array.sort((a, b) => a - b); // Sort numerically
//     let result = [];
//     let left = 0;
//     let right = array.length - 1;

//     while (left <= right) {
//         result.push(array[left++]); // Smallest
//         result.push(array[right--]); // Largest
//     }

//     return result;
// }

//sortNumbers([3, 2]);