# inventory-app-dotnet

This app was developed as a coding exersize project with the following requirements:

## Description
Stine deals with inventories for Soybean and Corn. As part of the research process, Stine must keep track of seed inventories to ensure that we can continue to grow and research any specific line.

The following is a simple problem that will give you a mocked JSON API that outputs inventories and packaging requests. The inventory contains the name of the inventory and the kernel counts on hand. The requests contain the number of kernels requested for packaging, for a given inventory.


## Problem
Assume that you are writing a simple internal web portal. 
* Use the following mocked API endpoint to get the data: https://mocki.io/v1/0077e191-c3ae-47f6-bbbd-3b3b905e4a60

1. Create a .net core rest API that queries the data above
   * Implement Dependency Injection in at least one place of the API (controller/service/etc).
2. Create a basic Angular (2+) application
    * Query the data from the .net core API created in step 1.
    * Display the packaging requests and the inventory that the requests are for.
    * Show the user if there is not enough inventory to satisfy the requested kernels.


### Notes
* You may use any version of .net core or Angular 2+.
* These are loose requirements and you can change/update the problem or solution, but please explain your reasoning.
* Use clean code and best practices, this is an easy problem to solve. The focus should be around quality and decision making.

### Submission
* Submit a zipped file or a publicly accessible git URL that contains all of your code, notes, etc.
* Do not include the node_modules folder.
