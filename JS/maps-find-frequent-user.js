// Imagine you're a webmaster of a popular website and you monitor visits from various users. You've got a list of identifier numbers linked to each visit,
// where each number represents a unique user. Now, imagine a situation where one of them visits the site more frequently, precisely,
// more than n/4 times, where n is the total number of visits. If that's the case, you'd want to find out who it is. 
// So, here's your task: Write a function that scans the list and points out that frequent visitor.

function frequentUser(visits) {
  let visitCount = new Map();
  let frequentThreshold = Math.floor(visits.length / 4); // round down
  
  for (let visit of visits) {
    
    let value = visitCount.get(visit);
    if (visitCount.has(visit)) {
      
      if (value >= frequentThreshold) {
        return visit;
      }
      visitCount.set(visit, value + 1)
    }
    else {
      visitCount.set(visit, 1);
    }
  }
  return -1;
}

console.log(`Frequent User: ${frequentUser([1,2,3,1,2,3,1,2,3,1])}`);  // Expected output: 1
console.log(`Frequent User: ${frequentUser([5,0,5,0,5,0,5,0,1,1,1,1,1])}`);  // Expected output: 5
console.log(`Frequent User: ${frequentUser([3,2,2,1,3,2,3,0,0,1,1,4])}`);  // Expected output: -1