window.addEventListener("load", solve);

function solve() {
    let addBtn = document.getElementById('add_btn');
    let firstName = document.getElementById('first_name');
    let lastName = document.getElementById('last_name');
    let phoneNumber = document.getElementById('phone');
    addBtn.addEventListener('click', onSubmit);
    let contacts = document.getElementById('pending_contact_list');
    let verified = document.getElementById('contact_list');

    function onSubmit(e) {
        e.preventDefault();

        let firstNameInput = firstName.value;
        let lastNameInput = lastName.value;
        let phoneNumberInput = phoneNumber.value;

        if (!firstNameInput || !lastNameInput || !phoneNumberInput) return;

        let spanName = createElement('span', `${firstNameInput} ${lastNameInput}`, { class: 'names' });
        let spanPhone = createElement('span', phoneNumberInput, { class: 'phone_number' });
        let editBtn = createElement('button', 'Edit', { class: 'edit_btn' });
        let verifyBtn = createElement('button', 'Verify', { class: 'verify_btn' });

        let liContact = createElement('li', null, { class: 'contact' }, spanName, spanPhone, editBtn, verifyBtn);

        contacts.appendChild(liContact);

        editBtn.addEventListener('click', () => onEdit(firstNameInput, lastNameInput, phoneNumberInput));
        verifyBtn.addEventListener('click', () => onVerify(liContact));

        document.querySelector('#contact_form').reset();

        function onEdit(firstNameInput, lastNameInput, phoneNumberInput) {
            [firstName.value, lastName.value, phoneNumber.value] = [firstNameInput, lastNameInput, phoneNumberInput];
            liContact.remove();
        }

        function onVerify(element) {
            element.className = 'verified_contact';

            let buttons = element.querySelectorAll('button');
            buttons.forEach(btn => btn.remove());

            let deleteBtn = createElement('button', 'Delete', { class: 'delete_btn' });
            deleteBtn.addEventListener('click', () => onDelete(liContact));
            element.appendChild(deleteBtn);
            verified.appendChild(element);
        }

        function onDelete(element) {
            element.remove();
        }
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
}


