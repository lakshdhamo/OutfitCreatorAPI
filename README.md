# OutfitCreate App API - Backend service

This project is generated in .NET 6.

## About API:
  This API is designed to fetch the Outfit details from an External API - `https://api.newyorker.de/`.
  Its a simple backend service to interact with External API and return the customized data to UI.
  Validations are in place at Controller methods.
  

## Solution Structure:
1. OutfitCreatorApi - API end point
2. OutfitCreator.Domain - Contains domain logics - fetch details from external API

## End points
1. OutfitDetails - fetch the outfit details based on the supplied limit, offset, country, gender, category(empty by default)
2. Countries - Returns the list of supported countries
3. Filters - Returns the list of category data based on the country code
4. Products - Returned Dictionary formart translated texts based on the country code
5. Product/{id} - Return the detailed product information with Variants (images, sizes, and other product information)

