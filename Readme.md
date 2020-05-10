# EmailService

<img src="https://codeopinion.com/wp-content/uploads/2018/07/Bitmap-MEDIUM_ASP.NET-Core-Logo_2colors_Square_RGB.png" width="120">

#### Setup Env variables
```
    SMTP_CLIENT
    CLIENT_PORT
    SENDER_AUTH_NAME
    SENDER_AUTH_PASS
    SENDER_NAME
```

#### Request format
```
{
	"subject": "string",
	"body": "string",
	"to": [
	    {"name": "string", "address": "validEmailString"}, 
	    {"name": "string", "address": "validEmailString"}
	 ]
}
```
