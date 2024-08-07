// Find the words from array2 that have an anagram in array1. Add up the length of these matching anagram words. The total length must be a number.
// Anagrams are words that have the same letters but rearranged. If a word has no anagram in the other array, abandon it.

function sortCharacters(input) {
    return input.split('').sort().join('');
}

function findAnagrams(array1, array2) {
    // get a set of unique signitures in array1
    let setOfUniqueSignitures = new Set();

    for (let word of array1) {
        setOfUniqueSignitures.add(sortCharacters(word));
    }


    let sumOfAnagramLengths = 0;

    // compare words in array2 with signitures in array1
    for (let word of array2) {
        let sortedWord = sortCharacters(word);

        if (setOfUniqueSignitures.has(sortedWord)) {
            sumOfAnagramLengths += word.length;
        }
    }

    return sumOfAnagramLengths;
}

let array1 = ["cat", "dog", "tac", "god", "act"];
let array2 = ["tca", "ogd", "atc", "taco"];
let result = findAnagrams(array1, array2);