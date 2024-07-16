# PatientsAPI

Using this database, implemented with "code first"
Technologies used: Entity Framework, Swagger
![image](https://github.com/user-attachments/assets/71e72067-b448-4a3d-9f51-8a0faf1da3fd)

This API allows to use these endpoints:

-Create Prescription Endpoint

This functionality provides an API endpoint to issue a new prescription. The endpoint accepts and processes data about the patient, the prescription, and the prescribing doctor. It includes validation and error handling for non-existent patients and medications, as well as checks for prescription constraints.

Endpoint: /api/prescription
Method: POST

-Patient Data Endpoint

his functionality provides an API endpoint to display comprehensive data about a specific patient. The endpoint retrieves and presents the following information:

Patient Details: General information about the patient.
Prescriptions: A list of prescriptions the patient has received.
Medications: Details of the medications the patient has taken.
Doctors: Information about the doctors who prescribed the medications.

Endpoint: /api/patient/{patientId}
Method: GET

** Whole project was done using the rules such as: REST, SOLID, DRY, YAGNI, KISS
