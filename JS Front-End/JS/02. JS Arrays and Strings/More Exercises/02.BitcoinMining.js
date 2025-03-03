function BitcoinMining(array) {
    const gramOfGold = 67.51;
    const bitcoinPrice = 11949.16;
    let totalMoney = 0
    let bitCoins = 0;
    let firstPurchase = 0;

    for (let i = 0; i < array.length; i++) {
        if (i % 3 == 2) {
            array[i] *= 0.7;
        }

        totalMoney += array[i] * gramOfGold;

        while (totalMoney >= bitcoinPrice) {
            totalMoney -= bitcoinPrice;
            firstPurchase = firstPurchase == 0 ? firstPurchase = i + 1 : firstPurchase;
            bitCoins++;
        }
    }

    console.log(`Bought bitcoins: ${bitCoins}`);
    if (firstPurchase != 0) {
        console.log(`Day of the first purchased bitcoin: ${firstPurchase}`);
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}

// function bitcoinMining(array) {
//     let daysCounter = 0;
//     let totalGold = 0;
//     let bitcoins = 0;
//     let day = 0;
//     let gram = 67.51;
//     let totalPrice = 0;
//     let firstDay = 0;
//     for (let i = 0; i < array.length; i++) {
//         day++;
//         daysCounter++;
//         totalGold = 0;
//         if (day % 3 != 0) {
//             totalGold += array[i];
//         } else if (day % 3 == 0) {
//             totalGold += array[i] * 0.7;
//         }
//         totalPrice = totalPrice + totalGold * gram;

//         if (totalPrice >= 11949.16) {
//             if (bitcoins == 0) {
//                 firstDay = daysCounter;
//                 while (totalPrice >= 11949.16) {
//                     totalPrice -= 11949.16;
//                     bitcoins++;
//                 }
//             } else if (bitcoins >= 1) {
//                 while (totalPrice >= 11949.16) {
//                     totalPrice -= 11949.16;
//                     bitcoins++;
//                 }
//             }
//         }
//     }
//     console.log(`Bought bitcoins: ${bitcoins}`);
//     if (bitcoins >= 1) {
//         console.log(`Day of the first purchased bitcoin: ${firstDay}`);
//     }
//     console.log(`Left money: ${totalPrice.toFixed(2)} lv.`);
// }

// function solve (myArr) {

//     let totalSum = 0;
//     let bitcoins = 0;
//     let firstPurchaseBTC = 0;

//     for (let i=0;i< myArr.length; i++) {

//         let day = i + 1;

//         let goldForTheDay = myArr[i];

//         if (day % 3 == 0){
//             goldForTheDay *= 0.7;
//         }

//         let currency = goldForTheDay * 67.51;
//         totalSum += currency;

//         if (totalSum >= 11949.16) {
//             while (totalSum >= 11949.16){
//                 bitcoins += 1;
//                 if (bitcoins == 1){
//                     firstPurchaseBTC = day;
//                 }
//                 totalSum -= 11949.16;
//             }


//         }
//     }

//     console.log(`Bought bitcoins: ${bitcoins}`)
//     if (bitcoins > 0){
//         console.log(`Day of the first purchased bitcoin: ${firstPurchaseBTC}`)
//     }
//     console.log(`Left money: ${totalSum.toFixed(2)} lv.`)

// }

BitcoinMining([100, 200, 300]);
BitcoinMining([50, 100]);
BitcoinMining([3124.15, 504.212, 2511.124]);
