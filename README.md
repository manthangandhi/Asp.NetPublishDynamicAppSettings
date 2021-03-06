﻿# ﻿﻿﻿﻿﻿﻿Asp.NetPublishDynamicAppSettings


This workaround is to demonstrate, changing appsettings.json dynamically for various environments during deployment.


While maintaining and deploying for various environments, there is a lot hassles managing those appsettings.json. So to avoid the those mind bursting hassles, we can leverage this workaround.


**_Let's begin,_**

Place all your required appsettings.json file into your project directory, such as `appsettings.json`  ,  `appsettings.developmet.json` , `appsettings.staging.json`.

Modify your default Startup constructor as this,

```
public Startup(IConfiguration configuration, IHostingEnvironment env)
{
	var builder = new ConfigurationBuilder()
       	.SetBasePath(Directory.GetCurrentDirectory())
	       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       	.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
	       builder.AddEnvironmentVariables();
       	Configuration = builder.Build();
}
```

In the above code snippet, the below line is an important factor that helps us to achieve our goal.

```
.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

```

This helps to load the appsettings.json name dynamically.
So by this it will load the appsettings.json file based on the environment value that we set in our project solution.

To publish the project for different environments, use below command:

```
dotnet publish /p:Configuration=Release /p:EnvironmentName=Staging 

```

This will generate the publish files with a `staging` environment.


Hope it will save your valuable time. :)
