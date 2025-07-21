let host = 'http://localhost:3030/jsonstore/reservations';

let reservationNames = document.getElementById('names');
let reservationDays = document.getElementById('days');
let reservationDates = document.getElementById('date');

let loadBtn = document.getElementById('load-history');
loadBtn.addEventListener('click', loadReservations);

let addBtn = document.getElementById('add-reservation');
addBtn.addEventListener('click', function (e) {
    e.preventDefault();
    onCreate();
})

let editBtn = document.getElementById('edit-reservation');
editBtn.addEventListener('click', function (e) {
    e.preventDefault();
    onUpdate();
})

async function loadReservations() {
    let data = await getAllReservations();

    let reservationList = document.getElementById('list');
    reservationList.replaceChildren();

    for (let entry of data) {
        let dateElement = createElement('h3', entry.date);
        let daysElement = createElement('h3', entry.days, { id: 'reservation_days' });
        let namesElement = createElement('h2', entry.names);

        let changeBtn = createElement('button', 'Change', { class: 'change-btn' });
        changeBtn.dataset.id = entry._id;

        let deleteBtn = createElement('button', 'Delete', { class: 'delete-btn' });
        // doneBtn.dataset.id = entry._id;

        let buttonsContainer = createElement('div', null, { class: 'buttons-container' }, changeBtn, deleteBtn);

        let containerDiv = createElement('div', null, { class: 'container' }, namesElement, dateElement, daysElement, buttonsContainer);
        reservationList.appendChild(containerDiv);

        changeBtn.addEventListener('click', () => onChange(entry, containerDiv));
        deleteBtn.addEventListener('click', () => onDelete(entry._id));
    }
}

async function onCreate() {
    let [names, days, date] = [reservationNames.value, reservationDays.value, reservationDates.value];
    if (!names || !days || !date) return;

    await createReservation(names, days, date);

    document.querySelector('form').reset();

    loadReservations();
}

function onChange(reservation, element) {
    [reservationNames.value, reservationDays.value, reservationDates.value] = [reservation.names, reservation.days, reservation.date];

    addBtn.disabled = true;
    editBtn.dataset.id = reservation._id;
    editBtn.disabled = false;

    element.remove();
}

async function onUpdate() {
    let [names, days, date] = [reservationNames.value, reservationDays.value, reservationDates.value];
    if (!names || !days || !date) return;

    let updateId = editBtn.dataset.id;
    await updateReservation(updateId, names, days, date);
    addBtn.disabled = false;
    editBtn.disabled = true;
    document.querySelector('form').reset();
    loadReservations();
}

async function onDelete(id) {
    await deleteReservation(id);
    loadReservations();
}

async function getAllReservations() {
    let res = await fetch(host);

    if (res.status == 204) {
        return [];
    }

    let data = await res.json();
    return Object.values(data);
}

async function createReservation(names, days, date) {
    let entry = {
        names,
        days,
        date
    };

    let options = {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(entry)
    }

    await fetch(host, options);
}

async function updateReservation(_id, names, days, date) {
    let entry = {
        _id,
        names,
        days,
        date
    };

    let options = {
        method: 'put',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(entry)
    }

    await fetch(`${host}/${_id}`, options);
}

async function deleteReservation(_id) {
    let options = {
        method: 'delete'
    }

    await fetch(`${host}/${_id}`, options);
}

function createElement(type, content, attributes = {}, ...children) {
    let element = document.createElement(type);

    if (content) {
        element.textContent = content;
    }

    for (let attr in attributes) {
        if (attr == 'class') {
            element.classList.add(...attributes[attr].split(' '));
        } else if (attr == 'id') {
            element.id = attributes[attr];
        }
        else {
            element.setAttribute(attr, attributes[attr]);
        }
    }

    for (let child of children) {
        if (typeof child === 'string') {
            child = document.createTextNode(child);
        }

        element.appendChild(child);
    }

    return element;
}