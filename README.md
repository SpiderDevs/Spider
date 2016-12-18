# Spider
License: MIT

I just start a works. So in code is a lot of TODOS and bugs. 






Usage: 
Test request: 
{
	"Chanel": "CHANNEL_1",
		"Service": "Test",
			"Method": "Test_1",
			"Request": "",	
}

User Register:
{
	"Chanel": "CHANNEL_1",
		"Service": "Authorisation",
			"Method": "UserRegister",
			"Request": "{\"Login\":\"UserName\",\"Password\":\"SecreetPassword\"}"
	
}

LogIn:
{
	"Chanel": "CHANNEL_1",
		"Service": "Authorisation",
			"Method": "LogIn",
			"Request": "{\"Login\":\"UserName\",\"Password\":\"SecreetPassword\"}"
	
}
After LogIn You can test: 
{
	"Chanel": "CHANNEL_1",
		"Service": "Test",
			"Method": "Test_1",
			"Request": "",	
			"Token":   //Here put Yours token from login response "013ddbab-6820-405c-9114-0189f01f0df4"
}
