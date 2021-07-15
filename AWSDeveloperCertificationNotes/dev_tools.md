# Intro to AWS Development Tools

## Systems development life cycle
* Software development goes through a series of phases in the systems development lifecycle (SDLC). The SDLC is a conceptual model used in project management. It describes the stages in an information system development project, from an initial feasibility study to the maintenance of the completed application.
* In general, an SDLC methodology follows these steps: plan, define, design, develop, deploy and maintain. 
* The Developer cetification focuses on the Develop phase. In the Develop phase, the new system is developed. New components and programs must be obtained and installed. System users must be trained, and all aspects of the system’s performance must be tested. If necessary, bugs must be fixed and adjustments must be made to improve performance.

### SDLC Methodologies
* Waterfall (or traditional) methodology: This is often considered the classic approach to the SDLC. The waterfall model describes a sequential development method in which each development phase has distinct goals and tasks that must completed before the next phase can begin. Under this paradigm, product teams might not hear back from customers for months, and often not until the product is commercialized.
* Agilesoftware developmentmethodology:Agile is a new conceptual framework that supports fast-paced, iterative software development. Under this new paradigm, product teams push their work to customers as quickly as possible so that they can collect feedback and improve the previous iteration of their products. Concepts such as minimum viable product (MVP), release candidate, velocity, etc. are all derived from this new approach. There are a number of agile software developmentmethodologies, e.g., Crystal methods, Dynamic Systems Development Method (DSDM), and Scrum. Under agile, software is developed iteratively in short time periods called sprints, which typically last 1 –4 weeks.

### Five Phases of Software Development
* Code - developers write application source code and check changes into a source code repository, such as a Git repository or AWS CodeCommit. Many teams use code reviews to provide peer feedback of code quality before they ship code into production. Other teams use pair programming as a way to provide real-time peer feedback.
* Build - an application’s source code is compiled and the quality of the code is tested on the build machine. The most common type of quality check is an automated test that does not require a server in order to run. These quality tests can be initiated from a test harness. Some teams extend their quality tests to include code metrics and style checks.
* Test - additional tests are performed that cannot be done during the Build phase. These tests require the software to be deployed to a production-like environment. Often, these tests include integration testing with other live systems, load testing, user interface (UI) testing, and penetration testing. A common pattern is for engineers to deploy builds to a personal development stage where they can check that their automated tests work correctly. They then deploy to pre-production stages where their application interacts with other systems to ensure that the software works in an integrated environment.
* Deploy - Though there are different deployment strategies, the common goal is to reduce risk when deploying new changes and to minimize the impact if a bad change is released to production.
* Maintain - After code is deployed, it must be monitored in production to determine if everything works as expected.

## Steps to get started developing on AWS
## Fundamentals of working with AWS software development kits (SDKs)
## Errors and exceptions
## Introduction to AWS X-Ray
## Introduction to Amazon CloudWatch and AWS CloudTrail
