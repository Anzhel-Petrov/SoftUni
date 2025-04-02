window.addEventListener("load", solve);

function solve() {
    let eventNameInput = document.getElementById('event');
    let eventNoteInput = document.getElementById('note');
    let eventDateInput = document.getElementById('date');
    let saveButton = document.getElementById('save');
    let deleteButton = document.querySelector('.btn.delete');
    //let deleteButton = document.getElementsByClassName('btn delete')[0];
    let upcomingEventList = document.getElementById('upcoming-list');
    let endedEventList = document.getElementById('events-list');

    saveButton.addEventListener('click', saveEvent);
    deleteButton.addEventListener('click', deleteEvents);

    function deleteEvents() {
        while (endedEventList.firstChild) {
            endedEventList.removeChild(endedEventList.firstChild);
        }
    }

    function saveEvent(e) {
        if (!eventNameInput.value || !eventNoteInput.value || !eventDateInput.value)
            return;
        let eventName = eventNameInput.value;
        let eventNote = eventNoteInput.value;
        let eventDate = eventDateInput.value;

        let newEventLi = document.createElement('li');
        newEventLi.classList.add('event-item');

        let newEventDiv = document.createElement('div');
        newEventDiv.classList.add('event-container');

        let newEventArticle = document.createElement('article');

        let newEventName = document.createElement('p');
        let newEventNote = document.createElement('p');
        let newEventDate = document.createElement('p');
        newEventName.textContent = `Name: ${eventName}`;
        newEventNote.textContent = `Note: ${eventNote}`;
        newEventDate.textContent = `Date: ${eventDate}`;

        let newEventButtonsDiv = document.createElement('div');
        newEventButtonsDiv.classList.add('buttons');

        let editButton = document.createElement('button');
        let doneButton = document.createElement('button');
        editButton.classList.add('btn', 'edit');
        doneButton.classList.add('btn', 'done');
        editButton.textContent = 'Edit';
        doneButton.textContent = 'Done';
        editButton.addEventListener('click', editEvent);
        doneButton.addEventListener('click', endEvent);

        upcomingEventList.appendChild(newEventLi);
        newEventLi.appendChild(newEventDiv);
        newEventDiv.appendChild(newEventArticle);
        newEventArticle.appendChild(newEventName);
        newEventArticle.appendChild(newEventNote);
        newEventArticle.appendChild(newEventDate);
        newEventDiv.appendChild(newEventButtonsDiv);
        newEventButtonsDiv.appendChild(editButton);
        newEventButtonsDiv.appendChild(doneButton);

        eventNameInput.value = '';
        eventNoteInput.value = '';
        eventDateInput.value = '';

        function editEvent() {
            eventNameInput.value = eventName;
            eventNoteInput.value = eventNote;
            eventDateInput.value = eventDate;
            newEventLi.remove();
        }

        function endEvent() {
            newEventLi.remove();
            newEventLi.replaceChild(newEventArticle, newEventDiv);
            endedEventList.appendChild(newEventLi);
        }
    }
}

