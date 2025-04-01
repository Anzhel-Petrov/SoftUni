document.addEventListener('DOMContentLoaded', solve);

function solve() {
  //TODO
}

// function solve() {
//   let tableBody = document.querySelector('tbody');
//   let furnitures = document.querySelector('#input textarea');
//   document.querySelector('#input input').addEventListener('click', generate);
  
//   function createCell(text) {
//       let td = document.createElement('td');
//       let p = document.createElement('p');
//       p.textContent = text;
//       td.appendChild(p);
//       return td;
//   }

//   function generate(e) {
//       e.preventDefault();

//       for (let item of JSON.parse(furnitures.value)) {
//           let tr = document.createElement('tr');

//           let imgData = document.createElement('td');
//           let img = document.createElement('img');
//           img.src = item.img;
//           imgData.appendChild(img);
//           tr.appendChild(imgData);

//           tr.appendChild(createCell(item.name));
//           tr.appendChild(createCell(item.price));
//           tr.appendChild(createCell(item.decFactor));

//           let checkCell = document.createElement('td');
//           let checkbox = document.createElement('input')
//           checkbox.type = 'checkbox';
//           checkCell.appendChild(checkbox);
//           tr.appendChild(checkCell); 

//           tableBody.appendChild(tr);
//       }
//   }

//   document.querySelector('input[value="Buy"]').addEventListener('click', buyItems);

//   function buyItems(e) {
//       e.preventDefault();

//       let checkedItems = document.querySelectorAll('input[type="checkbox"]:checked');
      
//       if (checkedItems.length === 0) {
//           return;
//       }

//       let itemNames = [];
//       let totalPrice = 0;
//       let avgDecFactor = 0;

//       for (let item of checkedItems) {
//           let row = item.parentElement.parentElement;
          
//           itemNames.push(row.querySelector('td:nth-child(2)').textContent);
//           totalPrice += Number(row.querySelector('td:nth-child(3)').textContent);
//           avgDecFactor += Number(row.querySelector('td:nth-child(4)').textContent);
//       }

//       let result = `Bought furniture: ${itemNames.join(', ')}\n`;
//       result += `Total price: ${totalPrice}\n`;
//       result += `Average decoration factor: ${avgDecFactor / checkedItems.length}`;

//       document.querySelector('textarea[rows="4"]').value = result;
//   }
// }

// function solve() {
  
//   let tableBody = document.getElementsByTagName('tbody')[0];
//   let inputSubmit = document.getElementById('input').querySelector('input[type="submit"');
//   let checkBoxes = document.querySelectorAll('input[type="checkbox"]');

//   for (let checkBox of checkBoxes) {
//       checkBox.disabled = false;
//   }

//   inputSubmit.addEventListener('click', function (e) {
//       e.preventDefault();
//       generateFurniture();
//   })

//   function generateFurniture() {
//       let input = document.getElementById('input').querySelector('textarea').value;
//       let inputArray = JSON.parse(input);
      
//       for (let object of inputArray) {
//       let image = object.img;
//       let newImage = document.createElement('img');
//       newImage.src = image;
      
//       let name = object.name;
//       let newName = document.createElement('p');
//       newName.textContent = name;

//       let price = object.price;
//       let newPrice = document.createElement('p');
//       newPrice.textContent = price;

//       let decFactor = object.decFactor;
//       let newDecFactor = document.createElement('p');
//       newDecFactor.textContent = decFactor;

//       let newRow = document.createElement('tr');
//       let imageCell = document.createElement('td');
//       imageCell.appendChild(newImage);
//       newRow.appendChild(imageCell);

//       let nameCell = document.createElement('td');
//       nameCell.appendChild(newName);
//       newRow.appendChild(nameCell);

//       let priceCell = document.createElement('td');
//       priceCell.appendChild(newPrice);
//       newRow.appendChild(priceCell);
      
//       let decFactorCell = document.createElement('td');
//       decFactorCell.appendChild(newDecFactor);
//       newRow.appendChild(decFactorCell);

//       let chechBoxCell = document.createElement('td');
//       let newCheckInput = document.createElement('input');
//       newCheckInput.type = 'checkbox';
//       newCheckInput.disabled = false;
//       chechBoxCell.appendChild(newCheckInput);
//       newRow.appendChild(chechBoxCell);

//       tableBody.appendChild(newRow);
//       }
//   }
  
//   let shopSubmit = document.getElementById('shop').querySelector('input[type="submit"');  
//   shopSubmit.addEventListener('click', function (e) {
//       e.preventDefault();
//       generateOutput();
//   })

//   function generateOutput() {
//       let tableRows = Array.from(document.querySelectorAll('tbody tr'));
//       let boughtFurniture = [];
//       let totalPrice = 0;
//       let totalDecFactor = 0;

//       for (let row of tableRows) {
//           let checkBox = row.querySelector('td:last-child input[type="checkbox"]')
//           if (checkBox.checked) {
//               totalPrice += Number(row.querySelector('td:nth-of-type(3) p').textContent);
//               totalDecFactor += Number(row.querySelector('td:nth-of-type(4) p').textContent);
//               boughtFurniture.push(row.querySelector('td:nth-of-type(2) p').textContent);
//           }
//       }

//       let avgDecFactor = (totalDecFactor / boughtFurniture.length);
//       let shopTextArea = document.getElementById('shop').querySelector('textarea');

