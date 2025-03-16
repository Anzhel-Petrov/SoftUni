function check_rows(m) {
    for (let r of m) {
        //r.sort();
        console.log(r);
        for (let i in r) {
            if (r[i] == i + 1) {
                console.log("true");
            }
        }
    }
}

check_rows([[1, 2, 3], [3, 2, 1], [2, 3, 1]]);