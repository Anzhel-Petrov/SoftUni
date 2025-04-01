document.addEventListener('DOMContentLoaded', solve);

function solve() {
    //TODO
}

// function solve() {
//     let table = document.querySelector('table');
//     let quickCheckBtn = document.querySelector('.buttons input[type="submit"]');
//     let clearBtn = document.querySelector('.buttons input[type="reset"]');
 
//     quickCheckBtn.addEventListener('click', function(e) {
//         e.preventDefault();
//         checkSudoku();
//     })
 
//     clearBtn.addEventListener('click', function(e) {
//         e.preventDefault();
//         clear();
//     });
 
//     function clear () {
//         document.getElementById('check').textContent = "";
//         let tableInputs = document.querySelectorAll('tbody tr td input');
//         for (let input of tableInputs) {
//             input.value = "";
//         }
//     }
 
//     function checkSudoku () {
//         let rowsColsArray = [];
//         let tableRows = table.querySelectorAll('tr');
//         let col1 = '';
//         let col2 = '';
//         let col3 = '';
//         let isValid = true;
 
//         for (let row of tableRows) {
//             let currentRow = '';
//             let rowValues = Array.from(row.querySelectorAll('td'));
//             col1 += rowValues[0].querySelector('input').value;
//             col2 += rowValues[1].querySelector('input').value;
//             col3 += rowValues[2].querySelector('input').value;
//             currentRow = rowValues[0].querySelector('input').value + rowValues[1].querySelector('input').value + rowValues[2].querySelector('input').value
//             rowsColsArray.push(currentRow);
//         }
 
//         rowsColsArray.push(col1);
//         rowsColsArray.push(col2);
//         rowsColsArray.push(col3);
 
//         for (let element of rowsColsArray) {
//             if (!element.includes('1') || !element.includes('2') || !element.includes('3')) {
//                 isValid = false;
//                 break;
//             }
//         }
 
//         if (isValid) {
//             table.style.border = '2px solid green';
//             document.getElementById('check').textContent = "Success!";
//         } else {
//             table.style.border = '2px solid red';
//             document.getElementById('check').textContent = "Keep trying ...";
//         }
//     }
// }

// function solve() {
//     let result = document.getElementById('check');
//     let table = document.querySelector('table');
 
//     document.querySelector('#solutionCheck').addEventListener('submit', (e) => {
//         e.preventDefault();
 
//         const data = Array.from(document.querySelectorAll('tbody tr'));
//         let matrix = [];
 
//         result.textContent = '';        
 
//         data.forEach((row) => matrix.push(Array.from(row.querySelectorAll('input')).map(x => x.value)));
 
//         for (let i = 0; i < 3; i++) {
 
//             let checkRow = new Set(matrix[i]);
//             let checkCol = new Set();
 
//             for (let j = 0; j < 3; j++) {
//                 checkCol.add(matrix[j][i]);
//             }
 
//             if (checkRow.size < 3 || checkCol.size < 3) {
//                 result.textContent = 'Keep trying ...';
//                 table.style.borderColor = 'red';
//                 return;
//             }
//         }
 
//         if (result.textContent == '') {
//             result.textContent = 'Success!';
//             table.style.borderColor  = 'green';
//         }
 
//     })
 
//     document.querySelector('input[type="reset"]').addEventListener('click', (e) => {
//         let boxes = document.querySelectorAll('input[type="number"]');
 
//         boxes.forEach((element)=>element.value = '');
//         result.textContent = '';
//         table.style.borderColor = '#234465'
//     })
// }