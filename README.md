
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
![Product Catalog](screenshots/catalog-page.png)

### Product Items (Shoes)
![Product Items](screenshots/product-items.png)

### Shopping Cart
![Shopping Cart](screenshots/cart-page.png)

### Azure Storage Services
**Azure Blob Storage**
![Blob Storage](screenshots/blob-storage.png)

**Azure Table Storage**
![Table Storage](screenshots/table-storage.png)

**Azure Queue Storage**
![Queue Storage](screenshots/queue-storage.png)

**Azure File Storage**
![File Storage](screenshots/file-storage.png)

### Azure SQL Database
![Azure SQL Database](screenshots/azure-sql.png)

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
