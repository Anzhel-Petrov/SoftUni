// function addressBook(array) {
//     let addressBook = {};

//     array.map(token => {
//         let [name, address] = token.split(':');
//         addressBook[name] = address;
//     });

//     let entries = Object.entries(addressBook);
//     entries.sort(([keyA], [keyB]) => keyA.localeCompare(keyB));

//     for (let [key, value] of entries) {
//         console.log(`${key} -> ${value}`);
//     }
// }

function addressBook(addressBookInput) {
    const addressBook = {};

    for (const addressAndName of addressBookInput) {
        const [name, address] = addressAndName.split(':');
        addressBook[name] = address;
    }

    const addressBookSorted = Object
        .entries(addressBook)
        .sort((a, b) => a[0].localeCompare(b[0]));

    addressBookSorted.forEach(([name, address]) => console.log(`${name} -> ${address}`))
}

// function addressBook(details) {
//     let addressInfo = {};

//     function sortObjectByKeys(obj) {
//         return Object.fromEntries(Object.entries(obj).sort(([keyA], [keyB]) => keyA.localeCompare(keyB)));
//     }

//     for (let data of details) {
//         let [name, address] = data.split(':');
//         addressInfo[name] = address;
//     }

//     let sortedInfo = sortObjectByKeys(addressInfo);

//     for (let [k, v] of Object.entries(sortedInfo)) {
//         console.log(`${k} -> ${v}`);
//     }
// }

addressBook(['Tim:Doe Crossing', 'Bill:Nelson Place', 'Peter:Carlyle Ave', 'Bill:Ornery Rd']);
addressBook(['Bob:Huxley Rd', 'John:Milwaukee Crossing', 'Peter:Fordem Ave',
    'Bob:Redwing Ave', 'George:Mesta Crossing', 'Ted:Gateway Way', 'Bill:Gateway Way',
    'John:Grover Rd', 'Peter:Huxley Rd', 'Jeff:Gateway Way', 'Jeff:Huxley Rd']);