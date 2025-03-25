function solve() {
   let towns = document.getElementById('towns').children;
   let searchText = document.getElementById('searchText').value;
   let result = document.getElementById('result');
   let matches = 0;

   console.log(towns);
   console.log(searchText);

   for (let town of towns) {
      if (!searchText)
         return;

      if (town.textContent.includes(searchText)) {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         matches++;
      }
      else {
         town.style.fontWeight = '';
         town.style.textDecoration = '';
      }
   }

   result.textContent = `${matches} matches found`;
}

// function search() {
//    let search = document.getElementById('searchText').value;
//    let citiesList = document.getElementsByTagName('li');
//    let matches = 0;

//    for (const city of citiesList) {
//       city.style.fontWeight = '';
//       city.style.textDecoration = '';
//    }

//    for (const city of citiesList) {
      
//       if(city.textContent.includes(search)) {
//          city.style.fontWeight = 'bold';
//          city.style.textDecoration = 'underline';

//          matches++;
//       }
//    }

//    document.getElementById('result').textContent = `${matches} matches found`;
// }

// function solve() {
//     const listItems = document.querySelectorAll('#towns li');
//     const searchText = document.getElementById('searchText').value.toLowerCase();
//     let results = [];
    
//     for (let item of listItems) {
//        item.style.fontWeight = 'normal';
//        item.style.textDecoration = 'none';
//     }
  
//     for (let item of listItems) {
//        if (item.textContent.toLowerCase().includes(searchText)) {
//           item.style.fontWeight = 'bold';
//           item.style.textDecoration = 'underline';
//           results.push(item);
//        }
//     }
  
//     let resultString = `${results.length} matches found`;
  
//     document.getElementById('result').innerHTML = resultString;
//  }

// function solve() {
//     let searchText = document.getElementById('searchText').value;
  
//     let unorderedList = document.querySelector('ul');
  
//     let children = unorderedList.children;
  
//     let matches = 0;
  
//     for (let listItem of children) {
//        if (listItem.textContent.includes(searchText)) {
//           listItem.style.fontWeight = 'bold';
//           listItem.style.textDecoration = 'underline';
//           matches++
//        }
//     }
  
//     let result = document.getElementById('result');
  
//     result.textContent = `${matches} matches found`;
//  }