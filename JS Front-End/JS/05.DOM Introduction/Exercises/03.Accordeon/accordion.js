function toggle() {
    //let getTheButton1 = document.querySelector('#accordion .head .button');

    let btn = document.getElementsByClassName("button")[0];
    let moreContent = document.getElementById('extra');

    if (btn.textContent == 'More') {
        btn.textContent = "Less";
        moreContent.style.display = 'block';
    }
    else {
        btn.textContent = "More";
        moreContent.style.display = 'none';
    }
}

// function toggle() {
//     const buttonElement = document.getElementsByClassName('button')[0];
//     const hiddenElement = document.getElementById('extra');

//     if(hiddenElement.style.display === 'none' || hiddenElement.style.display === '') {
//         hiddenElement.style.display = 'block';
//         buttonElement.textContent = 'Less';
//     } else {
//         hiddenElement.style.display = 'none';
//         buttonElement.textContent = 'More';
//     }
// }

// function toggle() {
//     let button = document.querySelector('.button');
//     let value = button.textContent;
//     if (value.toLowerCase() === "more") {
//         button.textContent = "Less";
//         document.getElementById('extra').style.display = 'block';
//     } else if (value.toLowerCase() === "less")
//         {
//             button.textContent = "More";
//             document.getElementById('extra').style.display = 'none';
//         }
// }

// function toggle() {
//     let button = document.getElementsByClassName('button')[0];
//     let textToAdd = document.getElementById('extra');
 
//     if (button.textContent == 'More') {
 
//         textToAdd.style.display = 'block';
 
//         button.textContent = 'Less';
 
//     } else if (button.textContent == 'Less') {
//         textToAdd.style.display = 'none';
 
//         button.textContent = 'More';
//     }
 
// }

// function toggle() {
//     let button = document.querySelector('.button').textContent;
 
//     if (button === 'More') {
//         document.querySelector('.button').textContent = 'Less'
//         document.getElementById('extra').style.display = 'block'
//     } else {
//         document.querySelector('.button').textContent = 'More'
//         document.getElementById('extra').style.display = 'none'
//     }
// }