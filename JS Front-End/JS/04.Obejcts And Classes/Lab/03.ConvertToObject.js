function convertToObject(jsonString) {
    let person = JSON.parse(jsonString);
    Object
        .keys(person)
        .forEach(key => console.log(`${key}: ${person[key]}`))
}

// function convertToObject(jsonString) {
//     let object = JSON.parse(jsonString);
//     const data = Object.entries(object);

//     for (let [key, value] of data) {
//         console.log(`${key}: ${value}`);
//     }
// }

convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');
convertToObject('{"name": "Peter", "age": 35, "town": "Plovdiv"}');