//       let result = `Bought furniture: ${boughtFurniture.join(', ')}\nTotal price: ${totalPrice}\nAverage decoration factor: ${avgDecFactor}`
//       shopTextArea.value = result;
//   }

// }

// function solve() {
//   let generateBtn = document.querySelector("[value='Generate']");
//   let objectInput = document.querySelector('#input > textarea');
//   let buyBtn = document.querySelector("[value='Buy']");

//   generateBtn.addEventListener('click', handleGenerateBtn);
//   buyBtn.addEventListener('click', handleBuyButton);

//   function handleGenerateBtn(event) {
//     event.preventDefault();
//     let table = document.querySelector('table tbody');
//     let parsedObj = JSON.parse(objectInput.value);

//     for (let obj of parsedObj) {
//       let newRow = document.createElement('tr');

//       let newImgData = document.createElement('td');
//       let newImg = document.createElement('img');
//       newImg.src = obj.img;
//       newImgData.appendChild(newImg);
//       newRow.appendChild(newImgData);

//       let newName = document.createElement('p');
//       let newNameData = document.createElement('td');
//       newName.textContent = obj['name'];

//       newNameData.appendChild(newName);
//       newRow.appendChild(newNameData);

//       let newPrice = document.createElement('p');
//       let newPriceData = document.createElement('td');
//       newPrice.textContent = obj['price'];

//       newPriceData.appendChild(newPrice);
//       newRow.appendChild(newPriceData);

//       let newDecFactor = document.createElement('p');
//       let newDecFactorData = document.createElement('td');

//       newDecFactor.textContent = obj.decFactor;

//       newDecFactorData.appendChild(newDecFactor);

//       newRow.appendChild(newDecFactorData);

//       let checkbox = document.createElement('input');
//       checkbox.type = 'checkbox';
//       let checkData = document.createElement('td');

//       checkData.appendChild(checkbox);

//       newRow.appendChild(checkData)
//       table.appendChild(newRow);
//     }

//     objectInput.value = '';
//   }

//   function handleBuyButton(event) {
//     event.preventDefault();
//     let checkboxes = document.querySelectorAll('td > input');
//     let textarea = document.querySelector('#shop > textarea');
//     let boughtFurniture = [];
//     let prices = [];
//     let decFactorArr = [];

//     for (let checkbox of checkboxes) {
//       if (checkbox.checked) {
//           boughtFurniture.push(checkbox.parentElement.parentElement.children[1].children[0].textContent);
//           prices.push(Number(checkbox.parentElement.parentElement.children[2].children[0].textContent))
//           decFactorArr.push(Number(checkbox.parentElement.parentElement.children[3].children[0].textContent))
//         }
//     }
//     textarea.value += `Bought furniture: ${boughtFurniture.join(', ')}`;

//     let sum = 0;

//     for (let price of prices) {
//       sum += price;
//     }

//     textarea.value += `\nTotal price: ${sum}`;

//     let decFactorSum = 0;

//     for (let factor of decFactorArr) {
//       decFactorSum += factor;
//     }

//     textarea.value += `\nAverage decoration factor: ${decFactorSum / decFactorArr.length}`
//   }
// }

// function solve() {
//   const generateForm = document.getElementById('input');
//   const shopForm = document.getElementById('shop');
//   const tableBody = document.querySelector('tbody')
 
//   generateForm.addEventListener('submit', (e) => {
//     e.preventDefault()
 
//     let inputText = e.target.querySelector('textarea');
//     let inputArr = JSON.parse(inputText.value);
 
//     inputArr.forEach((product) => {
//       let newTr = document.createElement('tr');
 
//       appendNewEl(newTr, 'img', 'src', product.img);
//       appendNewEl(newTr, 'p', 'textContent', product.name);
//       appendNewEl(newTr, 'p', 'textContent', product.price);
//       appendNewEl(newTr, 'p', 'textContent', product.decFactor);
//       appendNewEl(newTr, 'input', 'type', 'checkbox');
 
//       tableBody.appendChild(newTr);
//     })
//   })
 
//   function appendNewEl(parent, element, property, text) {
//     let newTd = document.createElement('td');
//     let newEle = document.createElement(element);
 
//     Object.assign(newEle, { [property]: text });
 
//     newTd.appendChild(newEle);
//     parent.appendChild(newTd);
//   }
 
//   shopForm.addEventListener('submit', (e) => {
//     e.preventDefault()
 
//     let result = e.target.querySelector('textarea')
//     let furnituresName = [];
//     let totalPrice = 0;
//     let totalDecFactor = 0;
 
//     Array.from(document.querySelectorAll('tr:has(input[type="checkbox"]:checked)')).forEach((element) => {
 
//       let [name, price, DecFactor] = element.querySelectorAll('td:nth-child(n+2) p');
 
//       furnituresName.push(name.textContent);
//       totalPrice += Number(price.textContent);
//       totalDecFactor += Number(DecFactor.textContent);
//     })
 
//     let avgDecFactor = totalDecFactor / furnituresName.length
 
//     result.textContent =
//       `Bought furniture: ${furnituresName.join(', ')}\n` +
//       `Total price: ${totalPrice}\n` +
//       `Average decoration factor: ${avgDecFactor}\n`;
//   })
// }