document.addEventListener('DOMContentLoaded', solve);

function solve() {
    // add individual event listener to reach button
    // each event listener does:
    // - rad associated input field
    // - convert values to secconds
    // - pass seconds to function which updates all fields

    document.getElementById('daysBtn').addEventListener('click', convertDays);
    document.getElementById('hoursBtn').addEventListener('click', convertHours);
    document.getElementById('minutesBtn').addEventListener('click', convertMinutes);
    document.getElementById('secondsBtn').addEventListener('click', convertSeconds);

    function convertDays(e) {
        e.preventDefault();
        let days = Number(document.getElementById('days-input').value);
        updateFields(days * 86400);
    }

    function convertHours(e) {
        e.preventDefault();
        let hours = Number(document.getElementById('hours-input').value);
        updateFields(hours * 3600);
    }

    function convertMinutes(e) {
        e.preventDefault();
        let minutes = Number(document.getElementById('minutes-input').value);
        updateFields(minutes * 60);
    }

    function convertSeconds(e) {
        e.preventDefault();
        let seconds = Number(document.getElementById('seconds-input').value);
        updateFields(seconds);
    }

    function updateFields(seconds) {
        // console.log('days', seconds / 86400);
        // console.log('hours', seconds / 3600);
        // console.log('minutes', seconds / 60);
        // console.log('seconds', seconds);
        document.getElementById('days-input').value = (seconds / 86400).toFixed(2);
        document.getElementById('hours-input').value = (seconds / 3600).toFixed(2);
        document.getElementById('minutes-input').value = (seconds / 60).toFixed(2);
        document.getElementById('seconds-input').value = (seconds).toFixed(2);
    }
}

// function solve() {
//     let conversionRates = {
//         days: 86400,
//         hours: 3600,
//         minutes: 60,
//         seconds: 1
//     };

//     document.querySelectorAll('input[type="submit"]').forEach(button => {
//         button.addEventListener('click', convertTime);
//     });

//     function convertTime(e) {
//         e.preventDefault();
//         let unit = this.id.replace('Btn', '');
//         let field = document.querySelector(`#${unit}-input`);
//         let value = Number(field.value);

//         let seconds = value * conversionRates[unit];

//         for (let [unit, rate] of Object.entries(conversionRates)) {
//             document.querySelector(`#${unit}-input`).value = (seconds / rate).toFixed(2);
//         }
//     }
// }

// function solve() {
//     let ratios = { days: 1, hours: 24, minutes: 1440, seconds: 86400 };
//     let inputs = {
//         days: document.getElementById('days-input'),
//         hours: document.getElementById('hours-input'),
//         minutes: document.getElementById('minutes-input'),
//         seconds: document.getElementById('seconds-input')
//     };
 
//     for (let unit in ratios) {
//         document.getElementById(unit + 'Btn').addEventListener('click', (event) => {
//             event.preventDefault();
 
//             let value = Number(inputs[unit].value);
//             if (value < 1) {
//                 return;
//             }
 
//             let inDays = value / ratios[unit];
//             for (let u in ratios) {
//                 inputs[u].value = (inDays * ratios[u]).toFixed(2);
//             }
//         });
//     }
 
//     let clearBtn = document.createElement('input');
//     clearBtn.type = 'button';
//     clearBtn.value = 'Clear';
//     document.getElementsByTagName('main')[0].appendChild(clearBtn);
 
//     clearBtn.addEventListener('click', () => {
//         for (let input of Object.values(inputs)) {
//             input.value = '';
//         }
//     });
// }

// function solve() {
//     let daysBtn = document.getElementById('daysBtn');
//     let hoursBtn = document.getElementById('hoursBtn');
//     let minutesBtn = document.getElementById('minutesBtn');
//     let secondsBtn = document.getElementById('secondsBtn');
 
//     daysBtn.addEventListener('click', convertDays);
//     hoursBtn.addEventListener('click', convertHours);
//     minutesBtn.addEventListener('click', convertMinutes);
//     secondsBtn.addEventListener('click', convertSeconds);
 
 
//     function convertDays(event) {
//         event.preventDefault();
 
//         let days = event.target.parentElement.children[1].value;
//         let hours = days * 24;
//         let minutes = days * 1440;
 
//         let seconds = days * 86400;
 
//         let inputHours = hoursBtn.parentElement.children[1];
//         let inputMinutes = minutesBtn.parentElement.children[1];
//         let inputSeconds = secondsBtn.parentElement.children[1];
 
//         inputHours.value = Number(hours).toFixed(2);
//         inputMinutes.value = Number(minutes).toFixed(2);
//         inputSeconds.value = Number(seconds).toFixed(2);
//     }
 
//     function convertHours(event) {
//         event.preventDefault();
 
//         let hours = event.target.parentElement.children[1].value;
 
//         let days = hours * 0.0416666667;
//         let minutes = hours * 60;
//         let seconds = hours * 3600;
 
