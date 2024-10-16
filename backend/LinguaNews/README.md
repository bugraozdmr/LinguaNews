<p align=center>
  <br>
  <span>LinguaNews Api Endpoints</span>
  <br>
</p>

For postmen json file uploaded.

## News
1.
##### Get All News
* `GET /news?pageindex=1&pagesize=10&query=Machine`

2.
##### Get News By Slug
* `GET /news/machine-learning`

3.
##### Create News
* `Post /news`
```json
{
    "Title" : "Title",
    "Intermediate" : "Intermediate",
    "Beginner" : "Beginner",
    "Advanced" : "Advanced",
    "Image" : "Image",
    "CategoryId" : 1
}
```

4.
##### Update News
* `Put /news`
```json
{
    "Id" : "254826f7-ccef-4979-b829-1c82f028abbc",
    "Title" : "Title 12 buğra",
    "Intermediate" : "Intermediate 1",
    "Beginner" : "Beginner",
    "Advanced" : "Advanced",
    "Image" : "Image",
    "CategoryId" : 2
}
```

5.
##### Delete News
* `Delete /news/93b71e39-c7ce-417c-9b6c-5fc25cec9285`

<hr>

## Categories

1.
##### Get All Categories
* `GET /category/all`

2.
##### Get Category By Id
* `GET /category/1`

3.
##### Create Category
* `Post /category`
```json
{
    "Name":"Category",
    "Description":"Description",
    "Image":"CustomImage"
}
```

4.
##### Update Category
* `Put /category`
```json
{
    "Id" : 11,
    "Name":"Category 1",
    "Description":"",
    "Image":"Image"
}
```

5.
##### Delete Category
* `Delete /category/1`

<hr>

###### Health Check
* `Get /health`