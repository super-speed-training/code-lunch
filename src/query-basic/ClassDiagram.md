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
}

Teacher .. Subject 
Student .. Registration
Subject .. Registration

@enduml