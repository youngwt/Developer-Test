# 288 Dev Test Shopping Cart by Wayne Atkinson Young

## Running the project

This project is comprised of 2 main parts, a dotnet 6 API for the backend and a Vue project for the front end. 
To run the API project locally use visual studio to open the ShoppingCart solution and build and run the project.
To run the front end you will need to have up to date versions of node, npm and the Vue cli

` npm install -g @vue/cli `

To run the project in a terminal window:

` npm run serve `

This will load a hot swappable development build of the front end on port 8080.
The API is currently configured to run on port 7136

## Testing

The API has unit tests that pass locally. There are also Github actions that build the API project in a CD pipeline.
The front end has been manually tested on chrome

## Future development

- Implement a proper database with an ORM such as Entity Framework for data driven catalogue management
- Implement APIs for CRUD operations on products
- Implement means to search, filter and page products in the catalogue
- Implement proper CI/CD pipelines - run unit tests on each build
- Make sure all environment variables such as ports are controled by the CI/CD pipeline
- Re-factor the shopping cart into finer grained Single Component Files
- Support internationalisation, ARIA support and support for different currencies on the front end
- Self host product images in somewhere such as Azure blob storage
- Add unit tests for the front end
- Add End-to-End tests using either a low-code tool like Katalon or self coded with Selenium
- Hire a UX professional to help improve the layout!