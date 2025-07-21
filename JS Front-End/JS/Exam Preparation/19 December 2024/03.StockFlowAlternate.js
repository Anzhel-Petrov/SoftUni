function orderTracker() {
    let baseUrl = `http://localhost:3030/jsonstore/orders/`;
    let orderList = document.getElementById('list');

    let orderNameField = document.getElementById('name');
    let orderQuantityField = document.getElementById('quantity');
    let orderDateField = document.getElementById('date');

    let loadBtn = document.getElementById('load-orders');
    loadBtn.addEventListener('click', getOrders);

    let orderBtn = document.getElementById('order-btn');
    orderBtn.addEventListener('click', function (e) {
        e.preventDefault();
        createOrder();
    })

    let editBtn = document.getElementById('edit-order');
    editBtn.addEventListener('click', function (e) {
        e.preventDefault();
        updateOrder();
    })

    function onChange(event) {
        let currentOrderElement = event.target.parentElement
        let currentOrderID = event.target.dataset.id

        let currentOrderName = currentOrderElement.querySelector('h2').textContent;
        let currentOrderQty = currentOrderElement.querySelector('h3:last-of-type').textContent;
        let currentOrderDate = currentOrderElement.querySelector('h3:first-of-type').textContent;

        orderNameField.value = currentOrderName;
        orderQuantityField.value = currentOrderQty;
        orderDateField.value = currentOrderDate;

        orderBtn.disabled = true;
        editBtn.dataset.id = currentOrderID;
        editBtn.disabled = false;

        currentOrderElement.remove()
    }

    async function getOrders() {

        let response = await fetch(baseUrl);
        let data = await response.json();

        let orders = Object.values(data);

        for (let order of orders) {
            let stockName = order.name;
            let quantity = order.quantity;
            let date = order.date;

            let nameElement = createElement('h2', stockName);
            let dateElement = createElement('h3', date);
            let quantityElement = createElement('h3', quantity);

            let changeBtn = createElement('button', 'Change', { class: 'change-btn' });
            changeBtn.dataset.id = order._id;
            changeBtn.addEventListener('click', onChange);

            let doneBtn = createElement('button', 'Done', { class: 'done-btn' });
            doneBtn.dataset.id = order._id;
            doneBtn.addEventListener('click', function () {
                deleteOrder(doneBtn.dataset.id);
            });

            let containerDiv = createElement('div', null, { class: 'container' }, nameElement, dateElement, quantityElement, changeBtn, doneBtn);
            orderList.appendChild(containerDiv);
        }
    }

    async function createOrder() {
        let newOrderName = orderNameField.value;
        let newOrderQty = orderQuantityField.value;
        let newOrderDate = orderDateField.value;

        let newOrder = {
            name: newOrderName,
            date: newOrderDate,
            quantity: newOrderQty,
        }

        let options = {
            method: 'post',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(newOrder),
        }

        orderList.replaceChildren();
        await fetch(baseUrl, options);

        orderNameField.value = '';
        orderQuantityField.value = '';
        orderDateField.value = '';

        getOrders();
    }

    async function updateOrder() {
        orderList.replaceChildren();

        let updateId = editBtn.dataset.id

        let updatedOrder = {
            name: orderNameField.value,
            date: orderDateField.value,
            quantity: orderQuantityField.value,
            _id: updateId,
        }

        let options = {
            method: 'put',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(updatedOrder),
        }

        await fetch(baseUrl + updateId, options);

        editBtn.dataset.id = '';
        editBtn.disabled = true;
        orderBtn.disabled = false;

        orderNameField.value = '';
        orderDateField.value = '';
        orderQuantityField.value = '';

        getOrders();
    }

    async function deleteOrder(id) {
        options = {
            method: 'delete',
        }

        orderList.replaceChildren();
        await fetch(baseUrl + id, options);

        getOrders();
    }
}

function createElement(type, content, attributes = {}, ...children) {
    let element = document.createElement(type);

    if (content) {
        element.textContent = content;
    }

    for (let attr in attributes) {
        if (attr === 'class') {
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

orderTracker();