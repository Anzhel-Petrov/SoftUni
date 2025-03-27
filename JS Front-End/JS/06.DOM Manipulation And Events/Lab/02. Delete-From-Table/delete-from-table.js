function deleteByEmail() {
    //let rows = Array.from(document.querySelectorAll('tbody tr'));
    let input = document.querySelector('[name="email"]');
    let result = document.getElementById('result');
    let rows = document.querySelectorAll('tbody tr');
    let pattern = input.value;


    if (!pattern)
        return;

    for (const row of rows) {
        console.log(row.children[row.children.length - 1]);
        if (row.children[row.children.length - 1].textContent === pattern) {
            //row.remove();
            let parent = row.parentElement;
            parent.removeChild(row);
            result.textContent = 'Deleted.';
            return;
        }
    }

    result.textContent = 'Not found.';
}

// function deleteByEmail() {
//     //let rows = Array.from(document.querySelectorAll('tbody td:nth-child(2)'));
//     let rows = Array.from(document.querySelectorAll('tbody tr'));
//     let input = document.querySelector('[name="email"]');
//     let result = document.getElementById('result');
//     let pattern = input.value;
//     let deleted = false;

//     for (const row of rows) {
//         let emailCol = row.children[1];
//         let email = emailCol.textContent;

//         if (email.includes(pattern)) {
//             row.remove();
//             deleted = true;
//             // let parent = row.parentElement;
//             // parent.removeChild(row);
//         }
//     }

//     result.textContent = deleted ? 'Deleted.' : 'Not found.';
// }

// function deleteByEmail() {
//     let tableRowsElements = document.querySelectorAll('tbody tr');
//     let emailToBeDeleted = document.querySelector('input[type ="text"]').value.trim();
//     let resultElement = document.getElementById('result');

//     for (const row of tableRowsElements) {
//         let email = row.cells[1];

//         if (email.textContent.trim() === emailToBeDeleted) {
//             row.remove();
//             resultElement.textContent = 'Deleted.';
//             return;
//         }
//     }

//     resultElement.textContent = 'Not found.';
// }
