*** DTN Code Exam - Lightning Strike App ***

Steps on how to run the console application:
- Update the lightning json file inside the LightningStrikeApp folder for the lightning input.
- Open the solution in Visual Studio.
- Build the whole solution/project.
- Run the LightningStrikeApp console program.
- Proceed to the Terminal Console window in order to see the printed Lightning Notification/Alerts.

Steps on how to run the LightningUnitTest:
- Right Click on the file LightningTest.cs and click/select RunTests.
- Proceed to the Test Results window, and see if you have Passed or Failed tests.

*** Additional Questions ***

Question #1: What is the time complexity for determining if a strike has occurred for a particular asset?

Answer:
- Based on the research and the architecture of the program I've created it is using a time complexity "Big O or O(n)"
- Because it refers to size of the input in this case it's the number of assets and lightning strikes in a list.
- And also it means that the search is linear and will improve over time as the assets alerted won't be included in the search anymore.

Question #2: If we put this code into production, but found it too slow, or it needed to scale to many more users or more frequent strikes, what are the first things you would think of to speed it up?

Answer:
- Let's say for example we already have deployed it into the production and we already have devices/sensors that captures lightning streams of data in Real Time.
- I will be creating another class library that can handle multiple lightning strike streams of data at ones and sort it based on the time received with less latency for more faster and accurate alerts.
- The assets can also be ordered and do a binary search which have a time complexity of O(log n).
- We can also modify and refactor the TileSystem (Map) for faster computations/conversions of Lightning stream properties into a Quadkey/Location.