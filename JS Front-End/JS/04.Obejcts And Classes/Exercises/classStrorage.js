// class Storage {
//     constructor (capacity) {
//         this.capacity = capacity;
//         this.storage = [];
//         this.totalCost = 0;
 
//         this.getTotalCost();
//     }
 
//     getTotalCost () {
        
//         for (let product of this.storage) {
//             this.totalCost += (Number(product.quantity) * Number(product.price));
//         }
 
//         return this.totalCost
//     }
 
//     addProduct (object) {
//         if (Number(object.quantity) <= this.capacity) {
//             this.storage.push(object);
//             this.capacity -= Number(object.quantity);
//         }
//         this.totalCost = 0
//         this.getTotalCost();
//     }
 
//     getProducts () {
//         let result = []
//         for (let product of this.storage) {
//             result.push(JSON.stringify(product));
//         }
 
//         return result.join('\n');
//     }
// }