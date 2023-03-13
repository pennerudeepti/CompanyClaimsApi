# CompanyClaimsApi
1. Download the Company Claims Api solution from Github repository and execute it.
2.  The CompanyClaims Api solution is built using visual studio 2022, .asp net core web api, c# language.
3.  The CompanyClaims Api is designed as Models, Data, Controller pattern.
4.  The CompanyClaimsController uses repository pattern approach to get the company cliam details.The endpoints like api/CompanyClaims/company//{companyId/}
5.  The CompanyClaimsRepository constructore have sample test data for the api.
6.  This can be tested using Swagger api tool Example: Get Company api endpoint (https://localhost:7013/api/CompanyClaims/company/1?id=1)
7.  The ClaimController uses Asynchronous programming async await and Inmemory database to post, put, get claims. 
8 . This cane be tested using Swagger api tool Example: Execute the post claim method with the required post body Example: Api end point  https://localhost:7013/api/Claim
<!-- {
  "claimId": 1,
  "ucr": "Test ucr",
  "companyId": 1,
  "claimDate": "2023-03-13T11:48:06.879Z",
  "lossDate": "2023-03-13T11:48:06.879Z",
  "assuredName": "",
  "incurredLoss": 0,
  "closed": true,
  "typeId": 1
 } -->
9.  The CompanyClaims Test unit test project is a unit test project using Nunit, Moq.Two unit test cases have been created for now.
10.  We can also improve this api with proper error handling and logging.