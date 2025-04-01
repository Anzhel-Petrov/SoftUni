document.addEventListener('DOMContentLoaded', solve);

function solve() {
    //TODO
}

// function solve() {
//     let btn = document.getElementById('convert');
 
//     let inputDistance = document.getElementById('inputDistance');
//     let select = document.getElementById('inputUnits');
//     let outputUnit = document.getElementById('outputUnits');
//     btn.addEventListener('click', handleButtonClick);
//     let outputDistance = document.getElementById('outputDistance');
 
//     function handleButtonClick() {
//         let inputEnteredDistance = inputDistance.value;
//         let selectedInputUnit = select.value;
//         let selectedOutputUnit = outputUnit.value;
//         let toMeters = 0;
 
//         let metersObj = {
//             'km': 0.001,
//             'cm': 100,
//             'mm': 1000,
//             'm': 1,
//             'mi': 0.0006213712,
//             'yrd': 1.0936132983,
//             'ft': 3.280839895,
//             'in': 39.3700787402,
//         }
 
//         function calculateMeters(toMeters, metersObj, selectedOutputUnit) {
//             toMeters *= metersObj[selectedOutputUnit];
//             return toMeters;
//         }
 
//         function returnMeters(outputDistance, toMeters, metersObj, selectedOutputUnit) {
//             outputDistance.value = calculateMeters(toMeters, metersObj, selectedOutputUnit);
//         }
 
//         if (selectedInputUnit == 'km') {
//             toMeters = inputEnteredDistance * 1000;
//             returnMeters(outputDistance, toMeters, metersObj, selectedOutputUnit)
//         } else if (selectedInputUnit == 'cm') {
//             toMeters = inputEnteredDistance * 0.01;
//             returnMeters(outputDistance, toMeters, metersObj, selectedOutputUnit)
//         } else if (selectedInputUnit == 'm') {
//             toMeters = inputEnteredDistance;
//             returnMeters(outputDistance, toMeters, metersObj, selectedOutputUnit)
//         } else if (selectedInputUnit == 'mm') {
//             toMeters = inputEnteredDistance * 0.001;
//             returnMeters(outputDistance, toMeters, metersObj, selectedOutputUnit)
//         } else if (selectedInputUnit == 'mi') {
//             toMeters = inputEnteredDistance * 1609.34;
//             returnMeters(outputDistance, toMeters, metersObj, selectedOutputUnit)
//         } else if (selectedInputUnit == 'yrd') {
//             toMeters = inputEnteredDistance * 0.9144;
//             returnMeters(outputDistance, toMeters, metersObj, selectedOutputUnit)
//         } else if (selectedInputUnit == 'ft') {
//             toMeters = inputEnteredDistance * 0.3048;
//             returnMeters(outputDistance, toMeters, metersObj, selectedOutputUnit)
//         } else if (selectedInputUnit == 'in') {
//             toMeters = inputEnteredDistance * 0.0254;
//             returnMeters(outputDistance, toMeters, metersObj, selectedOutputUnit)
//         }
//     }
// }

// function solve() {
//     document.getElementById('convert').addEventListener('click', convert);
 
//     let conversionMap = {
//         'km': n => n * 1000,
//         'm': n => n * 1,
//         'cm': n => n * 0.01,
//         'mm': n => n * 0.001,
//         'mi': n => n * 1609.34,
//         'yrd': n => n * 0.9144,
//         'ft': n => n * 0.3048,
//         'in': n => n * 0.0254,
//     }
 
//     function convert(e) {
//         e.preventDefault();
 
//         let inputDistance = Number(document.getElementById('inputDistance').value);
//         let outputDistance = document.getElementById('outputDistance');
 
//         let inputFrom = document.getElementById('inputUnits').value;
//         let outputTo = document.getElementById('outputUnits').value;
 
//         outputDistance.value = conversionMap[inputFrom](inputDistance) / conversionMap[outputTo](1);
//     }
// }

