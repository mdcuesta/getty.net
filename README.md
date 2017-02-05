Getty.Images.API for .NET
=========

Note: No longer maintained.  Getty Images has created an official client for their API starting 2015. See https://www.nuget.org/packages/GettyImages.Api/


.NET library for the Getty Images Search/Download API.

Version: 1.0.0.4

Author: Michael Dela Cuesta

Email: michael.dcuesta@gmail.com

Nuget Url: https://nuget.org/packages/Getty.Images.API/

Getty API Console Documentation: https://api.gettyimages.com/page/api-console

####Note from author 

I don't work for Getty Images.  I created this library for a project I'm working on for my employer. 

If you have encountered issues please report to michael.dcuesta@gmail.com or submit an issue to https://github.com/mdcuesta/getty.net/issues.


####Install via Nuget

```C#
Install-Package Getty.Images.API
```

####Starting a Session

```C#
// authorization info
var authInfo = new AuthInfo
{
  SystemId = "your_system_id",
  SystemPassword = "your_system_password",
  UserName = "some_username",
  Password = "some_password",
  ConnectionMode = ConnectionMode.Production
};

// instantiate api client
var apiClient = new Client(authInfo);

// creates a session to the api
apiClient.CreateSession();
```


####Authorization Token

after creating a session you can get the authorization token, the authorization token can be used later.  The authorization token expires every 30 mins, but it can be renewed.
```C#
var authToken = apiClient.AuthToken;

var newApiClient = new Client(authInfo, authToken);
```

####Renewing Authorization Token
```C#
var authInfo = new AuthInfo
{
  SystemId = "your_system_id",
  SystemPassword = "your_system_password",
  UserName = "some_username",
  Password = "some_password",
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
var apiClient = new Client(authInfo);

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
  Console.WriteLine(string.Format("Size Key: {0}", size.SizeKey));
}
```

####Get Image Download Authorizations

```C#
var apiClient = new Client(authInfo);

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
SizesDownloadableImage imageSize = image.SizesDownloadableImages[0];              


var downloadAuthorizationRequestBody = new GetImageDownloadAuthorizationsRequestBody
{
  ImageSizes = new List<ImageSize> 
  { 
    new ImageSize 
    { 
      ImageId = image.ImageId, 
      SizeKey = imageSize.SizeKey 
    }                
  }    
};

GetImageDownloadAuthorizationsResult result = 
  apiClient.GetImageDownloadAuthorizations(downloadAuthorizationRequestBody);

Console.WriteLine(result.Images[0].Authorizations[0].DownloadToken);
```

####Get Largest Image Download Authorizations

```C#
var apiClient = new Client(authInfo);

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

var downloadAuthorizationRequestBody = new GetLargestImageDownloadAuthorizationsRequestBody
{
  Images = new List<Image> { image }
};

GetImageDownloadAuthorizationsResult result =
  apiClient.GetLargestImageDownloadAuthorizations(downloadAuthorizationRequestBody);

Console.WriteLine(result.Images[0].Authorizations[0].DownloadToken);
```

###Create Download Request
```C#
var apiClient = new Client(authInfo);

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
SizesDownloadableImage imageSize = image.SizesDownloadableImages[0];


var downloadAuthorizationRequestBody = new GetImageDownloadAuthorizationsRequestBody
{
  ImageSizes = new List<ImageSize> 
  { 
    new ImageSize 
    { 
      ImageId = image.ImageId, 
      SizeKey = imageSize.SizeKey 
    }                
  }
};

GetImageDownloadAuthorizationsResult authorizationResult =
  apiClient.GetImageDownloadAuthorizations(downloadAuthorizationRequestBody);

string downloadToken = authorizationResult.Images[0].Authorizations[0].DownloadToken;

var createDownloadRequestBody = new CreateDownloadRequestBody
{
  DownloadItems = new List<DownloadItem> 
  {
    new DownloadItem { DownloadToken = downloadToken }
  }
};

CreateDownloadRequestResult result = apiClient.RequestDownload(createDownloadRequestBody);

Console.WriteLine(result.DownloadUrls[0].UrlAttachment);
```

####Search for Videos

```C#
var apiClient = new Client(authInfo);

var searchRequest = new SearchForVideosRequestBody();
searchRequest.Query = new Query { SearchPhrase = "Man jumps onto rock" };
searchRequest.ResultOptions = new ResultOptions { ItemCount = 1, ItemStartNumber = 1 };
searchRequest.Filter = new VideoSearchFilter 
{ 
  AssetFamilies = new List<string> 
  { 
    "Creative",
    "Editorial"
  }
};

SearchForVideosResult result = apiClient.SearchForVideos(searchRequest);
List<Video> videos = result.Videos;

Video video = videos[0];
```
