function login(input) {
    let username = input[0];
    let password = input[0].split('').reverse().join('');

    let tries = 4;

    for (let i = 1; i < input.length; i++) {
        tries--;
        if (input[i] != password) {
            if (tries == 0) {
                console.log(`User ${username} blocked!`)
                break;
            } else {
                console.log("Incorrect password. Try again.");
            }
        }
        else {
            console.log(`User ${username} logged in.`)
            break;
        }
    }
}

login(['Acer', 'login', 'go', 'let me in', 'recA']);
login(['momo', 'omom']);
login(['sunny', 'rainy', 'cloudy', 'sunny', 'not sunny']);