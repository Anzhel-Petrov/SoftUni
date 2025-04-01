function addItem() {
    let input = document.getElementById('newItemText');
    let text = input.value;

    if (!text) {
        return;
    }

    let newLi = document.createElement('li');
    newLi.textContent = text;

    let anchor = document.createElement('a');
    anchor.setAttribute('href', '#');
    //anchor.href = '#';
    anchor.textContent = "[Delete]";
    newLi.appendChild(anchor);
    anchor.addEventListener('click', removeElement);

    let list = document.getElementById('items');
    list.appendChild(newLi);

    input.value = '';

    function removeElement(e) {
        //e.currentTarget.parentNode.remove();
        let element = e.target;
        let parent = element.parentElement;
        parent.remove();

        //Or since we have access to the newLi referene we can do this
        //newLi.remove();
    }
}


// function addItem() {
//     let listElement = document.getElementById('items');
//     let newElementInputField = document.getElementById('newItemText');

//     let addedElement = document.createElement('li');
//     addedElement.textContent = newElementInputField.value;

//     let deleteElement = document.createElement('a');
//     deleteElement.textContent = '[Delete]';
//     deleteElement.href = '#'

//     addedElement.appendChild(deleteElement);
//     listElement.appendChild(addedElement);


//     deleteElement.addEventListener('click', deleteItem);

//     newElementInputField.value = '';

//     function deleteItem(event) {
//         event.currentTarget.parentNode.remove();
//     }
// }

// function addItem() {
//     let itemsElement = document.getElementById('items');
//     let newItemTextElement = document.getElementById('newItemText');

//     let liElement = document.createElement('li');
//     liElement.textContent = newItemTextElement.value;

//     let deleteButton = document.createElement('a');
//     deleteButton.textContent = '[Delete]';
//     deleteButton.setAttribute('href', '#');
//     deleteButton.addEventListener('click', (e) => {
//         e.currentTarget.parentElement.remove();
//     });

//     liElement.appendChild(deleteButton);
//     itemsElement.appendChild(liElement);
// }