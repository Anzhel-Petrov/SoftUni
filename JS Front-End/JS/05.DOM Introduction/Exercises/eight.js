// function solve() {
//     let result = [];
//     let rows = document.querySelector('tbody').children;
 
//     let checkedColumns = Array.from(document.querySelectorAll('th')).map(
//         (column, i) => column.children[0].checked ? [column.children[0].name, i] : null
//     ).filter(Boolean)
 
//     for (let row of rows) {
//         let currentRow = {};
 
//         for (let [columnName, index] of checkedColumns) {
//             let curentTds = Array.from(row.children);
//             currentRow[columnName] = curentTds[index].textContent;
//         }
 
//         result.push(currentRow);
//     }
 
//     document.getElementById('output').textContent = JSON.stringify(result);
// }

// function solve() {
//     const checkBoxes = document.querySelectorAll('thead th input[type="checkbox"]');
//     const rows = document.querySelectorAll('tbody tr');
//     const headings = document.querySelectorAll('thead th');
 
//     let checkedIndexes = [];
 
//     for (let i = 0; i < checkBoxes.length; i++) {
//         if (checkBoxes[i].checked) {
//             checkedIndexes.push(i);
//         }
//     }
 
//     let result = [];
 
//     for (let row of rows) {
//         const cells = row.querySelectorAll('td');
//         let rowObject = {};
        
//         for (let j = 0; j < checkedIndexes.length; j++) {
//             const index = checkedIndexes[j];
//             const headingCell = headings[index];
//             const headingName = headingCell.childNodes[0].textContent.trim();
//             rowObject[headingName] = cells[index].textContent.trim();
//         }
//         result.push((rowObject));
//     }
 
//     document.getElementById('output').value = JSON.stringify(result);
// }
