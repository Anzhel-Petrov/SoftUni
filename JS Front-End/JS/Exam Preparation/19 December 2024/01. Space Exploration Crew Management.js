function solve(input) {
    let iterations = Number(input.shift());
    let astronauts = {};

    // for (let i = 0; i < iterations; i++) {
    //     let [name, area, skills] = input.shift().split(' ');
    //     astronauts[name] = { area, skills: skills ? skills.split(',') : [] };
    // }
    for (let i = 0; i < iterations; i++) {
        let token = input.shift();
        let [name, area, ...skills] = token.split(' ');
        //astronauts[name] = astronauts[name] || { area, skills: skills.split(',') };
        if (!astronauts.hasOwnProperty(name)) {
            astronauts[name] = { area, skills: skills.join(' ').split(',') }
        }
    }

    for (let inpt of input) {
        if (inpt === 'End')
            break;
        let [command, name, ...rest] = inpt.split(' / ');
        switch (command) {
            case 'Perform':
                let [area, performTask] = rest;
                astronauts[name].area == area && astronauts[name]['skills'].includes(performTask)
                    ? console.log(`${name} has successfully performed the skill: ${performTask}!`)
                    : console.log(`${name} cannot perform the skill: ${performTask}.`);
                break;
            case 'Learn Skill':
                let newTask = rest.toString();
                astronauts[name]['skills'].includes(newTask)
                    ? console.log(`${name} already knows the skill: ${newTask}.`)
                    : (astronauts[name]["skills"].push(newTask), console.log(`${name} has learned a new skill: ${newTask}.`));
                break;
            case 'Transfer':
                let newArea = rest;
                astronauts[name].area = newArea;
                console.log(`${name} has been transferred to: ${newArea}`);
                break;
        }
    }

    for (let [name, info] of Object.entries(astronauts)) {
        let tasks = info['skills'].length > 0 ? info['skills'].sort().join(', ') : "";
        console.log(`Astronaut: ${name}, Section: ${info.area}, Skills: ${tasks}`);
    }
}

solve([
    "2",
    "Alice command_module piloting,communications",
    "Bob engineering_bay repair,maintenance",
    "Perform / Alice / command_module / piloting",
    "Perform / Bob / command_module / repair",
    "Learn Skill / Alice / navigation",
    "Perform / Alice / command_module / navigation",
    "Transfer / Bob / command_module",
    "Perform / Bob / command_module / maintenance",
    "End"
]
);

solve([
    "3",
    "Tom engineering_bay construction,maintenance",
    "Sara research_lab analysis,sampling",
    "Chris command_module piloting,communications",
    "Perform / Tom / engineering_bay / construction",
    "Learn Skill / Sara / robotics",
    "Perform / Sara / research_lab / robotics",
    "Transfer / Chris / research_lab",
    "Perform / Chris / research_lab / piloting",
    "Learn Skill / Tom / diagnostics",
    "Perform / Tom / engineering_bay / diagnostics",
    "End"
]
);