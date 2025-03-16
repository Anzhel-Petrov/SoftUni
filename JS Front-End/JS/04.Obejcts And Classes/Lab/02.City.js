// function printCity(city) {
//     const data = Object.entries(city);

//     for (let [key, value] of data) {
//         console.log(key, `->`, value);
//     }
// }

function printCity(city) {
    Object
        .keys(city)
        .forEach(key => console.log(`${key} -> ${city[key]}`))
}

printCity({ name: "Sofia", area: 492, population: 1238438, country: "Bulgaria", postCode: "1000" });
printCity({ name: "Plovdiv", area: 389, population: 1162358, country: "Bulgaria", postCode: "4000" });