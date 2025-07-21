let host = 'http://localhost:3030/jsonstore/workout';

let loadBtn = document.getElementById('load-workout');
loadBtn.addEventListener('click', showWorkouts);

let addBtn = document.getElementById('add-workout');
addBtn.addEventListener('click', onAdd);

let editBtn = document.getElementById('edit-workout');
editBtn.addEventListener('click', onChange)

async function showWorkouts() {
    let data = await getAllWorkouts();

    let list = document.getElementById('list');
    list.replaceChildren();

    for (let record of data) {
        let changeBtn = create('button', ['Change']);
        ///TODO add event listener to change button
        changeBtn.addEventListener('click', () => onEdit(record));
        changeBtn.className = 'change-btn';

        let deleteBtn = create('button', ['Delete']);
        ///TODO add event listener to delete button
        deleteBtn.addEventListener('click', async () => {
            await deleteWorkout(record._id);
            showWorkouts();
        });
        deleteBtn.className = 'delete-btn';

        let controlDiv = create('div', [changeBtn, deleteBtn], 'buttons-container');

        let element = create('div', [
            create('h2', [record.workout]),
            create('h3', [record.date]),
            create('h3', [record.location], 'location'),
            create('div', [], 'buttons-container'),
            controlDiv
        ]);

        element.className = 'container';

        list.appendChild(element);
    }
}

function onEdit(record) {
    document.getElementById('workout').value = record.workout;
    document.getElementById('location').value = record.location;
    document.getElementById('date').value = record.date;

    editBtn.dataset.id = record._id;
    addBtn.disabled = true;
    editBtn.disabled = false;
}

async function onAdd() {
    let workoutName = document.getElementById('workout');
    let workoutLocation = document.getElementById('location');
    let workoutDate = document.getElementById('date');

    if (!workoutName.value || !workoutLocation.value || !workoutDate.value) return;

    await addWorkout(workoutName.value, workoutLocation.value, workoutDate.value);

    workoutName.value = '';
    workoutLocation.value = '';
    workoutDate.value = '';

    showWorkouts();
}

async function onChange() {

}

async function getAllWorkouts() {
    let res = await fetch(host);

    if (res.status == 204) {
        return [];
    }

    let data = await res.json();
    return Object.values(data);
}

async function addWorkout(workout, location, date) {
    let entry = {
        workout,
        location,
        date
    }

    let options = {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(entry)
    }

    await fetch(host, options);
}

async function deleteWorkout(_id) {
    let options = {
        method: 'delete'
    }

    await fetch(`${host}/${_id}`, options);
}

async function updateWorkout(_id, workout, location, date) {
    let entry = {
        _id,
        workout,
        location,
        date
    };

    let options = {
        method: 'put',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(entry)
    }

    await fetch(`${host}/${_id}`, options);
}

function create(tagName, content, id) {
    let element = document.createElement(tagName);

    if (id) {
        element.id = id;
    }

    for (let child of content) {
        if (typeof child == 'object') {
            element.appendChild(child);
        } else {
            let node = document.createTextNode(child);

            element.appendChild(node);
        }
    }

    return element;
}