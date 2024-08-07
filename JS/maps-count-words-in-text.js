const text = "Cosmo,is,an,incredible,technical,companion,with,very,strong,skills,in,Algorithms,and,Data,Structures,and,a,great,teacher,for,technical,interviews.";
const wordCount = new Map();
const words = text.split(",");

// iterate through words and count frequencies;
for (var word in words) {    
    var count = wordCount.get(words[word]) || 0;
    wordCount.set(words[word], count + 1)
}
console.log(wordCount);