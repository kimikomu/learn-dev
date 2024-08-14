function countDigits(number) {
    if (number < 10) {
        return 1;
    } else {
        return 1 + countDigits(Math.floor(number / 10));
    }
}

console.log(countDigits(1302)); // Should output 4
