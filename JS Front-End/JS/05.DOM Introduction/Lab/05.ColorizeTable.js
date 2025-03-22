function colorize() {
    document.querySelectorAll('tbody tr:nth-child(2n)').forEach(element => {
        element.style.backgroundColor = 'teal';
    });
}