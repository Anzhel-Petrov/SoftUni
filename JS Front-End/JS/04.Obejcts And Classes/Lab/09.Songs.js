function songs(input) {
    class Song {
        typeList;
        name;
        time;

        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let numOfSongs = input[0];
    let filter = input[input.length - 1];
    let songsList = [];

    for (let i = 1; i <= numOfSongs; i++) {
        let [typeListm, name, time] = input[i].split('_');
        songsList.push(new Song(typeListm, name, time));
    }

    songsList
        .filter(song => filter === 'all' || song.typeList === filter)
        .forEach(song => console.log(song.name));

}

// function filterSongs(songsInput) {
//     class Song {
//         constructor(typeList, name, time) {
//             this.typeList = typeList;        
//             this.name = name;        
//             this.time = time;        
//         }
//     }

//     const songsCount = songsInput.shift();
//     const filterType = songsInput.pop();

//     for(const song of songsInput) {
//         const[typeList, name, time] = song.split('_');
//         const currentSong = new Song(typeList, name, time);

//         if(currentSong.typeList === filterType || filterType === 'all') {
//             console.log(currentSong.name);
//         }
//     }
// }

// function processSongs (songsData) {

//     class Song {
//         constructor (type, name, time) {
//             this.type = type;
//             this.name = name;
//             this.time = time;
//         }}

//     let songs = [];
//     let numberOfSongs = songsData.shift();
//     let typeSong = songsData.pop();

//     for (let i=0; i<numberOfSongs; i++){
//         let [type, name, time] = songsData[i].split('_');
//         songs.push(new Song(type, name, time));
//     }

//     if (typeSong === 'all') {
//         songs.forEach((i) => console.log(i.name))
//     } else {
//         let filtered = songs.filter((i) => i.type === typeSong);
//         filtered.forEach((i) => console.log(i.name));
//     }
// }

songs([3, 'favourite_DownTown_3:14', 'favourite_Kiss_4:16', 'favourite_Smooth Criminal_4:01', 'favourite']);