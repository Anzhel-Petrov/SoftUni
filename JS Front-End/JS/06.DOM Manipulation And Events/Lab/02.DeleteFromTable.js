function deleteByEmail() {
    let input = document.querySelector('[name="email"]');
    let pattern = input.value;

    console.log(pattern);
    let rows = Array.from(document.querySelectorAll('tbody tr'));
    console.log(rows);
}