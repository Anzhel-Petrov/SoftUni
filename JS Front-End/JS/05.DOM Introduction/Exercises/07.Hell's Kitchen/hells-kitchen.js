function solve() {
    let input = JSON.parse(document.querySelector('#inputs textarea').value);
    let restaurants = { 'employees': [], 'salaries': [] };

    input.map(entry => {
        let [restaurantName, employees] = entry.split(' - ');

        if (!restaurants.hasOwnProperty(restaurantName)) {
            restaurants[restaurantName] = { 'employees': [], 'salaries': [] };
        }

        employees.split(', ').map(entry => {
            let [employeeName, salary] = entry.split(' ');
            restaurants[restaurantName]['employees'].push(employeeName);
            restaurants[restaurantName]['salaries'].push(Number(salary));
        });

        let sum = 0;
        restaurants[restaurantName]['salaries'].map(s => sum += s);
        let averageSalary = sum / restaurants[restaurantName]['salaries'].length;

        console.log(sum);
        console.log(averageSalary);
    });

    console.log(restaurants);

}

// function solve() {
//     let data = document.querySelector('#inputs textarea').value;
//     let dataArr = JSON.parse(data);
//     let restaurantMap = new Map();
 
//     for (let element of dataArr) {
//         let [restaurant, workers] = element.split(' - ');
 
//         if (!restaurantMap.has(restaurant)) {
//             restaurantMap.set(restaurant, []);
//         }
 
//         let workerArr = workers.split(', ');
 
//         for (let worker of workerArr) {
//             let [name, wage] = worker.split(' ');
//             restaurantMap.get(restaurant).push({ name, wage: Number(wage) });
//         }
//     }
 
//     let bestRestaurantEntry = [...restaurantMap.entries()]
//         .map(([name, workers]) => {
//             let avgSalary = workers.reduce((acc, curr) => acc + curr.wage, 0) / workers.length;
//             let bestSalary = Math.max(...workers.map(w => w.wage));
//             return { name, avgSalary, bestSalary, workers };
//         })
//         .sort((a, b) => b.avgSalary - a.avgSalary)[0];
 
//     bestRestaurantEntry.workers.sort((a, b) => b.wage - a.wage);
 
//     document.querySelector('#bestRestaurant p').textContent =
//         `Name: ${bestRestaurantEntry.name} Average Salary: ${bestRestaurantEntry.avgSalary.toFixed(2)} Best Salary: ${bestRestaurantEntry.bestSalary.toFixed(2)}`;
 
//     document.querySelector('#workers p').textContent =
//         bestRestaurantEntry.workers.map(w => `Name: ${w.name} With Salary: ${w.wage}`).join(' ');
// }

// function solve() {
//     let textArea = document.querySelector('#inputs textarea').value;
//     let bestRestaurantP = document.querySelector('#bestRestaurant p');
//     let bestRestaurantWorkers = document.querySelector('#workers p');
 
//     textArea = JSON.parse(textArea);
//     let object = {};
//     let highestAverageSalary = Number.MIN_VALUE;
 
//     let bestRestaurant = '';
//     let bestRestaurantName = '';
//     let bestSalary = 0;
 
//     if (!textArea) {
//         return;
//     }
 
//     for (let text of textArea) {
//         let [name, employees] = text.split(' - ');
 
//         let splittedEmployees = employees.split(', ');
 
//         if (!(name in object)) {
//             object[name] = {'employees': [], 'salaries': []};
//         }
 
//         for (let employee of splittedEmployees) {
//             let [employeeName, salary] = employee.split(' ');
 
//             object[name]['employees'].push(employeeName);
//             object[name]['salaries'].push(Number(salary));
 
//         }
 
//         let sum = 0;
 
//         for (let i = 0; i < object[name]['salaries'].length; i++) {
//             sum += Number(object[name]['salaries'][i]);
//         }
 
//         let averageSalary = sum / object[name]['salaries'].length;
 
//         if (averageSalary > highestAverageSalary) {
//             highestAverageSalary = averageSalary;
//             bestRestaurant = object[name];
//             bestRestaurantName = name;
 
//             bestSalary = Math.max(...object[name]['salaries'])
//         }
//     }
 
//     let employeesWithSalaries = bestRestaurant['employees'].map((employee, index) => {
//         return { name: employee, salary: bestRestaurant['salaries'][index] };
//     });
 
//     employeesWithSalaries.sort((a, b) => b.salary - a.salary);
//     let helpArr = [];
//     bestRestaurantP.textContent = `Name: ${bestRestaurantName} Average Salary: ${highestAverageSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;
 
//     for (let i = 0; i < employeesWithSalaries.length; i++) {
//         helpArr.push(`Name: ${employeesWithSalaries[i].name} With Salary: ${employeesWithSalaries[i].salary}`);
//     }
 
//     bestRestaurantWorkers.textContent = helpArr.join(' ');
// }

// function solve() {
//     document.querySelector('#btnSend').addEventListener('click', () => {
//         let inputArray = JSON.parse(document.querySelector('textarea').value);
//         let restaurants = {};
    
//         inputArray.forEach(info => {
//           const [restaurant, workers] = info.split(' - ');
//           restaurants[restaurant] = restaurants[restaurant] || [];
//           workers.split(', ').forEach(worker => {
//             const [name, wage] = worker.split(' ');
//             restaurants[restaurant].push([name, Number(wage)]);
//           });
//         });
    
//         const getAverageWage = staff => staff.reduce((sum, [, wage]) => sum + wage, 0) / staff.length;
//         const bestRestaurant = Object.entries(restaurants)
//           .map(([name, staff]) => [name, staff, getAverageWage(staff)])
//           .sort(([, , avgA], [, , avgB]) => avgB - avgA)[0];
    
//         const [bestName, bestStaff, bestAvgWage] = bestRestaurant;
//         bestStaff.sort(([, wageA], [, wageB]) => wageB - wageA);
    
//         document.querySelector('#bestRestaurant p').textContent =
//           `Name: ${bestName} Average Salary: ${bestAvgWage.toFixed(2)} Best Salary: ${bestStaff[0][1].toFixed(2)}`;
//         document.querySelector('#workers p').textContent =
//           bestStaff.map(([name, wage]) => `Name: ${name} With Salary: ${wage}`).join(' ');
//       });
// }