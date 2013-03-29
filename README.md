Getty.api.NET
=========

.NET library for the Getty Images Search/Download API

Author: Michael Dela Cuesta
Email: michael.dcuesta@gmail.com

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
var apiClient = new Client(authInfo, authToken);

var searchRequest = new SearchForImages2RequestBody();
searchRequest.Query = new Query{ SearchPhrase ="sand" };
searchRequest.ResultOptions = new ResultOptions { ItemCount = 1, ItemStartNumber = 1};

SearchForImagesResult result = apiClient.Search(searchRequest);
```
