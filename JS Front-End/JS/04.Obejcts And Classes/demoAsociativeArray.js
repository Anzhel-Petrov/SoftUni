let phoneBook = {};

phoneBook['John Smith'] = '+1-555-7988';
phoneBook['Anne Frank'] = '+1-555-479';
phoneBook['Peter Parker'] = '+1-555-3245';

console.log(phoneBook);
console.log(phoneBook['Anne Frank']);

let entries = Object.entries(phoneBook);

console.log(entries);