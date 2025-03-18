function employees(names) {
    const employees = {};

    for (let name of names) {
        employees[name] = name.length;
    }

    Object
        .keys(employees)
        .forEach(key => console.log(`Name: ${key} -- Personal Number: ${employees[key]}`));

    // for (const [key, value] of Object.entries(employees)) {
    //     console.log(`Name: ${key} -- Personal Number: ${value}`)
    // }
}

// function printEmployeesInfo(employeeNames) {
//     employeeNames.forEach(name => {
//         const employee = {
//             name,
//             personalNumber: name.length,
//         };

//         console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`);
//     });
// }

// function employees(arr){
//     class Emp {
//         name;
//         lengthOfName;

//         constructor(name, lengthOfName) {
//             this.name = name;
//             this.lengthOfName = lengthOfName;
//         }
//     }

//     let employeesStorage = [];

//     for (let employee of arr){
//         let name = employee;
//         let length = name.length;

//         employeesStorage.push(new Emp(name, length));
//     }

//     for (let emp of employeesStorage) {
//         console.log(`Name: ${emp.name} -- Personal Number: ${emp.lengthOfName}`);
//     }
// }

// function employees (nameArr) {
//     class Employee {
//         constructor (name, personalNumber) {
//             this.name = name;
//             this.personalNumber = this.getPersonalNumber();
//         }

//         getPersonalNumber () {
//             return this.name.length;
//         }
//     }


//     for (let el of nameArr) {
//         let currEmployee = new Employee(el);
//         console.log(`Name: ${currEmployee.name} -- Personal Number: ${currEmployee.personalNumber}`)
//     }

// }

employees(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal']);
employees(['Samuel Jackson', 'Will Smith', 'Bruce Willis', 'Tom Holland']);