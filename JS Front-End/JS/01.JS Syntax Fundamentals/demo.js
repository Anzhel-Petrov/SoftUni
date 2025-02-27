// console.log('Hello World!');

// let a = 5;
// let b = 5;
// let c = a + b;
// let d = add(a,b);


// // console.log(c);
// function add(x, y) {
//     return x +y;
// }

// console.log(d);


// function solve(name) {
//     console.log(name);
// }

// solve('Peter');



// function greeting(name){
//     let greeting = `Hello, ${name}!`
//     console.log(greeting);
// }

// let myName = 'Peter';

// greeting(myName);



// function isExcellentGrade(grade) {
//     if(grade >= 5.50)
//     {
//         console.log(`Excellent`);}
//     else {
//         console.log(`Not excellent`);
//     }
// }

// isExcellentGrade(5.50);
// isExcellentGrade(5.49);
// isExcellentGrade(4.49);
// isExcellentGrade(6.00);


// function age(age){
//     if(age < 0)
//     {
//         console.log('out of bounds');
//     }
//     else if(age <= 2){
//         console.log('baby');
//     }
//     else if(age <= 13){
//         console.log('child');
//     }
//     else if(age <= 19){
//         console.log('teenager');
//     }
//     else if(age <= 65){
//         console.log('adult');
//     }
//     else {
//         console.log('elder');
//     }
// }

// age(20);
// age(1);
// age(100);
// age(7);
// age(44);
// age(-1);


function vacationPrice(numberOfPeople, groupType, dayOfWeek) {
    let totalPrice = 0;
    switch (groupType){
        case 'Students':

            if(dayOfWeek == 'Friday') {
                totalPrice = numberOfPeople * 8.45;
            }
            else if(dayOfWeek == 'Saturday') {
                totalPrice = numberOfPeople * 9.80;
            }
            else if(dayOfWeek == 'Sunday') {
                totalPrice = numberOfPeople * 10.46;
            }

            if(numberOfPeople >= 30){
                totalPrice = totalPrice * 0.85;
            }
            break;
        case 'Business':
            if(numberOfPeople >= 100) {
                numberOfPeople -= 10;
            }

            if(dayOfWeek == 'Friday') {
                totalPrice = numberOfPeople * 10.90;
            }
            else if(dayOfWeek == 'Saturday') {
                totalPrice = numberOfPeople * 15.60;
            }
            else if(dayOfWeek == 'Sunday') {
                totalPrice = numberOfPeople * 16;
            }
            break;
        case 'Regular':
            if(dayOfWeek == 'Friday') {
                totalPrice = numberOfPeople * 15;
            }
            else if(dayOfWeek == 'Saturday') {
                totalPrice = numberOfPeople * 20;
            }
            else if(dayOfWeek == 'Sunday') {
                totalPrice = numberOfPeople * 22.50;
            }

            if(numberOfPeople >= 10 && numberOfPeople <= 20){
                totalPrice = totalPrice * 0.95;
            }
            break;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`)
}

vacationPrice(30,'Students', 'Sunday');
vacationPrice(40,'Regular','Saturday');
vacationPrice(100,'Business','Saturday');

let a = 11;
let b = '11';
if(a == b) {
    console.log("Yes");
}
else {
    console.log("No");
}