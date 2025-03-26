// function solve(data) {
//     let movieList = [];
 
//     function addMovie(name) {
//         movie = {name};
//         movieList.push({name});
//     }
//     function directedBy(name, director) {
//         let movie = movieList.find(m => m.name == name);
//         if(movie) {
//             movie.director = director;
//         }
//     }
//     function onDate(name, date) {
//         let movie = movieList.find(m => m.name == name);
//         if(movie) {
//             movie.date = date;
//         }
//     }
//     for (let command of data) {
 
//         if(command.includes('addMovie')) {
//             let tokens = command.split('addMovie').map(k => k.trim());
//             let movieName = tokens[1];
//             addMovie(movieName);
//         } else if (command.includes('directedBy')) {
//             let [movieName, director] = command.split(' directedBy ');
//             directedBy(movieName, director);
//         } else if (command.includes('onDate')) {
//             let [movieName, date] = command.split(' onDate ');
//             onDate(movieName, date);
//         }
//     }
 
//     for (let movie of movieList) {
//         if(Object.entries(movie).length == 3) {
//             console.log(JSON.stringify(movie));
//         }
//     }
// }

// function movies (input) {
//     let movieArr = [];
 
//     for (let command of input) {
 
//         if (command.includes('addMovie')) {
//             let movieName = command.replace('addMovie ', '');
//             let movieObj = {name: movieName};
//             movieArr.push(movieObj)
//         } else if (command.includes('directedBy')){
//             let [movieName, director] = command.split(' directedBy ');
//             let movie = movieArr.find(m => m.name === movieName);
//             if (movie) {
//                 movie.director = director;
//             }
//         } else if (command.includes('onDate')) {
//             let [movieName, date] = command.split(' onDate ');
//             let movie = movieArr.find(m => m.name === movieName);
//             if (movie) {
//                 movie.date = date;
//             }
//         }
//     }
 
//     for (let movie of movieArr) {
//         if (movie.name && movie.director && movie.date) {
//             console.log(JSON.stringify(movie));
//         }
//     }
// }