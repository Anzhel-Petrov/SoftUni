function makeMap(jsonArr) {
    let myMap = new Map();

    for (let jsonString of jsonArr) {
        let currentObj = JSON.parse(jsonString);
        let key = Object.keys(currentObj);
        myMap.set(key[0], currentObj[key[0]]);
    }

    const sortedByKey = new Map(
        Array.from(myMap).sort((a, b) => a[0].localeCompare(b[0]))
    );

    for (let [term, definition] of sortedByKey) {
        console.log(`Term: ${term} => Definition: ${definition}`)
    }
}