# Simple Car Management

## About this project:
This project is make by team of 4 people in order to acquainted with using NUnit Framework. 

### Set up:
Create new console app:
![create-console-app](https://github.com/ttdat2232/car-management/blob/main/srceenshot/set-up/create-console-app.png)

Add new two libraries class:
![create-class-library](https://github.com/ttdat2232/car-management/blob/main/srceenshot/set-up/create-class-library.png)
![create-class-library](https://github.com/ttdat2232/car-management/blob/main/srceenshot/set-up/create-library-class.png)

Add new NUnit test project:
![nunit-test-project](https://github.com/ttdat2232/car-management/blob/main/srceenshot/set-up/create-NUnit-test-project.png)
![nunit-test-project](https://github.com/ttdat2232/car-management/blob/main/srceenshot/set-up/create-nunit-class.png)

### Implements:

This is some functions are going to be tested:
![tested-code](https://github.com/ttdat2232/car-management/blob/main/srceenshot/project/code-in-repository.png)

This is some code in RespositoryTest.cs:
![test-code](https://github.com/ttdat2232/car-management/blob/main/srceenshot/project/test-code.png)

### Result:
Testing result:
![test-result](https://github.com/ttdat2232/car-management/blob/main/srceenshot/result/result.png)

### Explanation: 
1. \[SetUp\] attribute provides a set of functions that are performed just before each test method is invoked.
2. \[Test\] attribute is used for marking method as a test. It can use for both non-parameterized test and parameterized which no causes any extra test case.
3. \[TestCase\] attribute can be used for providing parameters for a test method whenever it is invoked.

4. > \[TestCaseSource\] is used on a parameterized test method to identify the source from which the
   > required arguments will be provided.


### You can also learn more NUnit Framework at [https://docs.nunit.org/](https://docs.nunit.org/)
