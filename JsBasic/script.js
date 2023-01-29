// task 1
var bananaLine = "I can eat bananas all day";
alert(bananaLine.split(' ')[3]);

// task 2
var cars = ["Saab", "Volvo", "BMW"];

var bmw = cars[2]; // get BMW
cars[0] = "Bentley"; // Change first item
cars.pop(); // remove last item
cars[2] = "Audi"; // added new item Audi
cars[1] += bmw; // splice Volvo and BMW

alert(cars);