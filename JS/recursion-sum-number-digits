// Write a recursive function that will calculate the sum of digits in a given number.

function sumDigits(number) {
    if (number < 10) {
      return number;  // If number < 10, we are on a single digit. End function
    } else {
        // number % 10 == the last digit of the number
      return number % 10 + sumDigits(Math.floor(number / 10));
    }
  }
  console.log(sumDigits(54321)); // Should print 15 (5+4+3+2+1)
