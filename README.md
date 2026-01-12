
# ABC Retail – Azure Cloud Web Application

## Overview
ABC Retail is a cloud-hosted, full-stack e-commerce web application developed as an academic project to demonstrate modern **cloud computing, scalable architecture, and full-stack development** using **Microsoft Azure**.

The application enables management of **products, customer profiles, and orders**, while leveraging multiple **Azure Storage Services** and **Azure SQL Database** to simulate a production-ready cloud solution.

---

## Technologies Used (Tech Stack)

### Frontend
- ASP.NET Core MVC
- Razor Pages
- HTML5, CSS3
- Bootstrap (Responsive UI)

### Backend
- C# (.NET / ASP.NET Core)
- REST-based architecture
- Entity Framework Core

### Cloud & Hosting
- **Microsoft Azure App Service** – Web application hosting
- **Azure Functions** – Serverless automation and background processing

### Azure Storage Services
- **Azure Table Storage** – Customer and product metadata
- **Azure Blob Storage** – Product images and multimedia files
- **Azure Queue Storage** – Order processing and inventory workflows
- **Azure File Storage** – Contracts and application log files

### Database
- **Azure SQL Database**
  - Centralized relational data storage
  - Geo-replication for scalability and disaster recovery

### DevOps & Tools
- Visual Studio
- Azure Portal
- Git & GitHub
- CI/CD-ready architecture

---

## System Architecture

The application follows a **cloud-native, service-oriented architecture**, integrating multiple Azure services to ensure:

- Scalability
- Reliability
- Cost efficiency
- Maintainability

**High-level flow:**
1. User interacts with the web application hosted on Azure App Service
2. Data is stored and retrieved using Azure SQL and Azure Storage services
3. Azure Functions automate background tasks such as transaction processing
4. Azure Queues decouple order processing for reliability
5. Azure Blob and File Storage handle unstructured data

---

## Application Features

### Product Management
- View product catalog
- Store product metadata in Azure Table Storage
- Product images hosted in Azure Blob Storage

### Shopping Cart & Orders
- Add items to cart
- Process orders asynchronously using Azure Queue Storage
- Store order records in Azure SQL Database

### Customer Profiles
- Customer data stored in Azure Table Storage
- Secure data handling and validation

### Cloud Automation
- Azure Functions handle:
  - Order processing
  - Data updates across services
  - Background transaction workflows

---

## Screenshots

### Application Hosted on Azure App Service
<img width="1349" height="729" alt="azure app running" src="https://github.com/user-attachments/assets/18fddf14-f60d-4991-859b-70657db6aba1" />

### Product Catalog Page
<img width="1366" height="768" alt="Screenshot 2024-08-29 122443" src="https://github.com/user-attachments/assets/047277ed-889e-4ed3-851e-8a4441020e26" />

### Products Order History
<img width="1366" height="768" alt="Screenshot 2024-08-29 122515" src="https://github.com/user-attachments/assets/2699f63f-bebd-45ce-8333-4e5af01b0ba0" />

### Shopping Cart
<img width="1366" height="768" alt="Screenshot 2024-08-29 120550" src="https://github.com/user-attachments/assets/226205c5-237a-4cd3-9207-d1ce0d786f9f" />

### Azure Storage Services

###Azure Blob Storage
<img width="1366" height="768" alt="Screenshot 2024-08-29 121454" src="https://github.com/user-attachments/assets/101867a3-f54c-457a-95fe-4b4f829ce4d3" />

### Azure Table Storage
<img width="1366" height="768" alt="Screenshot 2024-08-29 120623" src="https://github.com/user-attachments/assets/e657d136-2039-4611-bd3a-fbeccfaa0133" />
<img width="1366" height="768" alt="Screenshot 2024-08-29 121534" src="https://github.com/user-attachments/assets/7bef5a79-82ba-4ac9-9ec1-89ab2628e3d8" />


### Azure Queue Storage
<img width="1366" height="768" alt="Screenshot 2024-08-29 123512" src="https://github.com/user-attachments/assets/8b6f14e1-1b33-4cfa-a168-9bed28f73cc9" />
<img width="1366" height="768" alt="Screenshot 2024-08-29 123457" src="https://github.com/user-attachments/assets/d6021679-707c-4080-b672-ff4c9816c6c8" />


### Azure File Storage
<img width="1366" height="768" alt="Screenshot 2024-08-29 121418" src="https://github.com/user-attachments/assets/a939e3ba-f39e-403c-8bc8-0f607b04dbbc" />


### Azure SQL Database
<img width="1366" height="768" alt="cloud record database" src="https://github.com/user-attachments/assets/d06c2569-45b7-4d06-899a-86d6b01d9fba" />
<img width="1349" height="720" alt="Database replica" src="https://github.com/user-attachments/assets/b7d85964-4218-4eed-80c4-93d79080f1f6" />

---

## Learning Outcomes

This project demonstrates:
- Full-stack web development using ASP.NET Core
- Cloud-native application design on Microsoft Azure
- Integration of structured and unstructured data storage
- Serverless automation with Azure Functions
- Scalable and reliable cloud architecture
- Secure handling of user and transactional data

---

## How to Run Locally

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
