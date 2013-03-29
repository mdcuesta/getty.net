Getty.Images.API for .NET
=========

.NET library for the Getty Images Search/Download API

Author: Michael Dela Cuesta

Email: michael.dcuesta@gmail.com

Nuget Url: https://nuget.org/packages/Getty.Images.API/

####Install via Nuget

```C#
Install-Package Getty.Images.API
```

####Starting a Session

```C#
// authorization info
var authInfo = new AuthInfo
{
  SystemId = "",
  SystemPassword = "",
  UserName = "",
  Password = "",
  ConnectionMode = ConnectionMode.Production
};

// instantiate api client
var apiClient = new Client(authInfo);

// creates a session to the api
apiClient.CreateSession();
```


####Authorization Token

after creating a session you can get the authorization token, the authorization token can be use later.  The authorization token expires every 30 mins, but it can be renewed.
```C#
var authToken = apiClient.AuthToken;
```

####Renewing Authorization Token
```C#
var authInfo = new AuthInfo
{
  SystemId = "",
  SystemPassword = "",
  UserName = "",
  Password = "",
  ConnectionMode = ConnectionMode.Production
};

// get saved authorization token
var authToken = GetAuthToken(); 

var apiClient = new Client(authInfo, authToken);

// renews authorization token, expired auth token cannot be renewed
apiClient.RenewSession();
```

####Searching Images
```C#
var apiClient = new Client(authInfo);

var searchRequest = new SearchForImages2RequestBody();
searchRequest.Query = new Query 
{ 
  SearchPhrase ="sand" 
};

searchRequest.ResultOptions = new ResultOptions 
{ 
  ItemCount = 50, 
  ItemStartNumber = 1
};

searchRequest.Filter = new Filter
{
  ImageFamilies = new List<string> { "Creative", "Editorial" },
  LicensingModels = new List<string> { "rightsmanaged", "royaltyfree" }
};

SearchForImagesResult result = apiClient.Search(searchRequest);

foreach (var image in result.Images)
{
  Console.WriteLine(image.Title);
  Console.WriteLine(image.ImageId);
  Console.WriteLine(image.UrlThumb);
  Console.WriteLine(image.UrlPreview);  
}
```

####Searching Images with Paging
```C#
int pageSize = 50;
int page = 2;

int startNumber = pageSize * (page - 1) + 1;

var apiClient = new Client(authInfo);

var searchRequest = new SearchForImages2RequestBody();
searchRequest.Query = new Query 
{ 
  SearchPhrase = "sun" 
};
            
searchRequest.ResultOptions = new ResultOptions 
{ 
  ItemCount = pageSize, 
  ItemStartNumber = startNumber 
};

searchRequest.Filter = new Filter
{
  ImageFamilies = new List<string> { "Creative", "Editorial" },
  LicensingModels = new List<string> { "rightsmanaged", "royaltyfree" }
};

SearchForImagesResult result = apiClient.Search(searchRequest);

Console.WriteLine(string.Format("Result Item Total Count: {0}", result.ItemTotalCount));
Console.WriteLine(string.Format("Result Start Number: {0}", result.ItemStartNumber));
```

####Get Image Details
```C#
var apiClient = new Client(authInfo, authToken);

var searchRequest = new SearchForImages2RequestBody();
searchRequest.Query = new Query { SearchPhrase = "sand" };
searchRequest.ResultOptions = new ResultOptions { ItemCount = 1, ItemStartNumber = 1 };
searchRequest.Filter = new Filter
{
  ImageFamilies = new List<string> { "Creative", "Editorial" },
  LicensingModels = new List<string> { "rightsmanaged", "royaltyfree" }
};
SearchForImagesResult searchResult = apiClient.Search(searchRequest);

var imageIds = new List<string> { searchResult.Images[0].ImageId };

var imageDetailRequestBody = new GetImageDetailsRequestBody
{
  ImageIds = imageIds
};

GetImageDetailsResult imageDetailResult = apiClient.GetDetails(imageDetailRequestBody);

Image image = imageDetailResult.Images[0];
foreach (var size in image.SizesDownloadableImages)
{
  Console.WriteLine(string.Format("Resolution/DPI: {0}", size.ResolutionDpi));
  Console.WriteLine(string.Format("Size Key: {0}"), size.SizeKey);
}
```
