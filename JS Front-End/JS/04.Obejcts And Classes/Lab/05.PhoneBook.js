// function phoneBook(array) {
//     let phoneBook = {};

//     for (const element of array) {
//         tokens = element.split(' ');
//         phoneBook[tokens[0]] = tokens[1];
//     }

//     for (const key in phoneBook) {
//         console.log(`${key}`, '->', phoneBook[key]);
//     }

//     for (let [n, v] of Object.entries(phoneBook)) {
//         console.log(`${n} -> ${v}`);
//     }

//     for (let entry of Object.entries(phoneBook)) {
//         console.log(`${entry[0]} -> ${entry[1]}`);
//     }
// }

// function phoneBook(phoneBookArray) {
//     const phoneBook = {};

//     for (const nameAndPhone of phoneBookArray) {
//         const [name, phone] = nameAndPhone.split(' ');
//         phoneBook[name] = phone;
//     }

//     for (const name in phoneBook) {
//         console.log(`${name} -> ${phoneBook[name]}`)
//     }
// }

function phoneBook(array) {
    let phoneBook = {};

    array.map(entry => {
        let [name, number] = entry.split(' '); // Destructure the split result
        phoneBook[name] = number;
    });

    for (const name in phoneBook) {
        console.log(`${name} -> ${phoneBook[name]}`)
    }
}

phoneBook(['Tim 0834212554', 'Peter 0877547887', 'Bill 0896543112', 'Tim 0876566344']);
phoneBook(['George 0552554', 'Peter 087587', 'George 0453112', 'Bill 0845344']);