//         let inputDays = daysBtn.parentElement.children[1];
//         let inputMinutes = minutesBtn.parentElement.children[1];
//         let inputSeconds = secondsBtn.parentElement.children[1];
 
//         inputDays.value = Number(days).toFixed(2);
//         inputMinutes.value = Number(minutes).toFixed(2);
//         inputSeconds.value = Number(seconds).toFixed(2);
//     }
 
//     function convertMinutes(event) {
//         event.preventDefault();
 
//         let minutes = event.target.parentElement.children[1].value;
 
//         let days = minutes * 0.000694444444;
//         let hours = minutes * 0.0166666667;
//         let seconds = minutes * 60;
 
//         let inputDays = daysBtn.parentElement.children[1];
//         let inputHours = hoursBtn.parentElement.children[1];
//         let inputSeconds = secondsBtn.parentElement.children[1];
 
//         inputDays.value = Number(days).toFixed(2);
//         inputHours.value = Number(hours).toFixed(2);
//         inputSeconds.value = Number(seconds).toFixed(2);
//     }
 
//     function convertSeconds(event) {
//         event.preventDefault();
 
//         let seconds = event.target.parentElement.children[1].value;
 
//         let days = seconds * 1.15740741 * 0.00001;
//         let hours = seconds * 0.000277777778;
//         let minutes = seconds * 0.0166666667;
 
//         let inputDays = daysBtn.parentElement.children[1];
//         let inputHours = hoursBtn.parentElement.children[1];
//         let inputMinutes = minutesBtn.parentElement.children[1];
 
//         inputDays.value = Number(days).toFixed(2);
//         inputHours.value = Number(hours).toFixed(2);
//         inputMinutes.value = Number(minutes).toFixed(2);
//     }
// }

// function solve() {
//     let convertBtns = Array.from(document.querySelectorAll("input[type='submit']"));
 
//     for (let btn of convertBtns) {
//         btn.addEventListener('click', (e) => {
//             e.preventDefault();
//             convertUnits(e);
//          });
//     }
 
//     let days = document.getElementById('days-input');
//     let hours = document.getElementById('hours-input');
//     let minutes = document.getElementById('minutes-input');
//     let seconds = document.getElementById('seconds-input');
 
//     function convertUnits (event) {
//         let currentEventUnit = event.currentTarget.parentElement.id;
//         if(currentEventUnit === 'days') {
//             let value = Number(days.value);
//             hours.value = (value * 24).toFixed(2);
//             minutes.value = (value * 1440).toFixed(2);
//             seconds.value = (value * 86400).toFixed(2);
//         } else if (currentEventUnit === 'hours') {
//             let value = Number(hours.value);
//             days.value = (value / 24).toFixed(2);
//             minutes.value = (value * 60).toFixed(2);
//             seconds.value = (value * 3600).toFixed(2);
//         } else if (currentEventUnit === 'minutes') {
//             let value = Number(minutes.value);
//             days.value = (value / 1440).toFixed(2);
//             hours.value = (value / 60).toFixed(2);
//             seconds.value = (value * 60).toFixed(2);
//         } else if (currentEventUnit === 'seconds') {
//             let value = Number(seconds.value);
//             days.value = (value / 86400).toFixed(2);
//             hours.value = (value / 3600).toFixed(2);
//             minutes.value = (value / 60).toFixed(2);
//         }
//     }
// }

// function solve() {
 
//     const days = document.getElementById('days-input');
//     const hours = document.getElementById('hours-input');
//     const minutes = document.getElementById('minutes-input');
//     const seconds = document.getElementById('seconds-input');
//     const daysBtn = document.getElementById('daysBtn');
//     const hoursBtn = document.getElementById('hoursBtn');
//     const minutesBtn = document.getElementById('minutesBtn');
//     const secondsBtn = document.getElementById('secondsBtn');
 
 
//     daysBtn.addEventListener('click', (events) => {
//         events.preventDefault();
//         hours.value = days.value * 24;
//         minutes.value = days.value * 1440;
//         seconds.value = days.value * 86400;
//     });
 
//     hoursBtn.addEventListener('click', (events) => {
//         events.preventDefault();
//         days.value = (hours.value / 24).toFixed(2);
//         minutes.value = hours.value * 60;
//         seconds.value = hours.value * 3600;
//     }); 
 
//     minutesBtn.addEventListener('click', (events) => {
//         events.preventDefault();
//         days.value = (minutes.value / 1440).toFixed(2);
//         hours.value = minutes.value / 60;
//         seconds.value = minutes.value * 60;
//     }); 
 
//     secondsBtn.addEventListener('click', (events) => {
//         events.preventDefault();
//         days.value = (seconds.value / 86400).toFixed(2);
//         hours.value = seconds.value / 3600;
//         minutes.value = seconds.value / 60;
//     }); 
// }