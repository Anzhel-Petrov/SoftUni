function func1() {
    console.log('it works');
}

function func2() {
    console.log('it also works');
}

func1();
func2();

let counter = 1;

function myFunc3() {
    counter++;
    return 5 + counter;
}

console.log(myFunc3());