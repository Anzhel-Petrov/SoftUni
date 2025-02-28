function PrintEveryNthElement (array, everyNthElement)
{
    let result = [];

    for (let i = 0; i < array.length; i+= everyNthElement) {
        result.push(array[i]);
    }

    //console.log(result);
    return result;
}

PrintEveryNthElement(['5', '20', '31', '4', '20'], 2);
PrintEveryNthElement(['dsa','asd', 'test', 'tset'], 2);
PrintEveryNthElement(['1', '2','3', '4', '5'], 6);