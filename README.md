# Introduction

Job Opening Manager was built for creating,updating and viewing jobs based on their departments and locations of offices.

## Authorization

All API requests require the use of a generated API key(Bearer Token). You can generate a new one, by registering yourself using the Register(if not registered) and Login functionalities.

### Request

`GET /register/`

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `email` | `string` | **Required**. Your Email Id |
| `password` | `string` | **Required**. Your Password |

### Response

    HTTP/1.1 200 OK

### Request

`GET /login/`

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `email` | `string` | **Required**. Your Email Id |
| `password` | `string` | **Required**. Your Password |
| `twoFactorCode` | `string` | **Optional**. 2FA Code  |
| `twoFactorRecoveryCode` | `string` | **Optional**. 2FA Recovery Code |


### Response

```javascript
{
  "tokenType": "string",
  "accessToken": "string",
  "expiresIn": 0,
  "refreshToken": "string"
}
```

To authenticate an API request, you should provide your Bearer Token in the `Authorization` header as Bearer {Token}.

## Job Management APIs
 ### Job Opening APIs
 ### Create/Add a new Job

 ### Request

`POST /v1/jobs/`

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `title` | `string` | **Required**. Job Title To be Added |
| `description` | `string` | **Required**. Job Description To be Added |
| `locationId` | `int` | **Required**. Id of the location where the there is a job opening |
| `departmentId` | `int` | **Required**. Id of the department in whihc there is an opening |
| `closingDate` | `DateTime` | **Required**. The date on whihc this Job opening will be closed |


### Response

```javascript
{
  "outputURL": "string" //Provides the URL  of the API along wth the route and the newly created Job Id.
}
```

 ### Update Department Information
  This API updates the department details. Request and Response structure is provided below:
  
  ### Request

`PUT /v1/jobs/{id}`

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `id` | `int` | **Required**. Id based on which the Job details will be updated |
| `title` | `string` | **Optional**. Job Title To be Updated |
| `description` | `string` | **Optional**. Job Description To be Updated |
| `locationId` | `int` | **Optional**. Id of the location where the there is a job opening |
| `departmentId` | `int` | **Optional**. Id of the department in whihc there is an opening |
| `closingDate` | `DateTime` | **Optional**. The date on whihc this Job opening will be closed |

### Response

```javascript
  200 OK
  Updated 1 row(s) successfully
```

 ### Retrieve Job Details Based On Id.
  This API fetches Job Details based on teh Id provided.
  
 ### Request

`GET /v1/jobs/{id}`

### Response

```javascript
 {
  "id": int,
  "code": "string",
  "title": "string",
  "description": "string",
  "location": {
    "id": int,
    "title": "string",
    "city": "string",
    "state": "string",
    "country": "string",
    "zip": int
  },
  "department": {
    "id": int,
    "title": "string"
  },
  "postedDate": "string", //formatted as MM-DD-YYYY
  "closingDate": "string"  //formatted as MM-DD-YYYY
}
```

 ### Retrieve Job Listing based on Search Parameter or location Id or department Id.
  This API fetches a list of hobs that matches the search text provided or based on location Id/Department Id provided.
  
 ### Request

`POST /v1/jobs/list`

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `q` | `string` | **Required**. SearchText to find the jobs based on the title/description of job or the title of locations/departments |
| `pageNo` | `string` | **Required**. Used for pagination to denote Page Number  |
| `pageSize` | `string` | **Required**.  Used for pagination denotes the number of jobs to be fetched |
| `locationId` | `string` | **Optional**. Location Id where the job is located, will search based on that |
| `departmentId` | `string` | **Optional**.  Department Id in which the job has an opening, will search based on that |

### Response

```javascript
 {
  "totals": int,
  "data": [
    {
      "id": int,
      "code": "string",
      "title": "string",
      "location": "string",
      "department": "string",
      "postedDate": "DateTime",
      "closingDate": "DateTime"
    }
  ]
}
```


 ### Departments APIs 
 ### Create/Add a new Department
  This API creates a department. Request and Response structure is provided below:
  
  ### Request

`POST /v1/department/`

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `title` | `string` | **Required**. Department Title To be Added(Example: Project Management, Accounting, etc) |


### Response

```javascript
{
  "outputURL": "string" //Provides the URL  of the API along wth the route and the newly created department Id.
}
```

 ### Update Department Information
  This API updates the department details. Request and Response structure is provided below:
  
  ### Request

`PUT /v1/department/{id}`

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `id` | `int` | **Required**. Id based on which the Department details will be updated |
| `title` | `string` | **Optional**. Title can be provided if it needs to be updated |


### Response

```javascript
  200 OK
  Updated 1 row(s) successfully
```
 ### Retrieve All Departments Info.
  This API fetches all the existing and newly created department information.
 ### Request

`GET /v1/departments`

### Response

```javascript
 [
  {
    "id": int,
    "title": "string"
  }
]
```
### Location APIs 
 ### Create/Add Locations 
  This API creates/adds a location where the job opening is added. Request and Response structure is provided below:
  
  ### Request

`POST /v1/location/`

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `title` | `string` | **Required**. Location Title To be Added(Example: India Office, USA Office) |
| `city` | `string` | **Required**.  City where the office is located. |
| `state` | `string` | **Required**. State where the office is located |
| `country` | `string` | **Required**. Country in which the office is located |
| `zip` | `string` | **Required**. Zip of the Office located |



### Response

```javascript
{
  "outputURL": "string" //Provides the URL  of the API along wth the route and the newly created location Id.
}
```
 ### Update Location Information 
  This API updates the department details. Request and Response structure is provided below:
  
  ### Request

`PUT /v1/locations/{id}`

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `id` | `int` | **Required**. Id based on which the Department details will be updated |
| `title` | `string` | **Optional**. Location Title To be Updated(Example: India Office, USA Office) |
| `city` | `string` | **Optional**.  City where the office is located. |
| `state` | `string` | **Optional**. State where the office is located |
| `country` | `string` | **Optional**. Country in which the office is located |
| `zip` | `string` | **Optional**. Zip of the Office located |


### Response

```javascript
  200 OK
  Updated 1 row(s) successfully
```

 ### Retrieve all Locations Information
 This API fetches all the existing and newly created location along with additional information.
### Request

`GET /v1/locations`

### Response

```javascript
 [
  {
    "id": int,
    "title": "string",
    "city": "string",
    "state": "string",
    "country": "string",
    "zip": "string"
  }
]
```


















 
      
