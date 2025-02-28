function PascalCaseSplitter(text) {
    let splitText = [];
    let indexPointer = 0;
    for (let i = 1; i < text.length; i++) {
       if (text[i] == text[i].toUpperCase())
       {
            splitText.push(text.substring(indexPointer, text.indexOf(text[i], i)));
            indexPointer = i;
       }
    }

    splitText.push(text.substring(indexPointer));
    
    console.log(splitText.join(', '));
}

PascalCaseSplitter('SplitMeIfYouCanHaHaYouCantOrYouCan');
PascalCaseSplitter('HoldTheDoor');
PascalCaseSplitter('ThisIsSoAnnoyingToDo');
