function ThePyramidOfKingDjoser(base, increment) {
    let stone = 0;
    let marble = 0;
    let lapisLazuli = 0;
    let gold = 0;
    let step = 0;
    let height = 0

    while (base > 2) {
        step++;
        height += increment;
        stone += Math.pow(base - 2, 2) * increment;
        step % 5 == 0 ? lapisLazuli += (base * 4 - 4) * increment : marble += (base * 4 - 4) * increment;
        base -= 2;
    }

    gold = Math.pow(base, 2) * increment;
    height += increment;

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuli)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(height)}`);
}

ThePyramidOfKingDjoser(11, 1);
ThePyramidOfKingDjoser(11, 0.75);
ThePyramidOfKingDjoser(12, 1);
ThePyramidOfKingDjoser(23, 0.5);