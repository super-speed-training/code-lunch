# ประเภทของ model

## Internal model
* เป็น model ที่ใช้ในการคุยกันภายใน backend ด้วยกันเอง สามารถใช้กับ database model ได้เลย

**ตัวอย่าง**

ข้อมูล นักเรียน ที่เก็บไว้ใน database 

|Id|Name|BirthDate|CreationDateTime|ClassRoomId|
|--|--|--|--|--|
|s000001|Shayan Bains|01/01/2010|01/01/2019|c01|
|s000002|Arnold Wallis|15/07/2011|01/01/2019|c01|
|s000003|Macey Blanchard|07/12/2015|01/01/2019|c02|
|s000004|Fatima Larson|21/11/2016|01/01/2019|c02|

หน้าตา model
```
public class StudentInfo
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreationDateTime { get; set; }
    public string ClassRoomId { get; set; }
}
```

## External model
* เป็น model ที่ใช้ในการคุยกับของนอกระบบ backend หรือใช้กับพวก view ห้ามเอา database model ไปใช้

**ตัวอย่าง**

หน้า UI ที่นำข้อมูลไปแสดงผล

รหัสประจำตัวนักเรียน: `s000001`  
ชื่อ `Shayan Bains`  
วันเกิด `01/01/2010`  
อายุ `9` ปี  
ชั้นเรียน `ม.6/3`

หน้าตา model ของ student สำหรับแสดงในหน้า profile
```
public class StudentInfo
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public int Age => BirthDate.Year;
    public string ClassRoomName { get; set; }
}
```