let myObj = { name: 'Peter', age: 21 };

console.log(myObj.occupation);

myObj.occupation = 'Teacher';

console.log(myObj);

delete myObj.hariColor;

console.log(myObj);

//Create an object
let person = { name: 'Pesho', age: 20 };

//Get property value
    /*1*/console.log(person.name);
    /*2*/console.log(person['age']);

//Add property to an empty object
let animal = {};
animal.name = 'sharo';
animal['age'] = 7;
animal['weigth'] = 50;

console.log(animal);

//Delete property
delete animal.weigth;
console.log(animal)

//Iterate through KVP of an object
Object.keys(animal).forEach(key => console.log(`${key}: ${animal[key]}`))

//Convert from JS object to JSON
const json = JSON.stringify(animal);
console.log(animal);

//Convert from JSON object to JS object
const json2 = '{ "name": "Gosho", "age": 20 }';
const object = JSON.parse(json2);
console.log(object);