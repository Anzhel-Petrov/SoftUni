function solve(input) {
    let numberOfGuildMemebers = Number(input.shift());
    let members = {};

    for (let i = 0; i < numberOfGuildMemebers; i++) {
        let [memberName, role, skills] = input.shift().split(" ");
        members[memberName] = { role, skills: skills ? skills.split(",") : [] };;
    }

    while (input[0] != 'End') {
        let line = input.shift();
        let [command, memberName, ...rest] = line.split(' / ');

        switch (command) {
            case 'Perform':
                let [role, performSkill] = rest;
                members[memberName].role == role && members[memberName]['skills'].includes(performSkill)
                    ? console.log(`${memberName} has successfully performed the skill: ${performSkill}!`)
                    : console.log(`${memberName} cannot perform the skill: ${performSkill}.`);
                break;
            case 'Learn Skill':
                let newSkill = rest.toString();
                members[memberName]['skills'].includes(newSkill)
                    ? console.log(`${memberName} already knows the skill: ${newSkill}.`)
                    : (members[memberName]['skills'].push(newSkill), console.log(`${memberName} has learned a new skill: ${newSkill}.`));
                break;
            case 'Reassign':
                let newRole = rest;
                members[memberName].role = newRole;
                console.log(`${memberName} has been reassigned to: ${newRole}`);
                break;
        }
    }

    for (let [memberName, roleAndSkills] of Object.entries(members)) {
        let skills = roleAndSkills['skills'].length > 0 ? roleAndSkills['skills'].sort() : "";
        console.log(`Guild Member: ${memberName}, Role: ${roleAndSkills.role}, Skills: ${skills.join(', ')}`);
    }
}

solve([
    "3",
    "Arthur warrior swordsmanship,shield",
    "Merlin mage fireball,teleport",
    "Gwen healer healing,alchemy",
    "Perform / Arthur / warrior / swordsmanship",
    "Perform / Merlin / warrior / fireball",
    "Learn Skill / Gwen / purification",
    "Perform / Gwen / healer / purification",
    "Reassign / Merlin / healer",
    "Perform / Merlin / healer / teleport",
    "End"]);

solve([
    "4",
    "Lancelot knight jousting,swordplay",
    "Morgana sorceress dark_magic,illusion",
    "Robin archer archery,stealth",
    "Galahad paladin healing,swordplay",
    "Perform / Robin / archer / archery",
    "Perform / Morgana / knight / illusion",
    "Learn Skill / Lancelot / swordplay",
    "Learn Skill / Robin / tracking",
    "Learn Skill / Robin / tracking",
    "Reassign / Galahad / warrior",
    "Perform / Galahad / warrior / healing",
    "Reassign / Galahad / healer",
    "Perform / Galahad / healer / healing",
    "End"]);