function solve(input) {

    let numberOfFarmers = Number(input.shift());
    let farmers = {};

    for (let i = 0; i < numberOfFarmers; i++) {
        // for (let i = 0; i < numberOfFarmers; i++) {
        //     let [name, area, tasks] = input.shift().split(" ");
        //     farmers[name] = { area, tasks: tasks ? tasks.split(",") : [] };
        // }

        let token = input.shift(input[i]);
        //let farmer = input[i].substring(0, input[i].indexOf(' '));
        // let [farmerName, ...farmerSkills] = input[i].split(' ').map(word => {
        //     farmerSkills.split(',').map(w => farmers[farmerName].push(word));
        // });
        //let [farmerName, farmerSkills] = input[i].splice(0, input[i].indexOf(' '));
        let [farmerName, farmerArea, farmerSkills] = token.split(' ');
        // if (!farmers.hasOwnProperty(farmerName)) {
        //     farmers[farmerName] = { 'skills': [] };
        // }
        farmers[farmerName] = farmers[farmerName] || { farmerArea, farmerSkills: farmerSkills.split(',') };
        //farmers[farmerName] = { farmerArea, farmerSkills: farmerSkills.split(',') };
    }

    for (let inpt of input) {
        if (inpt === 'End')
            break;
        let [command, farmerName, ...rest] = inpt.split(' / ');
        switch (command) {
            case 'Execute':
                let [area, performTask] = rest;
                farmers[farmerName].farmerArea == area && farmers[farmerName]['farmerSkills'].includes(performTask)
                    ? console.log(`${farmerName} has executed the task: ${performTask}!`)
                    : console.log(`${farmerName} cannot execute the task: ${performTask}.`);
                break;
            case 'Learn Task':
                let newTask = rest.toString();
                farmers[farmerName]['farmerSkills'].includes(newTask)
                    ? console.log(`${farmerName} already knows how to perform ${newTask}.`)
                    : (farmers[farmerName]["farmerSkills"].push(newTask), console.log(`${farmerName} has learned a new task: ${newTask}.`));
                break;
            case 'Change Area':
                let newArea = rest;
                farmers[farmerName].farmerArea = newArea;
                console.log(`${farmerName} has changed their work area to: ${newArea}`);
                break;
        }
    }

    for (let [name, areaAndSkills] of Object.entries(farmers)) {
        let tasks = areaAndSkills['farmerSkills'].length > 0 ? areaAndSkills['farmerSkills'].sort() : "";
        console.log(`Farmer: ${name}, Area: ${areaAndSkills.farmerArea}, Tasks: ${tasks.join(', ')}`);
    }
}

solve([
    "3",
    "John garden watering,weeding",
    "Mary barn feeding,cleaning",
    "John space fucking,sucking",
    "Execute / John / garden / watering",
    "Execute / Mary / garden / feeding",
    "Learn Task / John / planting",
    "Execute / John / garden / planting",
    "Change Area / Mary / garden",
    "Execute / Mary / garden / cleaning",
    "End"
]
);