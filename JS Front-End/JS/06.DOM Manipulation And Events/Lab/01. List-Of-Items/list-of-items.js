function addItem() {
    let input = document.getElementById('newItemText');
    let text = input.value;

    if (!text) {
        return;
    }

    let newLi = document.createElement('li');
    newLi.textContent = text;

    let list = document.getElementById('items');
    list.appendChild(newLi);

    input.value = '';
}

// function additem() {
//     let text = document.getElementById('newItemText').value;
//     let li = document.createElement('li');
//     li.appendChild(document.createTextNode(text));
//     document.getElementById('items').appendChild(li);
//     document.getElementById('newItemText').value = '';
// }

// function addItem() {
//     let unorderedListElement = document.getElementById('items');
//     let newItemElement = document.getElementById('newItemText');
//     let newItemValue = newItemElement.value;

//     let newElement = document.createElement('li');
//     newElement.textContent = newItemValue;
//     unorderedListElement.appendChild(newElement);

//     newItemElement.value = '';
// }
