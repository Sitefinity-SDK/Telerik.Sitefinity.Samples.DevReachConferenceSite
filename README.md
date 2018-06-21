DevReachConferenceSite
=====================================

>**Latest supported version**: Sitefinity CMS 11.0.6700.0

### Overview

The DevReach sample project demonstrates how to create a simple conference site utilizing the Related Data feature capabilities.

Using the DevReach sample, you can:

* Set up a working solution for conference site
* Create relations between different type of items
* Related items in the back end and easily display them in the front end
* View examples of RelatedData API

### Prerequisites

- You must have a Sitefinity CMS license.
- Your setup must comply with the system requirements.  
 For more information, see the [System requirements](https://docs.sitefinity.com/system-requirements) for the  respective Sitefinity CMS version.

### Installation

1. Restore the database.  
 a. In SQL Management Studio, open the context menu of _Databases_ and click _Restore Database..._  
 b. Select _Device >> ... >> Add_ and navigate to the `~\SitefinityWebApp` folder and select.  
 c. Select the `DevReach.bak` file and click _OK >> OK >> OK_.  
2. Modify the connection string.  
 a. Open the downloaded project in Visual Studio.  
 b. In the _Solution Explorer_, navigate to _SitefinityWebApp >> App_Data >> Sitefinity >> Configuration_.  
 b. Open the `DataConfig.config` file and modify the `connectionString` value to match your server address.  
 c. Build the solution.
2. Clear the NuGet cache files.  
 a. Open the `BugTracker` solution file in Visual Studio.  
 b. In the toolbar, navigate to _Tools >> NuGet Package Manager >> Package Manager Settings_.  
 c. In the left pane, navigate to _NuGet Package Manager >> General_.  
 d. Click _Clear All NuGet Cache(s)_.
3. Restore the NuGet packages in the solution.  
   
   >**NOTE**: The solution in this repository relies on NuGet packages with automatic package restore while the build procedure takes place.   
   >For a full list of the referenced packages and their versions see the [packages.config](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.BugTracker/blob/master/SitefinityWebApp/packages.config) file.    
   >For a history and additional information related to package versions on different releases of this repository, see the [Releases page](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.BugTracker/releases).
   >  
   a. Navigate to _Tools >> NuGet Package Manager >> Package Manager Console_.  
   b. In _Source_, select Sitefinity CMS NuGet Repository.  
   c. Click _Restore_ button.

### Login

1. In the context menu of SitefinityWebApp, click _View >> View in Browser_.  
 After the project initializes, the _License activation_ page appears.
2. Activate your license.  
 For more information, see [Activate a license](http://docs.sitefinity.com/activate-a-license).
3. To login into the Sitefinity CMS backend, use the following credentials:  
 **Username:** admin  
 **Password:** password

### Additional resources

#### Youtube video:   
Check the follow up [video](https://www.youtube.com/watch?v=WVKasAtZZYk) for the Sitefinity partner webinar aired on 08 April 2014.    
[![Related Content](https://raw.githubusercontent.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.DevReachConferenceSite/master/EmbedVideo.png)](http://youtu.be/WVKasAtZZYk)

#### Progress Sitefinity CMS Documentation:   
Sitefinity CMS enables you relate content to any other content, thus relating items of different types. For  developer documentation about this powerful _Related data_ field can be at [Content relations: Related data](http://docs.sitefinity.com/content-relations-related-data).
