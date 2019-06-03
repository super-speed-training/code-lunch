# MongoDB CRUD

[Official document](https://docs.mongodb.com/manual/core/crud)

```
Working code ≠ Production code
```

# Create
![img](assets/single-user.JPG)
* collection.**InsertOne()**
* collection.**InsertOneAsync()**

![img](assets/multi-users.JPG)
* collection.**InsertMany()**
* collection.**InsertManyAsync()**

![img](assets/group-users.png)
* collection.**BulkWrite()**
* collection.**BulkWriteAsync()**

# Read
* collection.**Find()**
* collection.**FindAsync()**
* ~~collection.**FindOneAndDelete()**~~ ❌
* ~~collection.**FindOneAndDeleteAsync()**~~ ❌
* ~~collection.**FindOneAndReplace()**~~ ❌
* ~~collection.**FindOneAndReplaceAsync()**~~ ❌
* ~~collection.**FindOneAndUpdate()**~~ ❌
* ~~collection.**FindOneAndUpdateAsync()**~~ ❌

![img](assets/single-user.JPG)
* collection.Find().**Count()**
* collection.Find().**CountAsync()**
* collection.Find().**Any()**
* collection.Find().**AnyAsync()**

![img](assets/single-user.JPG) + Data
* ~~collection.Find().**First()**~~ ❌
* ~~collection.Find().**FirstAsync()**~~ ❌
* collection.Find().**FirstOrDefault()**
* collection.Find().**FirstOrDefaultAsync()**

![img](assets/multi-users.JPG)
* collection.Find().**ToList()**
* collection.Find().**ToListAsync()**

![img](assets/multi-users.JPG) + Transformation
* collection.Find().ToEnumerable()**.Select()**.ToListAsync()
* collection.Find().ToEnumerable()**.SelectMany()**.ToListAsync()

# Update
![img](assets/single-user.JPG)
* collection.**UpdateOne()**
* collection.**UpdateOneAsync()**
* ~~collection.**ReplaceOne()**~~ ❓
* ~~collection.**ReplaceOneAsync()**~~ ❓

![img](assets/multi-users.JPG)
* collection.**UpdateMany()**
* collection.**UpdateManyAsync()**

![img](assets/group-users.png)
* collection.**BulkWrite()**
* collection.**BulkWriteAsync()**

## Definitions
```
var def = Builders<Student>.Update
    .Set(it => it.Name, "John")
    .Set(it => it.Grade, "A");  
collection.Update(it => it.id == "s05", def);
```

## Upsert
Upsert Option
If `updateOne()`, `updateMany()`, or `replaceOne()` includes upsert : true and no documents match the specified filter, then the operation creates a new document and inserts it. If there are matching documents, then the operation modifies or replaces the matching document or documents.
```
var def = Builders<Student>.Update.Set(it => it.Name, "John");
collection.Update(it => it.id == "s05", def, new UpdateOptions { IsUpsert = true })
```

# Delete
![img](assets/single-user.JPG)
* ~~collection.**DeleteOne()**~~ ❌
* ~~collection.**DeleteOneAsync()**~~ ❌

![img](assets/multi-users.JPG)
* ~~collection.**DeleteMany()**~~ ❌
* ~~collection.**DeleteManyAsync()**~~ ❌

![img](assets/group-users.png)
* ~~collection.**BulkWrite()**~~ ❌
* ~~collection.**BulkWriteAsync()**~~ ❌

> Update > Delete

# Definitions
```
Builders<SurveyData>.Update  
Builders<SurveyData>.Filter  
Builders<SurveyData>.Sort  
```
