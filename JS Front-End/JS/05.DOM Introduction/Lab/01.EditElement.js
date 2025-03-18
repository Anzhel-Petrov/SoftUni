function editElement(elementReference, match, replacer) {
    elementReference.textContent = elementReference.textContent.replaceAll(match, replacer);
}

// function editElement(element, match, replacer) {
//     while(element.textContent.includes(match)) {
//         element.textContent = element.textContent.replace(match, replacer);
//     }
// }

// function editElement(ref, match, replacer) {
//     const content = ref.textContent;
//     const matcher = new RegExp(match, 'g');
//     const edited = content.replace(matcher, replacer);
//     ref.textContent = edited;
// }