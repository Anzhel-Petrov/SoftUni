document.addEventListener('DOMContentLoaded', solve);

function solve() {
    let buttons = document.querySelectorAll('button');

    buttons.forEach(btn => {
        btn.addEventListener('click', showMoreInfo);
    });

    function showMoreInfo(e) {
        e.preventDefault();
        let hiddenProfileInfo = e.target.parentElement.querySelector('.hidden-fields.active');
        let userId = hiddenProfileInfo.id.replace('HiddenFields','');
        let isLocked = document.getElementById(`${userId}Lock`).checked;

        if(isLocked)
            return;
        
        if (hiddenProfileInfo.style.display == 'block')
        {
            hiddenProfileInfo.style.display = 'none';
            e.target.textContent = 'Show more';
        } else {
            hiddenProfileInfo.style.display = 'block';
            e.target.textContent = 'Show less';
        }
    }
}

// function solve() {
//     let profiles = Array.from(document.getElementsByClassName('profile'));
 
//     for (let profile of profiles) {
//         let userLocked = profile.querySelector('input[id$="Lock"]');
//         let userUnlocked = profile.querySelector('input[id$="Unlock"]');
//         let showMore = profile.children[profile.children.length - 1];
//         let hiddenFields = profile.querySelector('.hidden-fields');
 
//         showMore.addEventListener('click', handleShowMore);
 
//         function handleShowMore(event) {
//             if (userUnlocked.checked) {
//                 hiddenFields.style.display = 'none'
//                 if (hiddenFields.style.display == 'none') {
//                     hiddenFields.style.display = 'block';
//                     showMore.textContent = 'Show less'
//                 } else {
//                     hiddenFields.style.display = 'none';
//                     showMore.textContent = 'Show more'
//                 }
//             }
//         }
//     }
// }

// function solve() {
//     document.querySelectorAll('button').forEach(b => b.addEventListener('click', showInfo));
 
//     function showInfo(e) {
//         let hidden = e.target.parentElement.getElementsByClassName('hidden-fields active')[0];
//         let unlockButton = e.target.parentElement.querySelectorAll('input[type="radio"]')[1];
 
//         if (e.target.textContent === 'Show more') {
//             if (unlockButton.checked) {
//                 hidden.style.display = 'block';
//                 e.target.textContent = 'Show less'
//             }
//         } else {
//             if (unlockButton.checked) {
//                 hidden.style.display = 'none';
//                 e.target.textContent = 'Show more'
//             }
//         }
//     }
// }

// function solve() {
//     let profilesArr = Array.from(document.getElementsByClassName('profile'));
 
//     for (let profile of profilesArr) {
//         let btn = profile.querySelector('button');
//         btn.addEventListener('click', showMore);
//     }
 
//     function showMore (event) {
//         let button = event.currentTarget;
//         let currentProfile = event.currentTarget.parentElement;
//         let currentProfileHidden = currentProfile.querySelector('div:last-of-type');
//         let currentProfileLock = currentProfile.querySelector('.radio-group input[type="radio"]:first-of-type');
//         let isLocked = currentProfileLock.checked;
 
//         if (button.textContent === 'Show more') {
            
//             if(!isLocked) {
//                 button.textContent = 'Show less';
//                 currentProfileHidden.classList.remove('active');
//             }
//         } else {
//             button.textContent = 'Show more';
//             currentProfileHidden.classList.add('active');
//         }
//     }
// }