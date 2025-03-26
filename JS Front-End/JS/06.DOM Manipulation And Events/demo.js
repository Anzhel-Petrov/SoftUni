//1. DOM MANIPULATION
let orderedListElement = document.getElementById('some-list-item');

//create element
let element = document.createElement('p'); //an html tag name as argument

//add element 
//by .appendChild()
element.appendChild(orderedListElement); //to the end of the list of children of the parent node

let existingElement = document.getElementById('some-existing-element');
orderedListElement.appendChild(existingElement); //the element is now moved in the end, not duplicated

//by .prepend()
orderedListElement.prepend(element); //in the beginning of the list of children of the parent node

//remove element
//by .removeChild()
let parentElement = document.getElementById('some-parent-element');
let childElement = document.getElementById('some-child-element');
parentElement.removeChild(childElement);
//Findinge the parent element of the childElement
let parent = childElement.parentElement;
parent.removeChild(childElement);
//If the specified node is not a child of the parent node, an error will be thrown. It's a good practice to check if the node is actually a child of the specified parent node before attempting to remove it.
//You can also use the .remove() method directly on the child element without needing to specify its parent. This method is simpler and more straightforward if you don't need a reference to the parent node:
childElement.remove();

//clone element
let cloneElement = element.cloneNode(); //shallow copy
let shallowCopy = element.cloneNode(false) //shallow copy
let deepCopy = element.cloneNode(true) //deep copy
//if method is called with no parameter, the default behaviour is for shallow copy
//A shallow clone copies the node without any of its children. It's like duplicating only the outer layer of an element.
//A deep clone copies the node and all its descendants, effectively duplicating the entire subtree.

//add class name
//by .className property
element.className = 'some-class-name' //if the element already has some classes,the method will completely overwrite the existing class list with the new value: 'some-class-name'

//by classList property
element.classList.add('some-class-name') //if the element already has some classes,the method will add the class name, without affecting the existing class names

//2. EVENTS

//Adding Event Listeners
const someFunction = () => {
    console.log('Hello, World!');
}

element.addEventListener('click', someFunction); //You can listen for events on elements by using the addEventListener() method, which allows you to specify the event to listen for and the callback function to execute when the event occurs.

element.removeEventListener('click', someFunction); //Similarly, you can remove event listeners by using the removeEventListener() method, specifying the same event and callback function used in addEventListener().

//mouse events
//keyboard events
//touch events
//focus events
//DOM/UI events
//form events