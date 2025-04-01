document.addEventListener('DOMContentLoaded', solve);

function solve() {
    let button = document.querySelector('input[type="submit"]');
    let selectElement = document.getElementById('menu');
    let selectOption = document.getElementById('newItemText');
    let selectValue = document.getElementById('newItemValue');
       
    button.addEventListener('click', addContent);

    function addContent(e) {
        e.preventDefault();
        let newOption = document.createElement('option');
        //newOption.setAttribute('value', selectValue);
        newOption.value = selectValue.value;
        newOption.textContent = selectOption.value;
        selectElement.appendChild(newOption);

        selectOption.value = '';
        selectValue.value = '';
    }
}

// function solve() {
//     let newItemText = document.getElementById('newItemText');
//     let newItemValue = document.getElementById('newItemValue');
//     let select = document.getElementById('menu');    
//     let button = document.querySelector("[type='submit']");
 
//     button.addEventListener('click', handleButtonClick);
 
//     function handleButtonClick(event) {
//         event.preventDefault();
//         let newOption = document.createElement('option');
//         newOption.textContent = newItemText.value;
//         newOption.value = newItemValue.value;
 
//         select.appendChild(newOption);
 
//         newItemText.value = '';
//         newItemValue.value = '';
//     }
// }

// function solve() {
//     let selectMenu = document.getElementById('menu');
//     let addBtn = document.querySelector('form input[type="submit"]');
//     addBtn.addEventListener('click', function (e) {
//         e.preventDefault();
//         addOption();
//     });
 
//     function addOption() {
//         let currentValue = document.getElementById('newItemValue').value;
//         let currentText =  document.getElementById('newItemText').value;
 
//         let newOption = document.createElement('option');
//         newOption.value = currentValue;
//         newOption.textContent = currentText;
//         selectMenu.appendChild(newOption);
 
//         document.getElementById('newItemValue').value = '';
//         document.getElementById('newItemText').value = '';
//     }
// }

// function solve() {
//     let dropdown = document.getElementById('menu');
//     document.querySelector('input[type="submit"]').addEventListener('click', addOption);
 
//     function addOption(e) {
//         e.preventDefault();
//         let text = document.getElementById('newItemText');
//         let value = document.getElementById('newItemValue');
 
//         let option = document.createElement('option');
//         option.textContent = text.value;
//         option.value = value.value;
 
//         dropdown.appendChild(option);
 
//         text.value = '';
//         value.value = '';
//     }
// }