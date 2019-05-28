@startuml

class Student {
  Id: string
  Name: string
}

class Teacher {
  Id: string
  Name: string
}

class Subject {
  Id: string
  Name: string
  TeacherId: string
}

class Registration {
  Id: int
  StudentId: string
  SubjectId: string
  Semester: string
  Grade: int
}

Teacher .. Subject 
Student .. Registration
Subject .. Registration

@enduml