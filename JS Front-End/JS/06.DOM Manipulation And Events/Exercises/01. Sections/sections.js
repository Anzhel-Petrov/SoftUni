document.addEventListener('DOMContentLoaded', solve);

function solve() {
   // add event listener to submit button

   // prevent form submition
   //find input emelement and value
   //parse value to array
   //for every string in array:
   // - create div
   // - create paragraph
   // - set paragraph
   // - append to div and append fiv to output

   let submitBtn = document.querySelector('input[type="submit"]');
   submitBtn.addEventListener('click', addContent);

   function addContent(ev) {
      ev.preventDefault();
      console.log(ev);

      let input = document.querySelector('input[type="text"]').value
      .split(',')
      .map(i => i.trim());
      console.log(input);
      let contentDiv = document.getElementById('content');

      for (const entry of input) {
         let div = document.createElement('div');
         let paragraph = document.createElement('p');
         paragraph.textContent = entry;
         div.appendChild(paragraph);
         contentDiv.appendChild(div);
      }
   }
}

// function solve() {
//    let form = document.getElementById('task-input');
//    let contentDiv = document.getElementById('content');
//    //let button = document.querySelector('#task-input [type="submit"]');
//    let button = document.querySelector('input[type="submit"]');
//    let input = document.querySelector('#task-input [type="text"]').value
//       .split(',')
//       .map(i => i.trim());
//    form.addEventListener('sumbit', (event) => {
//       event.preventDefault();
//    });
//    button.onclick = (event) => {showParagraphInAnElement(input);
//    //button.addEventListener("click", () => showParagraphInAnElement(data));
//    //button.addEventListener('click', showParagraphInAnElement(input));

//    function showParagraphInAnElement(array) {
//       for (let i = 0; i < array.length; i++) {
//          let div = document.createElement('div');
//          let paragraph = document.createElement('p');
//          paragraph.textContent = array[i];
//          div.appendChild(paragraph);
//          contentDiv.appendChild(div);
//       }
//    }
// }
// }

// function solve() {
//    let contentDiv = document.getElementById('content');
//    let form = document.getElementById('task-input');
//    let inputField = document.querySelector('#task-input [type="text"]');

//    form.addEventListener('submit', function (event) {
//       event.preventDefault(); // Prevents form submission

//       let input = inputField.value
//          .split(',')
//          .map(i => i.trim());

//       showParagraphInAnElement(input);
//    });

//    function showParagraphInAnElement(array) {
//       contentDiv.innerHTML = ""; // Optional: Clear previous content

//       for (let i = 0; i < array.length; i++) {
//          let div = document.createElement('div');
//          let paragraph = document.createElement('p');
//          paragraph.textContent = array[i];
//          div.appendChild(paragraph);
//          contentDiv.appendChild(div);
//       }
//    }
// }

// function solve() {
//    let result = document.getElementById('content');
//    let sections = document.querySelector('[type="text"]');
//    let genBtn = document.querySelector('[type="submit"]');
//    genBtn.addEventListener('click', generate);
 
//    function generate(event) {
//       event.preventDefault();
//       let text = sections.value.split(', ');
 
//       for (let t of text) {
//          let div = document.createElement('div');
//          let p = document.createElement('p');
//          p.textContent = t;
//          p.style.display = 'none';
 
//          div.appendChild(p);
//          div.addEventListener('click', (e) => {
//             e.target.querySelector('p').style.display = 'block';
//         });
 
//          result.appendChild(div);
//       }
//    }
// }

// function solve() {
   
//    let targetDiv = document.getElementById('content');
//    let generateBtn = document.querySelector("input[type='submit']");
//    generateBtn.addEventListener('click', (e) => {
//       e.preventDefault();
//       generateDivs();
//    });
 
//    function generateDivs() {
      
//       let sections = document.querySelector("input[type='text']").value.split(', ');
//       if (sections.length > 0) {
//          for (let element of sections) {
            
//             let newDiv = document.createElement('div');
//             let newPara = document.createElement('p');
//             newPara.textContent = element;
//             newDiv.appendChild(newPara);
//             targetDiv.appendChild(newDiv);
//          }
//    }
//    }
// }

// function solve() {
//    let inputValue = document.querySelector("[type='text']");
 
//    let button =  document.querySelector("[type='submit']");
 
//    button.addEventListener('click', checkInputValue);
 
//    let content = document.getElementById('content');
 
//    function checkInputValue(event) {
//       event.preventDefault();
//       let splittedInput = inputValue.value.split(', ');
 
//       for (let string of splittedInput) {
//          let newSection = document.createElement('div');
//          let newP = document.createElement('p');
//          newP.style.display = 'none';
//          newP.textContent = string;
 
//          newSection.appendChild(newP);
 
//          newSection.addEventListener('click', handleSection);
 
//          function handleSection(event) {
//             event.target.querySelector('p').style.display = 'block';
//          }
 
//          content.appendChild(newSection);
//       }
//    }
// }