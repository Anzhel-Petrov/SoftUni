function solve(input) {
    let numberOfChemicals = Number(input.shift());
    let chemicals = {};

    for (let i = 0; i < numberOfChemicals; i++) {
        let [chemicalName, amount] = input.shift().split(' # ');
        chemicals[chemicalName] = chemicals[chemicalName] || { amount: Number(amount) };
    }

    while (input[0] != 'End') {
        let line = input.shift();
        let [command, chemicalName, ...rest] = line.split(' # ');
        switch (command) {
            case 'Mix':
                let [chemicalName2, amount] = rest;
                if (chemicals.hasOwnProperty(chemicalName) && chemicals.hasOwnProperty(chemicalName2)
                    && chemicals[chemicalName].amount > amount && chemicals[chemicalName2].amount > amount) {
                    chemicals[chemicalName].amount -= amount;
                    chemicals[chemicalName2].amount -= amount;
                    console.log(`${chemicalName} and ${chemicalName2} have been mixed. ${amount} units of each were used.`);
                } else {
                    console.log(`Insufficient quantity of ${chemicalName}/${chemicalName2} to mix.`);
                }
                break;
            case 'Replenish':
                let replenishAmount = Number(rest);
                if (chemicals.hasOwnProperty(chemicalName)) {
                    if (chemicals[chemicalName].amount + replenishAmount >= 500) {
                        let added = 500 - chemicals[chemicalName].amount;
                        chemicals[chemicalName].amount = 500;
                        console.log(`${chemicalName} quantity increased by ${added} units, reaching maximum capacity of 500 units!`)
                    }
                    else {
                        chemicals[chemicalName].amount += replenishAmount;
                        console.log(`${chemicalName} quantity increased by ${replenishAmount} units!`);
                    }

                }
                else {
                    console.log(`The Chemical ${chemicalName} is not available in the lab.`);
                }
                break;
            case 'Add Formula':
                let formula = rest.toString();
                if (chemicals.hasOwnProperty(chemicalName)) {
                    chemicals[chemicalName].formula = formula;
                    console.log(`${chemicalName} has been assigned the formula ${formula}.`);
                }
                else {
                    console.log(`The Chemical ${chemicalName} is not available in the lab.`);
                }
                break;
        }
    }

    for (let [chemicalName, info] of Object.entries(chemicals)) {
        chemicals[chemicalName].formula ?
            console.log(`Chemical: ${chemicalName}, Quantity: ${chemicals[chemicalName].amount}, Formula: ${chemicals[chemicalName].formula}`)
            : console.log(`Chemical: ${chemicalName}, Quantity: ${chemicals[chemicalName].amount}`);
    }
}

// solve(['4',
//     'Water # 200',
//     'Salt # 100',
//     'Acid # 50',
//     'Base # 80',
//     'Mix # Water # Salt # 50',
//     'Replenish # Salt # 150',
//     'Add Formula # Acid # H2SO4',
//     'End']
// )

solve(['3',
    'Sodium # 300',
    'Chlorine # 100',
    'Hydrogen # 200',
    'Mix # Sodium # Chlorine # 200',
    'Replenish # Sodium # 250',
    'Add Formula # Sulfuric Acid # H2SO4',
    'Add Formula # Sodium # Na',
    'Mix # Hydrogen # Chlorine # 50',
    'End']
)