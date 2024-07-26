# 🏢 Out of Office
**Out of Office** - is a solution for companies that simplifies the process of how an employee makes a request for time off.

## 🖼️ Application Structure
When you launch the application, you can first see a role selection window:

![image](https://github.com/user-attachments/assets/3cbeeabc-6e58-41b1-b519-91b3d74b065f)

After selecting and confirming one of the options, the form of the corresponding role will open, there are currently **three of them**:

### 🧑‍💼 Employee Form
This form contains two tabs with lists:
- Projects
- Leave Requests

![image](https://github.com/user-attachments/assets/c68f5ddf-7d6b-4e53-a5b0-d308c65ca779)

### 🫂 HR Manager Form
Contains four tabs with lists:
- Employees
- Projects
- Leave Requests
- Approval Requests

![image](https://github.com/user-attachments/assets/e4ada530-61f9-4834-b07b-36e78136b37f)

### 🤵‍♂️ Project Manager Form
Also contains four tabs with lists:
- Employees
- Projects
- Leave Requests
- Approval Requests

![image](https://github.com/user-attachments/assets/63b9def8-5c2b-43f0-8857-a681f9c32e83)

## 💪 App Features
- #### Sort by column content
Click on column header to do it:

![bandicam 2024-07-26 22-21-21-755](https://github.com/user-attachments/assets/37b17cb2-8c33-4b62-aab5-bc7da97f9d50)

- #### See details about
Double click on row with record to see (or even change) details of record in special form:

![image](https://github.com/user-attachments/assets/b1ba598f-8147-4b3a-aada-651695d87a98)

- #### Add new record
Different roles have the ability to create and add new entries to specific lists. 
Click "New [list item name]" button to open new form where you can add data:

![image](https://github.com/user-attachments/assets/89e59c67-0e17-44e6-9ec3-4e14be0ddd80)

- #### Refresh list
Click on bottom right "Refresh" button to do it:

![bandicam 2024-07-26 22-47-39-110](https://github.com/user-attachments/assets/826b2110-1df7-46b6-ae8c-03cb4c1e2a87)

- #### Change role
Click the top right button in the tab to change your role (different roles have different access levels):

![bandicam 2024-07-26 22-34-35-388](https://github.com/user-attachments/assets/f2d98d60-a3dc-404d-bbc0-4f21ce7cf03e)

## 🪴 DB(database) Schema
This is how the DB scheme looks like which is used in the application:

![1 1](https://github.com/user-attachments/assets/0738f5a8-eb4c-443d-8483-c03bd11b1551)

## SQL queries that were used to create the DB:

- **AbsenceReasons**
```sql
CREATE TABLE "AbsenceReasons" (
	"AbsenceReasonID"	INTEGER NOT NULL,
	"AbsenceReasonName"	TEXT NOT NULL,
	CONSTRAINT "PK_AbsenceReasons" PRIMARY KEY("AbsenceReasonID" AUTOINCREMENT)
);
```

- **ApprovalRequests**
```sql
CREATE TABLE "ApprovalRequests" (
	"ApprovalRequestID"	INTEGER NOT NULL,
	"ApproverID"	INTEGER NOT NULL,
	"Comment"	TEXT,
	"LeaveRequestID"	INTEGER NOT NULL,
	"StatusID"	INTEGER NOT NULL,
	CONSTRAINT "PK_ApprovalRequests" PRIMARY KEY("ApprovalRequestID" AUTOINCREMENT),
	CONSTRAINT "FK_ApprovalRequests_Employees_ApproverID" FOREIGN KEY("ApproverID") REFERENCES "Employees"("EmployeeID"),
	CONSTRAINT "FK_ApprovalRequests_LeaveRequests_LeaveRequestID" FOREIGN KEY("LeaveRequestID") REFERENCES "LeaveRequests"("LeaveRequestID"),
	CONSTRAINT "FK_ApprovalRequests_LeaveStatuses_StatusID" FOREIGN KEY("StatusID") REFERENCES "LeaveStatuses"("LeaveStatusID")
);
```

- **EmployeeProjects**
```sql
CREATE TABLE "EmployeeProjects" (
	"EmployeeId"	INTEGER NOT NULL,
	"ProjectId"	INTEGER NOT NULL,
	CONSTRAINT "FK_EmployeeProjects_Employees_EmployeeId" FOREIGN KEY("EmployeeId") REFERENCES "Employees"("EmployeeID") ON DELETE CASCADE,
	CONSTRAINT "FK_EmployeeProjects_Projects_ProjectId" FOREIGN KEY("ProjectId") REFERENCES "Projects"("ProjectID") ON DELETE CASCADE,
	CONSTRAINT "PK_EmployeeProjects" PRIMARY KEY("EmployeeId","ProjectId")
);
```

- **Employees**
```sql
CREATE TABLE "Employees" (
	"EmployeeID"	INTEGER NOT NULL,
	"FullName"	TEXT NOT NULL,
	"OutOfOfficeBalance"	REAL NOT NULL,
	"PeoplePartnerID"	INTEGER NOT NULL,
	"PhotoID"	INTEGER,
	"PositionID"	INTEGER NOT NULL,
	"StatusID"	INTEGER NOT NULL,
	"SubdivisionID"	INTEGER NOT NULL,
	CONSTRAINT "FK_Employees_Photos_PhotoID" FOREIGN KEY("PhotoID") REFERENCES "Photos"("PhotoID"),
	CONSTRAINT "FK_Employees_Employees_PeoplePartnerID" FOREIGN KEY("PeoplePartnerID") REFERENCES "Employees"("EmployeeID"),
	CONSTRAINT "FK_Employees_Positions_PositionID" FOREIGN KEY("PositionID") REFERENCES "Positions"("PositionID"),
	CONSTRAINT "FK_Employees_Statuses_StatusID" FOREIGN KEY("StatusID") REFERENCES "Statuses"("StatusID"),
	CONSTRAINT "FK_Employees_Subdivisions_SubdivisionID" FOREIGN KEY("SubdivisionID") REFERENCES "Subdivisions"("SubdivisionID"),
	CONSTRAINT "PK_Employees" PRIMARY KEY("EmployeeID" AUTOINCREMENT)
);
```

- **LeaveRequests**
```sql
CREATE TABLE "LeaveRequests" (
	"LeaveRequestID"	INTEGER NOT NULL,
	"AbsenceReasonID"	INTEGER NOT NULL,
	"Comment"	TEXT,
	"EmployeeID"	INTEGER NOT NULL,
	"EndDate"	datetime NOT NULL,
	"StartDate"	datetime NOT NULL,
	"Status"	INTEGER NOT NULL,
	CONSTRAINT "FK_LeaveRequests_Employees_EmployeeID" FOREIGN KEY("EmployeeID") REFERENCES "Employees"("EmployeeID"),
	CONSTRAINT "FK_LeaveRequests_LeaveStatuses_Status" FOREIGN KEY("Status") REFERENCES "LeaveStatuses"("LeaveStatusID"),
	CONSTRAINT "FK_LeaveRequests_AbsenceReasons_AbsenceReasonID" FOREIGN KEY("AbsenceReasonID") REFERENCES "AbsenceReasons"("AbsenceReasonID"),
	CONSTRAINT "PK_LeaveRequests" PRIMARY KEY("LeaveRequestID" AUTOINCREMENT)
);
```

- **LeaveStatuses**
```sql
CREATE TABLE "LeaveStatuses" (
	"LeaveStatusID"	INTEGER NOT NULL,
	"LeaveStatusName"	TEXT NOT NULL,
	CONSTRAINT "PK_LeaveStatuses" PRIMARY KEY("LeaveStatusID" AUTOINCREMENT)
);
```

- **Photos**
```sql
CREATE TABLE "Photos" (
	"PhotoID"	INTEGER NOT NULL,
	"FilePath"	TEXT NOT NULL,
	CONSTRAINT "PK_Photos" PRIMARY KEY("PhotoID" AUTOINCREMENT)
);
```

- **Positions**
```sql
CREATE TABLE "Positions" (
	"PositionID"	INTEGER NOT NULL,
	"PositionName"	TEXT NOT NULL,
	CONSTRAINT "PK_Positions" PRIMARY KEY("PositionID" AUTOINCREMENT)
);
```

- **ProjectTypes**
```sql
CREATE TABLE "ProjectTypes" (
	"ProjectTypeID"	INTEGER NOT NULL,
	"ProjectTypeName"	TEXT NOT NULL,
	CONSTRAINT "PK_ProjectTypes" PRIMARY KEY("ProjectTypeID" AUTOINCREMENT)
);
```

- **Projects**
```sql
CREATE TABLE "Projects" (
	"ProjectID"	INTEGER NOT NULL,
	"ProjectName"	TEXT NOT NULL,
	"ProjectTypeID"	INTEGER NOT NULL,
	"StartDate"	datetime NOT NULL,
	"EndDate"	datetime,
	"ProjectManagerID"	INTEGER NOT NULL,
	"Comment"	TEXT,
	"StatusID"	INTEGER NOT NULL,
	CONSTRAINT "FK_Projects_Statuses_StatusID" FOREIGN KEY("StatusID") REFERENCES "Statuses"("StatusID"),
	CONSTRAINT "FK_Projects_ProjectTypes_ProjectTypeID" FOREIGN KEY("ProjectTypeID") REFERENCES "ProjectTypes"("ProjectTypeID"),
	CONSTRAINT "FK_Projects_Employees_ProjectManagerID" FOREIGN KEY("ProjectManagerID") REFERENCES "Employees"("EmployeeID"),
	CONSTRAINT "PK_Projects" PRIMARY KEY("ProjectID" AUTOINCREMENT)
);
```

- **Statuses**
```sql
CREATE TABLE "Statuses" (
	"StatusID"	INTEGER NOT NULL,
	"StatusName"	TEXT NOT NULL,
	CONSTRAINT "PK_Statuses" PRIMARY KEY("StatusID" AUTOINCREMENT)
);
```

- **Subdivisions**
```sql
CREATE TABLE "Subdivisions" (
	"SubdivisionID"	INTEGER NOT NULL,
	"SubdivisionName"	TEXT NOT NULL,
	CONSTRAINT "PK_Subdivisions" PRIMARY KEY("SubdivisionID" AUTOINCREMENT)
);
```

+ Automatically generated tables **__EFMigrationsHistory** & **sqlite_sequence**

## P.S.
Yes, there's a lot of hardcode and violations of DRY principles, and I know that. The application was developed in a hurry😩
So, I will be very grateful for any feedback!
