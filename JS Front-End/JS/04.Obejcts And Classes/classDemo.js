class Student {
    constructor(name) {
        this.name = name;
    }
}

class Person {
    firstName;
    lastName;
    age;

    constructor(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }
}

//let myPerson = new Person();
let myPerson = new Person('Peter', 'Johnson', 32)
console.log(myPerson);

// myPerson.firstName = 'Peter';
// myPerson.lastName = 'Johnson';
// myPerson.age = 32;

console.log(myPerson);
