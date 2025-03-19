// function collectList() {
//     //document.querySelectorAll('li').forEach(li => console.log(li.textContent));
//     //Array.from(document.querySelectorAll('li')).map(li => console.log(li.textContent));
//     //[...document.querySelectorAll('li')].map(li => console.log(li.textContent));
//     //document.querySelectorAll('li').forEach(li => document.querySelector('textarea').textContent = li.textContent);

//     let result = [];
//     document.querySelectorAll('li').forEach(li => result.push(li.textContent));
//     let output = document.getElementById('extract');
//     output.value = result.join('\n');
// }

function collectList() {
    let list = document.getElementById('items');
    let items = list.children;
    let result = [];

    for (let li of items) {
        result.push(li.textContent);
    }

    let output = document.getElementById('result');
    output.value = result.join('\n');
}

// function collectList() {
//     const itemsElement = document.getElementById('items');
//     const textAreaElement = document.getElementById('extract');

//     textAreaElement.value = itemsElement.textContent;
// }