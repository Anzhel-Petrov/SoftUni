function solve(string) {
    let wordObj = {};

    let wordArr = string.split(' ');

    for (let word of wordArr) {
        if (word.toLowerCase() in wordObj) {
            wordObj[word.toLowerCase()] += 1;
        } else {
            wordObj[word.toLowerCase()] = 1;
        }
    }

    let wordKeys = Object.keys(wordObj);
    let oddWordKeys = [];

    for (let key of wordKeys) {
        if (wordObj[key] % 2 != 0) {
            oddWordKeys.push(key);
        }
    }

    console.log(oddWordKeys.join(' '));
}