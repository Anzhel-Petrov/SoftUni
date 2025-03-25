function solve() {
    let input = document.getElementById('text').value.toLowerCase().split(' ');
    let currentCase = document.getElementById('naming-convention').value;
    let result = document.getElementById('result');

    if (currentCase === 'Camel Case') {
        result.textContent = input
            .map((word, index) => index === 0
                ? word.toLowerCase()
                : word.charAt(0).toUpperCase() + word.slice(1))
            .join('');
    }
    else if (currentCase === 'Pascal Case') {
        result.textContent = input
            .map(word => word.charAt(0).toUpperCase() + word.slice(1))
            .join('');
    }
    else {
        result.textContent = 'Error!'
    }
}

// function solve() {
//     let textElement = document.getElementById('text').value;
//     let conventionNameElement = document.getElementById('naming-convention').value;
  
//     let result = textElement
//       .toLowerCase()
//       .split(' ')
//       .map(word => word.charAt(0).toUpperCase() + word.slice(1))
//       .join('');
  
//       switch(conventionNameElement) {
//         case 'Camel Case':
//           result = result.charAt(0).toLowerCase() + result.slice(1);
//           break;
//         case 'Pascal Case':
//           break;
//         default:
//           result = 'Error!';
//           break;
//       } 
  
//     document.getElementById('result').textContent = result;
//   }

// function solve() {
//     let firstParameter = document.getElementById('text').value;
//     let command = document.getElementById('naming-convention').value;
//     let i;
   
//     firstParameter = firstParameter.split(' ').map((x) => x.toLowerCase());
   
//     if (command == 'Camel Case') {
//       i = 1;
//     } else if (command == 'Pascal Case') {
//       i = 0;
//     } else{
//       document.getElementById('result').textContent = 'Error!';
//       return;
//     }
   
//     for (i; i < firstParameter.length; i++) {
//       firstParameter[i] = firstParameter[i].charAt(0).toUpperCase() + firstParameter[i].slice(1);
//     }
   
//     document.getElementById('result').textContent = firstParameter.join('');
   
//   }

// function solve() {
//     let text = document.getElementById('text').value;
   
//     let inputCase = document.getElementById('naming-convention');
   
//     let result = document.getElementById('result');
   
//     if (inputCase.value == 'Camel Case') {
//       text = text.toLowerCase().split(' ');
//       let helpArr = [text[0]];
   
//       for (let word of text.slice(1)) {
//         helpArr.push(word[0].toUpperCase() + word.slice(1));
//       }
   
//       result.textContent = helpArr.join('');
   
//     } else if (inputCase.value == 'Pascal Case') {
//       text = text.toLowerCase().split(' ');
//       let helpArr = [];
   
//       for (let word of text) {
//         helpArr.push(word[0].toUpperCase() + word.slice(1));
//       }
   
//       result.textContent = helpArr.join('');
//     } else {
//       result.textContent = 'Error!';
//     }
//   }

// function solve() {
//     let words = document.getElementById("text").value.split(' ');
//     let convention = document.getElementById("naming-convention").value;
//     let result = [];
 
//     function capitalize(val) {
//         return val[0].toUpperCase() + val.slice(1);
//     }
 
//     if (convention === 'Camel Case') {
//         result.push(words[0].toLowerCase());
//         for (let i = 1; i < words.length; i++) {
//             result.push(capitalize(words[i].toLowerCase()));
//         }
//     } else if (convention === 'Pascal Case') {
//         for (let i = 0; i < words.length; i++) {
//             result.push(capitalize(words[i].toLowerCase()));
//         }
//     } else {
//         result.push('Error!');
//     }
 
//     // Shorter Solution
//     // const capitalize = word => word[0].toUpperCase() + word.slice(1).toLowerCase();
 
//     // let result;
//     // if (convention === 'Camel Case') {
//     //     result = words.map((word, i) => i === 0 ? word.toLowerCase() : capitalize(word));
//     // } else if (convention === 'Pascal Case') {
//     //     result = words.map(word => capitalize(word));
//     // } else {
//     //     result = ['Error!'];
//     // }
 
//     document.getElementById("result").textContent = result.join('');
// }

// function solve() {
//     const text = document.getElementById("text").value;
//     const naming = document.getElementById("naming-convention").value;
//     const resultContainer = document.getElementById("result");
   
//     const splitted = text.split(" ");
   
//     let resultString = "";
   
//     if (naming == "Pascal Case") {
//       for (let i = 0; i < splitted.length; i++) {
//         resultString += splitted[i][0].toUpperCase() +
//           splitted[i].slice(1, splitted[i].length).toLowerCase();
//       }
//       resultContainer.textContent = resultString;
//     } else if (naming == "Camel Case") {
//       resultString += splitted[0][0].toLowerCase()
//         + splitted[0].slice(1, splitted[0].length).toLowerCase();
//       for (let i = 1; i < splitted.length; i++) {
//         resultString += splitted[i][0].toUpperCase() +
//           splitted[i].slice(1, splitted[i].length).toLowerCase();
//       }
//       resultContainer.textContent = resultString;
//     } else {
//       resultContainer.textContent = "Error!";
//     }
//   }

// function solve() {
//     let textValue = document.getElementById('text').value;
//     let textType = document.getElementById('naming-convention').value;
   
//     let valueArray = textValue.toLowerCase().split(' ');
//     let result = ''
   
//     if (textType === 'Camel Case') {
//       result = valueArray[0];
//       for (let i = 1; i < valueArray.length; i++) {
//         result += valueArray[i][0].toUpperCase() + valueArray[i].slice(1);
//       }
//     } else if (textType === 'Pascal Case') {
//       for (let word of valueArray) {
//         result += word[0].toUpperCase() + word.slice(1);
//       }
//     } else {
//       result = 'Error!';
//     }
   
//     document.getElementById('result').textContent = result;
   
//   }

// function solve() {
//     let input = document.getElementById("text").value.toLowerCase();
//     let currentCase = document.getElementById("naming-convention").value;
//     let words = input.split(' ').map(word => word.charAt(0).toUpperCase() + word.slice(1));
   
//     let result = currentCase === "Camel Case" 
//       ? words[0].toLowerCase() + words.slice(1).join("") 
//       : currentCase === "Pascal Case" 
//       ? words.join("") 
//       : "Error!";
   
//     document.getElementById("result").textContent = result;
//   }