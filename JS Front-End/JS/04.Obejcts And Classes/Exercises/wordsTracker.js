// function solve (arr) {
 
//     let searched = arr[0].split(' ');
//     arr.shift();
//     let occurrences = {};
//     for (let i=0; i< searched.length; i++){
//         let word = searched[i];
//         occurrences[word] = 0;
//     }
 
 
//     for (let i=0; i< arr.length; i++){
//         if (occurrences.hasOwnProperty(arr[i])){
//             occurrences[arr[i]] += 1;
//         }
 
//     }
 
//     let sorted = Object.entries(occurrences).sort((a,b) => b[1] - a[1]);
 
//     for (const [key,value] of sorted) {
//         console.log(`${key} - ${value}`);
//     }
 
// }
 
// solve ([
//     'this sentence', 
//     'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
//     ]
//     );
 
// //solve ([
// //    'is the', 
// //    'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']
// //    );


// function wordsTracker(array) {
//     let searchedWords = array[0].split(' ');
//     let targetWords = array.splice(1, array.length - 1);
//     let wordObj = {};
 
//     for (let word of searchedWords) {
//         wordObj[word] = 0;
 
//         for (let element of targetWords) {
//             if (element === word) {
//                 wordObj[word] += 1;
//             }
//         }
//     }
 
//     let sortedEntries = Object.entries(wordObj).sort((a, b) => b[1] - a[1])
 
//     for (let entry of sortedEntries) {
//         console.log(`${entry[0]} - ${entry[1]}`)
//     }
// }