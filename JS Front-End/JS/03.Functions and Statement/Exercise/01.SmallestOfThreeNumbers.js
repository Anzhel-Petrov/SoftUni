// function smallestOfThree(...nums) {
//     let numbers = Array.from(nums);
//     let smallestNum = numbers[0];
//     for (let i = 1; i < numbers.length; i++) {
//         if (numbers[i] < smallestNum) {
//             smallestNum = numbers[i];
//         }
//     }

//     console.log(smallestNum);
// }

function smallestOfThree(...numbers) {
    let numbersAsArray = Array.from(numbers);
    let minNumber = Number.MAX_SAFE_INTEGER;

    for (const number of numbersAsArray) {
        if (number < minNumber) {
            minNumber = number;
        }
    }

    return minNumber;
}

smallestOfThree(2, 5, 3);
smallestOfThree(600, 342, 123);
smallestOfThree(25, 21, 4);
smallestOfThree(2, 2, 2);