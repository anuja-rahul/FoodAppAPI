# FoodApp-API

FoodApp is a simple ASP.NET Core application that provides an API for managing meal planning (breakfast). This README provides an overview of the project, including setup instructions, API documentation, and example request models.

## Table of Contents

- [Setup](#setup)
- [API Documentation](#api-documentation)
  - [Create Breakfast](#create-breakfast)
  - [Get Breakfast](#get-breakfast)
  - [Update Breakfast](#update-breakfast)
  - [Delete Breakfast](#delete-breakfast)
- [Example Request Models](#example-request-models)
- [License](#license)
- [Contributions](#contributions)

## Setup

1. Clone the repository:

    ```sh
    git clone https://github.com/anuja-rahul/FoodAppAPI.git
    ```

2. Navigate to the project directory:

    ```sh
    cd FoodApp
    ```

3. Restore the dependencies:

    ```sh
    dotnet restore
    ```

4. Run the application:

    ```sh
    dotnet run
    ```

## API Documentation

### Create Breakfast

- **Endpoint:** `POST /breakfast`
- **Description:** Creates a new breakfast item.
- **Request Body:**
        ```json
        {
            "name": "Pancakes",
            "description": "Delicious fluffy pancakes",
            "startDateTime": "2024-01-01T08:00:00Z",
            "endDateTime": "2024-01-01T10:00:00Z",
            "savory": ["Bacon", "Eggs"],
            "sweet": ["Maple Syrup", "Blueberries"]
        }
        ```
- **Response:**
        - **201 Created:** Returns the created breakfast item.

### Get Breakfast

- **Endpoint:** `GET /breakfast/{id}`
- **Description:** Retrieves a breakfast item by its ID.
- **Response:**
        - **200 OK:** Returns the breakfast item.
        - **404 Not Found:** If the breakfast item does not exist.

### Update Breakfast

- **Endpoint:** `PUT /breakfast/{id}`
- **Description:** Updates an existing breakfast item.
- **Request Body:**
        ```json
        {
            "name": "Updated Pancakes",
            "description": "Even more delicious pancakes",
            "startDateTime": "2024-01-01T08:00:00Z",
            "endDateTime": "2024-01-01T10:00:00Z",
            "savory": ["Bacon", "Eggs"],
            "sweet": ["Maple Syrup", "Strawberries"]
        }
        ```
- **Response:**
        - **204 No Content:** If the breakfast item was successfully updated.
        - **201 Created:** If a new breakfast item was created.

### Delete Breakfast

- **Endpoint:** `DELETE /breakfast/{id}`
- **Description:** Deletes a breakfast item by its ID.
- **Response:**
        - **204 No Content:** If the breakfast item was successfully deleted.
        - **404 Not Found:** If the breakfast item does not exist.

## Example Request Models

### CreateBreakfastRequest

```json
{
    "name": "Pancakes",
    "description": "Delicious fluffy pancakes",
    "startDateTime": "2024-01-01T08:00:00Z",
    "endDateTime": "2024-01-01T10:00:00Z",
    "savory": ["Bacon", "Eggs"],
    "sweet": ["Maple Syrup", "Blueberries"]
}
```

### UpsertBreakfastRequest

```json
{
    "name": "Updated Pancakes",
    "description": "Even more delicious pancakes",
    "startDateTime": "2024-01-01T08:00:00Z",
    "endDateTime": "2024-01-01T10:00:00Z",
    "savory": ["Bacon", "Eggs"],
    "sweet": ["Maple Syrup", "Strawberries"]
}
```

### BreakfastResponse

```json
{
    "id": "d290f1ee-6c54-4b01-90e6-d701748f0851",
    "name": "Pancakes",
    "description": "Delicious fluffy pancakes",
    "startDateTime": "2024-01-01T08:00:00Z",
    "endDateTime": "2024-01-01T10:00:00Z",
    "lastModifiedDateTime": "2024-01-01T07:00:00Z",
    "savory": ["Bacon", "Eggs"],
    "sweet": ["Maple Syrup", "Blueberries"]
}
```

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Contributions

Contributions are welcomed! If you have any ideas, suggestions, or improvements, feel free to open an issue or submit a pull request.
