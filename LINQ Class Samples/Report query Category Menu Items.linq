<Query Kind="Statements">
  <Connection>
    <ID>e5256fec-8d71-4903-be1e-cb1756234d7c</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPathEncoded>&lt;MyDocuments&gt;\GitHub\ClassDemos\eRestaurantSystem\bin\Debug\eRestaurantSystem.dll</CustomAssemblyPathEncoded>
    <CustomAssemblyPath>C:\Users\owner\Documents\GitHub\ClassDemos\eRestaurantSystem\bin\Debug\eRestaurantSystem.dll</CustomAssemblyPath>
    <CustomTypeName>eRestaurantSystem.DAL.eRestaurantContext</CustomTypeName>
    <AppConfigPath>C:\Users\owner\Documents\GitHub\ClassDemos\Website\Web.config</AppConfigPath>
  </Connection>
</Query>

 var results = from cat in Items
               orderby cat.MenuCategory.Description
               select new 
               {
                    CategoryDescription = cat.MenuCategory.Description,
                    ItemDescription = cat.Description,
                    Price = cat.CurrentPrice,
                    Calories = cat.Calories,
                    Comment = cat.Comment
               };
results.Dump();