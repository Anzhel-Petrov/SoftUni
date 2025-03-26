function solve() {
   //let rows = document.querySelectorAll('tbody tr');
   let rows = document.querySelectorAll('.container tbody tr');
   let searchText = document.getElementById('searchField');
   let pattern = searchText.value;

   if (!pattern)
      return;

   for (const row of rows) {
      if (row.textContent.includes(pattern)) {
         //row.className = 'selected';
         row.classList.add('select');
      } else {
         row.classList.remove('select');
      }
   }

   searchText.value = '';
}

// function solve() {
//     document.querySelectorAll(".select").forEach(el => el.classList.remove("select"));
  
//     let searchFields = document.querySelectorAll("tbody tr");
//     let searchText = document.getElementById("searchField");
  
//     if (!searchText.value.trim()) {
//        searchText.value = '';
//        return;
//     }
  
//     for (let field of searchFields) {
//        if (field.textContent.toLowerCase().includes(searchText.value.toLowerCase())) {
//           field.classList.add("select");
//        }
//     }
  
//     searchText.value = '';
//  }

// function solve() {
//     let tableRows = document.querySelectorAll('tbody tr');
  
//     let searchField = document.getElementById('searchField').value;
  
//     if (!searchField) {
//        return;
//     }
  
//     for (let row of tableRows) {
//        if (row.className == 'select') {
//           row.className = '';
//        }
  
//        let children = row.children;
  
//        for (let child of children) {
//           if (child.textContent.includes(searchField)) {
//              row.className = 'select';
//              break;
//           }
//        }
//     }
  
//     document.getElementById('searchField').value = '';
//  }

// function solve() {
//     let seacrhString = document.getElementById('searchField').value.toLowerCase();
//     let rows = document.querySelectorAll('tbody tr');
  
//     for (let item of rows) {
//        item.classList.remove('select');
//     }
  
//     for (let tr of rows) {
//        let cells = tr.querySelectorAll('td');
//        for (let el of cells) {
//           if (el.textContent.toLowerCase().includes(seacrhString) && seacrhString !== '') {
//              tr.classList.add('select');
//              break;
//           }
//        }
//     }
//  }