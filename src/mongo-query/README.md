# การเขียน Mongo query selectors

[(Official) Query and Projection Operators](https://docs.mongodb.com/manual/reference/operator/query/)

## Comparison - คำสั่งในการเปรียบเทียบค่า
|Name|Description|Sample|
|--|--|--|
|$eq|==|{ field: { $eq: value } }|
|$gt|>|{ field: { $gt: value } }|
|$gte|>=|{ field: { $gte: value } }|
|$lt|<|{ field: { $lt: value }|
|$lte|<=|{ field: { $lte: value }|
|$ne|!=|{ field: { $ne: value }|
|$in|Any|{ field: { $in: [value1, value2, ... valueN ] } }|
|$nin|!Any|{ field: { $nin: [value1, value2, ... valueN ] } }|

### Example
|_id|name|qty|
|--|--|--|
|1|A|15|
|2|B|20|
|3|C|25|
|4|D|20|

```
db.inventory.find( { qty: { $eq: 20 } } )

[
    { _id: 2, name: B, qty: 20 },
    { _id: 4, name: D, qty: 20 },
]
```

## Logical
|Name|Description|Sample|
|--|--|--|
|$and| & |{ $and: [ { expression1 }, { expression2 } , ... , { expressionN } ] }|
|$or|OR|{ $or: [ { expression1 }, { expression2 }, ... , { expressionN } ] }|
|$not|!|{ field: { $not: { operator-expression } } }|
|$nor|!Any|{ $nor: [ { expression1 }, { expression2 }, ...  { expressionN } ] }|

### Example
|_id|name|qty|
|--|--|--|
|1|A|15|
|2|B|20|
|3|C|25|
|4|D|20|

```
db.inventory.find( { $or: [ { name: "A" }, { qty: { $gte: 25 } } ] } )

[
    { _id: 1, name: A, qty: 15 },
    { _id: 3, name: C, qty: 25 },
]
```

## Element
|Name|Description|Sample|
|--|--|--|
|$exists|มีฟิล์นั้นอยู่หรือไม่|{ field: { $exists: boolean } }|

### Example
|_id|name|qty|
|--|--|--|
|1|A|15|
|2|B|20|
|3|C|25|
|4|D|20|
|5|E|null|
|6|F||

```
db.inventory.find( { qty: { $exists: false } } )

[
    { _id: 6, name: F },
]
```
```
db.inventory.find( { qty: { $exists: true, $gte: 25 } } )

[
    { _id: 3, name: C, qty: 25 },
]
```

# Mongo Shell Methods

|Method|C#|
|--|--|
|.find()|Where|
|.count()|Count|
|.limit()|Take|
|.sort(sort)|(1:OrderByAscending) (-1:OrderByDescending)|

### Example
|_id|name|qty|
|--|--|--|
|1|A|15|
|2|B|20|
|3|C|25|
|4|D|20|

```
db.inventory.find({}).count()
4
```
```
db.inventory.find({}).limit(2)
[
    { _id: 1, name: "A", qty: 15 },
    { _id: 2, name: "B", qty: 20 }
]
```
```
db.inventory.find({}).sort({qty: -1})
[
    { _id: 3, name: "C", qty: 25 },
    { _id: 2, name: "B", qty: 20 },
    { _id: 4, name: "D", qty: 20 },
    { _id: 1, name: "A", qty: 15 },
]
```

# Regular Expressions (RegEx)

[https://regexr.com](https://regexr.com)

|_id|name|
|--|--|
|1|alley|
|2|bld1v155746295612912500012|
|3|bld1v155746367813912500012|
|4|bldlst1v21205062006007|
|5|unt1v155746296699312500012|
|6|unt1v155746368906012500012|
|7|unt4b1vbld1v155746295612912500012|

```
db.inventory.find({ name: /unt1/ })

[
    { _id: 5, name: "unt1v155746296699312500012" },
    { _id: 6, name: "unt1v155746368906012500012" },
]
```
