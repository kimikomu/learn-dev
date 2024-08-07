function findFirstDuplicateIds(ids) {
    let idSet = new Set();

    // loop through ids and add them to the idSet. Since it is a Set(), each value will always be unique. (Duplicates are disposed of)
    for (let id of ids) {
        if (idSet.has(id)) {
            idSet.add(id);
        } else {
            // if the idSet already has an id, we have a duplication!
            return id;
        }
    }
    // Return an empty string if no duplications are found.
    return "";
}


console.log(findFirstDuplicateIds(["X123", "A456", "X123", "8789", "A456", "C111"])); // expected result "X123"
console.log(findFirstDuplicateIds(["2999", "Y888", "2999", "Y888"])); // expected result "2999"
console.log(findFirstDuplicateIds(["E100", "8200", "C300", "E100", "D400", "C300 "])); // expected result "E100"