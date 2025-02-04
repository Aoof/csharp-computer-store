# Computer Program

## Overview
This program simulates a computer store inventory management system. It allows users to add, update, and display computers in the inventory. The program also includes authentication to ensure that only authorized users can modify the inventory.

## Classes

### Computer
The `Computer` class represents a computer with the following properties:
- `brand`: The brand of the computer.
- `model`: The model of the computer.
- `SN`: The serial number of the computer.
- `price`: The price of the computer.

The class also includes:
- A static `count` variable to keep track of the number of `Computer` instances created.
- Constructors to initialize the properties.
- Properties to get and set the values of the fields.
- An override of the `ToString` method to display the computer details.
- A static method `findNumberOfCreatedinventory` to return the number of `Computer` instances created.

### ComputerProgram
The `ComputerProgram` class contains the main logic of the program. It includes:
- Constants for the password and maximum login attempts.
- Static variables for the inventory array, available space, login status, and failed login attempts.
- A property `inventorySize` to get the current size of the inventory.

#### Methods
- `Main()`: The entry point of the program. It initializes the inventory and displays the main menu.
- `ShowMenu()`: Displays the main menu and handles user input for different operations.
- `Authenticate()`: Handles user authentication by checking the password.
- `AddComputers(int n = -1)`: Adds computers to the inventory. If `n` is not specified, it prompts the user for the number of computers to add.
- `UpdateComputer()`: Updates the details of a computer in the inventory.
- `DisplayBrandComputers()`: Displays all computers of a specified brand.
- `DisplayFilteredComputers()`: Displays all computers with a price less than a specified value.

## Usage

1. **Run the Program**: Execute the program to start the inventory management system.
2. **Set Inventory Capacity**: Enter the capacity of the inventory when prompted.
3. **Main Menu**: Choose from the following options:
   - Add a computer to inventory
   - Update a computer in inventory
   - Display all computers of a brand
   - Display all computers with a price less than a given value
   - Exit

### Adding Computers
- Select the option to add computers.
- Enter the number of computers to add.
- For each computer, enter the brand, model, price, and serial number.

### Updating a Computer
- Select the option to update a computer.
- Enter the index of the computer to update.
- Choose the property to update (brand, model, serial number, or price) and enter the new value.

### Displaying Computers
- Select the option to display computers of a specific brand or with a price less than a specified value.
- Enter the brand name or maximum price to filter the computers.

## Authentication
- The program requires a password to add or update computers.
- The default password is `password`.
- Users have a maximum of 3 attempts to enter the correct password.

## Example
```
Welcome to the Computer Store!
Please enter the capacity of your inventory: 5

1. Add a computer to inventory
2. Update a computer in inventory
3. Display all computers of a brand
4. Display all computers with a price less than a given value
5. Exit
Enter your choice: 1

Please enter the amount of computers you'd like to enter: 2
Please enter your password: ******
Computer # 0
Please enter the brand name of this computer: Dell
Please enter the model of this computer: XPS 13
Please enter the price of this computer: 999.99
Please enter the serial number of this computer: 123456789

Computer # 1
Please enter the brand name of this computer: HP
Please enter the model of this computer: Spectre x360
Please enter the price of this computer: 1199.99
Please enter the serial number of this computer: 987654321
```

## Deleting a Computer
- Select the option to delete a computer.
- Enter the index of the computer to delete.
- The computer at the specified index will be removed from the inventory, and the inventory will be adjusted accordingly.

## Example
```
Welcome to the Computer Store!
Please enter the capacity of your inventory: 5

1. Add a computer to inventory
2. Update a computer in inventory
3. Display all computers of a brand
4. Display all computers with a price less than a given value
5. Exit
6. Delete a computer from inventory
Enter your choice: 6

Please enter the computer index to delete: 1
Computer deleted successfully!
```

## Notes
- Ensure that the inventory capacity is set correctly at the start of the program.
- The program uses a simple password authentication mechanism. The default password is `password`.
- The inventory is managed using an array, and the available space is tracked to prevent overfilling the inventory.
- The program provides a user-friendly interface to manage the inventory through a console-based menu system.

## Future Enhancements
- Implement a more secure authentication mechanism.
- Add functionality to save and load the inventory from a file.
- Improve the user interface for better usability.
- Add more detailed error handling and validation for user inputs.
