function solve() {
  //let input = document.getElementById('input').value;
  //let sentences = input.split('.').filter(s => s.trim() !== '');
  let input = document.getElementById('input').value.trim().split('.').filter(Boolean);
  let output = document.getElementById('output');

  if (input.length === 0)
    return;
  console.log(input.length);
  while (input.length > 3) {
    output.innerHTML += `<p>${input.splice(0, 3).map(s => s.trim() + '.').join(' ')}</p>`
  }
  output.innerHTML += `<p>${input.map(s => s.trim() + '.').join(' ')}</p>`
}

//100/100
// function solve() {
//   let text = document.getElementById('input').value;
//   let sentences = text.split('.').filter(s=>s.trim() !== '');
//   let result = [];

//   for (let i = 0; i < sentences.length; i += 3) {
//    let paragraphSentences = sentences.slice(i, i + 3).map(s=>s.trim() + '.').join(' ');
//    let paragraph = `<p>${paragraphSentences}</p>`;
//    result.push(paragraph);
//   }

//   document.getElementById('output').innerHTML = result.join('\n');
// }

// function solve() {
//   let text = document.getElementById('input').value;
//   let outputElement = document.getElementById('output');

//   let peroidsCount = 0;
//   let tempText = '';

//   for (let i = 0; i < text.length; i++) {
//     tempText += text[i];

//     if(text[i] === '.') {
//       peroidsCount++;
//     }
    
//     if(peroidsCount === 3 || i === text.length - 1) {

//       let paragraph = document.createElement('p');
//       paragraph.textContent = tempText;
//       outputElement.appendChild(paragraph);

//       peroidsCount = 0;
//       tempText = '';
//     }
//   }
// }

// 80/100
// function solve() {
//   let inputField = document.getElementById('input').value;
//   let outputField = document.getElementById('output');
//   let result = [];
//   let tempSentence = '';
//   let dotCoutner = 0;

//   for (i=0; i < inputField.length; i++){
//     w = inputField[i]
//     if (inputField[i] === '.') {
//       tempSentence += w;
//       dotCoutner += 1;
//     }
  
//     if (dotCoutner === 3) {
//       result.push(tempSentence);
//       dotCoutner = 0;
//       tempSentence = '';
//       continue;
//     }

//     if (w != '.'){
//     tempSentence += w;
//     }
//     if (i === inputField.length - 1) {
//       result.push(tempSentence);
//     }
//   }

//   for (let text of result) {
//     let p = document.createElement('p');
//     p.textContent = text;
//     outputField.appendChild(p);
//   }
  
//   // console.log(result)
// }

// 100/100
// function solve() {
//   const input = document.getElementById('input').value;
//   const output = document.getElementById('output');
//   output.innerHTML = '';

//   const sentences = input.split('.').filter(s => s.trim() !== '').map(s => s.trim() + '.');
//   let paragraph = [];

//   for (let i = 0; i < sentences.length; i++) {
//     paragraph.push(sentences[i]);

//     if (paragraph.length === 3 || i === sentences.length - 1) {
//       const p = document.createElement('p');
//       p.textContent = paragraph.join(' ');
//       output.appendChild(p);
//       paragraph = [];
//     }
//   }
// }