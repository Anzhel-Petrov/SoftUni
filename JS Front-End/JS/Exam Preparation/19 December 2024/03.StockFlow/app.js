let host = 'http://localhost:3030/jsonstore/orders';

let orderNameField = document.getElementById('name');
let orderQuantityField = document.getElementById('quantity');
let orderDateField = document.getElementById('date');

let loadBtn = document.getElementById('load-orders');
loadBtn.addEventListener('click', loadOrders);

let orderBtn = document.getElementById('order-btn');
orderBtn.addEventListener('click', function (e) {
    e.preventDefault();
    onCreate();
})

let editBtn = document.getElementById('edit-order');
editBtn.addEventListener('click', function (e) {
    e.preventDefault();
    onUpdate();
})

async function loadOrders() {
    let data = await getAllOrders();

    let orderList = document.getElementById('list');
    orderList.replaceChildren();

    for (let entry of data) {
        let nameElement = createElement('h2', entry.name);
        let dateElement = createElement('h3', entry.date);
        let quantityElement = createElement('h3', entry.quantity);

        let changeBtn = createElement('button', 'Change', { class: 'change-btn' });
        changeBtn.dataset.id = entry._id;

        let doneBtn = createElement('button', 'Done', { class: 'done-btn' });
        // doneBtn.dataset.id = entry._id;

        let containerDiv = createElement('div', null, { class: 'container' }, nameElement, dateElement, quantityElement, changeBtn, doneBtn);
        orderList.appendChild(containerDiv);

        changeBtn.addEventListener('click', () => onChange(entry, containerDiv));
        doneBtn.addEventListener('click', () => onDelete(entry._id));
    }
}

async function onCreate() {
    let [name, quantity, date] = [orderNameField.value, orderQuantityField.value, orderDateField.value];
    if (!name || !quantity || !date) return;

    await createOrder(orderNameField.value, orderQuantityField.value, orderDateField.value);

    document.querySelector('form').reset();

    loadOrders();
}

function onChange(order, element) {
    [orderNameField.value, orderQuantityField.value, orderDateField.value] = [order.name, order.quantity, order.date];

    orderBtn.disabled = true;
    editBtn.dataset.id = order._id;
    editBtn.disabled = false;

    element.remove();
}

async function onUpdate() {
    let [name, quantity, date] = [orderNameField.value, orderQuantityField.value, orderDateField.value];
    if (!name || !quantity || !date) return;

    let updateId = editBtn.dataset.id;
    await updateOrder(updateId, name, quantity, date);
    orderBtn.disabled = false;
    editBtn.disabled = true;
    document.querySelector('form').reset();
    loadOrders();
}

async function onDelete(id) {
    await deleteOrder(id);
    loadOrders();
}

async function getAllOrders() {
    let res = await fetch(host);

    if (res.status == 204) {
        return [];
    }

    let data = await res.json();
    return Object.values(data);
}

async function createOrder(name, quantity, date) {
    let entry = {
        name,
        quantity,
        date
    };

    let options = {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(entry)
    }

    await fetch(host, options);
}

async function updateOrder(_id, name, quantity, date) {
    let entry = {
        _id,
        name,
        quantity,
        date
    };

    let options = {
        method: 'put',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(entry)
    }

    await fetch(`${host}/${_id}`, options);
}

async function deleteOrder(_id) {
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
        } else {
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