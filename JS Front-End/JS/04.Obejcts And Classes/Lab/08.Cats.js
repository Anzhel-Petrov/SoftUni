function cats(catsArray) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    for (const cat of catsArray) {
        let [name, age] = cat.split(' ');
        let myCat = new Cat(name, Number(age));
        myCat.meow();
    }
}

// function cats(catsArray) {
//     class Cat {
//         constructor(name, age) {
//             this.name = name;
//             this.age = age;
//         }

//         meow() {
//             console.log(`${this.name}, age ${this.age} says Meow`);
//         }
//     }

//     function parseCatData(entries) {
//         let [name, age] = entries.split(' ');
//         return new Cat(name, Number(age));
//     }

//     let cats = catsArray.map(parseCatData);

//     for (let cat of cats) {
//         cat.meow();
//     }
// }

// function printCatInfo(catInfoInput) {
//     class Cat {
//         constructor(name, age) {
//             this.name = name;
//             this.age = age;
//         }

//         meow() {
//             console.log(`${this.name}, age ${this.age} says Meow`);
//         }
//     }

//     for(const info of catInfoInput) {
//         const [name, age] = info.split(' ');

//         const cat = new Cat(name, age);
//         cat.meow();
//     }
// }

// function catCreator(arr) {
//     class Cat{
//         constructor(name_, age) {
//             this.name = name_;
//             this.age = age;
//         }
//         meow(){
//             console.log(`${this.name}, age ${this.age} says Meow`);
//         }}

//     let catsInfo = {}

//     for (let catData of arr){
//         let [catName, catAge] = catData.split(' ');
//         catsInfo[catName] = catAge;
//     }

//     for (let [cat, age] of Object.entries(catsInfo)){
//         let cato = new Cat(cat, age);
//         cato.meow();
//     }
// }

cats(['Mellow 2', 'Tom 5']);