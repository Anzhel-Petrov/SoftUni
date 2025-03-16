function meetings(meetings) {
    let meetingSchedule = {};

    meetings.map(meeting => {
        let [day, person] = meeting.split(' ');

        if (meetingSchedule.hasOwnProperty(day)) {
            console.log(`Conflict on ${day}!`);
        }
        else {
            console.log(`Scheduled for ${day}`);
            meetingSchedule[day] = person;
        }
    });

    for (const name in meetingSchedule) {
        console.log(`${name} -> ${meetingSchedule[name]}`)
    }
}

// function meetings(meetingsInput) {
//     const meetings = {};

//     for (const meet of meetingsInput) {
//         const [day, name] = meet.split(' ');

//         if (meetings[day]) {
//             console.log(`Conflict on ${day}!`);
//         } else {
//             meetings[day] = name;
//             console.log(`Scheduled for ${day}`);
//         }
//     }

//     for (const day in meetings) {
//         console.log(`${day} -> ${meetings[day]}`);
//     }
// }

meetings(['Monday Peter', 'Wednesday Bill', 'Monday Tim', 'Friday Tim']);
meetings(['Friday Bob', 'Saturday Ted', 'Monday Bill', 'Monday John', 'Wednesday George']);